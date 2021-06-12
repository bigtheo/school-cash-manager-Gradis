using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class FrmNouveauPaiementDAP : Form
    {
        public FrmNouveauPaiementDAP()
        {
            InitializeComponent();
        }

        #region barre de titre..
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr intPtr, int v1, int v2, int v3);
        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanelBarreDeTitre_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion


        #region Recherche des infos de l'élève EAP

        private void GetName()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "SELECT noms from ELEVEDAP where Id=@Id";
                MySqlParameter p_id = new MySqlParameter("@Id", MySqlDbType.Int32)
                {
                    Value = nupId.Value
                };
                cmd.Parameters.Add(p_id);   
                txtNoms.Text =(string) cmd.ExecuteScalar();
            }

        }

        private string GetClasseId()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "SELECT Classe_id from ELEVEDAP where Id=@Id";
                MySqlParameter p_id= new MySqlParameter("@Id", MySqlDbType.Int32)
                {
                    Value = nupId.Value
                };
                cmd.Parameters.Add(p_id);
                object valeur = cmd.ExecuteScalar();
                if (valeur != null)
                {
                    return cmd.ExecuteScalar().ToString();
                }
                return "Id non attribué";
            }

        }

        private void GetClasse()
        {

            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "SELECT nom from classe where Id=@Id";
                MySqlParameter p_id = new MySqlParameter("@Id", MySqlDbType.Int32)
                {
                    Value = GetClasseId()
                };
                cmd.Parameters.Add(p_id);
                try
                {
                    cbx_classe.Text =(string) cmd.ExecuteScalar();
                }
                catch (FormatException)
                {

                    cbx_classe.Text = "";
                }

            }
        }

        private void GetDescription()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "SELECT description from eleveDAP where Id=@Id";
                MySqlParameter p_id = new MySqlParameter("@Id", MySqlDbType.Int32)
                {
                    Value = GetClasseId()
                };
                cmd.Parameters.Add(p_id);
                try
                {
                    rtxtDescription.Text = (string)cmd.ExecuteScalar();
                }
                catch (FormatException)
                {

                    rtxtDescription.Text = "";
                }

            }
        }
        private decimal GetMontantDAP()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "SELECT montant from ELEVEDAP where Id=@Id";
                MySqlParameter p_id= new MySqlParameter("@Id", MySqlDbType.Int32)
                {
                    Value = nupId.Value
                };
                cmd.Parameters.Add(p_id);
                object valeur = cmd.ExecuteScalar();
                if(valeur!=null)
                return(decimal) cmd.ExecuteScalar();
                return 0;

            }
        }

        private decimal GetMontantDapPaye()
        {

            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select sum(montant) from dap where eleve_id=@Id";
                MySqlParameter p_id = new MySqlParameter("@Id", MySqlDbType.Int32)
                {
                    Value = nupId.Value
                };
                cmd.Parameters.Add(p_id);

                if(decimal.TryParse(cmd.ExecuteScalar().ToString(),out decimal montant))
                {
                    return montant;
                }
                else
                {
                    return 0;
                }



            }
        }

        private void CalculerRestePayer()
        {
            nupReste.Value = GetMontantDAP() - GetMontantDapPaye();
        }
    
        private void NupId_ValueChanged(object sender, EventArgs e)
        {
            GetInfoEleveAP();
        }
        private void GetInfoEleveAP()
        {
            GetName();
            GetClasse();
            nupDAP.Value = GetMontantDAP();
            nupMontantDapPaye.Value = GetMontantDapPaye();
            GetDescription();
            CalculerRestePayer();
            nupMontant.Maximum = nupReste.Value;
            nupMontant.Value = 0;

        }

        #endregion

        #region Enregistrement
        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            Enregistrer();
            CreerRecu();
        }
        private void Enregistrer()
        {
            if (nupReste.Value == 0 && txtNoms.Text!="" && cbx_classe.Text !="")
            {
                MessageBox.Show($"{txtNoms.Text} n'a pas de dettes !!!!");
            }
            else
            {
                using (MySqlCommand cmd=new MySqlCommand ())
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "INSERT INTO DAP(Id,montant,eleve_id) values(@Id,@montant,@eleve_id)";

                    MySqlParameter p_id = new MySqlParameter("@Id", MySqlDbType.Int64);
                    MySqlParameter p_montant = new MySqlParameter("@montant", MySqlDbType.Decimal);
                    MySqlParameter p_eleve_id = new MySqlParameter("@eleve_id", MySqlDbType.Int64);

                    //les valeurs des paramtres

                    p_id.Value = null;
                    p_montant.Value = nupMontant.Value;
                    p_eleve_id.Value = nupId.Value;

                    //assignation 
                    cmd.Parameters.Add(p_id);
                    cmd.Parameters.Add(p_montant);
                    cmd.Parameters.Add(p_eleve_id);

                    try
                    {
                        DialogResult result = MessageBox.Show("Voulez-vous vraiment enregistrer ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                           if(cmd.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Enregistrement du DAP effectué !");
                                Operations.PrintPDFByProcess();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enregistrement annulé ");
                        }
                    }
                    catch (MySqlException ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }



        }
        #endregion

        #region CREATION du recu DAP

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
            string noms_eleve = "  " + nupId.Value + " " + txtNoms.Text + "  " + cbx_classe.Text;
            string numero_recu = "réçu DAP N° " + Operations.ObtenirNumeroRecuAccompte();//appel du numéro récu accompte
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

            PdfPTable tableau_principal = new PdfPTable(2); //déclarer le tableau de deux colonnes
            Chunk chunk_frais = new Chunk("Total dette ", police_cellule);
           
            Chunk chunk_frais_valeur;
         
            
            chunk_frais_valeur = new Chunk(  nupDAP.Value.ToString(), police_cellule);

            //les paragraphes
            PdfPCell colspan = new PdfPCell(new Phrase("Information sur le paiement", police_cellule))
            {
                Colspan = 2,
                HorizontalAlignment = 1,
                PaddingBottom = 5,
                PaddingTop = 5
            };
            Paragraph p_chunck_frais = new Paragraph(chunk_frais);
            Paragraph p_chunck_montant = new Paragraph(chunk_frais_valeur);

            tableau_principal.AddCell(colspan);
            tableau_principal.AddCell(p_chunck_frais);
            tableau_principal.AddCell(p_chunck_montant);
            //on ajoute les en-têtes

            //on ajoute les valeurs
            Chunk chunk_montant = new Chunk("Total payé", police_cellule);

            Chunk chunk_montant_valeur = new Chunk(nupMontantDapPaye.Value + " CDF", police_cellule);
            //les paragraphes des mes chunks
            Paragraph p_chunk_montant = new Paragraph(chunk_montant);
            Paragraph p_chunk_montant_valeur = new Paragraph(chunk_montant_valeur);


            tableau_principal.AddCell(p_chunk_montant);
            tableau_principal.AddCell(p_chunk_montant_valeur);


            tableau_principal.AddCell(new Paragraph(new Chunk("Montant payé", police_cellule)));
            tableau_principal.AddCell(new Paragraph(new Chunk(nupMontant.Value.ToString() + " CDF", police_cellule)));

            tableau_principal.AddCell(new Paragraph(new Chunk("Reste à payer", police_cellule)));
            tableau_principal.AddCell(new Paragraph(new Chunk(nupReste.Value-nupMontant.Value  + " CDF", police_cellule)));
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
           // new FrmApercuAvantImpression().ShowDialog();

            this.Cursor = Cursors.Default;
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
        #endregion
    }
}