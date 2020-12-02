using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ClassRoomDAO
    {


        private DBConnection dbConnect;
        private MySqlConnection con;

        public ClassRoomDAO()
        {
            dbConnect = DBConnection.getInstance();
        }

        /// <summary>
        /// Craga todas las clases de la tabla
        /// </summary>
        /// <returns>lista con todas las clases, nulo en caso de error</returns>
        public List<ClassRoom> loadAllClassRooms()
        {
            List<ClassRoom> listWithClassRoom = new List<ClassRoom>();
            String query = "SELECT * FROM classroom";
            ClassRoom cs;

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
                                cs = new ClassRoom(int.Parse(reader.GetString(0)), reader.GetString(1), reader.GetString(2),reader.GetInt32(3));
                                listWithClassRoom.Add(cs);

                            }
                        }
                        else
                        {
                            listWithClassRoom = null;
                        }
                        reader.Close();

                    }
                }
            }
            catch (MySqlException error1)
            {
                listWithClassRoom = null;
            }
            catch (Exception error2)
            {
                listWithClassRoom = null;
            }


            return listWithClassRoom;

        }

    }
}
