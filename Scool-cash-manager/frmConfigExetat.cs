using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class frmConfigExetat : Form
    {
        public frmConfigExetat()
        {
            InitializeComponent();
        }

        #region au chargement du formulaire

        private void FrmConfigExetat_Load(object sender, EventArgs e)
        {
            Views.AfficherTout("v_classe_frais_exetat", dgvliste);
            Operations.ChargerClassesDansComboBox(cbx_classe);
        }

        #endregion au chargement du formulaire

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            
            if(ChampsOk())
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "Insert into classe_frais_exetat(id,montant,frais_exetat_id,classe_id) values(@id,@montant,@frais_exetat_id,@classe_id)";

                    //ajout des parametres
                    cmd.Parameters.Add("@id", MySqlDbType.Int32);
                    cmd.Parameters.Add("@montant", MySqlDbType.Double);
                    cmd.Parameters.Add("@classe_id", MySqlDbType.Int32);
                    cmd.Parameters.Add("@frais_exetat_id", MySqlDbType.Int32);

                    //ajout des valeurs aux parametres
                    cmd.Parameters["@id"].Value = null;
                    cmd.Parameters["@montant"].Value = nupdownMontant.Value;
                    cmd.Parameters["@classe_id"].Value = Operations.ObtenirClasseID(cbx_classe.Text);
                    cmd.Parameters["@frais_exetat_id"].Value = cbx_tranche.SelectedIndex + 1;

                    DialogResult result = MessageBox.Show("Voulez-vous vraiment enregistrer ?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Enregistrement éffectué avec succès !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        MessageBox.Show("Ducplicatat :"+cbx_tranche.Text +" est déja enregistré(e) pour la "+cbx_classe.Text , "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ex.Number == 1452)
                    {
                        MessageBox.Show("Référence :frais ou classe inexistante !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show(ex.Message+ex.Number);
                }
            }
        }

        private bool ChampsOk()
        {
            if (!String.IsNullOrEmpty(cbx_classe.Text.Trim()) && !String.IsNullOrEmpty(cbx_tranche.Text.Trim()) && nupdownMontant.Value != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}