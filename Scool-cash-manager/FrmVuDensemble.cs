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

namespace Scool_cash_manager
{
    public partial class FrmVuDensemble : Form
    {
        public FrmVuDensemble()
        {
            InitializeComponent();
            //on charges toutes les classes !!!
            Operations.ChargerClassesDansComboBox(cbx_classe);
        }

        #region les fonctions qui vérifie si l'élève a déjà payé un frais mensuel qui retourne les liste


        //la méthode qui permet d'afficher tous les paeiment
        public List<string> lst_id()
        {
            string Sql = "select id from eleve where classe_id in(select id from classe where nom='" + cbx_classe.Text + "') order by(nom) asc";
            MySqlCommand cmd = new MySqlCommand(Sql, Connexion.con);
            MySqlDataReader dr = cmd.ExecuteReader();

            List<string> list_des_id = new List<string>();

            while (dr.Read())
            {

                list_des_id.Add(dr.GetValue(0).ToString());
            }

            dr.Close();
            return list_des_id;
        }


        public List<string> lst_nom()
        {
            string Sql = "select concat_ws(' ',nom,postnom,prenom) from eleve where classe_id IN(select id from classe where nom='" + cbx_classe.Text + "') order by(nom) asc";
            MySqlCommand cmd = new MySqlCommand(Sql, Connexion.con);
            MySqlDataReader dr = cmd.ExecuteReader();

            List<string> list_des_id = new List<string>();

            while (dr.Read())
            {

                list_des_id.Add(dr.GetValue(0).ToString());
            }

            dr.Close();
            return list_des_id;
        }


        public List<string> lst_incription()
        {
            List<string> list_des_mois = new List<string>();
            List<string> list_des_id = lst_id();

            for (int i = 0; i <= list_des_id.Count - 1; i++)
            {

                string Sql = "select count(id) from paiement_mensuel where frais_mensuel_id in( select id from frais_mensuel where designation='inscription') and eleve_id='" + list_des_id.ElementAt(i) + "'";
                MySqlCommand cmd = new MySqlCommand(Sql, Connexion.con);
                int valeur_requete = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (valeur_requete != 0)
                {
                    list_des_mois.Add("oui");

                }
                else
                {
                    list_des_mois.Add("nom");
                }
            }

            return list_des_mois;
        }


        public List<string> lst_septembre()
        {
            List<string> list_des_mois = new List<string>();
            List<string> list_des_id = new List<string>();
            list_des_id = lst_id();

            for (int i = 0; i <= list_des_id.Count - 1; i++)
            {

                string Sql = "select count(id) from paiement_mensuel where frais_mensuel_id in( select id from frais_mensuel where designation='septembre') and eleve_id='" + list_des_id.ElementAt(i) + "'";
                MySqlCommand cmd = new MySqlCommand(Sql, Connexion.con);
                int valeur_requete = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (valeur_requete != 0)
                {
                    list_des_mois.Add("oui");

                }
                else
                {
                    list_des_mois.Add("non");
                }
            }

            return list_des_mois;
        }


        public List<string> lst_octobre()
        {
            List<string> list_des_mois = new List<string>();
            List<string> list_des_id = new List<string>();
            list_des_id = lst_id();

            for (int i = 0; i <= list_des_id.Count - 1; i++)
            {

                string Sql = "select count(id) from paiement_mensuel where frais_mensuel_id in( select id from frais_mensuel where designation='octobre') and eleve_id='" + list_des_id.ElementAt(i) + "'";
                MySqlCommand cmd = new MySqlCommand(Sql, Connexion.con);
                int valeur_requete = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (valeur_requete != 0)
                {
                    list_des_mois.Add("oui");

                }
                else
                {
                    list_des_mois.Add("non");
                }
            }

            return list_des_mois;
        }


