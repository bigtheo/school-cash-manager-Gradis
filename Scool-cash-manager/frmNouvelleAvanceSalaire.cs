using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class frmNouvelleAvanceSalaire : Form
    {
        public frmNouvelleAvanceSalaire()
        {
            InitializeComponent();
        }

        #region barre de titre

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr intPtr, int v1, int v2, int v3);

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanelBarreDeTitre_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnFermer_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion barre de titre

        #region Enregistrement de l'avance sur salaire

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            Enregistrer();
        }

        private void Enregistrer()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "INSERT INTO Avance(Mois,montant,enseigant_id) values (@Mois,@montant,@enseigant_id)";
                MySqlParameter p_Mois = new MySqlParameter("@mois", MySqlDbType.Enum);
                MySqlParameter p_Montant = new MySqlParameter("@montant", MySqlDbType.Decimal);
                MySqlParameter p_enseigant_id = new MySqlParameter("@enseigant_id", MySqlDbType.Int64);

                p_Mois.Value = cbxMois.Text;
                p_Montant.Value = nup_montant.Value;
                p_enseigant_id.Value = nup_matricule.Value;

                cmd.Parameters.Add(p_Mois);
                cmd.Parameters.Add(p_enseigant_id);
                cmd.Parameters.Add(p_Montant);

                try
                {
                    DialogResult result = MessageBox.Show("Voulez-vous vraiment enregistrer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show($"Enregistrement éffectué avec succès !!!\n {rowsAffected} lignes affectée(s)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CreerRecu();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion Enregistrement de l'avance sur salaire

        #region Rechercher des informations du personnel

        private void AfficherInfoPersonnelParID()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = $"Select e.noms,e.fonction,e.salaire_brut,s.nom_section from enseignant as e Inner join section as s on s.id=e.section_id where e.id={nup_matricule.Value} ";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    foreach (DataRow valeur in table.Rows)
                    {
                        txtNoms.Text = Convert.ToString(valeur[0]);
                        cbx_fonction.Text = Convert.ToString(valeur[1]);
                        nup_salaire_brut.Value = Convert.ToDecimal(valeur[2]);
                        cbx_section.Text = Convert.ToString(valeur[3]);
                        string monthName;
                        if(DateTime.Now.Day <=6  || DateTime.Now.Day>=20)
                        {
                           if(DateTime.Now.Day<=6)
                            monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month-1);
                            else
                                monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
                        }
                        else 
                        {
                            monthName = "trance du mois";
                            MessageBox.Show("Impossible d'attribuer les avances dans cette tranche de temps","Information",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        cbxMois.Text = monthName;
                    }

                    if (table.Rows.Count == 0)
                    {
                        txtNoms.Clear();
                        cbx_fonction.Text = "";
                        nup_salaire_brut.Value = 0;
                        cbx_section.Text = "";
                        cbxMois.Text = "";
                    }
                }
            }
        }

        private void Nup_matricule_ValueChanged(object sender, EventArgs e)
        {
            AfficherInfoPersonnelParID();
            nup_montant.Maximum = nup_salaire_brut.Value ;
        }

        #endregion Rechercher des informations du personnel

        #region Reçu de l'avance

        /// <summary>
        /// cette méthode permet de retounet le numéro ud dernier réçu....
        /// </summary>
        /// <returns></returns>
        private string ObtenirNumeroAvance()
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "select id from avance order by(id) desc limit 1";
                    cmd.CommandType = CommandType.Text;

                    //on exécute la requete
                    return Convert.ToString(cmd.ExecuteScalar());
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return "0";
            }
        }

        /// <summary>
        /// cette méthode permet de créer les document qui contient les infos du réçu
        /// </summary>
        private void CreerRecu()
        {
            #region Création du document

            this.Cursor = Cursors.WaitCursor;

            iTextSharp.text.Rectangle taille = new iTextSharp.text.Rectangle(new iTextSharp.text.Rectangle(288, 720)); // le format(longueur et largueur) du récu
            Document doc = new Document(taille);
            doc.SetMargins(30, 30, 7, 30);
            try
            {
                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ficher_rapport.pdf");
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                PdfWriter.GetInstance(doc, fs);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

            doc.Open(); //ouverture du document pour y écrire

            #endregion Création du document

            #region les polices utilisées et les couleurs

            BaseColor couleur_cellule = new BaseColor(0, 0, 0);
            BaseColor couleur_noms = new BaseColor(1, 101, 201);

            iTextSharp.text.Font police_cellule = FontFactory.GetFont("TIMES NEW ROMAN", 9, couleur_cellule);
            iTextSharp.text.Font police_noms_eleve = FontFactory.GetFont("TIMES NEW ROMAN", 11, couleur_noms);
            iTextSharp.text.Font police_nom_ecole = FontFactory.GetFont("TIMES NEW ROMAN", 14, 1, new BaseColor(255, 140, 0));

            #endregion les polices utilisées et les couleurs

            #region les en-têtes

            #region en-tête date et annee scolaire

            //On récupére le jour actuel Et l'annéé scolaire

            DateTime date_du_jour = DateTime.Now;
            string anne_scolaire = "2020-2021";

            Chunk chunk_date_du_jour = new Chunk("Date du jour ", police_cellule);
            Chunk chunk_anne_scolaire = new Chunk("Année Scolaire ", police_cellule);

            //les paragraphes
            Paragraph p_date_du_jour = new Paragraph(chunk_date_du_jour);
            Paragraph p_date_annee_scolaire = new Paragraph(chunk_anne_scolaire);

            //on crée le petit table qui va prendre les en-tête (date du jour et année scolaire)
            PdfPTable tableau_entete = new PdfPTable(2); //deux colonns

            tableau_entete.SetWidths(new float[] { 40, 60 });
            //on ajoute les en-entetes au tableaux
            tableau_entete.AddCell(p_date_annee_scolaire);
            tableau_entete.AddCell(p_date_du_jour);

            //les paragraphes des mes chunks
            Paragraph p_chunk_annee_scolaire = new Paragraph(new Chunk(anne_scolaire, police_cellule));
            Paragraph p_chunk_date_du_jour = new Paragraph(new Chunk(date_du_jour.ToString(), police_cellule));

            //on ajoute les valeurs aux tableau
            tableau_entete.AddCell(p_chunk_annee_scolaire);
            tableau_entete.AddCell(p_chunk_date_du_jour);

            #endregion en-tête date et annee scolaire

            #region les en-têtes nom école, id et noms élèves

            string nom_ecole = Operations.ObtenirNomEtablissement() + "\n";
            string noms_eleve = "  " + nup_matricule.Value + " " + txtNoms.Text + " " + " " + cbx_section.Text;
            string numero_recu = "Avance N° " + ObtenirNumeroAvance();
            string adresse_ecole = ObtenirAdresse();

            Chunk chunk_nom_ecole = new Chunk(nom_ecole, police_nom_ecole);
            Chunk chunk_noms_eleve = new Chunk(noms_eleve, police_noms_eleve);
            Chunk chunk_numero_recu = new Chunk(numero_recu, police_cellule);
            Chunk chunk_adresse_ecole = new Chunk(adresse_ecole, police_cellule);

            //les paragraphes

            Paragraph p_chunk_nom_ecole = new Paragraph(chunk_nom_ecole);
            Paragraph p_chunk_noms_eleve = new Paragraph(chunk_noms_eleve);
            Paragraph p_chunk_numero_recu = new Paragraph(chunk_numero_recu);
            Paragraph p_chunk_adresse_ecole = new Paragraph(chunk_adresse_ecole);

            //alignement

            p_chunk_nom_ecole.Alignment = 0;
            p_chunk_adresse_ecole.Alignment = 0;
            p_chunk_noms_eleve.Alignment = 1;
            p_chunk_numero_recu.Alignment = 1;

            #endregion les en-têtes nom école, id et noms élèves

            #endregion les en-têtes

            #region le tableau principal

            PdfPTable tableau_principal = new PdfPTable(3); //déclarer le tableau de deux colonnes
            
            tableau_principal.SetWidths(new float[] { 20, 50, 30 });
                Chunk chunk_frais = new Chunk("Date et Heure", police_cellule);
            Chunk chunk_frais_valeur = new Chunk("Montant", police_cellule);
            Chunk chunk_avance_id = new Chunk("N°", police_cellule);

            //les paragraphes
            PdfPCell colspan = new PdfPCell(new Phrase("Avances du mois de "+cbxMois.Text , police_cellule))
            {
                Colspan = 3,
                HorizontalAlignment = 1,
                PaddingBottom = 5,
                PaddingTop = 5
            };
            Paragraph p_chunck_frais = new Paragraph(chunk_frais);
            Paragraph p_chunck_montant = new Paragraph(chunk_frais_valeur);
            Paragraph p_chunck_avance_id = new Paragraph(chunk_avance_id);

            tableau_principal.AddCell(colspan);
            tableau_principal.AddCell(p_chunck_avance_id);
            tableau_principal.AddCell(p_chunck_frais);
            tableau_principal.AddCell(p_chunck_montant);
            //on ajoute les en-têtes

            //on ajoute les valeurs
            chunk_avance_id = new Chunk("0", police_cellule);
            Chunk chunk_montant = new Chunk("salaire brut", police_cellule);
            Chunk chunk_montant_valeur = new Chunk(nup_salaire_brut.Value + " CDF", police_cellule);


            //les paragraphes des mes chunks
            Paragraph p_chunk_avance_id = new Paragraph(chunk_avance_id);
            Paragraph p_chunk_montant = new Paragraph(chunk_montant);
            Paragraph p_chunk_montant_valeur = new Paragraph(chunk_montant_valeur);
            
            tableau_principal.AddCell(p_chunk_avance_id);
            tableau_principal.AddCell(p_chunk_montant);
            tableau_principal.AddCell(p_chunk_montant_valeur);

            #region ajout des toutes les avances dans le tableau

            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select Id as 'N°',date_paie as 'Date et Heure', Montant from avance where enseigant_id=@enseignant_id and mois=@mois";
                MySqlParameter p_mois = new MySqlParameter("@mois", MySqlDbType.VarChar);
                MySqlParameter p_enseignant_id = new MySqlParameter("@enseignant_id", MySqlDbType.Int32)
                {
                    Value = nup_matricule.Value
                };
                p_mois .Value = cbxMois.Text;

                cmd.Parameters.Add(p_enseignant_id);
                cmd.Parameters.Add(p_mois);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    p_chunck_avance_id = new Paragraph(reader.GetString(0),police_cellule);
                    p_chunk_montant = new Paragraph(reader.GetString(1), police_cellule);
                    p_chunk_montant_valeur = new Paragraph(reader.GetString(2), police_cellule);

                    tableau_principal.AddCell(p_chunck_avance_id);
                    tableau_principal.AddCell(p_chunk_montant);
                    tableau_principal.AddCell(p_chunk_montant_valeur);
                }

                //on ajoute le solde
                //on ajoute les valeurs

                chunk_avance_id = new Chunk("01", police_cellule);
                chunk_montant = new Chunk("Solde", police_cellule);
                chunk_montant_valeur = new Chunk(nup_salaire_brut.Value - ObtenirTotalAvance() + " CDF", police_cellule);

                p_chunck_avance_id = new Paragraph(chunk_avance_id);
                p_chunk_montant = new Paragraph(chunk_montant);
                p_chunk_montant_valeur = new Paragraph(chunk_montant_valeur);

                tableau_principal.AddCell(p_chunck_avance_id);
                tableau_principal.AddCell(p_chunk_montant);
                tableau_principal.AddCell(p_chunk_montant_valeur);
            }
            #endregion


            #endregion le tableau principal

            #region ajout des en-têtes et tableau aux document

            //on ajoutes les élèments de l'en-entête
            Paragraph passerligne = new Paragraph("\n", police_cellule);
            doc.Add(p_chunk_nom_ecole);
            doc.Add(p_chunk_adresse_ecole);
            doc.Add(p_chunk_noms_eleve);
            doc.Add(p_chunk_numero_recu);
            doc.Add(passerligne); //on passe à la ligne

            //on ajoutes le tableau en-tête
            doc.Add(tableau_entete);

            doc.Add(passerligne); //on passe à la ligne
            //on ajoute le tableau principal
            doc.Add(tableau_principal);

            #endregion ajout des en-têtes et tableau aux document

            //on ferme le document après écriture
            doc.Close();
            new FrmApercuAvantImpression().ShowDialog();

            this.Cursor = Cursors.Default;
        }

        private decimal ObtenirTotalAvance()
        {
            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select sum(montant) from avance where enseigant_id=@enseignant_id";
                MySqlParameter p_enseignant_id = new MySqlParameter("@enseignant_id", MySqlDbType.Int32)
                {
                    Value = nup_matricule.Value
                };
                cmd.Parameters.Add(p_enseignant_id);
                try
                {
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {

                    MessageBox.Show(ex.Message);
                    return 0;
                }
            } 
        }

        private string ObtenirAdresse()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select adresse from configuration limit 1";
                return cmd.ExecuteScalar().ToString();
            }
        }

        #endregion Reçu du paiement mensuel
    }
}