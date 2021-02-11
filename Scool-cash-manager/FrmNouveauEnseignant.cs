using MySql.Data.MySqlClient;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class FrmNouveauEnseignant : Form
    {
        public FrmNouveauEnseignant()
        {
            InitializeComponent();
        }

        #region barre de titre

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr intPtr, int v1, int v2, int v3);

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

        #region enregistrement...

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            Enrgistrer();
        }

        private void Enrgistrer()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "INSERT INTO Enseignant(noms,Genre,Fonction,salaire_brut,section_id) values(@noms,@Genre,@Fonction,@salaire_brut,@section_id)";
                // les parametres MySql...
                MySqlParameter p_noms = new MySqlParameter("@noms", MySqlDbType.VarChar, 50);
                MySqlParameter p_genre = new MySqlParameter("@Genre", MySqlDbType.Enum);
                MySqlParameter p_fonction = new MySqlParameter("@Fonction", MySqlDbType.Enum);
                MySqlParameter p_salaire_brut = new MySqlParameter("@Salaire_brut", MySqlDbType.Decimal);
                MySqlParameter p_section_id = new MySqlParameter("@section_id", MySqlDbType.Int24);

                //les valeurs de parametres....

                p_noms.Value = txtNoms.Text;
                p_genre.Value = cbxGenre.Text;
                p_fonction.Value = cbxFonction.Text;
                p_salaire_brut.Value = nup_salaire_brut.Value;
                p_section_id.Value = cbx_section_id.SelectedIndex+1;

                //assigantion à la commande
                cmd.Parameters.Add(p_noms);
                cmd.Parameters.Add(p_genre);
                cmd.Parameters.Add(p_fonction);
                cmd.Parameters.Add(p_salaire_brut);
                cmd.Parameters.Add(p_section_id);

                try
                {
                    DialogResult result = MessageBox.Show("Voulez-vous vraiment enregistrer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int RowsAffected = cmd.ExecuteNonQuery();

                        MessageBox.Show($"Enrgistrement effectué avec succès \n{RowsAffected} ligne(s) affectée(s) !!!");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion enregistrement...
    }
}