using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    public partial class FrmNouveauPaiementManuels : Form
    {
        public FrmNouveauPaiementManuels()
        {
            InitializeComponent();
        }

        #region barre de titre

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr intPtr, int lparam, int hwparam, int rparam);

        private void PanelBarreDeTitre_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion barre de titre

        #region au chargement du formulaire...

        private void FrmNouveauPaiementManuels_Load(object sender, EventArgs e)
        {
        }

        #endregion au chargement du formulaire...

        #region Recherche des infos

        //au changement de l'ide du manuel..
        private void Nupd_id_manuel_ValueChanged(object sender, EventArgs e)
        {
            GetInfoManuels();
        }

        private void GetInfoManuels()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
           
                Connexion.Connecter();
                cmd.Connection = Connexion.con;

                cmd.CommandText = "SELECT intitule,prix_unitaire from manuels WHERE id=@id";
                cmd.Parameters.Add("@id", MySqlDbType.Int32);
                cmd.Parameters["@id"].Value = nupd_id_manuel.Value;

                if (!nupd_id_manuel.Value.Equals(0))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        txt_Intitule.Text = reader.GetValue(0).ToString();
                        txt_montant.Text = reader.GetValue(1).ToString();
                        
                    }
                }
                else
                {
                    txt_Intitule.Text = "0";
                    txt_montant.Text = "0";
                }

            }
        }

        
  

        private void TrouverNomClasseEleveParID()
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "Afficher_noms_eleve_par_id";
                    cmd.CommandType = CommandType.StoredProcedure;

                    //creation des parametres...
                    MySqlParameter p_id = new MySqlParameter("@p_id", MySqlDbType.Int32);
                    MySqlParameter p_noms_eleve = new MySqlParameter("@p_noms_eleve", MySqlDbType.VarChar, 150);
                    MySqlParameter p_classe = new MySqlParameter("@p_classe", MySqlDbType.VarChar, 15);

                    //le sens des parametres...
                    p_id.Direction = ParameterDirection.Input;
                    p_noms_eleve.Direction = ParameterDirection.Output;
                    p_classe.Direction = ParameterDirection.Output;

                    //assignation des parametres
                    cmd.Parameters.Add(p_id);
                    cmd.Parameters.Add(p_noms_eleve);
                    cmd.Parameters.Add(p_classe);

                    //ajout de l'id de l'élève au parametre
                    p_id.Value = nupdown_id.Value;

                    //exécution de la commande
                    cmd.ExecuteNonQuery();

                    //récuperation des valeurs aux paremtres OutPut
                    txt_noms.Text = p_noms_eleve.Value.ToString();
                    txt_classe.Text = p_classe.Value.ToString();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //au changement de l'id de l'élève
        private void Nupdown_id_ValueChanged(object sender, EventArgs e) => TrouverNomClasseEleveParID();

        #endregion Recherche des infos

        #region Enregistrement de l'achat du(es) manuel(s)
        private void BtnEnregistrer_Click(object sender, EventArgs e)
        {
            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "INSERT INTO PAIEMENT_MANUELS(id,date_paie,quantite,eleve_id,manuel_id) VALUES(@id,@date_paie,@quantite,@eleve_id,@manuel_id)";
                
                //les parametres Mysql
                MySqlParameter p_id = new MySqlParameter("@id", MySqlDbType.Int32);
                MySqlParameter p_date_date = new MySqlParameter("@date_paie", MySqlDbType.DateTime);
                MySqlParameter p_quantite = new MySqlParameter("@quantite", MySqlDbType.Int32);
                MySqlParameter p_eleve_id = new MySqlParameter("@eleve_id", MySqlDbType.Int32);
                MySqlParameter p_manuel_id = new MySqlParameter("@manuel_id", MySqlDbType.Int32);

                //les valeurs des nos parametres
                p_id.Value = null;
                p_date_date.Value = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                p_quantite.Value = nup_Quantite.Value;
                p_eleve_id.Value = nupdown_id.Value;
                p_manuel_id.Value = nupd_id_manuel.Value;

                //assignation des parametres à MySqlCommand
                cmd.Parameters.Add(p_id);
                cmd.Parameters.Add(p_date_date);
                cmd.Parameters.Add(p_quantite);
                cmd.Parameters.Add(p_eleve_id);
                cmd.Parameters.Add(p_manuel_id);

                //exécution de la requete..
                try
                {
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Enregistrement éffectué avec succès !");
                    }
                }
                catch (MySqlException ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }
        #endregion

        #region calcul du prix total
        private void Nup_Quantite_ValueChanged(object sender, EventArgs e)
        {
            CalculerPrixTotal(nup_Quantite.Value, txt_montant.Text);
        }

        private void CalculerPrixTotal(decimal value, string text)
        {
            if (!txt_montant.Text.Equals(String.Empty))
            {
                decimal _prix_unitaire = Decimal.Parse(text);
                decimal _prix_total = _prix_unitaire * value;
                txt_prix_total.Text = _prix_total.ToString();
            }
          
        }

        private void Txt_montant_TextChanged(object sender, EventArgs e)
        {
            CalculerPrixTotal(nup_Quantite.Value, txt_montant.Text);
        }
        #endregion
    }
}