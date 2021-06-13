using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class FrmConfigDAP : Form
    {
        public FrmConfigDAP()
        {
            InitializeComponent();
            ChargerInformationDAP();  
           
        }
        private void ChargerInformationDAP()
        {
            Operations.ChargerClassesDansComboBox(cbx_classe);

            if (cbx_classe.Items.Count > 0)
            {
                cbx_classe.SelectedIndex = 0;
                AfficherDAP();
            }
                
        }

        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            new FrmNouveauEleveDAP().ShowDialog();
        }

        private void AfficherDAP()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "SELECT d.Id,d.noms,c.nom as classe,d.montant,sum(dap.montant) as 'Payé',d.montant-sum(dap.montant) as Reste,d.description from elevedap as d INNER join classe as c ON d.classe_id = c.Id left join dap on d.id=dap.eleve_id group by d.id";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvliste.DataSource = table;
                }
                CustomizeDataGriView();
            }
        }

        private void Cbx_classe_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "SELECT d.Id,d.noms,c.nom as classe,d.montant,sum(dap.montant) as 'Payé',d.montant-sum(dap.montant) as Reste,d.description from elevedap as d INNER join classe as c ON d.classe_id = c.Id left join dap on d.id=dap.eleve_id where c.nom=@p_classe group by d.id;";

                MySqlParameter p_classe = new MySqlParameter("@p_classe", MySqlDbType.VarChar, 10)
                {
                    Value = cbx_classe.Text
                };

                cmd.Parameters.Add(p_classe);
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvliste.DataSource = table;
                }

                CustomizeDataGriView();
            }
        }

        private void CustomizeDataGriView()
        {
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

        private void ImprimerDAP()
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
            string t_classe = "Classe : Toutes\n";
            string t_date_du_jour = "Imprimé le  : " + DateTime.Now.ToString() + "\n";
            if (!cbx_classe.Text.Equals(String.Empty))
            {
                t_classe = "Classe : " + cbx_classe.Text + "\n";
            }
            string t_title_principal = "Liste des élèves Des  Années Passées & leurs Dettes";
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
            PdfPTable tableau = new PdfPTable(8)
            {
                WidthPercentage = 100
            }; //un tableau de 5 colonnes N°, nom, postnom et prenom
            tableau.SetWidths(new float[] { 5, 5, 20, 7, 8,7,7, 15 });

            Phrase p_numero = new Phrase("N°", police_entete_tableau);
            Phrase p_Id = new Phrase("Id", police_entete_tableau);
            Phrase p_nom = new Phrase("Noms", police_entete_tableau);
            Phrase p_classe = new Phrase("Classe", police_entete_tableau);
            Phrase p_montant = new Phrase("Montant", police_entete_tableau);
            Phrase p_paye = new Phrase("Payé", police_entete_tableau);
            Phrase p_reste = new Phrase("Reste", police_entete_tableau);
            Phrase p_adresse = new Phrase("Description", police_entete_tableau);



            tableau.AddCell(p_numero);
            tableau.AddCell(p_Id);
            tableau.AddCell(p_nom);
            tableau.AddCell(p_classe);
            tableau.AddCell(p_montant);
            tableau.AddCell(p_paye);
            tableau.AddCell(p_reste);
            tableau.AddCell(p_adresse);
            int nombre_ligne = dgvliste.Rows.Count;

            for (int i = 0; i < nombre_ligne; i++)
            {

                tableau.AddCell(new Phrase((i + 1).ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[0].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[1].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[2].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[3].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[4].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[5].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[6].Value.ToString(), police_Cellule));

            }

            doc.Add(tableau);
            #endregion


            doc.Close();
            this.Cursor = Cursors.Default;
            Operations.PrintToASpecificPirnter();

        }

        private void BtnImprimer_Click(object sender, EventArgs e)
        {
            ImprimerDAP();
        }
    }
}