        public List<string> lst_novembre()
        {
            List<string> list_des_mois = new List<string>();
            List<string> list_des_id = new List<string>();
            list_des_id = lst_id();

            for (int i = 0; i <= list_des_id.Count - 1; i++)
            {

                string Sql = "select count(id) from paiement_mensuel where frais_mensuel_id in( select id from frais_mensuel where designation='novembre') and eleve_id='" + list_des_id.ElementAt(i) + "'";
                MySqlCommand cmd = new MySqlCommand(Sql, Connexion.con);
                int valeur_requete = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (valeur_requete != 0)
                {
                    list_des_mois.Add("oui");

                }
                else
                {
                    list_des_mois.Add("non");
                }
            }

            return list_des_mois;
        }


        public List<string> Lst_decembre()
        {
            List<string> list_des_mois = new List<string>();
            List<string> list_des_id = new List<string>();
            list_des_id = lst_id();

            for (int i = 0; i <= list_des_id.Count - 1; i++)
            {

                string Sql = "select count(id) from paiement_mensuel where frais_mensuel_id in( select id from frais_mensuel where designation='décembre') and eleve_id='" + list_des_id.ElementAt(i) + "'";
                MySqlCommand cmd = new MySqlCommand(Sql, Connexion.con);
                int valeur_requete = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (valeur_requete != 0)
                {
                    list_des_mois.Add("oui");

                }
                else
                {
                    list_des_mois.Add("non");
                }
            }

            return list_des_mois;
        }


        public List<string> lst_janvier()
        {
            List<string> list_des_mois = new List<string>();
            List<string> list_des_id = new List<string>();
            list_des_id = lst_id();

            for (int i = 0; i <= list_des_id.Count - 1; i++)
            {

                string Sql = "select count(id) from paiement_mensuel where frais_mensuel_id in( select id from frais_mensuel where designation='janvier') and eleve_id='" + list_des_id.ElementAt(i) + "'";
                MySqlCommand cmd = new MySqlCommand(Sql, Connexion.con);
                int valeur_requete = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (valeur_requete != 0)
                {
                    list_des_mois.Add("oui");

                }
                else
                {
                    list_des_mois.Add("non");
                }
            }

            return list_des_mois;
        }


    
        public List<string> lst_fevrier()
        {
            List<string> list_des_mois = new List<string>();
            List<string> list_des_id = new List<string>();
            list_des_id = lst_id();

            for (int i = 0; i <= list_des_id.Count - 1; i++)
            {

                string Sql = "select count(id) from paiement_mensuel where frais_mensuel_id in( select id from frais_mensuel where designation='février') and eleve_id='" + list_des_id.ElementAt(i) + "'";
                MySqlCommand cmd = new MySqlCommand(Sql, Connexion.con);
                int valeur_requete = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (valeur_requete != 0)
                {
                    list_des_mois.Add("oui");

                }
                else
                {
                    list_des_mois.Add("non");
                }
            }

            return list_des_mois;
        }


        public List<string> Lst_mars
        {
            get
            {
                List<string> list_des_mois = new List<string>();
                List<string> list_des_id = new List<string>();
                list_des_id = lst_id();

                for (int i = 0; i <= list_des_id.Count - 1; i++)
                {

                    string Sql = "select count(id) from paiement_mensuel where frais_mensuel_id in( select id from frais_mensuel where designation='mars') and eleve_id='" + list_des_id.ElementAt(i) + "'";
                    MySqlCommand cmd = new MySqlCommand(Sql, Connexion.con);
                    int valeur_requete = Int32.Parse(cmd.ExecuteScalar().ToString());
                    if (valeur_requete != 0)
                    {
                        list_des_mois.Add("oui");

                    }
                    else
                    {
                        list_des_mois.Add("non");
                    }
                }

                return list_des_mois;
            }
        }

