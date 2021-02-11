using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class FrmEnfantAcharge : Form
    {
        public FrmEnfantAcharge()
        {
            InitializeComponent();
            Actualiser();
        }

        private void BtnNouveau_Click(object sender, EventArgs e)
        {
            new FrmNouveauEnseignant().ShowDialog();
        }

        private void BtnNouvelleAssociation_Click(object sender, EventArgs e)
        {
            new FrmLienDeParente().ShowDialog();
        }

        #region Selection des nombres tatol d'enseignant et enfants

        private void AfficherAffiliation()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select a.id,en.id as Matricule ,en.noms as 'Nom du Personnel',concat_ws(' ',e.nom,e.postnom) as Enfants,c.nom as Classe" +
                    " from associer as a " +
                    "inner join enseignant as en on en.id = a.enseignant_id " +
                    "inner join eleve as e on e.id = a.eleve_id " +
                    "Inner join classe as c on c.id=e.classe_id";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvListe.DataSource = table;

                    if (dgvListe.Rows.Count == 0)
                    {
                        dgvListe.Hide();
                        lblMessage.Show();
                    }
                    else
                    {
                        dgvListe.Show();
                        lblMessage.Hide();
                    }
                }
            }
        }

        private void AfficherNombreEnseignantAyantDesEnfant()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select count(*) from enseignant";
                try
                {
                    lbl_nombre_enseigant.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AfficherNombreEnfantAffilie()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select count(*) from associer";
                try
                {
                    lbl_nombre_enfant.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Actualiser()
        {
            AfficherAffiliation();
            AfficherNombreEnfantAffilie();
            AfficherNombreEnseignantAyantDesEnfant();
        }
        #endregion Selection des nombres tatol d'enseignant et enfants
    }
}