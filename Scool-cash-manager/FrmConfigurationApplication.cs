using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class FrmConfigurationApplication : Form
    {
        public FrmConfigurationApplication()
        {
            InitializeComponent();
            ObtenirInfoConfiguration();
        }

        #region barre de titre...

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr handle, int v, int v1, int v2);

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanelBarreDeTitre_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion barre de titre...

        #region obtenir les informations de coonfigurations

        /// <summary>
        /// Cette méthôde permet d'obtnir les informations de configuration de l'application (configuration de basse)
        /// </summary>
        private void ObtenirInfoConfiguration()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "Select* from configuration where id=1";
                using (MySqlDataReader reader=cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        txt_nom_entite.Text = reader.GetValue(1).ToString();
                        txt_adresse.Text = reader.GetValue(3).ToString();
                        txt_telephone.Text = reader.GetValue(5).ToString();
                        rt_devise.Text = reader.GetValue(4).ToString();
                        nud_jour_mois.Value = reader.GetDecimal(6);

                        if (!reader.IsDBNull(2)) //s'il n'y a pas de logo...
                        {
                            byte[] imgb = (byte[])reader.GetValue(2);
                            MemoryStream ms = new MemoryStream(imgb);
                            pbx_logo.Image = Image.FromStream(ms);
                        }
                    }
                    reader.Dispose();
                    cmd.Dispose();
                }
            }

        }

     
        #endregion

        #region enregistrement...


        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (txt_adresse.Text ==""||txt_nom_entite.Text =="" || txt_telephone.Text =="" || rt_devise.Text =="")
            {
               DialogResult result= MessageBox.Show("Certains champs sont vides ,\nVoulez-vous continuer ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result.Equals(DialogResult.Yes))
                {
                    return;
                }
                    
            }
            //conversion du logo en byte
            byte[] image;
            if (pbx_logo.Image != null)
            {
                MemoryStream memory = new MemoryStream();
                pbx_logo.Image.Save(memory, pbx_logo.Image.RawFormat);
                image = memory.ToArray();
            }
            else
            {
            DialogResult result=  MessageBox.Show("Le logo n'est pas ajoutée,\nVoulez-vous enregistrer sans logo ? ","Avertissement",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    image = null;
                }
                else
                {
                    return; //on quitte la méthôde...
                }
            }

            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "UPDATE Configuration SET id=@id,nom_entite=@nom_entite,logo=@logo,Adresse=@Adresse,devise=@devise,Telephone=@Telephone,jour_mois_condition=@jour_mois_condition where id=@id ";
                MySqlParameter p_id = new MySqlParameter("@id", MySqlDbType.Int32);
                MySqlParameter p_nom_entite = new MySqlParameter("@nom_entite", MySqlDbType.LongText);
                MySqlParameter p_logo = new MySqlParameter("@logo", MySqlDbType.LongBlob);
                MySqlParameter p_adresse = new MySqlParameter("@adresse", MySqlDbType.Text);
                MySqlParameter p_devise = new MySqlParameter("@devise", MySqlDbType.Text );
                MySqlParameter p_telephone = new MySqlParameter("@telephone", MySqlDbType.VarChar,20 );
                MySqlParameter p_jour_mois_condition = new MySqlParameter("@jour_mois_condition", MySqlDbType.Int32 );

                //les valeurs des parametres...

                p_id.Value = 1;
                p_nom_entite.Value = txt_nom_entite.Text;
                p_adresse.Value = txt_adresse.Text;
                p_devise.Value = rt_devise.Text;
                p_logo.Value = image;
                p_telephone.Value = txt_telephone.Text;
                p_jour_mois_condition.Value = nud_jour_mois.Value;

                //assignation des parametres à la commande

                cmd.Parameters.Add(p_id);
                cmd.Parameters.Add(p_nom_entite);
                cmd.Parameters.Add(p_logo);
                cmd.Parameters.Add(p_adresse);
                cmd.Parameters.Add(p_devise);
                cmd.Parameters.Add(p_telephone);
                cmd.Parameters.Add(p_jour_mois_condition);
            

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Enregistrement éffectué","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }


            }
        }
        #endregion

        #region parcourir le logo...
        private void BtnParcourir_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "choisir l'image (*.jpg *.png ) |*.jpg; *.png"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbx_logo.Image = Image.FromFile(openFileDialog1.FileName);
                pbx_logo.Text = openFileDialog1.FileName;
            }
        }

        private void Pbx_logo_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "choisir l'image (*.jpg *.png ) |*.jpg; *.png"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbx_logo.Image = Image.FromFile(openFileDialog1.FileName);
                pbx_logo.Text = openFileDialog1.FileName;
            }
        }
        #endregion

        //nettoyer l'image dans le pictureBox...
        private void BtnClear_Click(object sender, EventArgs e)
        {
            pbx_logo.Image=null;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}