        public List<string> Lst_avril()
        {
            List<string> list_des_mois = new List<string>();
            List<string> list_des_id = new List<string>();
            list_des_id = lst_id();

            for (int i = 0; i <= list_des_id.Count - 1; i++)
            {

                string Sql = "select count(id) from paiement_mensuel where frais_mensuel_id in( select id from frais_mensuel where designation='avril') and eleve_id='" + list_des_id.ElementAt(i) + "'";
                MySqlCommand cmd = new MySqlCommand(Sql, Connexion.con);
                int valeur_requete = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (valeur_requete != 0)
                {
                    list_des_mois.Add("oui");

                }
                else
                {
                    list_des_mois.Add("non");
                }
            }

            return list_des_mois;
        }


        public List<string> lst_mai()
        {
            List<string> list_des_mois = new List<string>();
            List<string> list_des_id = new List<string>();
            list_des_id = lst_id();

            for (int i = 0; i <= list_des_id.Count - 1; i++)
            {

                string Sql = "select count(id) from paiement_mensuel where frais_mensuel_id in( select id from frais_mensuel where designation='mai') and eleve_id='" + list_des_id.ElementAt(i) + "'";
                MySqlCommand cmd = new MySqlCommand(Sql, Connexion.con);
                int valeur_requete = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (valeur_requete != 0)
                {
                    list_des_mois.Add("oui");

                }
                else
                {
                    list_des_mois.Add("non");
                }
            }

            return list_des_mois;
        }


        public List<string> lst_juin()
        {
            List<string> list_des_mois = new List<string>();
            List<string> list_des_id = new List<string>();
            list_des_id = lst_id();

            for (int i = 0; i <= list_des_id.Count - 1; i++)
            {

                string Sql = "select count(id) from paiement_mensuel where frais_mensuel_id in( select id from frais_mensuel where designation='juin') and eleve_id='" + list_des_id.ElementAt(i) + "'";
                MySqlCommand cmd = new MySqlCommand(Sql, Connexion.con);
                int valeur_requete = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (valeur_requete != 0)
                {
                    list_des_mois.Add("oui");

                }
                else
                {
                    list_des_mois.Add("non");
                }
            }

            return list_des_mois;
        }

        public List<string> lst_juillet()
        {
            List<string> list_des_mois = new List<string>();
            List<string> list_des_id = new List<string>();
            list_des_id = lst_id();

            for (int i = 0; i <= list_des_id.Count - 1; i++)
            {

                string Sql = "select count(id) from paiement_mensuel where frais_mensuel_id in( select id from frais_mensuel where designation='juillet') and eleve_id='" + list_des_id.ElementAt(i) + "'";
                MySqlCommand cmd = new MySqlCommand(Sql, Connexion.con);
                int valeur_requete = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (valeur_requete != 0)
                {
                    list_des_mois.Add("oui");

                }
                else
                {
                    list_des_mois.Add("non");
                }
            }

            return list_des_mois;
        }


        #endregion

        #region remplissage du datagriview
        private void RemplirGrille()
        {

            List<string> list_id = lst_id();
            List<string> list_nom = lst_nom();
            List<string> list_incription = lst_incription();
            List<string> list_septembre = lst_septembre();
            List<string> list_octobre = lst_octobre();
            List<string> list_novembre = lst_novembre();
            List<string> list_decembre = Lst_decembre();
            List<string> list_janvier = lst_janvier();
            List<string> list_fevrier = lst_fevrier();
            List<string> list_mars = Lst_mars;
            List<string> list_avril = Lst_avril();
            List<string> list_mai = lst_mai();
            List<string> list_juin = lst_juin();
            List<string> list_juillet = lst_juillet();


            dgvliste.Rows.Clear();

            for (int i = 0; i <= list_id.Count - 1; i++)
            {
                dgvliste.Rows.Add(list_id.ElementAt(i), list_nom.ElementAt(i), list_incription.ElementAt(i), list_septembre.ElementAt(i), list_octobre.ElementAt(i), list_novembre.ElementAt(i), list_decembre.ElementAt(i), list_janvier.ElementAt(i), list_fevrier.ElementAt(i), list_mars.ElementAt(i), list_avril.ElementAt(i), list_mai.ElementAt(i), list_juin.ElementAt(i), list_juillet.ElementAt(i));
            }

        }
        #endregion

     

