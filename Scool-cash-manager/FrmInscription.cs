using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class FrmInscription : Form
    {
        public FrmInscription()
        {
            InitializeComponent();
        }

        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            new FrmNouveauEleve().ShowDialog();
        }

        #region au chargement du foprmulaire...

        private void FrmInscription_Load(object sender, EventArgs e)
        {
            //affichage des infos de la liste d'élève
            Views.AfficherTout("v_liste_elve limit 50", dgvliste);
            //charger les classe dans le comboBox
            Operations.ChargerClassesDansComboBox(cbx_classe);
            //on affiche le message aucune inscription dans le cas correspondant
            if (dgvliste.Rows.Count == 0)
            {
                dgvliste.Hide();
                lblMessage.Show();
            }
        }

        #endregion au chargement du foprmulaire...


        #region au click sure les boutons modifier, nouveau,details et Imprimer
        private void BtnModifier_Click(object sender, EventArgs e)
        {
            RecupereIdEleve();
            new FrmModifierEleve().ShowDialog();
        }
        private void BtnDetails_Click(object sender, EventArgs e)
        {
            RecupereIdEleve();
            new frmDetailsEleve().Show();
        }
        #endregion

        #region envoie de l'id dans une variable static pour être recuperée dans le details
        public static string id_eleve;
    

        //lorsqu'on double clique dans la cellule
        private void Dgvliste_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RecupereIdEleve();
            new frmDetailsEleve().Show();
        }

        /// <summary>
        /// cette methôde permet d'affecter la valeur
        /// </summary>
        private void RecupereIdEleve()
        {
            if (dgvliste.CurrentCell != null)
            {
                id_eleve = dgvliste.CurrentRow.Cells[0].Value.ToString();
            }
            else
            {
                MessageBox.Show("Aucune ligne", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
     
        }
        #endregion

        #region au changement de la valeur dans le comboBox
        private void Cbx_classe_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "SELECT* from v_liste_elve where classe=@p_classe";
                cmd.CommandType = System.Data.CommandType.Text;

                MySqlParameter p_classe = new MySqlParameter("@p_classe", MySqlDbType.VarChar, 15)
                {
                    Value = cbx_classe.Text
                };
                cmd.Parameters.Add(p_classe);

                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                    if (cbx_classe.Text != String.Empty)
                    {
                        dgvliste.DataSource = table;
                        dataAdapter.Dispose();
                        cmd.Dispose();
                    }
                    else // si la classe vaut vide on affiche tous...
                    {
                        Views.AfficherTout("v_liste_elve", dgvliste);
                    }
                    

                    //on cache la grille dans le cas où aucune donnée n'est trouvée
                    if (dgvliste.Rows.Count < 1)
                    {
                        dgvliste.Hide();
                        lblMessage.Show();
                    }
                    else
                    {
                        lblMessage.Hide();
                        dgvliste.Show();
                    }
                }



            }
        }
        #endregion

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
            string t_nom_ecole = Operations.ObtenirNomEtablissement()+"\n";
            string t_classe = "Classe : Toutes\n";
            string t_date_du_jour = "Imprimé le  : " + DateTime.Now.ToString() + "\n";
            if (!cbx_classe.Text.Equals(String.Empty))
            {
                 t_classe = "Classe : "+cbx_classe.Text+"\n";
            }
            string t_title_principal = "Liste des élèves Inscrits";
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
            PdfPTable tableau = new PdfPTable(6)
            {
                WidthPercentage = 100
            }; //un tableau de 5 colonnes N°, nom, postnom et prenom
            tableau.SetWidths(new float[] { 6, 6, 22,5, 7, 20 });
            
            Phrase p_numero = new Phrase("N°", police_entete_tableau);
            Phrase p_Id = new Phrase("Id", police_entete_tableau);
            Phrase p_nom = new Phrase("Noms", police_entete_tableau);
            Phrase p_postnom = new Phrase("Sexe", police_entete_tableau);
            Phrase p_prenom = new Phrase("Classe", police_entete_tableau);
            Phrase p_adresse = new Phrase("Adresse", police_entete_tableau);

           

            tableau.AddCell(p_numero);
            tableau.AddCell(p_Id);
            tableau.AddCell(p_nom);
            tableau.AddCell(p_postnom);
            tableau.AddCell(p_prenom);
            tableau.AddCell(p_adresse);
            int nombre_ligne = dgvliste.Rows.Count;
     
            for (int i = 0; i <nombre_ligne; i++)
            {

                tableau.AddCell(new Phrase((i+1).ToString(),police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[0].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[1].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[2].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[3].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[4].Value.ToString(), police_Cellule));

            }

            doc.Add(tableau);
            #endregion


            doc.Close();
            this.Cursor = Cursors.Default;
            new FrmApercuAvantImpression().Show();

      
        }
    }
}