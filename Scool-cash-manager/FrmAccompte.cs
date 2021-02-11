using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class FrmAccompte : Form
    {
        public FrmAccompte()
        {
            InitializeComponent();
            ListerAccompteVerifie();
        }

        #region barre de titre
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr intPtr, int v1, int v2, int v3);

        private void PanelBarreDeTitre_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xf112, 0xf012, 0);
        }
        #endregion

        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            new FrmNouvelAccompte().ShowDialog();
        }

        private void listerAccompteParDate()
        {
            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = $"select a.Id as 'N°',a.date_paie as 'Date et Heure',e.id,concat_ws(' ',e.nom,e.postnom) as Noms,f.designation,a.montant " 
                    +"from accompte as a inner join frais_mensuel as f on a.frais_mensuel_id = f.id " 
                    +"Inner join eleve as e on a.eleve_id = e.id where date(a.date_paie)=@date_paie";
                MySqlParameter p_date_paie = new MySqlParameter("@date_paie", MySqlDbType.Date);
                p_date_paie.Value = dtp_date.Value;
                cmd.Parameters.Add(p_date_paie);
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvliste.DataSource = table;
                }
            }
        }

        private void dtp_date_ValueChanged(object sender, EventArgs e)
        {
            ListerAccompteVerifie();
        }
        private void ListerAccompteVerifie()
        {
            listerAccompteParDate();
            if (dgvliste.Rows.Count > 0)
            {
                dgvliste.Visible = true;
                lblMessage.Hide();
            }
            else
            {
                dgvliste.Visible = false;
                lblMessage.Show();
            }
        }
    }
}
