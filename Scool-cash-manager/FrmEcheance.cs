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
    public partial class FrmEcheance : Form
    {
        public FrmEcheance()
        {
            InitializeComponent();
            AfficherEcheance();
            CalculerTotal();
        }

        #region Affiher les écheances
        private void AfficherEcheance()
        {
            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                if (cbx_frais.Text == "Inscription")
                {
                    //la requete du frais d'inscription entre  date1 et date2

                    cmd.CommandText = "select p.id,p.date_paie as 'Date Heure',concat_ws(' ',p.eleve_id, e.nom,e.postnom,e.prenom) as Noms,f.designation,f.montant from paiement_mensuel as p " +
                        "INNER JOIN eleve as e ON e.id = p.eleve_id " +
                        "INNER JOIN frais_mensuel as f on f.id = p.frais_mensuel_id " +
                        "where date_paie between @date1 and @date2 and f.designation = 'Inscription' ";
                }
                else {
                    //la requete du frais mensuel entre date1 et date2

                    cmd.CommandText = "select p.id,p.date_paie as 'Date Heure',concat_ws(' ',p.eleve_id, e.nom,e.postnom,e.prenom) as Noms,f.designation,f.montant from paiement_mensuel as p " +
                        "INNER JOIN eleve as e ON e.id = p.eleve_id " +
                        "INNER JOIN frais_mensuel as f on f.id = p.frais_mensuel_id " +
                        "where date_paie between @date1 and @date2 and f.designation!='Inscription'";
                }
                MySqlParameter p_date1 = new MySqlParameter("@date1", MySqlDbType.Date);
                MySqlParameter p_date2 = new MySqlParameter("@date2", MySqlDbType.Date);
                p_date1.Value = dtp_date1.Value;
                p_date2.Value = dtp_date2.Value;
                cmd.Parameters.Add(p_date1);
                cmd.Parameters.Add(p_date2);
                using (MySqlDataAdapter adapter=new MySqlDataAdapter (cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvliste.DataSource = table;
                }
                if (dgvliste.Rows.Count == 0)
                {
                    dgvliste.Hide();
                    lblMessage.Text = "Aucune infromation Trouvée entre "+Environment.NewLine +dtp_date1.Value+" et "+dtp_date2.Value;
                    lblMessage.Show();
                }
                else {
                    dgvliste.Show();
                    lblMessage.Hide();
                }
            }
           

        }
    
        private void cbx_frais_SelectedIndexChanged(object sender, EventArgs e)
        {
            AfficherEcheance();
            CalculerTotal();
        }

        private void dtp_date1_ValueChanged(object sender, EventArgs e)
        {
            AfficherEcheance();
            CalculerTotal();
        }

        private void dtp_date2_ValueChanged(object sender, EventArgs e)
        {
            AfficherEcheance();
            CalculerTotal();
        }
        #endregion

        private void CalculerTotal()
        {
            List<decimal> Montants = new List<decimal>();

            int indiceDerniereColonne = dgvliste.Columns.Count-1;
            int indiceNombreLigne = dgvliste.Rows.Count;
            decimal valeur=0;
            for(int i = 0; i < indiceNombreLigne; i++)
            {
                if (decimal.TryParse(dgvliste.Rows[i].Cells[indiceDerniereColonne].Value.ToString(), out valeur))
                    Montants.Add(valeur);
            }

            decimal somme = 0;
            foreach(decimal montant in Montants)
            {
                somme += montant;
            }
            lbl_total.Text="Le montant Total : " +somme;
        }
    }
}
