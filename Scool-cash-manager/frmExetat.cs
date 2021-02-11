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
    public partial class frmExetat : Form
    {
        public frmExetat()
        {
            InitializeComponent();
        }

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region au chargement du formulaire
        private void FrmExetat_Load(object sender, EventArgs e)
        {
            Views.AfficherTout("v_paimentExetatJournalier", dgvliste);
            if (dgvliste.Rows.Count == 0)
            {
                dgvliste.Hide();
                lblMessage.Show();
            }
        }
        #endregion
        private void BtnNouveau_Click(object sender, EventArgs e)
        {
          new  frmNouveauPaiementExetat().ShowDialog();
        }
    }
}