        private void Cbx_classe_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemplirGrille();
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
            iTextSharp.text.Font police_titre = FontFactory.GetFont("calibri", 14, 1);
            iTextSharp.text.Font police_titre_principal = FontFactory.GetFont("calibri", 14);
            iTextSharp.text.Font police_entete_tableau = FontFactory.GetFont("Century Gothic", 9, 1);
            iTextSharp.text.Font police_Cellule = FontFactory.GetFont("arial", 8);
            Paragraph PasserLigne = new Paragraph(Environment.NewLine);
            #endregion

            #region en-tête du document
            string t_nom_ecole = Operations.ObtenirNomEtablissement()+"\n";
            string t_classe = "Classe : Toutes\n";
            string t_date_du_jour = "Imprimé le  : " + DateTime.Now.ToString() + "\n";
            if (!cbx_classe.Text.Equals(String.Empty))
            {
                t_classe = "Classe : " + cbx_classe.Text + "\n";
            }
            string t_title_principal = "Liste des élèves : Vue d'ensemble";
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
            PdfPTable tableau = new PdfPTable(15); //un tableau de 5 colonnes N°, nom, postnom et prenom
            tableau.WidthPercentage = 98;

            tableau.SetWidths(new float[] { 7, 7, 20, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 });

            Phrase p_numero = new Phrase("N°", police_entete_tableau);
            Phrase p_Id = new Phrase("Id", police_entete_tableau);
            Phrase p_nom = new Phrase("Noms", police_entete_tableau);
            Phrase p_Inscription = new Phrase("Insc.", police_entete_tableau);
            Phrase p_septembre= new Phrase("Sept.", police_entete_tableau);
            Phrase p_octobre = new Phrase("Oct.", police_entete_tableau);
            Phrase p_Novembre = new Phrase("Nov.", police_entete_tableau);
            Phrase p_decembre = new Phrase("Dec.", police_entete_tableau);
            Phrase p_janvier = new Phrase("Jan.", police_entete_tableau);
            Phrase p_fevrier = new Phrase("Fév.", police_entete_tableau);
            Phrase p_mars = new Phrase("Mars", police_entete_tableau);
            Phrase p_avril = new Phrase("Avr.", police_entete_tableau);
            Phrase p_mai = new Phrase("Mai.", police_entete_tableau);
            Phrase p_juin = new Phrase("Juin.", police_entete_tableau);
            Phrase p_juillet = new Phrase("Juil.", police_entete_tableau);


            tableau.AddCell(p_numero);
            tableau.AddCell(p_Id);
            tableau.AddCell(p_nom);
            tableau.AddCell(p_Inscription);
            tableau.AddCell(p_septembre);
            tableau.AddCell(p_octobre);
            tableau.AddCell(p_Novembre);
            tableau.AddCell(p_decembre);
            tableau.AddCell(p_janvier);
            tableau.AddCell(p_fevrier);
            tableau.AddCell(p_mars);
            tableau.AddCell(p_avril);
            tableau.AddCell(p_mai);
            tableau.AddCell(p_juin);
            tableau.AddCell(p_juillet);

            int nombre_ligne = dgvliste.Rows.Count;

            for (int i = 0; i < nombre_ligne; i++)
            {

                tableau.AddCell((i + 1).ToString());
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[0].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[1].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[2].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[3].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[4].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[5].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[6].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[7].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[8].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[9].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[10].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[11].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[12].Value.ToString(), police_Cellule));
                tableau.AddCell(new Phrase(dgvliste.Rows[i].Cells[13].Value.ToString(), police_Cellule));


            }

            doc.Add(tableau);
            #endregion


            doc.Close();
            this.Cursor = Cursors.Default;
            new FrmApercuAvantImpression().Show();

        }
    }
}
