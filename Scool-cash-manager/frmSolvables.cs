using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class frmSolvables : Form
    {
        private const int V = 1;
        public frmSolvables()
        {
            InitializeComponent();
            Operations.ChargerClassesDansComboBox(cbx_classe);
        }

        private void FrmSolvables_Load(object sender, EventArgs e)
        {
            Listersolvable();
            if (dgvliste.Rows.Count == 0)
            {
                dgvliste.Hide();
                lblMessage.Show();
            }
        }

        private void Listersolvable()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "ps_ListeSolvablesparMois";
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter p_mois = new MySqlParameter("@p_mois", MySqlDbType.VarChar, 20)
                {
                    Direction = ParameterDirection.Input,
                    Value = cbx_frais.Text
                };
                MySqlParameter p_classe = new MySqlParameter("@p_classe", MySqlDbType.VarChar, 20)
                {
                    Direction = ParameterDirection.Input,
                    Value = cbx_classe.Text
                };

                cmd.Parameters.Add(p_mois);
                cmd.Parameters.Add(p_classe);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvliste.DataSource = table;

                    if (dgvliste.Rows.Count == 0)
                    {
                        dgvliste.Hide();
                        lblMessage.Show();
                    }
                    else
                    {
                        dgvliste.Show();
                        lblMessage.Hide();
                    }

                    adapter.Dispose();
                    cmd.Dispose();
                }
            }
        }

        private void Cbx_frais_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listersolvable();
        }

        private void Cbx_classe_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listersolvable();
        }

        private void BtnImprimer_Click(object sender, EventArgs e)
        {

            #region Création du document

            this.Cursor = Cursors.WaitCursor;
            Document doc = new Document();

            try
            {
                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ficher_rapport.pdf");
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                PdfWriter pdfWriter = PdfWriter.GetInstance(doc, fs);

                PDFBackgroundHelper myEvent = new PDFBackgroundHelper();
                pdfWriter.PageEvent = myEvent;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

            #endregion Création du document

            doc.Open(); //on ouvre le document pour y écrire...

            #region Police utilisé

            Font police_titre = FontFactory.GetFont("calibri", 14, 1);
            Font police_titre_principal = FontFactory.GetFont("calibri", 14);
            Font police_entete_tableau = FontFactory.GetFont("Century Gothic", 12, 1);
            Font police_Cellule = FontFactory.GetFont("arial", 10);
            Paragraph PasserLigne = new Paragraph(Environment.NewLine);

            #endregion Police utilisé

            #region en-tête du document

            string t_nom_ecole = Operations.ObtenirNomEtablissement() + "\n";
            string t_classe = "Classe : Toutes\n";
            string t_date_du_jour = "Imprimé le  : " + DateTime.Now.ToString() + "\n";
            if (!cbx_classe.Text.Equals(String.Empty))
            {
                t_classe = "Classe : " + cbx_classe.Text + "\n";
            }
            string t_title_principal = "Liste des élèves Solvables du mois de " + cbx_frais.Text;
            doc.Add(PasserLigne);

            Phrase phrase_nom_ecole = new Phrase(t_nom_ecole, police_titre);
            Phrase phrase_classe = new Phrase(t_classe, police_titre);
            Phrase phrase_date_jour = new Phrase(t_date_du_jour, police_Cellule);
            Chunk chunkUnderline = new Chunk(t_title_principal, police_titre_principal);
            chunkUnderline.SetUnderline(0.4f, -2f);
            Paragraph p_title_principal = new Paragraph(chunkUnderline)
            {
                Alignment = 1 //on centre le titre principal
            };

            //on ajoute les paragraphes au document
            doc.Add(phrase_nom_ecole);
            doc.Add(phrase_classe);
            doc.Add(phrase_date_jour);
            doc.Add(p_title_principal);
            doc.Add(PasserLigne);

            #endregion en-tête du document

            #region le tableau

            #region les élèves ayant effectivement payé
            PdfPTable tableau = new PdfPTable(5); //un tableau de 5 colonnes N°, nom, postnom et prenom

            tableau.SetWidths(new float[] { 7, 7, 35, 7, 11 });

            Phrase p_numero = new Phrase("N°", police_entete_tableau);
            Phrase p_Id = new Phrase("Id", police_entete_tableau);
            Phrase p_nom = new Phrase("Noms", police_entete_tableau);
            Phrase p_postnom = new Phrase("Sexe", police_entete_tableau);
            Phrase p_prenom = new Phrase("Classe", police_entete_tableau);

            tableau.AddCell(p_numero);
            tableau.AddCell(p_Id);
            tableau.AddCell(p_nom);
            tableau.AddCell(p_postnom);
            tableau.AddCell(p_prenom);

            int nombre_ligne = dgvliste.Rows.Count;

            for (int i = 0; i < nombre_ligne; i++)
            {
                tableau.AddCell((i + 1).ToString());
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[0].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[1].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[2].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[3].Value.ToString(), police_Cellule));
            }
            #endregion

            #region ajout des élèves affiliés, ....

            //ajout des élèves afiliés
            PdfPCell pdfcell_colspan = new PdfPCell(new Phrase("Enfants affiliés", police_entete_tableau))
            {
                Colspan = 5,
                HorizontalAlignment = V
            };

            DataTable table = GetTableEnfantAffilie();
            if (table.Rows.Count > 0)
                tableau.AddCell(pdfcell_colspan);
            int j = 0;
            foreach (DataRow row in table.Rows)
            {
                tableau.AddCell((j + 1).ToString());
                tableau.AddCell(new Phrase(row[0].ToString(), police_Cellule));
                tableau.AddCell(new Phrase(row[1].ToString(), police_Cellule));
                tableau.AddCell(new Phrase(row[2].ToString(), police_Cellule));
                tableau.AddCell(new Phrase(row[3].ToString(), police_Cellule));
                j++;
            }
            #endregion ajout des liste pour accompte, ....

            #region les ayant pris l'inscription tardivement
            //les inscriptions tardives
            pdfcell_colspan = new PdfPCell(new Phrase("Ayant pris les inscriptions tardives", police_entete_tableau))
            {
                Colspan = 5,
                HorizontalAlignment = V
            };
            table = GetTableInscriptionTardive();
            if (table.Rows.Count > 0)
                tableau.AddCell(pdfcell_colspan);
            j = 0;
            foreach (DataRow row in table.Rows)
            {
                tableau.AddCell((j + 1).ToString());
                tableau.AddCell(new Phrase(row[0].ToString(), police_Cellule));
                tableau.AddCell(new Phrase(row[1].ToString(), police_Cellule));
                tableau.AddCell(new Phrase(row[2].ToString(), police_Cellule));
                tableau.AddCell(new Phrase(row[3].ToString(), police_Cellule));
                j++;
            }


            #endregion


            doc.Add(tableau);

            #endregion le tableau

            doc.Close();
            this.Cursor = Cursors.Default;
            new FrmApercuAvantImpression().Show();
        }

        private DataTable GetTableEnfantAffilie()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select e.id,concat_ws(' ',e.nom,e.postnom,e.prenom) as Noms,e.genre as Sexe,c.nom as classe from eleve as e  " +
                    "INNER JOIN associer as a on a.eleve_id = e.id " +
                    "INNER JOIN classe as c on c.id = e.classe_id  where c.nom = @classe ";
                MySqlParameter p_classe = new MySqlParameter("@classe", MySqlDbType.VarChar)
                {
                    Value = cbx_classe.Text
                };
                cmd.Parameters.Add(p_classe);
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    da.Fill(table);
                    return table;
                }
            }
        }

        private DataTable GetTableInscriptionTardive()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select e.id,concat_ws(' ', e.nom, e.postnom, e.prenom) as Noms,e.genre ,c.nom as classe from eleve as e " +
                    "inner join paiement_mensuel as p on p.eleve_id = e.id " +
                    "inner join frais_mensuel as f on f.id = p.frais_mensuel_id " +
                    "inner join classe as c on c.id = e.classe_id where day(p.date_paie)>= @jour_du_mois " +
                    "and f.designation = 'Inscription'  and month(p.date_paie)= month(now()) - 1 and c.nom=@classe ";

                MySqlParameter p_classe = new MySqlParameter("@classe", MySqlDbType.VarChar)
                {
                    Value = cbx_classe.Text
                };
                MySqlParameter p_jour = new MySqlParameter("@jour_du_mois", MySqlDbType.Int32)
                {
                    Value = GetJourCondition()
                };
                cmd.Parameters.Add(p_classe);
                cmd.Parameters.Add(p_jour);

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    da.Fill(table);
                    return table;
                }
            }
        }
        private int GetJourCondition()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "Select jour_mois_condition from configuration where id=1";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    int valeur = 0;
                    while (reader.Read())
                    {
                        valeur = reader.GetInt32(0);
                    }
                    reader.Dispose();
                    cmd.Dispose();
                    return valeur;
                }
            }

        }
    }
}