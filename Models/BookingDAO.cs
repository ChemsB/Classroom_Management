using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BookingDAO
    {

        private DBConnection dbConnect;
        private MySqlConnection con;
        public BookingDAO()
        {
            dbConnect = DBConnection.getInstance();
        }


        /// <summary>
        /// Carga todas las reservas de la tabla
        /// </summary>
        /// <returns>lista con todas las reservas, nulo en caso de error</returns>
        public List<Booking> loadAllBookings()
        {
            List<Booking> listWithBookings = new List<Booking>();
            String query = "SELECT * FROM bookings";
            Booking book;

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
                                book = new Booking(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                                listWithBookings.Add(book);

                            }
                        }
                        else
                        {
                            listWithBookings = null;
                        }
                        reader.Close();

                    }
                }
            }
            catch (MySqlException error1)
            {
                listWithBookings = null;
            }
            catch (Exception error2)
            {
                listWithBookings = null;
            }


            return listWithBookings;

        }


        /// <summary>
        /// Inserta una reserva
        /// </summary>
        /// <param name="booking">reserva a añadir</param>
        /// <returns>true en caso de ir bien, false en caso de error</returns>
        public Boolean insertBooking(Booking booking)
        {
            Boolean res = false;
            String queryInsert = "INSERT INTO bookings(userName,userEmail,className,day,hours) VALUES (@userName,@userEmail,@className,@day,@hour)"; //la consulta que li fem a la BBDD
            try
            {
                con = dbConnect.getConnection();
                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(queryInsert, con))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@userName", booking.UserName));
                        cmd.Parameters.Add(new MySqlParameter("@userEmail", booking.UserEmail));
                        cmd.Parameters.Add(new MySqlParameter("@className", booking.ClassName));
                        cmd.Parameters.Add(new MySqlParameter("@day", booking.Day));
                        cmd.Parameters.Add(new MySqlParameter("@hour", booking.Hours));

                        cmd.ExecuteNonQuery();

                        res = true;


                    }
                }
            }
            catch (MySqlException error1)
            {
                res = false;
            }
            catch (Exception error2)
            {
                res = false;
            }
            return res;

        }


    }
}
