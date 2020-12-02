using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TimeZoneDAO
    {
        private DBConnection dbConnect;
        private MySqlConnection con;
        public TimeZoneDAO()
        {
            dbConnect = DBConnection.getInstance();
        }


        /// <summary>
        /// Carga todos los horarios de la tabla horarios
        /// </summary>
        /// <returns>lista con todos los horarios</returns>
        public List<TimeZones> loadAllTimeZones()
        {
            List<TimeZones> listWithTimeZones = new List<TimeZones>();
            String query = "SELECT * FROM timezones";
            TimeZones zone;

            try
            {
                con = dbConnect.getConnection();
                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                zone = new TimeZones(int.Parse(reader.GetString(0)), Convert.ToDateTime(reader.GetString(1)).ToString("yyyy/MM/dd"), reader.GetString(2));
                                listWithTimeZones.Add(zone);

                            }
                        }
                        else
                        {
                            listWithTimeZones = null;
                        }
                        reader.Close();

                    }
                }
            }
            catch (MySqlException error1)
            {
                Console.WriteLine("Error MySql en el login d'UserDAO: " + error1.Message);
            }
            catch (Exception error2)
            {
                Console.WriteLine("Error general en el login - UserDAO: " + error2.Message);
            }


            return listWithTimeZones;

        }


        /// <summary>
        /// Busca un horario dependiendo del dia seleccionado
        /// </summary>
        /// <param name="timeZone">dia a buscar</param>
        /// <returns>el horario completo dado un dia</returns>
        public TimeZones searchTimeZone(String timeZone)
        {
            TimeZones timeZoneSelected = new TimeZones();
            String query = "SELECT * FROM timezones WHERE day=@day";
            TimeZones zone;

            try
            {
                con = dbConnect.getConnection();
                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        
                        cmd.Parameters.Add(new MySqlParameter("@day", timeZone));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                timeZoneSelected = new TimeZones(int.Parse(reader.GetString(0)), Convert.ToDateTime(reader.GetString(1)).ToString("yyyy/MM/dd"), reader.GetString(2));
                                
                            }
                        }
                        else
                        {
                            timeZoneSelected = null;
                        }
                        reader.Close();

                    }
                }
            }
            catch (MySqlException error1)
            {
                Console.WriteLine("Error MySql en el login d'UserDAO: " + error1.Message);
            }
            catch (Exception error2)
            {
                Console.WriteLine("Error general en el login - UserDAO: " + error2.Message);
            }


            return timeZoneSelected;

        }


    }
}
