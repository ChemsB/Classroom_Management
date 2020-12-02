using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class DBConnection
    {
        private static string connectionString = "Server=localhost;Database=dbproven;Uid=root;Pwd=;";//cal ficar com a Uid i Pwd un usuari donat d'alta a la base de dades amb permissos restringits
        private static DBConnection instance;
        private static MySqlConnection con=null;


        private DBConnection()
        {

        }
        public static DBConnection getInstance()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }
            return instance;
        }


        public MySqlConnection getConnection()
        {
            try
            {
                using (con = new MySqlConnection(connectionString)) ;
                
                
            }catch(MySqlException e)
            {

                Console.WriteLine("Error en la getConnection"+e.Message);
            }
            
            return con;

        }
    }
}
