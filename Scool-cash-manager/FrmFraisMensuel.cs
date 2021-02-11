using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class FrmFraisMensuel : Form
    {
        public FrmFraisMensuel()
        {
            InitializeComponent();
        }

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmFraisMensuel_Load(object sender, EventArgs e)
        {

            AfficherJournaleMensuelInscription();
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
        }

        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            new frmNouveauPaiementMensuel().ShowDialog();
        }

        private void AfficherJournaleMensuelInscription()
        {
            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "JournalMensuelEtInscription";
                cmd.CommandType = CommandType.StoredProcedure;
                //les parametres
                MySqlParameter p_date = new MySqlParameter("@p_date", MySqlDbType.Date);
                
                p_date.Value = DateTime.Now.Date;
                cmd.Parameters.Add(p_date);
                using (MySqlDataAdapter adapter=new MySqlDataAdapter (cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvliste.DataSource = table;

                }
                
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            bool isDetails = dgvliste.Columns.Count>2;
            if (!isDetails) 
            {
                Views.AfficherTout("v_afficherPaiementMensuelJournalier", dgvliste);
                isDetails = true;
                if (dgvliste.Rows.Count == 0)
                {
                    dgvliste.Hide();
                    lblMessage.Show();
                }
                btnDetails.Text = "Synthèse";
            }
            else{
             
                isDetails = false;
                AfficherJournaleMensuelInscription();
                btnDetails.Text = "Détails";
            }
            
        }

        private void BtnEcheance_Click(object sender, EventArgs e)
        {

        }
    }
}