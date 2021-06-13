using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class FrmModifierEleve : Form
    {
        public FrmModifierEleve()
        {
            InitializeComponent();
        }

        #region barre de titre

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr intPtr, int hwm, int lparam, int lwp);

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanelBarreDeTitre_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion barre de titre

        #region Mise à jour...

        //mise à jour de infos des parents..
        private bool UpdatedPere()
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "UPDATE pere set nom=@nom,telephone=@telephone where id=@pere_id";

                    MySqlParameter p_nom = new MySqlParameter("@nom", MySqlDbType.VarChar, 50);
                    MySqlParameter p_telephone = new MySqlParameter("@telephone", MySqlDbType.VarChar, 15);
                    MySqlParameter p_pere_id = new MySqlParameter("@pere_id", MySqlDbType.Int32);

                    cmd.Parameters.Add(p_nom);
                    cmd.Parameters.Add(p_telephone);
                    cmd.Parameters.Add(p_pere_id);

                    p_nom.Value = txt_nom_pere.Text;
                    p_telephone.Value = txt_telephone_pere.Text;
                    p_pere_id.Value = Operations.ObtenirIdPereParIDelve(txt_id.Text);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    return false;

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool UpdatedMere()
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "UPDATE mere set nom=@nom,telephone=@telephone where id=@mere_id";

                    MySqlParameter p_nom = new MySqlParameter("@nom", MySqlDbType.VarChar, 50);
                    MySqlParameter p_telephone = new MySqlParameter("@telephone", MySqlDbType.VarChar, 15);
                    MySqlParameter p_mere_id = new MySqlParameter("@mere_id", MySqlDbType.Int32);

                    cmd.Parameters.Add(p_nom);
                    cmd.Parameters.Add(p_telephone);
                    cmd.Parameters.Add(p_mere_id);

                    p_nom.Value = txt_nom_mere.Text;
                    p_telephone.Value = txt_telephone_mere.Text;
                    p_mere_id.Value = Operations.ObtenirIdMereParIDelve(txt_id.Text);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// cette méthôde modifie le la ligne de la table élève par son id
        /// </summary>
        /// <returns>true</returns>
        private bool UpdateEleve()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "UpdateEleve";
                    cmd.CommandType = CommandType.StoredProcedure;

                    //ajout des parametres...
                    cmd.Parameters.Add("@p_id", MySqlDbType.Int32);
                    cmd.Parameters.Add("@p_nom", MySqlDbType.VarChar, 45);
                    cmd.Parameters.Add("@p_postnom", MySqlDbType.VarChar, 45);
                    cmd.Parameters.Add("@p_prenom", MySqlDbType.VarChar, 45);
                    cmd.Parameters.Add("@p_genre", MySqlDbType.Enum);
                    cmd.Parameters.Add("@p_date_naissance", MySqlDbType.Date);
                    cmd.Parameters.Add("@p_lieu_naissance", MySqlDbType.VarChar, 45);
                    cmd.Parameters.Add("@p_adresse", MySqlDbType.Text);
                    cmd.Parameters.Add("@p_classe_id", MySqlDbType.Int32);
                    cmd.Parameters.Add("@p_pere_id", MySqlDbType.Int32);
                    cmd.Parameters.Add("@p_mere_id", MySqlDbType.Int32);

                    //ajout des directions des parametres...
                    cmd.Parameters["@p_id"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@p_nom"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@p_postnom"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@p_prenom"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@p_genre"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@p_lieu_naissance"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@p_date_naissance"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@p_adresse"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@p_classe_id"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@p_pere_id"].Direction = ParameterDirection.Input;
                    cmd.Parameters["@p_mere_id"].Direction = ParameterDirection.Input;

                    //ajout des valeurs aux parametres...
                    cmd.Parameters["@p_id"].Value = txt_id.Text.Trim();
                    cmd.Parameters["@p_nom"].Value = txt_nom.Text.Trim();
                    cmd.Parameters["@p_postnom"].Value = txt_postnom.Text.Trim();
                    cmd.Parameters["@p_prenom"].Value = txt_prenom.Text.Trim();
                    cmd.Parameters["@p_genre"].Value = cbx_genre.Text.Trim();
                    cmd.Parameters["@p_lieu_naissance"].Value = cbx_lieu_naissance.Text.Trim();
                    cmd.Parameters["@p_date_naissance"].Value = dtp_date_naissance.Value.ToString("yyyy-MM-dd");
                    cmd.Parameters["@p_adresse"].Value = txt_adresse.Text.Trim();
                    cmd.Parameters["@p_classe_id"].Value = classe_id;
                    //appel des méthôde qui permettent de trouver les ID des parents de l'élève
                    cmd.Parameters["@p_pere_id"].Value = Operations.ObtenirIdPereParIDelve(txt_id.Text);
                    cmd.Parameters["@p_mere_id"].Value = Operations.ObtenirIdMereParIDelve(txt_id.Text);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message + ex.Number);
                    return false;
                }
            }
        }

        private bool UpdatePhoto()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "UPDATE  images_eleves set image=@image where eleve_id=@eleve_id";
                MySqlParameter p_image = new MySqlParameter("@image", MySqlDbType.LongBlob);
                MySqlParameter p_eleve_id = new MySqlParameter("@eleve_id", MySqlDbType.Int32);
              
                byte[] image;
                if (pbxPhoto.Image != null)
                {
                    MemoryStream memory = new MemoryStream();
                    pbxPhoto.Image.Save(memory, pbxPhoto.Image.RawFormat);
                    image = memory.ToArray();
                }
                else
                {
                    DialogResult result = MessageBox.Show("La photo n'est pas ajoutée,\nVoulez-vous enregistrer sans photoe ? ", "Avertissement", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (result == DialogResult.OK)
                    {
                        image = null;
                    }
                    else
                    {
                        return false;
                    }

                }
                p_image.Value = image;
                p_eleve_id.Value = FrmInscription.id_eleve;
                cmd.Parameters.Add(p_eleve_id);
                cmd.Parameters.Add(p_image);


                if (cmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
                else
                {
                    cmd.CommandText = "INSERT INTO images_eleves(id,nom,image,eleve_id) values(@id,@nom,@image,@eleve_id)";
                    MySqlParameter p_nom = new MySqlParameter("@nom", MySqlDbType.TinyText);
                    MySqlParameter p_id = new MySqlParameter("@id", MySqlDbType.TinyText)
                    {
                        Value = null
                    };
                    p_nom.Value = txt_nom.Text + txt_postnom.Text + txt_prenom.Text;

                    cmd.Parameters.Add(p_id);
                    cmd.Parameters.Add(p_nom);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    return true;
                }
            }
        }
        #endregion Mise à jour...

        #region appel des méthôdes

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (ChampsOk())
            {
                if (
                    UpdateEleve() && UpdatedPere() && 
                    UpdatedMere() && UpdatePhoto() &&
                    UpdatePaiement()
                    )
                {
                    MessageBox.Show("Information Mise à jour avec succès !!!");
                    CreerRecu();

                }
                else
                {
                    MessageBox.Show("Enregiostrement Impossible");
                }
               
            }
        }

        private bool UpdatePaiement()
        {
            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = $"update paiement_mensuel set frais_mensuel_id={Operations.ObtenirFraisInscrptionID(cbx_classe.Text)} where eleve_id={txt_id.Value} limit 1";
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;

                }catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        private bool ChampsOk()
        {
            if (txt_nom.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("Veuillez saisir le nom", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_nom.Focus();
                return false;
            }
            else
             if (txt_postnom.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("Veuillez saisir le postnom", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_postnom.Focus();
                return false;
            }
            else
                if (cbx_classe.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("Veuillez saisir la classe", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbx_classe.Focus();
                return false;
            }
            else
                if (cbx_genre.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("Veuillez déterminer le sexe", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbx_genre.Focus();
                return false;
            }
            else
                if (cbx_section.Text.Trim().Equals(String.Empty))
            {
                MessageBox.Show("Veuillez déterminer la section", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbx_section.Focus();
                return false;
            }
            {
                return true;
            }
        }

        #endregion appel des méthôdes

        #region au chargement du formulaire

        //efface les valeurs du formulaire
        private void Raz()
        {
            txt_id.Value = 0;
            txt_nom.Clear();
            txt_postnom.Clear();
            txt_prenom.Clear();
            cbx_genre.Text = "";
            dtp_date_naissance.Text = "";
            cbx_lieu_naissance.Text = "";
            cbx_classe.Text = "";
            txt_nom_pere.Clear();
            txt_telephone_pere.Clear();
            txt_nom_mere.Clear();
            txt_telephone_mere.Clear();
            txt_adresse.Clear();
            cbx_section.Text = "";
            pbxPhoto.Image = null;
        }

        private void Charger_Infos(string id_eleve)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "select* from v_infos_d_un_eleve where id=@id";
                    cmd.Parameters.Add("@id", MySqlDbType.Int32);
                    cmd.Parameters["@id"].Value = id_eleve;
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    if (!String.IsNullOrEmpty(id_eleve) || !string.IsNullOrWhiteSpace(id_eleve))
                    {
                        dataAdapter.Fill(table);

                        if (table.Rows.Count == 0)
                        {
                            Raz();
                        }
                    }
                    else
                    {
                        Raz();
                    }

                    foreach (DataRow dataRow in table.Rows)
                    {
                        txt_id.Text = dataRow["id"].ToString();
                        txt_nom.Text = dataRow["nom"].ToString();
                        txt_postnom.Text = dataRow["postnom"].ToString();
                        txt_prenom.Text = dataRow["prenom"].ToString();
                        cbx_genre.Text = dataRow["genre"].ToString();
                        dtp_date_naissance.Text = dataRow["date_naissance"].ToString();
                        cbx_lieu_naissance.Text = dataRow["lieu_naissance"].ToString();
                        txt_nom_pere.Text = dataRow["nom_pere"].ToString();
                        txt_telephone_pere.Text = dataRow["tel_pere"].ToString();
                        txt_nom_mere.Text = dataRow["nom_mere"].ToString();
                        txt_telephone_mere.Text = dataRow["tel_mere"].ToString();
                        txt_adresse.Text = dataRow["adresse"].ToString();
                        cbx_section.Text = dataRow["nom_section"].ToString();
                        cbx_classe.Text = dataRow["classe"].ToString();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ObtenirPhoto()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select image from images_eleves where eleve_id=@eleve_id";

                MySqlParameter p_eleve_id = new MySqlParameter("@eleve_id", MySqlDbType.LongBlob)
                {
                    Value = txt_id.Value
                };

                cmd.Parameters.Add(p_eleve_id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0)) //s'il n'y a pas de logo...
                    {
                        byte[] imgb = (byte[])reader.GetValue(0);
                        MemoryStream ms = new MemoryStream(imgb);
                        pbxPhoto.Image = System.Drawing.Image.FromStream(ms);
                    }
                    else
                    {
                        pbxPhoto.Image = null;
                    }
                }

            }
        }

        private void FrmModifierEleve_Load(object sender, EventArgs e)
        {
            Charger_Infos(FrmInscription.id_eleve);
            CustomizeAutocomplete();
            ObtenirPhoto();
        }

        #endregion au chargement du formulaire

        #region AUTO_COMPLETE

        private void CustomizeAutocomplete()
        {
            this.Cursor = Cursors.WaitCursor;
            //nom
            txt_nom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_nom.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            GetNomAutocomplete(DataCollection, "v_nom");
            txt_nom.AutoCompleteCustomSource = DataCollection;

            //postnom
            txt_postnom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_postnom.AutoCompleteSource = AutoCompleteSource.CustomSource;
            DataCollection = new AutoCompleteStringCollection();
            GetNomAutocomplete(DataCollection, "v_postnom");
            txt_postnom.AutoCompleteCustomSource = DataCollection;

            //prenom
            txt_prenom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_prenom.AutoCompleteSource = AutoCompleteSource.CustomSource;
            DataCollection = new AutoCompleteStringCollection();
            GetNomAutocomplete(DataCollection, "v_prenom");
            txt_prenom.AutoCompleteCustomSource = DataCollection;

            //nom père
            txt_nom_pere.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_nom_pere.AutoCompleteSource = AutoCompleteSource.CustomSource;
            DataCollection = new AutoCompleteStringCollection();
            GetNomAutocomplete(DataCollection, "v_nom_mere");
            txt_nom_pere.AutoCompleteCustomSource = DataCollection;

            //nom mère
            txt_nom_mere.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_nom_mere.AutoCompleteSource = AutoCompleteSource.CustomSource;
            DataCollection = new AutoCompleteStringCollection();
            GetNomAutocomplete(DataCollection, "v_nom_mere");
            txt_nom_mere.AutoCompleteCustomSource = DataCollection;

            //tel. père
            txt_telephone_pere.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_telephone_pere.AutoCompleteSource = AutoCompleteSource.CustomSource;
            DataCollection = new AutoCompleteStringCollection();
            GetNomAutocomplete(DataCollection, "v_telephone");
            txt_telephone_pere.AutoCompleteCustomSource = DataCollection;

            //tel. mère
            txt_telephone_mere.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_telephone_mere.AutoCompleteSource = AutoCompleteSource.CustomSource;
            DataCollection = new AutoCompleteStringCollection();
            GetNomAutocomplete(DataCollection, "v_telephone");
            txt_telephone_mere.AutoCompleteCustomSource = DataCollection;

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// cette procedure obtient le nom des élève
        /// </summary>
        private void GetNomAutocomplete(AutoCompleteStringCollection collection, string view)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                if (view == "v_nom")
                {
                    cmd.CommandText = "select nom from " + view;
                }
                else if (view == "v_postnom")
                {
                    cmd.CommandText = "select postnom from " + view;
                }
                else if (view == "v_prenom")
                {
                    cmd.CommandText = "select prenom from " + view;
                }
                else
                {
                    cmd.CommandText = "select* from " + view;
                }

                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                using (MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmd))
                {
                    try
                    {
                        DataTable table = new DataTable();
                        sqlDataAdapter.Fill(table);
                        foreach (DataRow row in table.Rows)
                        {
                            collection.Add(row[0].ToString());
                        }

                        sqlDataAdapter.Dispose();
                        cmd.Dispose();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        #endregion AUTO_COMPLETE

        private void Txt_id_ValueChanged(object sender, EventArgs e)
        {
            Charger_Infos(txt_id.Value.ToString());
            ObtenirPhoto();
        }

        #region classes et sections

        private void Cbx_section_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbx_classe.Text = "";
            Operations.ChargerClassesParSectionIDDansComboBox(cbx_classe, (cbx_section.SelectedIndex + 1).ToString());
        }

        private void Cbx_classe_SelectedIndexChanged(object sender, EventArgs e)
        {
            classe_id = Operations.TrouverClasse_idParNomClasse(cbx_classe.Text);
        }

        private string classe_id = "0";


        #endregion classes et sections

        private void BtnParcourir_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "choisir l'image (*.jpg *.png ) |*.jpg; *.png"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbxPhoto.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
                pbxPhoto.Text = openFileDialog1.FileName;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            pbxPhoto.Image = null;
        }


        #region Reçu du paiement mensuel

      

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
            string noms_eleve ="  "+ txt_id .Value+ " " + txt_nom.Text + " " + txt_postnom.Text + " " + txt_prenom.Text + " " + cbx_classe.Text;
            string numero_recu = "réçu N° " +txt_id.Value;
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
            Chunk chunk_frais_valeur = new Chunk("Inscription", police_cellule);

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
            Chunk chunk_montant_valeur = new Chunk(Operations.ObtenirMontantInscription(cbx_classe.Text) + " CDF", police_cellule);
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
            

            this.Cursor = Cursors.Default;
            Operations.PrintToASpecificPirnter();
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