using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class FrmLienDeParente : Form
    {
        public FrmLienDeParente()
        {
            InitializeComponent();
        }
        #region barre de titre...

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr ptr, int v1, int v2, int v3);

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

        #endregion barre de titre...

        #region recherche des infos sur l'enseignat et l'enfant

        private void TrouverInformationsEnfant()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select concat_ws(' ',nom, postnom) from eleve where id=@id";
                cmd.CommandType = CommandType.Text;

                MySqlParameter p_Id = new MySqlParameter("@Id", MySqlDbType.Int64);
                cmd.Parameters.AddWithValue(p_Id.ParameterName, nnup_id_eleve.Value);

                try
                {
                    txtNom_eleve.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TrouverInformationsTravailleur()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select noms from Enseignant where id=@id";
                cmd.CommandType = CommandType.Text;

                MySqlParameter p_Id = new MySqlParameter("@Id", MySqlDbType.Int64);
                cmd.Parameters.AddWithValue(p_Id.ParameterName, nupMatricule_enseignant.Value);

                try
                {
                    txtnom_enseignant.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void NupMatricule_enseignant_ValueChanged(object sender, EventArgs e)
        {
            TrouverInformationsTravailleur();
        }

        private void Nnup_id_eleve_ValueChanged(object sender, EventArgs e)
        {
            TrouverInformationsEnfant();
        }

        #endregion recherche des infos sur l'enseignat et l'enfant

        #region Enregistrement du lien famial

        private void Enregistrer()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "INSERT INTO ASSOCIER(eleve_id,enseignant_id) values(@eleve_id,@enseignant_id)";
                MySqlParameter p_eleve_id = new MySqlParameter("@eleve_id", MySqlDbType.Int64);
                MySqlParameter p_enseignant_id = new MySqlParameter("@enseignant_id", MySqlDbType.Int64);

                cmd.Parameters.AddWithValue(p_eleve_id.ParameterName, nnup_id_eleve.Value);
                cmd.Parameters.AddWithValue(p_enseignant_id.ParameterName, nupMatricule_enseignant.Value);

                try
                {

                    DialogResult result = MessageBox.Show("Voulez-vous vraiment enregistrer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
                    if (result == DialogResult.Yes)
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show($"enregistrement effectué avec succès \n{rowsAffected} affectée(s)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Enregistrement annulé");
                    }
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 1062:
                            MessageBox.Show($"duplicat, cet élève est déjà associé à un père, code d'erreur : {ex.Number}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 1452:
                            MessageBox.Show($"Référence : le père ou/et l'enfant doit avoir des matricules attribués, code d'erreur : {ex.Number}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        default:
                            MessageBox.Show($"{ex.Message} code d'erreur : {ex.Number}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
            }
        }
        #endregion

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            Enregistrer();
        }
    }
}
