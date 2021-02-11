using MySql.Data.MySqlClient;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    /*cette classe contient toutes les méthodes qui vont servir à
     afficher les donner des views mysql */

    internal class Views
    {
        //... les methôdes sur les Views MySql
        #region les views sur Users

        /// <summary>
        /// Cette méthôde permet d'afficher les données d'une views Mysql dans le DataGridView
        /// </summary>
        /// <param name="views">le nom de le vue Mysql</param>
        /// <param name="dataGrid">le nom du datagriview </param>
        public static void AfficherTout(string views, DataGridView dataGrid)
        {
           
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "select* from " + views;
                    cmd.CommandType = CommandType.Text;
                    DataTable table = new DataTable();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(table);
                    dataGrid.DataSource = table;
                    dataAdapter.Dispose();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion les views sur Users
    }
}