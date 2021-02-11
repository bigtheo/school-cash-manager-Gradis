using MySql.Data.MySqlClient;

using System.Windows.Forms;

namespace Scool_cash_manager
{
    public static class Connexion
    {
        //attributs de la classe de connexion

        public static MySqlConnection con;
        public static string uid;
        public static string pwd;

        #region la méthode de connexion
        // la méthode qui permet l'ouverture de la connection
        public static bool Connecter() 
        {
            _ = frmLogin.serveur;
            try
            {
                string serveur = "127.0.0.1";
                pwd = "1993";
                uid = "root";
                string constring = "persistsecurityinfo=True; server=" + serveur + "; database=school_cash_managerdb;uid=" + uid + ";password=" + pwd + "";
                con = new MySqlConnection(constring);
                con.Open();

                //on excute la requette de verification
                string password = frmLogin.password;
                string login = frmLogin.login;
                password = "1993";
                login = "kapapa";
                string sql = "select count(id) from users where password='" + password + "' and nom='" + login + "'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                int nbre = 0;
                while (dr.Read())
                {
                    nbre = int.Parse((dr.GetString(0)));
                }
                dr.Dispose();
                if (nbre == 1)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (MySqlException ex)
            {
                int number = ex.Number;
                if (number == 1042)
                    System.Windows.Forms.MessageBox.Show("Erreur de connexion au serveur des données !\nVeuillez demarrer le serveur avant de lancer la connexion\nLe code d'erreur : " + number, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (number == 0)
                    System.Windows.Forms.MessageBox.Show("Erreur de connexion au serveur des données !\nLe login ou le nom utilisateur est incorect\nLe code d'erreur : " + number, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    System.Windows.Forms.MessageBox.Show(ex.Message + "\nLe code d'erreur : " + number, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion la méthode de connexion

    }
}