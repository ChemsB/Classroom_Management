using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Users
    {
        //atributos
        private String username;
        private String password;
        private String rol;
        private String email;

        //accesores
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Rol { get => rol; set => rol = value; }
        public string Email { get => email; set => email = value; }

        public Users()
        {
        }

        //Constructores
        public Users(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public Users(string username, string password, string rol, string email)
        {
            this.username = username;
            this.password = password;
            this.rol = rol;
            this.email = email;
        }



    }
}
