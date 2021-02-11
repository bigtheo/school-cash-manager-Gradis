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
    public partial class frmDetailsEleve : Form
    {
        public frmDetailsEleve()
        {
            InitializeComponent();
        }

        #region barre de titre...
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr intPtr, int hwm, int lparam, int lwp);
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanelBarreDeTitre_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region au chargement du formualaire..;
        private void FrmDetailsEleve_Load(object sender, EventArgs e)
        {
            Charger_Infos();
            ObtenirPhoto();

        }

        private void ObtenirPhoto()
        {
            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select image from images_eleves where eleve_id=@eleve_id";

                MySqlParameter p_eleve_id = new MySqlParameter("@eleve_id", MySqlDbType.LongBlob);
                p_eleve_id.Value = FrmInscription.id_eleve;
                cmd.Parameters.Add(p_eleve_id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0)) //s'il n'y a pas de logo...
                    {
                        byte[] imgb = (byte[])reader.GetValue(0);
                        MemoryStream ms = new MemoryStream(imgb);
                        pbxPhoto.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        pbxPhoto.Image = null;
                    }
                }

            }
        }
        private void Charger_Infos()
        {
            using(MySqlCommand cmd =new MySqlCommand())
            {
                try
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "select* from v_infos_d_un_eleve where id=@id";
                    cmd.Parameters.Add("@id", MySqlDbType.Int32);
                    cmd.Parameters["@id"].Value= FrmInscription.id_eleve;
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                    
                    foreach(DataRow dataRow in table.Rows)
                    {
                        txt_nom.Text = dataRow["nom"].ToString();
                        txt_postnom.Text = dataRow["postnom"].ToString();
                        txt_prenom.Text = dataRow["prenom"].ToString();
                        cbx_genre.Text = dataRow["genre"].ToString();
                        dtp_date_naissance.Text = dataRow["date_naissance"].ToString();
                        cbx_lieu_naissance.Text = dataRow["lieu_naissance"].ToString();
                        cbx_classe.Text = dataRow["classe"].ToString();
                        txt_nom_pere.Text = dataRow["nom_pere"].ToString();
                        txt_telephone_pere.Text =dataRow["tel_pere"].ToString();
                        txt_nom_mere.Text = dataRow["nom_mere"].ToString();
                        txt_telephone_mere.Text = dataRow["tel_mere"].ToString();
                        txt_adresse.Text = dataRow["adresse"].ToString();
                        cbx_section.Text = dataRow["nom_section"].ToString();

                    }

                }catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion
    }
}
