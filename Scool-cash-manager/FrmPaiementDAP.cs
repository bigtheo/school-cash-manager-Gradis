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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = iTextSharp.text.Font;

namespace Scool_cash_manager
{
    public partial class FrmPaiementDAP : Form
    {
        public FrmPaiementDAP()
        {
            InitializeComponent();
            AfficherPaiementDap();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            new FrmNouveauPaiementDAP().ShowDialog();
        }
        private void AfficherPaiementDap()
        {
            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select d.id,d.date_paie as 'Date et Heure',e.noms,c.nom as classe,d.montant  from dap as d inner join elevedap as e on e.id = d.eleve_id inner join classe as c on e.classe_id = c.id where date(date_paie)=@date ";
                MySqlParameter p_classe = new MySqlParameter("@date", MySqlDbType.Date)
                {
                    Value = dtp_date.Value
                };
                cmd.Parameters.Add(p_classe);
                using (MySqlDataAdapter adapter=new MySqlDataAdapter (cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvliste.DataSource = table;
                }

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

        private void Dtp_date_ValueChanged(object sender, EventArgs e)
        {
            AfficherPaiementDap();
        }
        private decimal ObtenirTotalDAP()
        {
            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select sum(montant) from dap where date(date_paie)=@date_paie";
                MySqlParameter p_date_paie = new MySqlParameter("@date_paie", MySqlDbType.Date)
                {
                    Value = dtp_date.Value
                };
                cmd.Parameters.Add(p_date_paie);
                if(decimal.TryParse(cmd.ExecuteScalar().ToString(),out decimal result))
                   {
                    return result;
                   }
                
                return 0;
            }
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
            #endregion

            doc.Open(); //on ouvre le document pour y écrire...


            #region Police utilisé
            iTextSharp.text.Font police_titre = FontFactory.GetFont("Arial", 14, 1);
            Font police_titre_principal = FontFactory.GetFont("Times new roman", 12);
            Font police_entete_tableau = FontFactory.GetFont("Century Gothic", 12, 1);
            Font police_Cellule = FontFactory.GetFont("arial", 8);
            Paragraph PasserLigne = new Paragraph(Environment.NewLine);
            #endregion

            #region en-tête du document
            string t_nom_ecole = Operations.ObtenirNomEtablissement() + "\n";
            string t_classe = "Classe : Toutes\n";
            string t_date_du_jour = "Journal du  : " + dtp_date.Value  + "\n";
  
            string t_title_principal = "Journal des paiements D.AP.";
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
            PdfPTable tableau = new PdfPTable(5)
            {
                WidthPercentage = 80
            }; //un tableau de 5 colonnes N°, nom, postnom et prenom
            tableau.SetWidths(new float[] { 9, 15, 25, 10, 13 });

            Phrase p_numero = new Phrase("N°", police_entete_tableau);
            Phrase p_Id = new Phrase("Date et Heure", police_entete_tableau);
            Phrase p_nom = new Phrase("Noms", police_entete_tableau);
            Phrase p_postnom = new Phrase("Classe", police_entete_tableau);
            Phrase p_prenom = new Phrase("Montant", police_entete_tableau);



            tableau.AddCell(p_numero);
            tableau.AddCell(p_Id);
            tableau.AddCell(p_nom);
            tableau.AddCell(p_postnom);
            tableau.AddCell(p_prenom);

            int nombre_ligne = dgvliste.Rows.Count;

            for (int i = 0; i < nombre_ligne; i++)
            {

                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[0].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[1].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[2].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[3].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[4].Value.ToString(), police_Cellule));

            }

            tableau.AddCell(new Phrase("01", police_Cellule));
            tableau.AddCell(new Phrase("Total", police_Cellule));
            tableau.AddCell(new Phrase("-", police_Cellule));
            tableau.AddCell(new Phrase("-", police_Cellule));
            tableau.AddCell(new Phrase(ObtenirTotalDAP().ToString(), police_Cellule));

            doc.Add(tableau);
            #endregion


            doc.Close();
            this.Cursor = Cursors.Default;
            Operations.PrintToASpecificPirnter();
        }
    }
}
