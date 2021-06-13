using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Scool_cash_manager
{
    internal class Operations
    {
        public  static string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ficher_rapport.pdf");

        #region les méthôdes sur la table frais (frais mensuel, de l'état...)



        #endregion les méthôdes sur la table frais (frais mensuel, de l'état...)

        #region les méthôdes sur la table classe

        /// <summary>
        /// Cette méthode permet de charger les classes dans la liste combinée
        /// </summary>
        /// <param name="cbx">Liste Combinée</param>
        public static void ChargerClassesDansComboBox(ComboBox cbx)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandText = "select nom as classe from v_listeClasse";
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    cbx.Items.Clear();
                    while (reader.Read())
                    {
                        cbx.Items.Add(reader.GetValue(0).ToString());
                    }
                    reader.Dispose();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// cette méthôde permet de charger les classes dans la liste combinée par par section id
        /// </summary>
        /// <param name="cbx"></param>
        public static void ChargerClassesParSectionIDDansComboBox(ComboBox cbx, string section_id)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    cmd.CommandText = "select nom as Classe from classe where section_id=@section_id";
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.Parameters.Add("@section_id", MySqlDbType.Int32);
                    cmd.Parameters["@section_id"].Value = section_id;

                    MySqlDataReader reader = cmd.ExecuteReader();
                    cbx.Items.Clear();
                    while (reader.Read())
                    {
                        cbx.Items.Add(reader.GetValue(0).ToString());
                    }
                    reader.Dispose();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        /// <summary>
        /// Cette méthôde permet de trouver l'id de la classe par le nom de la celle-ci
        /// </summary>
        /// <param name="classe">Le nom de la classe</param>
        /// <returns>l'id de la classe</returns>
        public static string TrouverClasse_idParNomClasse(string classe)
        {
            using(MySqlCommand cmd=new MySqlCommand())
            {
                try
                {
                    Connexion.Connecter();
                    cmd.Connection=Connexion.con;
                    cmd.CommandText = "SELECT id FROM classe where nom=@nom";
                    MySqlParameter p_nom_classe = new MySqlParameter("@nom", MySqlDbType.VarChar, 15);
                    cmd.Parameters.Add(p_nom_classe);
                    p_nom_classe.Value = classe;

                    string nom_classe = cmd.ExecuteScalar().ToString();

                    if (nom_classe != null)
                    {
                        return nom_classe;
                    }
                    else
                    {
                        return "";
                    }

                }
                catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return "";
                }
                

            }
        }
        /// <summary>
        /// Cette méthode permet de trouver l'id de la classe par son nom
        /// </summary>
        /// <param name="nom_classe"></param>
        /// <returns>Le nom de la classe</returns>
        public static string ObtenirClasseID(string nom_classe)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "Select id from classe where nom = @nom";

                cmd.Parameters.Add("@nom", MySqlDbType.VarChar, 15);
                cmd.Parameters["@nom"].Value = nom_classe;
                try
                {
                    if (nom_classe != String.Empty)
                        return cmd.ExecuteScalar().ToString();
                    else
                        return "";

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return "";
                }
            }

        }
        #endregion les méthôdes sur la table classe

        #region méthôde sur la table élève...
        /// <summary>
        /// cette méthôde permet de retourné l'id du dernier élève inscrit
        /// </summary>
        /// <returns></returns>
        public static string ObtenirIDdernierEleve()
        {
            using(MySqlCommand cmd=new MySqlCommand())
            {
                try
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "select max(id) from eleve";

                    string eleve_id = cmd.ExecuteScalar().ToString();
                    if (eleve_id != null)
                    {
                        return eleve_id;
                    }
                    else
                    {
                        return "";
                    }

                }
                catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return "";
                }
            }
        }
        #endregion

        #region méthôdes sur la table pere et mere
        /// <summary>
        /// cette méthode permet de trouver l'id du dernier père
        /// </summary>
        /// <returns></returns>
        public static string ObtenirDernierIdPere()
        {
            try
            {
                using (MySqlCommand cmd=new MySqlCommand ())
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "SELECT MAX(id) from pere";
                    string pere_id = cmd.ExecuteScalar().ToString();

                    if (pere_id != null)
                    {
                        return pere_id;
                    }
                    else
                    {
                        return "";
                    }

                }
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }
        /// <summary>
        /// cette méthode trouve l'id de la dernière dans la table;
        /// </summary>
        /// <returns>L'id de la mère </returns>
        public static string ObtenirDernierIdMere()
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "SELECT MAX(id) from mere";
                    string pere_id = cmd.ExecuteScalar().ToString();

                    if (pere_id != null)
                    {
                        return pere_id;
                    }
                    else
                    {
                        return "";
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }
        /// <summary>
        /// Cette méthode permet de touver l'id du père par l'id de l'élève
        /// </summary>
        /// <param name="eleve_id"></param>
        /// <returns></returns>
        public static string ObtenirIdPereParIDelve(string eleve_id)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "SELECT pere_id from eleve WHERE id=@eleve_id";
                    cmd.Parameters.Add("@eleve_id", MySqlDbType.VarChar, 15);
                    cmd.Parameters["@eleve_id"].Value = eleve_id;

                    string pere_id = cmd.ExecuteScalar().ToString();

                    if (pere_id != null)
                    {
                        return pere_id;
                    }
                    else
                    {
                        return "";
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }
        /// <summary>
        /// Cette méthode permet de touver l'id de la mère par l'id de l'élève
        /// </summary>
        /// <param name="eleve_id"></param>
        /// <returns></returns>
        public static string ObtenirIdMereParIDelve(string eleve_id)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    Connexion.Connecter();
                    cmd.Connection = Connexion.con;
                    cmd.CommandText = "SELECT mere_id from eleve WHERE id=@eleve_id";
                    cmd.Parameters.Add("@eleve_id", MySqlDbType.VarChar, 15);
                    cmd.Parameters["@eleve_id"].Value = eleve_id;

                    string pere_id = cmd.ExecuteScalar().ToString();

                    if (pere_id != null)
                    {
                        return pere_id;
                    }
                    else
                    {
                        return "";
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }
        #endregion

        #region les méthodes sur la tabke frais examen

        #endregion

        #region la sauvergarde de la base des données
         public static void Backup()
        {
            string constring = "server=localhost;user=root;pwd=1993;database=school_cash_managerdb;";
            string nom_du_fichier = DateTime.Now.Date.ToString("\\backup dd MMM yyyy HH mm") +".sql";
            string file= Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+ "\\cashmgr" + nom_du_fichier;
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
   
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                         mb.ExportToFile(file); 
          
                        conn.Close();
                        MessageBox.Show("Sauvegarde éffectuée avec succès !!!","Infrmation",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            }
        }
        #endregion

        #region Méthôdes sur la table de configuration
        public static string ObtenirNomEtablissement()
        {
            
            using (MySqlCommand cmd=new MySqlCommand  ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "select nom_entite from configuration where id=1 ";
                try
                {
                    
                    return cmd.ExecuteScalar().ToString();
                    
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return "";
                }
              
            }
        }
        #endregion
        #region methodes sur l'inscription
        public static Int32 ObtenirFraisInscrptionID(string classe)
        {
            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "SELECT coalesce(id) from frais_mensuel where classe_id in(select id from classe where nom='" + classe+"') and designation='inscription'";
                try
                {
                    if (cmd.ExecuteScalar() != null)
                    {
                        return Int32.Parse( cmd.ExecuteScalar().ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (MySqlException ex)
                {

                    MessageBox.Show(ex.Message);
                    return 0;
                }
                
            }
        }

        internal static string ObtenirMontantInscription(string classe)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "SELECT coalesce(montant) from frais_mensuel where classe_id in(select id from classe where nom='" + classe + "') and designation='inscription'";
                try
                {
                    if (cmd.ExecuteScalar()!=null)
                    {
                        return cmd.ExecuteScalar().ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
                catch (MySqlException ex)
                {

                    MessageBox.Show(ex.Message);
                    return "0";
                }

            }
        }
        #endregion

        #region methodes sur l'accompte
        internal static string ObtenirNumeroRecuAccompte()
        {
            using (MySqlCommand cmd=new MySqlCommand ())
            {
                Connexion.Connecter();
                cmd.Connection = Connexion.con;
                cmd.CommandText = "SELECT MAX(id) from Accompte";
                try
                {
                    return cmd.ExecuteScalar().ToString();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return "0";
                }
            }
        }
        #endregion

        #region méthode stattic sur l'impression
        public static void PrintPDFByProcess()
        {
            try
            {
                using (Process p = new Process())
                {
                    p.StartInfo = new ProcessStartInfo()
                    {
                        CreateNoWindow = true,
                        Verb = "print",
                        FileName = fileName
                    };

                    p.Start();

                    p.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        public static void PrintToASpecificPirnter()
        {     
                using (PrintDialog printDialog=new PrintDialog ())
                {
                printDialog.AllowSomePages = true;
                printDialog.AllowSelection = true;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    var StartInfo = new ProcessStartInfo();
                    StartInfo.CreateNoWindow = true;
                    StartInfo.UseShellExecute = true;
                    StartInfo.Verb = "printTo";
                    StartInfo.Arguments = "\"" + printDialog.PrinterSettings.PrinterName + "\"";
                    StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    StartInfo.FileName = fileName;

                    Process.Start(StartInfo);
                }
                    
                }
                

        }
        #endregion


    }
}