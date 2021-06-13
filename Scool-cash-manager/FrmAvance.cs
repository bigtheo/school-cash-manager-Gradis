using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class FrmAvance : Form
    {
        public FrmAvance()
        {
            InitializeComponent();
            AfficherAvanceJournaliere();
            cbx_mois.Text  = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
        }

        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            new frmNouvelleAvanceSalaire().ShowDialog();
        }

        private void AfficherAvanceSolde()
        {
            string monthName=cbx_mois.Text;

            using (MySqlCommand cmd = new MySqlCommand())
            {
               
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "SELECT en.Id,en.Noms,en.fonction,s.nom_section as Section,en.salaire_brut as Brut,a.mois as 'Mois', " +
                    "sum(a.montant) as Avance,en.salaire_brut - sum(a.montant) as Solde " +
                    "from  enseignant as en " +
                    "inner join avance as a on a.enseigant_id = en.id" +
                    " inner JOIN section as s ON s.id = en.section_id " +
                    " where a.mois = @mois group by(en.id) " +
                    "union " +
                    "SELECT en.Id,en.Noms,en.fonction,s.nom_section as Section,en.salaire_brut as Brut,'-' as 'Mois', " +
                    "0 as Avance,en.salaire_brut as Solde from enseignant as en " +
                    "inner JOIN section as s ON s.id = en.section_id where en.id not in(select enseigant_id from avance where mois = @mois)";
                MySqlParameter mySqlParameter = new MySqlParameter("@mois", MySqlDbType.VarChar)
                {
                    Value = monthName
                };
                MySqlParameter p_mois = mySqlParameter;
                cmd.Parameters.Add(p_mois);

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
                }
            }
        }

        private void AfficherAvanceJournaliere()
        {

            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select a.Id,a.date_paie as 'Date et heure',e.noms,s.nom_section as Section,a.montant,a.mois from avance as a " +
                    "inner join enseignant as e on e.id = a.enseigant_id " +
                    "inner join section as s on s.id = e.section_id where date(a.date_paie)= @date_paie ";
                MySqlParameter mySqlParameter = new MySqlParameter("@mois", MySqlDbType.VarChar)
                {
                    Value = cbx_mois.Text
                };
 
                MySqlParameter p_mois = mySqlParameter;
                MySqlParameter p_date = new MySqlParameter("@date_paie",MySqlDbType.Date)
                {
                    Value=dtp_date_jour.Value
                };

                cmd.Parameters.Add(p_mois);
                cmd.Parameters.Add(p_date);

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
                }
            }
        }

        private void BtnDetails_Click(object sender, EventArgs e)
        {
            AfficherAvanceSolde();
        }

        private void Imprimer()
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
            #endregion

            doc.Open(); //on ouvre le document pour y écrire...


            #region Police utilisé
            Font police_titre = FontFactory.GetFont("Arial", 14, 1);
            Font police_titre_principal = FontFactory.GetFont("Times new roman", 12);
            Font police_entete_tableau = FontFactory.GetFont("Century Gothic", 12, 1);
            Font police_Cellule = FontFactory.GetFont("arial", 8);
            Paragraph PasserLigne = new Paragraph(Environment.NewLine);
            #endregion

            #region en-tête du document
            string t_nom_ecole = Operations.ObtenirNomEtablissement() + "\n";
            string t_classe = "Section : Toutes\n";
            string t_date_du_jour = "Imprimé le  : " + DateTime.Now.ToString() + "\n";
            int nombre_colonne = dgvliste.Columns.Count;
            string t_title_principal;
            if (nombre_colonne==6)
             t_title_principal = "Liste des avances journalières";
            else
                t_title_principal = "Liste de paie du personnel du mois de "+cbx_mois.Text ;

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

            #endregion
         
            #region le tableau
            PdfPTable tableau = new PdfPTable(nombre_colonne)
            {
                WidthPercentage = 100
            }; //un tableau de 5 colonnes N°, nom, postnom et prenom
            if (nombre_colonne == 6)
            {
                tableau.SetWidths(new float[] { 6, 15, 22, 8, 10, 10 });

                Phrase p_numero = new Phrase("N°", police_entete_tableau);
                Phrase p_Date = new Phrase("Date et heure", police_entete_tableau);
                Phrase p_noms = new Phrase("Noms", police_entete_tableau);
                Phrase p_section = new Phrase("Section", police_entete_tableau);
                Phrase p_montant = new Phrase("Mois", police_entete_tableau);
                Phrase p_mois = new Phrase("Montant", police_entete_tableau);

                tableau.AddCell(p_numero);
                tableau.AddCell(p_Date);
                tableau.AddCell(p_noms);
                tableau.AddCell(p_section);
                tableau.AddCell(p_montant);
                tableau.AddCell(p_mois);

            }
            else
            {
                tableau.SetWidths(new float[] { 6, 22, 12, 8, 10, 10 ,10,10});
                Phrase p_numero = new Phrase("N°", police_entete_tableau);
                Phrase p_Date = new Phrase("Noms", police_entete_tableau);
                Phrase p_noms = new Phrase("Fonction", police_entete_tableau);
                Phrase p_section = new Phrase("Section", police_entete_tableau);
                Phrase p_montant = new Phrase("Brut", police_entete_tableau);
                Phrase p_mois = new Phrase("Mois", police_entete_tableau);
                Phrase p_avance = new Phrase("Avance", police_entete_tableau);
                Phrase p_solde = new Phrase("Solde", police_entete_tableau);

                tableau.AddCell(p_numero);
                tableau.AddCell(p_Date);
                tableau.AddCell(p_noms);
                tableau.AddCell(p_section);
                tableau.AddCell(p_montant);
                tableau.AddCell(p_mois);
                tableau.AddCell(p_avance);
                tableau.AddCell(p_solde);
            }




            int nombre_ligne = dgvliste.Rows.Count;
  
            if (nombre_colonne == 6)
            {
                for (int i = 0; i < nombre_ligne; i++)
                {

                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[0].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[1].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[2].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[3].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[5].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[4].Value.ToString(), police_Cellule));

                }

                //on ajoute le total avance, brut et solde au tableau
                tableau.AddCell(new Phrase("01", police_Cellule));
                tableau.AddCell(new Phrase("TOTAL", police_Cellule));
                tableau.AddCell(new Phrase("-", police_Cellule));
                tableau.AddCell(new Phrase("-", police_Cellule));
                tableau.AddCell(new Phrase("-", police_Cellule));
                tableau.AddCell(new Phrase(ObtenirTotalJournalier().ToString(), police_Cellule));

            }
            else
            {
                for (int i = 0; i < nombre_ligne; i++)
                {

                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[0].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[1].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[2].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[3].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[4].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[5].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[6].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[7].Value.ToString(), police_Cellule));

                }

                //on ajoute le total avance, brut et solde au tableau
                tableau.AddCell(new Phrase("01", police_Cellule));
                tableau.AddCell(new Phrase("TOTAL", police_Cellule));
                tableau.AddCell(new Phrase("-", police_Cellule));
                tableau.AddCell(new Phrase("-", police_Cellule));
                tableau.AddCell(new Phrase(ObtenirTotalBrut().ToString(), police_Cellule));
                tableau.AddCell(new Phrase("-", police_Cellule));
                tableau.AddCell(new Phrase(ObtenirTotalAvance().ToString(), police_Cellule));
                tableau.AddCell(new Phrase(ObtenirTotalSolde().ToString(), police_Cellule));
            }


            doc.Add(tableau);
            #endregion


            doc.Close();
            this.Cursor = Cursors.Default;
            Operations.PrintToASpecificPirnter();
        }

        private decimal ObtenirTotalJournalier()
        {
            
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select sum(montant) from avance where date(date_paie)=date(now())";
                if(decimal.TryParse(cmd.ExecuteScalar().ToString(),out decimal result))
                {
                    return result;
                }
                return 0;
            }
        }

        private decimal ObtenirTotalSolde()
        {
            return ObtenirTotalBrut() - ObtenirTotalAvance();
        }

        private decimal ObtenirTotalAvance()
        {
            string monthName;
            if (DateTime.Now.Day <= 6 || DateTime.Now.Day >= 20)
            {
                if (DateTime.Now.Day <= 6)
                    monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month - 1);
                else
                    monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            }
            else
            {
                monthName = "trance du mois";
            }

            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select sum(montant) from avance where mois=@mois";
                MySqlParameter p_mois = new MySqlParameter("@mois", MySqlDbType.VarChar)
                {
                    Value =monthName
                };
                cmd.Parameters.Add(p_mois);
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        private decimal ObtenirTotalBrut()
        {
            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select sum(salaire_brut) from enseignant";
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        private void BtnImprimer_Click(object sender, EventArgs e)
        {
            Imprimer();
        }

        private void Dtp_date_jour_ValueChanged(object sender, EventArgs e)
        {
            AfficherAvanceJournaliere();
        }
    }
}