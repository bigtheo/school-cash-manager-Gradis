using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class frmConfigClasses : Form
    {
        public frmConfigClasses()
        {
            InitializeComponent();
        }

        #region enregistrement
        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            if(ChampsOk())
            using(MySqlCommand cmd=new MySqlCommand())
            {
                try
                {
                    cmd.CommandText = "insert into classe(id,nom,section_id) values(@id,@nom,@section_id)";
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;                  
                    cmd.Parameters.Add("@id", MySqlDbType.Int32);
                    cmd.Parameters.Add("@nom", MySqlDbType.VarChar,10);
                    cmd.Parameters.Add("@section_id", MySqlDbType.Int32);

                    cmd.Parameters["@id"].Value = null;
                    cmd.Parameters["@nom"].Value = cbx_classe.Text;
                    cmd.Parameters["@section_id"].Value = cbx_section.SelectedIndex +1;

                    DialogResult result = MessageBox.Show("Voulez-vraiment enregistrer ?", "Confirmation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Enregistrement éffectué avec succès", "Infotmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }catch(MySqlException ex)
                {
                    //en cas de duplicatat
                    if (ex.Number == 1062)
                    {
                        MessageBox.Show("Duplicatat : Cette classe déjà enregistrée !!! ", "Message d'erreur", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
                    }
                    else
                    MessageBox.Show(ex.Message);
                }
            }

        }
        /// <summary>
        /// vérifie si tous les champs sont pas vides
        /// </summary>
        /// <returns>bool</returns>
        private bool ChampsOk()
        {
            if(!String.IsNullOrEmpty(cbx_classe.Text.Trim() )&&!String.IsNullOrEmpty(cbx_section.Text.Trim()) &&!String.IsNullOrWhiteSpace(cbx_section.Text.Trim()) &&!String.IsNullOrWhiteSpace(cbx_classe.Text.Trim()))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Veuillez remplir les champs vides avant d'enregistrer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion 

        #region au chargement du formulaire...
        private void FrmConfigClasses_Load(object sender, EventArgs e)
        {
            Views.AfficherTout("v_classe", dgvliste);
        }

        private void TabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            Views.AfficherTout("v_classe", dgvliste);
        }
        #endregion
    }
}
