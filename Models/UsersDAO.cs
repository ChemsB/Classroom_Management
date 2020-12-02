using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UsersDAO
    {
        private DBConnection dbConnect;
        private MySqlConnection con;
        public UsersDAO()
        {
            dbConnect = DBConnection.getInstance();
        }

        /// <summary>
        /// Este método me detecta si un usuario está en la tabla users
        /// </summary>
        /// <param name="user">user viene dado por el controlador</param>
        /// <returns></returns>
        public Users login(Users user)
        {
            Users res = new Users();
            String query = "SELECT * FROM users WHERE userName=@user AND password=@pass"; //la consulta que li fem a la BBDD
            try
            {
                con = dbConnect.getConnection();
                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@user", user.Username));
                        cmd.Parameters.Add(new MySqlParameter("@pass", user.Password));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                res = new Users(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));

                            }
                        }
                        else
                        {
                            res = null;
                        }
                        reader.Close();

                    }
                }
            }
            catch (MySqlException err)
            {
                res = null;
            }
            catch (Exception err)
            {
                res = null;
            }
            return res;

        }


        /// <summary>
        /// Encuentra un usuario por el nombre
        /// </summary>
        /// <param name="name"> nombre del usuario</param>
        /// <returns>el usuario si lo encuentra, nulo en caso de error</returns>
        public Users findUserByName(String name)
        {
            Users user = new Users();


            String query = "SELECT * FROM users WHERE userName=@user"; //la consulta que li fem a la BBDD
            try
            {
                con = dbConnect.getConnection();
                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@user", name));
                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                user = new Users(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));

                            }
                        }
                        else
                        {
                            user = null;
                        }
                        reader.Close();

                    }
                }
            }
            catch (MySqlException err)
            {
                user = null;
            }
            catch (Exception err)
            {
                user = null;
            }


            return user;

        }


        /// <summary>
        /// Lee toda la tabla de usuarios
        /// </summary>
        /// <returns>lista con todos los usuarios</returns>
        public List<Users> loadAllUsers()
        {
            List<Users> listWithUsers = new List<Users>();
            String query = "SELECT * FROM users";
            Users us;

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
                                us = new Users(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                                listWithUsers.Add(us);

                            }
                        }
                        else
                        {
                            listWithUsers = null;
                        }
                        reader.Close();

                    }
                }
            }
            catch (MySqlException err)
            {
                listWithUsers = null;
            }
            catch (Exception err)
            {
                listWithUsers = null;
            }

            return listWithUsers;

        }


        /// <summary>
        /// Modifica un elemento de la tabla usuarios
        /// </summary>
        /// <param name="user">nuevos datos a modificar</param>
        /// <returns>true si ha ido bien, false en caso de error</returns>
        public Boolean modifyData(Users user)
        {


            Boolean res = false;
            String queryInsert = "UPDATE users SET email=@newEmail, password=@newPass WHERE userName=@user"; //la consulta que li fem a la BBDD
            try
            {
                con = dbConnect.getConnection();
                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(queryInsert, con))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@user", user.Username));
                        cmd.Parameters.Add(new MySqlParameter("@newPass", user.Password));
                        cmd.Parameters.Add(new MySqlParameter("@newEmail", user.Email));

                        cmd.ExecuteNonQuery();

                        res = true;


                    }
                }
            }
            catch (MySqlException err)
            {
                res = false;
            }
            catch (Exception err)
            {
                res = false;
            }


            return res;


        }


        /// <summary>
        /// Inserta un nuevo usuario en la tabla usuarios
        /// </summary>
        /// <param name="user">usuario a añadir</param>
        /// <returns>true si lo añade, false en caso de error</returns>
        public Boolean insertData(Users user)
        {
            Boolean res = false;
            String queryInsert = "INSERT INTO users VALUES (@user,@pass,@rol,@mail)"; //la consulta que li fem a la BBDD
            try
            {
                con = dbConnect.getConnection();
                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(queryInsert, con))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@user", user.Username));
                        cmd.Parameters.Add(new MySqlParameter("@pass", user.Password));
                        cmd.Parameters.Add(new MySqlParameter("@rol", user.Rol));
                        cmd.Parameters.Add(new MySqlParameter("@mail", user.Email));

                        cmd.ExecuteNonQuery();

                        res = true;
                        

                    }
                }
            }
            catch (MySqlException err)
            {
                res = false;
            }
            catch (Exception err)
            {
                res = false;
            }
            return res;

        }


        /// <summary>
        /// Elimina un usuario de la tabla
        /// </summary>
        /// <param name="user">usuario a eliminar</param>
        /// <returns>true en caso de eliminarlo, false en caso de error</returns>
        public Boolean deleteUser(Users user)
        {
            Boolean res = false;
            String queryInsert = "DELETE FROM users WHERE userName=@user"; //la consulta que li fem a la BBDD
            try
            {
                con = dbConnect.getConnection();
                if (con != null)
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(queryInsert, con))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@user", user.Username));

                        cmd.ExecuteNonQuery();

                        res = true;


                    }
                }
            }
            catch (MySqlException err)
            {
                res = false;
            }
            catch (Exception err)
            {
                res = false;
            }
            return res;

        }
    }
}
