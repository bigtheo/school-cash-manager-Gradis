﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class frmNouveauPaiementMensuel : Form
    {
        public frmNouveauPaiementMensuel()
        {
            InitializeComponent();
            ListerPaiementParID();
            
        }

        #region barre de titre

        [DllImport("User32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr intPtr, int lparam, int hwm, int hparam);

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanelBarreDeTitre_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion barre de titre

        #region recherche des infos des élèves pour payer les frais....

        /// <summary>
        /// Cette procedure cherche le mois que l'élève vient payer par son id
        /// </summary>
        private void OntenirMoisApayer()
        {
            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "Ps_obtenirMoisApayer";
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter p_eleve_id = new MySqlParameter("@p_eleve_id", MySqlDbType.Int32)
                {
                    Direction = ParameterDirection.Input
                };
                MySqlParameter p_moisApayer = new MySqlParameter("@p_moisApayer", MySqlDbType.VarChar, 20)
                {
                    Direction = ParameterDirection.Output
                };

                p_eleve_id.Value = nupdown_id.Value;
                cmd.Parameters.Add(p_eleve_id);
                cmd.Parameters.Add(p_moisApayer);

                cmd.ExecuteNonQuery();

                txt_frais_mensuel.Text= p_moisApayer.Value.ToString();


            }
        }

        /// <summary>
        /// Cette procedure permet d'afficher le noms et la classe de l'élève
        /// </summary>
        private void TrouverNomClasseEleveParID()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "Afficher_noms_eleve_par_id";
                    cmd.CommandType = CommandType.StoredProcedure;

                    //creation des parametres...
                    MySqlParameter p_id = new MySqlParameter("@p_id", MySqlDbType.Int32);
                    MySqlParameter p_noms_eleve = new MySqlParameter("@p_noms_eleve", MySqlDbType.VarChar, 150);
                    MySqlParameter p_classe = new MySqlParameter("@p_classe", MySqlDbType.VarChar, 15);

                    //le sens des parametres...
                    p_id.Direction = ParameterDirection.Input;
                    p_noms_eleve.Direction = ParameterDirection.Output;
                    p_classe.Direction = ParameterDirection.Output;

                    //assignation des parametres
                    cmd.Parameters.Add(p_id);
                    cmd.Parameters.Add(p_noms_eleve);
                    cmd.Parameters.Add(p_classe);

                    //ajout de l'id de l'élève au parametre
                    p_id.Value = nupdown_id.Value;

                    //exécution de la commande
                    cmd.ExecuteNonQuery();

                    //récuperation des valeurs aux paremtres OutPut
                    txt_noms.Text = p_noms_eleve.Value.ToString();
                    txt_classe.Text = p_classe.Value.ToString();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ListerPaiementParID()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "AfficherPaiementDunEleveParID";
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter p_id = new MySqlParameter("@p_id", MySqlDbType.Int32)
                {
                    Direction = ParameterDirection.Input,
                    Value = nupdown_id.Value
                };
                cmd.Parameters.Add(p_id);

                //ajout des colonne à ma liste

                using (MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    sqlDataAdapter.Fill(table);
                    dgvliste.DataSource = table;
                   
                    sqlDataAdapter.Dispose();
                    cmd.Dispose();
                }
            }
        }

        private void TrouverMontantParClasseFraisMensuelID()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "ps_ObtenirMontantMensuel";
                    cmd.CommandType = CommandType.StoredProcedure;

                    //decalaration des paramtres...
                    MySqlParameter p_classe = new MySqlParameter("@p_classe", MySqlDbType.VarChar, 20);
                    MySqlParameter p_frais_mensuel_id = new MySqlParameter("@p_designation_frais", MySqlDbType.VarChar, 20);
                    MySqlParameter p_montant_frais_mensuel = new MySqlParameter("@p_montant", MySqlDbType.Decimal);
                    MySqlParameter p_montant_frais_mensuel_id = new MySqlParameter("@p_frais_mensuel_id", MySqlDbType.Int32);

                    //direction des parametres...
                    p_classe.Direction = ParameterDirection.Input;
                    p_montant_frais_mensuel.Direction = ParameterDirection.Input;
                    p_montant_frais_mensuel.Direction = ParameterDirection.Output;
                    p_montant_frais_mensuel_id.Direction = ParameterDirection.Output;

                    //assignattion de params a la cmd

                    cmd.Parameters.Add(p_frais_mensuel_id);
                    cmd.Parameters.Add(p_classe);
                    cmd.Parameters.Add(p_montant_frais_mensuel);
                    cmd.Parameters.Add(p_montant_frais_mensuel_id);

                    //les valeurs des parametres...

                    p_classe.Value = txt_classe.Text;
                    p_frais_mensuel_id.Value = txt_frais_mensuel.Text;

                    //exécution de la requette
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    //récuperation du montant...
                    nupdown_montant.Value = Convert.ToDecimal(p_montant_frais_mensuel.Value);
                    lbl_frais_mensuel_id.Text = p_montant_frais_mensuel_id.Value.ToString();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Nupdown_id_ValueChanged(object sender, EventArgs e)
        {
            TrouverNomClasseEleveParID();
            ListerPaiementParID();  
            OntenirMoisApayer();
            TrouverMontantParClasseFraisMensuelID();


        }

        #endregion recherche des infos des élèves pour payer les frais....

        #region enregistrement du frais mensuel

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            SavePaiementMensuel();
        }

        /// <summary>
        /// Cette procedure peremt d'enregistrer le paiement mensuel
        /// </summary>
        private void SavePaiementMensuel()
        {
            if (ChampsOk())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "Insert Into paiement_mensuel(id,date_paie,eleve_id,frais_mensuel_id,user_id) VALUES(@id,@date_paie,@eleve_id,@frais_mensuel_id,@user_id)";
                    cmd.CommandType = CommandType.Text;

                    //les parametres
                    MySqlParameter p_id = new MySqlParameter("@id", MySqlDbType.Int32);
                    MySqlParameter p_date_paie = new MySqlParameter("@date_paie", MySqlDbType.DateTime);
                    MySqlParameter p_frais_mensuel_id = new MySqlParameter("@frais_mensuel_id", MySqlDbType.Int32);
                    MySqlParameter p_eleve_id = new MySqlParameter("@eleve_id", MySqlDbType.Int32);
                    MySqlParameter p_user_id = new MySqlParameter("@user_id", MySqlDbType.Int32);

                    //les valeurs des parametres
                    p_id.Value = null;
                    p_date_paie.Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    p_frais_mensuel_id.Value = lbl_frais_mensuel_id.Text;
                    p_eleve_id.Value = nupdown_id.Value;
                    p_user_id.Value = 1; //obtenir l'id d'utilisateur

                    cmd.Parameters.Add(p_id);
                    cmd.Parameters.Add(p_date_paie);
                    cmd.Parameters.Add(p_frais_mensuel_id);
                    cmd.Parameters.Add(p_eleve_id);
                    cmd.Parameters.Add(p_user_id);

                    try
                    {
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Paiement enregistré avec succès !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CreerRecu();
                            Operations.PrintPDFByProcess();
                            
                        }
                    }
                    catch (MySqlException ex)
                    {
                        if (ex.Number == 1452)
                            MessageBox.Show( "Le mois de  "+ txt_frais_mensuel.Text+" n'est pas configuré pour cette classe !!" + ex.Number);
                        else
                            if (ex.Number == 1062)
                            MessageBox.Show("Cet élève a déjà payé le mois de " + txt_frais_mensuel.Text );
                        else
                            MessageBox.Show(ex.Message + "\n Code d'erreur :" + ex.Number);

                    }
                }
            }
            else
            {
                MessageBox.Show("Enregistrement impossible\nVeuillez vérifier les informations", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ChampsOk()
        {
            return !txt_classe.Text.Equals(string.Empty) && !txt_frais_mensuel.Text.Equals(String.Empty) && !txt_noms.Text.Equals(String.Empty) && !nupdown_montant.Value.Equals(0);
        }

        #endregion enregistrement du frais mensuel

        #region Reçu du paiement mensuel

        /// <summary>
        /// cette méthode permet de retounet le numéro ud dernier réçu....
        /// </summary>
        /// <returns></returns>
        private string ObtenirNumeroRecuMensuel()
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "PS_DernierNumeroRecuMensuel";
                    cmd.CommandType = CommandType.StoredProcedure;
                  
                    MySqlParameter p_numero_recu = new MySqlParameter("@p_numero_recu", MySqlDbType.Int64)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(p_numero_recu);

                    //on exécute la requete 
                    cmd.ExecuteNonQuery();                  
                    return p_numero_recu.Value.ToString();
                    
                    
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

            Rectangle taille = new Rectangle(new Rectangle(288, 720)); // le format(longueur et largueur) du récu
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
            string noms_eleve = "  " + nupdown_id.Value + " " + txt_noms.Text + " " +  " " + txt_classe.Text;
            string numero_recu = "réçu N° "+ ObtenirNumeroRecuMensuel();
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
            Chunk chunk_frais = new Chunk("Frais payés", police_cellule);
            Chunk chunk_frais_valeur = new Chunk(txt_frais_mensuel.Text , police_cellule);

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
            Chunk chunk_montant = new Chunk("Montant payé", police_cellule);
            Chunk chunk_montant_valeur = new Chunk(nupdown_montant.Value + " CDF", police_cellule);
            //les paragraphes des mes chunks
            Paragraph p_chunk_montant = new Paragraph(chunk_montant);
            Paragraph p_chunk_montant_valeur = new Paragraph(chunk_montant_valeur);


            tableau_principal.AddCell(p_chunk_montant);
            tableau_principal.AddCell(p_chunk_montant_valeur);

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
        #endregion Reçu du paiement mensuel

        private void Cbx_frais_mensuel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!nupdown_id.Value.Equals(null)&&!nupdown_id.Value.ToString().Equals("inconnu"))
            {
                TrouverMontantParClasseFraisMensuelID();
            }
         
        }

        private void Txt_frais_mensuel_TextChanged(object sender, EventArgs e)
        {
            TrouverMontantParClasseFraisMensuelID();
        }
    }
}