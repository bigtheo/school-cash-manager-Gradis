using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Scool_cash_manager
{
    public partial class FrmConfigManuels : Form
    {
        public FrmConfigManuels()
        {
            InitializeComponent();
        }

        #region enregistrement
        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if(ChampsOk())
            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                try
                {
                    cmd.CommandText = "Insert into manuels(id,intitule,auteur,prix_unitaire) values(@id,@intitule,@auteur,@prix_unitaire)";
                    cmd.Parameters.Add("@id", MySqlDbType.Int32);
                    cmd.Parameters.Add("@auteur", MySqlDbType.VarChar,45);
                    cmd.Parameters.Add("@intitule", MySqlDbType.Text);
                    cmd.Parameters.Add("@prix_unitaire", MySqlDbType.Double);

                    cmd.Parameters["@id"].Value = null;
                    cmd.Parameters["@auteur"].Value = txt_auteur.Text ;
                    cmd.Parameters["@intitule"].Value = txt_intitule_manuel.Text ;
                    cmd.Parameters["@prix_unitaire"].Value = nupdownMontant.Value;

                    DialogResult result = MessageBox.Show("Voulez-vous vraiment enregistrer ?","confirmer",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if(result==DialogResult.Yes)
                    {
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Enregistrement éffectué avec succès !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool ChampsOk()
        {
            if (!String.IsNullOrEmpty(txt_auteur.Text.Trim()) && !String.IsNullOrEmpty(txt_intitule_manuel.Text.Trim()) && nupdownMontant.Value != 0)
            {
                return true;
            }else
            {
                MessageBox.Show("Veuillez remplir les champs vides", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        #region au chargement du formulaire ...

        private void FrmConfigManuels_Load(object sender, EventArgs e)
        {
            Views.AfficherTout("v_manuels", dgvliste);
        }

        private void TabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            Views.AfficherTout("v_manuels", dgvliste);
        }
        #endregion
    }
}