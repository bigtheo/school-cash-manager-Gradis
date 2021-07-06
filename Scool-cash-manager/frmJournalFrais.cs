﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class FrmJournalFrais : Form
    {
        public FrmJournalFrais()
        {
            InitializeComponent();
        }

        private void FrmJournalFrais_Load(object sender, EventArgs e)
        {
            ListerPaiementsJouralier();
        }

        private void ListerPaiementsJouralier()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "PS_JournalDesFrais";
                cmd.CommandType = CommandType.StoredProcedure;

                //les parametres..
                MySqlParameter p_index = new MySqlParameter("@p_index_frais", MySqlDbType.Int16)
                {
                    Direction = ParameterDirection.Input,
                    Value = cbx_frais.SelectedIndex
                };

                MySqlParameter p_date = new MySqlParameter("@p_date", MySqlDbType.Date)
                {
                    Direction = ParameterDirection.Input,
                    Value = dtp_date.Value
                };

                cmd.Parameters.Add(p_date);
                cmd.Parameters.Add(p_index);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvliste.DataSource = table;

                    if (dgvliste.Rows.Count == 0)
                    {
                        dgvliste.Hide();
                        lblMessage.Show();
                        lblMessage.Text = "Aucune Opération n'a été éffectuée \nle " + dtp_date.Text;
                    }
                    else
                    {
                        dgvliste.Show();
                        lblMessage.Hide();
                    }

                    if (cbx_frais.SelectedIndex == 0)
                    {
                        label1.Text = "Le Journal des frais mensuels";
                    }else if (cbx_frais.SelectedIndex == 1)
                    {
                        label1.Text = "Le Journal des frais d'examen ";
                    }
                    else if (cbx_frais.SelectedIndex == 2)
                    {
                        label1.Text = "Le Journal frais d'examen d'etat  ";
                    }
                    else if (cbx_frais.SelectedIndex == 3)
                    {
                        label1.Text = "Le Journal vente des manuels  ";
                    }
                    else if (cbx_frais.SelectedIndex == 4)
                    {
                        label1.Text = "Le Journal des frais de l'état  ";
                    }
                    else
                    {
                        label1.Text = "Le Journal des frais : Aucun frais selectionné. ";
                    }

                    cmd.Dispose();
                    adapter.Dispose();
                }
            }
        }

        private void Cbx_frais_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListerPaiementsJouralier();
        }

        private void Dtp_date_ValueChanged(object sender, EventArgs e)
        {
            ListerPaiementsJouralier();
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
            Font police_titre = FontFactory.GetFont("calibri", 14, 1);
            Font police_titre_principal = FontFactory.GetFont("calibri", 14);
            Font police_entete_tableau = FontFactory.GetFont("Century Gothic", 11, 1);
            Font police_Cellule = FontFactory.GetFont("arial", 8);
            Font police_Cellule_intitule_manuel = FontFactory.GetFont("arial", 8);
            Paragraph PasserLigne = new Paragraph(Environment.NewLine);
            #endregion

            #region en-tête du document
            string t_nom_ecole = Operations.ObtenirNomEtablissement()+"\n";
            string t_classe = "Classe : Toutes\n";
            string t_date_du_jour = "Imprimé le  : " + DateTime.Now.ToString()+"\n";
            string t_date_impresion = "Journal du : "+dtp_date.Text;
          
            string t_title_principal = "Journal des paiements  du frais : " + cbx_frais.Text+"\n";
            doc.Add(PasserLigne);

            Phrase phrase_nom_ecole = new Phrase(t_nom_ecole, police_titre);
            Phrase phrase_classe = new Phrase(t_classe, police_titre);
            Phrase phrase_date_du_jour = new Phrase(t_date_du_jour, police_Cellule);
            Phrase phrase_date_impression = new Phrase(t_date_impresion, police_Cellule);

            Chunk chunkUnderline = new Chunk(t_title_principal, police_titre_principal);
            chunkUnderline.SetUnderline(0.4f, -2f);
            Paragraph p_title_principal = new Paragraph(chunkUnderline)
            {
                Alignment = 1 //on centre le titre principal

            };


            //on ajoute les paragraphes au document
            doc.Add(phrase_nom_ecole);
            doc.Add(phrase_classe);
            doc.Add(phrase_date_du_jour);
            doc.Add(phrase_date_impression);
            doc.Add(p_title_principal);
            doc.Add(PasserLigne);

            #endregion

            #region le tableau

            PdfPTable tableau;
           
            if (cbx_frais.Text =="Manuels") //si le manuels est selectionner
            {
                tableau = new PdfPTable(9)
                {
                    WidthPercentage = 100
                }; //un tableau de 5 colonnes N°, nom, postnom et prenom

                tableau.SetWidths(new float[] { 6, 9, 6, 25, 10, 27, 7,5,9 });
                Phrase p_numero = new Phrase("N° réçu", police_entete_tableau);
                Phrase p_heure = new Phrase("Heure", police_entete_tableau);
                Phrase p_Id = new Phrase("Id", police_entete_tableau);
                Phrase p_Noms = new Phrase("Noms", police_entete_tableau);
                Phrase p_classe = new Phrase("Classe", police_entete_tableau);
                Phrase p_designation = new Phrase("Intitulé du manuel", police_entete_tableau);
                Phrase p_prix_unitaire = new Phrase("P.U", police_entete_tableau);
                Phrase p_quantite = new Phrase("Q.T", police_entete_tableau);
                Phrase p_prix_total = new Phrase("P.T", police_entete_tableau);


                tableau.AddCell(p_numero);
                tableau.AddCell(p_heure);
                tableau.AddCell(p_Id);
                tableau.AddCell(p_Noms);
                tableau.AddCell(p_classe);
                tableau.AddCell(p_designation);
                tableau.AddCell(p_prix_unitaire);
                tableau.AddCell(p_quantite);
                tableau.AddCell(p_prix_total);

                int nombre_ligne = dgvliste.Rows.Count;

                for (int i = 0; i < nombre_ligne; i++)
                {


                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[0].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[1].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[2].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[3].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[4].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[5].Value.ToString(), police_Cellule_intitule_manuel));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[6].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[7].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[8].Value.ToString(), police_Cellule));


                  
                }


            }
            else //au cas contraire
            {
                tableau = new PdfPTable(7); //un tableau de 5 colonnes N°, nom, postnom et prenom
                tableau.SetWidths(new float[] { 7, 10, 6, 27, 9 ,15,11});
                Phrase p_numero = new Phrase("N° réçu", police_entete_tableau);
                Phrase p_heure = new Phrase("Heure", police_entete_tableau);
                Phrase p_Id = new Phrase("Id", police_entete_tableau);
                Phrase p_Noms = new Phrase("Noms", police_entete_tableau);
                Phrase p_classe = new Phrase("Classe", police_entete_tableau);
                Phrase p_designation = new Phrase("Désignation", police_entete_tableau);
                Phrase p_montant = new Phrase("Montant", police_entete_tableau);


                tableau.AddCell(p_numero);
                tableau.AddCell(p_heure);
                tableau.AddCell(p_Id);
                tableau.AddCell(p_Noms);
                tableau.AddCell(p_classe);
                tableau.AddCell(p_designation);
                tableau.AddCell(p_montant);

                int nombre_ligne = dgvliste.Rows.Count;

                for (int i = 0; i < nombre_ligne; i++)
                {

                  
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[0].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[1].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[2].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[3].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[4].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[5].Value.ToString(), police_Cellule));
                    tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[6].Value.ToString(), police_Cellule));

                    

                   
                }

             
            }

            doc.Add(tableau);
            doc.Close();
            this.Cursor = Cursors.Default;
            Operations.PrintToASpecificPirnter();
        }





        #endregion

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            if (dgvliste.CurrentRow.Cells[0].Value.ToString() == "-")
                return;
            int id = Convert.ToInt32(dgvliste.CurrentRow.Cells[0].Value);
            if (id != 0)
            {
                string sql = "delete from paiement_mensuel where id=@id";
                MySqlParameter p_id = new MySqlParameter("@id", MySqlDbType.Int64)
                {
                    Value = id
                };
                
                using (MySqlCommand cmd=new MySqlCommand (sql,Connexion.con))
                {
                    cmd.Parameters.Add(p_id);
                    DialogResult dr = MessageBox.Show($"voulez-vous annuler le recu N° {id} ?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show("Annulation du reçu effectuée ");
                    }
                    

                }
            }
        }
    }
    }