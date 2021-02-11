using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Scool_cash_manager
{
    public partial class FrmTableauDeBord : Form
    {
        public FrmTableauDeBord()
        {
            InitializeComponent();
            cbx_mois.SelectedIndex = 0;
            cbx_section.SelectedIndex = 0;

            timer1.Start();
            AfficherNombreEleveInscrit();
            AfficherNombreEleveInscritMaternelle();
            AfficherNombreEleveInscritPrimaire();
            AfficherNombreEleveInscritSecondaire();
            Operations.ChargerClassesDansComboBox(cbx_classe);

            AfficherNombreEleveEnOrdre(cbx_mois.Text);
            //   AffcherNombreNombreEleveNonOrdre(cbx_mois.Text);
            ChargerChart();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblDateHeure.Text = DateTime.Now.ToString();
        }

        #region methodes qui permettent derechercher les informations à afficher

        private void AfficherNombreEleveInscrit()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "Select count(*) from eleve";
                try
                {
                    lblTotalInscrit.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AfficherNombreEleveInscritMaternelle()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select count(*) from eleve as e inner join Classe as c on c.id=e.classe_id inner join section as s on s.id=c.section_id where s.id = 1";
                try
                {
                    lblTotalMaternelle.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AfficherNombreEleveInscritPrimaire()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select count(*) from eleve as e inner join Classe as c on c.id=e.classe_id inner join section as s on s.id=c.section_id where s.id = 2";
                try
                {
                    lblTotalPrimaire.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AfficherNombreEleveInscritSecondaire()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select count(*) from eleve as e inner join Classe as c on c.id=e.classe_id inner join section as s on s.id=c.section_id where s.id = 3";
                try
                {
                    lblTotalSecondaire.Text = Convert.ToString(cmd.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AfficherNombreEleveEnOrdre(string mois)
        {
            string requete;
            //si le mois vaut null ou vide ....
            if (mois.Trim()=="Tous")
            {
                requete = "select count(*) from paiement_mensuel as p INNER JOIN frais_mensuel as f ON f.id = p.frais_mensuel_id where f.designation != 'Inscription'";
            }//dans le ou le mois n'est pas null ou vide....
            else
            {
                requete = "select count(*) from paiement_mensuel as p INNER JOIN frais_mensuel as f ON f.id = p.frais_mensuel_id where f.designation ='"+cbx_mois.Text+"'";
            }

            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = requete;

                lblEnOrdre.Text = Convert.ToString(cmd.ExecuteScalar());
                
            }
        }

        private void AffcherNombreNombreEleveNonOrdre(string mois)
        {
            string requete;
            //si le mois vaut null ou vide ....
            if (mois.Trim() == "Tous")
            {
                requete = "select count(*) from eleve as e where id not in(" +
                    "select p.id from paiement_mensuel as p " +
                    "INNER JOIN frais_mensuel as f ON f.id = p.frais_mensuel_id " +
                    "where f.designation != 'Inscription' )";
            }//dans le ou le mois n'est pas null ou vide....
            else
            {
                requete = "SELECT  count(*) as nombre from eleve as e " +
                    "INNER JOIN classe as c ON e.classe_id = c.id  " +
                    "INNER JOIN paiement_mensuel as pm ON pm.eleve_id = e.id" +
                    " INNER JOIN frais_mensuel as fm ON pm.frais_mensuel_id = fm.id" +
                    " WHERE e.id not in" +
                    "(" +
                    " select e.id from eleve AS e " +
                    "INNER JOIN paiement_mensuel as pm ON pm.eleve_id = e.id " +
                    "INNER JOIN frais_mensuel as fm ON pm.frais_mensuel_id = fm.id " +
                    " INNER JOIN classe as c on e.classe_id = c.id " +
                    "  WHERE fm.designation = '"+mois+"' " +
                    ") and fm.designation != 'Inscription'";
            }

            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = requete;

                lblNonEnOrdre.Text = Convert.ToString(cmd.ExecuteScalar());

            }
        }

        #endregion methodes qui permettent derechercher les informations à afficher

        private void Cbx_mois_SelectedIndexChanged(object sender, EventArgs e)
        {
            AfficherNombreEleveEnOrdre(cbx_mois.Text);
           // AffcherNombreNombreEleveNonOrdre(cbx_mois.Text);
        }


        private void ChargerChart()
        {
            Series series = new Series();
            series.Points.AddXY("maternelle",Convert.ToDouble(lblTotalMaternelle.Text));
            series.Points.AddXY("Primaire",Convert.ToDouble(lblTotalPrimaire.Text));
            series.Points.AddXY("Secondaire",Convert.ToDouble(lblTotalSecondaire.Text));
            chart1.Series.Clear();
            chart1.Series.Add(series);
            series.Name = "Section";

        }
    }
}