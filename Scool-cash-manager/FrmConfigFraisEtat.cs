using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class FrmConfigFraisEtat : Form
    {
        public FrmConfigFraisEtat()
        {
            InitializeComponent();
        }

        private void FrmConfigFraisEtat_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Views.AfficherTout("v_classe_frais_etat", dgvliste);
            Operations.ChargerClassesDansComboBox(cbx_classe);
            this.Cursor = Cursors.Default;
        }

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if(ChampsOk())
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "insert into classe_frais_etat(id,frais_etat_id,classe_id,montant) values(@id,@frais_etat_id,@classe_id,@montant)";
                    //ajout des parametres...
                    cmd.Parameters.Add("@id", MySqlDbType.Int32);
                    cmd.Parameters.Add("@frais_etat_id", MySqlDbType.Int32);
                    cmd.Parameters.Add("@classe_id", MySqlDbType.Int32);
                    cmd.Parameters.Add("@montant", MySqlDbType.Double);

                    //ajout des valeurs aux parametres...
                    cmd.Parameters["@id"].Value = null;
                    cmd.Parameters["@frais_etat_id"].Value = cbx_tranche.SelectedIndex + 1;
                    cmd.Parameters["@classe_id"].Value = Operations.ObtenirClasseID(cbx_classe.Text);
                    cmd.Parameters["@montant"].Value = nupdownMontant.Value;

                    DialogResult result = MessageBox.Show("Voulez-vous vraiment enregistrer ? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                        MessageBox.Show("Diplicatat : "+cbx_tranche.Text +" est déjà enregistré pour  la "+cbx_classe.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ex.Number == 1452)
                    {
                        MessageBox.Show("Réference : classe ou frais inexistant(e) ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Veuillez remplir les champs vides", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}