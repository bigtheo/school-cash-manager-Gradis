using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class frmConfigExamen : Form
    {
        public frmConfigExamen()
        {
            InitializeComponent();
        }

        #region au chargement du formulaire...

        private void FrmConfigExamen_Load(object sender, EventArgs e)
        {
            Views.AfficherTout("v_classe_frais_examen  ", dgvliste);
            Operations.ChargerClassesDansComboBox(cbx_classe);
        }

        #endregion au chargement du formulaire...

        #region enregistrement des infos dans la table classe_frais_mensuel...

        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if (ChampsOk())
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        Connexion.Connecter();
                        cmd.Connection = Connexion.con;
                        cmd.CommandText = "InsererClasseFraisExamen";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add("@p_id", MySqlDbType.Int32);
                        cmd.Parameters["@p_id"].Direction = System.Data.ParameterDirection.Input;
                        cmd.Parameters.Add("@p_frais_examen_id", MySqlDbType.Int32);
                        cmd.Parameters["@p_frais_examen_id"].Direction = System.Data.ParameterDirection.Input;
                        cmd.Parameters.Add("@p_classe_id", MySqlDbType.Int32);
                        cmd.Parameters["@p_classe_id"].Direction = System.Data.ParameterDirection.Input;
                        cmd.Parameters.Add("@p_montant", MySqlDbType.Double);
                        cmd.Parameters["@p_montant"].Direction = System.Data.ParameterDirection.Input;

                        //ajout des valeurs aux parametres...

                        cmd.Parameters["@p_id"].Value = null;
                        cmd.Parameters["@p_frais_examen_id"].Value = cbx_tranche.SelectedIndex + 1; //il n'y a que deux frais d'examen dont l'un a comme l'id 1 et l'autre 2
                        cmd.Parameters["@p_classe_id"].Value = Operations.ObtenirClasseID(cbx_classe.Text); //appel de la methode qui permet de trouver l'id de la classe
                        cmd.Parameters["@p_montant"].Value = nupdownMontant.Value;
                        DialogResult result = MessageBox.Show("Voulez-vous vraiment enregistrer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Enregistrement éffectué avec succès !", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        if (ex.Number == 1062)
                        {
                            MessageBox.Show("Duplicatat : Enregistrement déjà éffectué  pour la classe " + cbx_classe.Text + " et le " + cbx_tranche.Text+" Semestre", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (ex.Number == 1054)
                        {
                            MessageBox.Show("Référence : vérifier la classe ou le frais ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show(ex.Message);
                    }
                }
        }

        /// <summary>
        /// Cette méthôde retourne true si les champs sont remplis
        /// </summary>
        /// <returns>bool</returns>
        private bool ChampsOk()
        {
            if (!String.IsNullOrEmpty(cbx_classe.Text.Trim()) && !string.IsNullOrEmpty(cbx_tranche.Text.Trim())&&nupdownMontant.Value !=0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Veuillez remplir les champs vides", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion enregistrement des infos dans la table classe_frais_mensuel...
    }
}