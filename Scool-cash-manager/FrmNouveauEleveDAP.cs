using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace Scool_cash_manager
{
    public partial class FrmNouveauEleveDAP : Form
    {
        public bool TousLesChampsRempli 
        { 
            get 
            {
                return txtNoms.Text != "" && cbx_classe.Text != "" && rtxtDescription.Text != "" && nupMontant.Value > 0;
            }
         }
         

        public FrmNouveauEleveDAP()
        {
            InitializeComponent();
            Operations.ChargerClassesDansComboBox(cbx_classe);
        }

        #region barre de titre 
        [DllImport("user32.dll", EntryPoint= "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr intPtr, int v1, int v2, int v3);
        private void PanelBarreDeTitre_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void BtnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (TousLesChampsRempli)
            {
                DialogResult result = MessageBox.Show("Voulez-vous vraiment enrgistrer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Enregistrer();
                }
                else
                {
                    MessageBox.Show("Enregistrement annulé");
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }
        }

        private void Enregistrer()
        {
            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "INSERT INTO elevedap(Id,noms,classe_id,Montant,description) VALUES (@id,@noms,@classe_id,@montant,@description)";

                MySqlParameter p_id = new MySqlParameter("@Id", MySqlDbType.Int64);
                MySqlParameter p_nom = new MySqlParameter("@noms", MySqlDbType.VarChar,50);
                MySqlParameter p_classe_id = new MySqlParameter("@classe_id", MySqlDbType.Int32);
                MySqlParameter p_montant = new MySqlParameter("@montant", MySqlDbType.Decimal,12);
                MySqlParameter p_description = new MySqlParameter("@description", MySqlDbType.Text);


                //les valeurs des parametres....
                p_id.Value = null;
                p_nom.Value  = txtNoms.Text;
                p_classe_id.Value = Operations.ObtenirClasseID(cbx_classe.Text);
                p_montant.Value = nupMontant.Value;
                p_description.Value = rtxtDescription.Text;

                //assignation des paramtres à la commande SQL

                cmd.Parameters.Add(p_id);
                cmd.Parameters.Add(p_nom);
                cmd.Parameters.Add(p_classe_id);
                cmd.Parameters.Add(p_montant);
                cmd.Parameters.Add(p_description);
                //exécution de la requette SQL

                try
                {
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Enregistrement éffectué avec succès !!","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        ClearControls();
                    }
                }
                catch (MySqlException ex)
                {

                    MessageBox.Show($"Erreur : {ex.Message}");
                }
               
            }
        }

        private void ClearControls()
        {
            txtNoms.Clear();
            rtxtDescription.Clear();
            cbx_classe.Text = "";
            nupMontant.Value = 0;
            txtNoms.Focus();
        }
       
    }
}
