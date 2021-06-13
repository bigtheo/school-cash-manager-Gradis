using System;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class FrmFraisEtat : Form
    {
        public FrmFraisEtat()
        {
            InitializeComponent();
        }

        private void FrmFraisEtat_Load(object sender, EventArgs e)
        {
            Views.AfficherTout("v_paimentFraisEtatJounalier", dgvliste);
            if (dgvliste.Rows.Count == 0)
            {
                dgvliste.Hide();
                lblMessage.Show();
            }
        }

        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            new FrmNouveauPaiementFraisEtat().ShowDialog();
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {

        }
    }
}