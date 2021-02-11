using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class frmConfigFraisMensuel : Form
    {
        public frmConfigFraisMensuel()
        {
            InitializeComponent();
        }

        private void FrmConfigFraisMensuel_Load(object sender, EventArgs e)
        {
            
            this.Cursor = Cursors.WaitCursor;
            Views.AfficherTout("v_classe_frais_mensuel ", dgvliste);
            Operations.ChargerClassesDansComboBox(cbx_classe);
            this.Cursor = Cursors.Default;
        }


        #region enregistrement de des frais mensuels.....
        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if(ChampsOk())
            using(MySqlCommand cmd=new MySqlCommand())
            {
                try
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "INSERT INTO frais_mensuel(id,montant,classe_id,designation) values(@p_id,@p_montant,@p_classe_id,@p_designation)";


                    //ajout des parametres
                    cmd.Parameters.Add("@p_id", MySqlDbType.Int32);
                    cmd.Parameters.Add("@p_montant", MySqlDbType.Decimal);
                    cmd.Parameters.Add("@p_designation", MySqlDbType.VarChar,20);
                    cmd.Parameters.Add("@p_classe_id", MySqlDbType.Int32);


                    //ajout des valeurs aux parametres
                    cmd.Parameters["@p_id"].Value = null;
                    cmd.Parameters["@p_montant"].Value = nupdownMontant.Value;
                    cmd.Parameters["@p_designation"].Value = cbx_frais_mensuel.Text;
                    cmd.Parameters["@p_classe_id"].Value = Operations.ObtenirClasseID(cbx_classe.Text);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Enregistrement éffectué avec succès !!","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                catch(MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                      DialogResult result=  MessageBox.Show("Duplicatat : "+cbx_frais_mensuel.Text +" déjà enregistrée pour cette classe \nVoulez-vous modifier le montant à "+nupdownMontant.Value.ToString()+"CDF ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            if (result == DialogResult.Yes)
                            {
                                cmd.Parameters.Clear();
                                cmd.CommandText = "UPDATE frais_mensuel set montant=@montant where classe_id=@classe_id and designation=@designation";
                                MySqlParameter p_montant = new MySqlParameter("@montant", MySqlDbType.Decimal)
                                {
                                    Value = nupdownMontant.Value
                                };
                                MySqlParameter p_classe_id = new MySqlParameter("@classe_id", MySqlDbType.Int32)
                                {
                                    Value = Operations.ObtenirClasseID(cbx_classe.Text)
                                };
                                MySqlParameter p_designation = new MySqlParameter("@designation", MySqlDbType.VarChar, 20)
                                {
                                    Value=cbx_frais_mensuel.Text 
                                };
                                cmd.Parameters.Add(p_montant);
                                cmd.Parameters.Add(p_classe_id);
                                cmd.Parameters.Add(p_designation);
                                if (cmd.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show("Modification éffectuée avec succès !!\nLe frais "+cbx_frais_mensuel.Text+" pour la "+cbx_classe.Text +" vaut :"+nupdownMontant.Value .ToString()+" CDF", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                    }
                    else
                        if (ex.Number == 1452)
                    {
                        MessageBox.Show("Référence : Classe non enregitrée ! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    MessageBox.Show(ex.Message+" "+ex.Number);
                }
            }
        }

        private bool ChampsOk()
        {
            if(!String.IsNullOrEmpty(cbx_classe.Text.Trim()) && !String.IsNullOrEmpty(cbx_frais_mensuel.Text.Trim()) && nupdownMontant.Value != 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Veuillez remplir les champs vides", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion
    }
}