using System;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class frmFraisExamen : Form
    {
        public frmFraisExamen()
        {
            InitializeComponent();
        }

        private void FrmFraisExamen_Load(object sender, EventArgs e)
        {
            Views.AfficherTout("V_PaiementExemanJournalier", dgvliste);
            if (dgvliste.Rows.Count == 0)
            {
                dgvliste.Hide();
                lblMessage.Show();
            }
        }

        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            new frmNouveauPaiementExamen().ShowDialog();
        }
    }
}