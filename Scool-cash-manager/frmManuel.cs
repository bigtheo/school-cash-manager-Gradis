using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class frmManuel : Form
    {
        public frmManuel()
        {
            InitializeComponent();
        }

        private void FrmManuel_Load(object sender, EventArgs e)
        {
            Views.AfficherTout("v_paiementManuelsJournalier", dgvliste);
            if (dgvliste.Rows.Count == 0)
            {
                dgvliste.Hide();
                lblMessage.Show();
            }
        }

        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            new FrmNouveauPaiementManuels().ShowDialog();
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

            string t_title_principal = "Liste des ventes du jour (éccussions & journaux de classe)";
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
            tableau.SetWidths(new float[] { 6, 15, 22, 6, 20, 10,10, 10});

            Phrase p_numero = new Phrase("N°", police_entete_tableau);
            Phrase p_Date = new Phrase("Date et heure", police_entete_tableau);
            Phrase p_noms = new Phrase("Noms", police_entete_tableau);
            Phrase p_classe = new Phrase("classe", police_entete_tableau);
            Phrase p_Intitule = new Phrase("Intitulé", police_entete_tableau);
            Phrase p_quantite = new Phrase("quantité", police_entete_tableau);
            Phrase p_prix_unitaire = new Phrase("prix unitaire", police_entete_tableau);
            Phrase p_prix_total = new Phrase("Total", police_entete_tableau);



            tableau.AddCell(p_numero);
            tableau.AddCell(p_Date);
            tableau.AddCell(p_noms);
            tableau.AddCell(p_classe);
            tableau.AddCell(p_Intitule);
            tableau.AddCell(p_quantite);
            tableau.AddCell(p_prix_unitaire);
            tableau.AddCell(p_prix_total);

            int nombre_ligne = dgvliste.Rows.Count;

            for (int i = 0; i < nombre_ligne; i++)
            {

                tableau.AddCell(new Phrase((i + 1).ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[1].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[2].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[3].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[4].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[5].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[6].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[7].Value.ToString(), police_Cellule));

            }

            doc.Add(tableau);
            #endregion


            doc.Close();
            this.Cursor = Cursors.Default;
            Operations.PrintToASpecificPirnter();
        }

        private void BtnImprimer_Click(object sender, EventArgs e)
        {
            Imprimer();
        }
    }
}