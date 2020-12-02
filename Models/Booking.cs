using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Booking
    {

        //Atributos
        private int idBooking;
        private String userName;
        private String userEmail;
        private String className;
        private String day;
        private String hours;

        //Accesores
        public int IdBooking { get => idBooking; set => idBooking = value; }
        public string UserName { get => userName; set => userName = value; }
        public string UserEmail { get => userEmail; set => userEmail = value; }
        public string ClassName { get => className; set => className = value; }
        public string Day { get => day; set => day = value; }
        public string Hours { get => hours; set => hours = value; }

        //Contructores
        public Booking(int idBooking, string userName, string userEmail, string className, string day, string hours)
        {
            this.idBooking = idBooking;
            this.userName = userName;
            this.userEmail = userEmail;
            this.className = className;
            this.day = day;
            this.hours = hours;
        }

        public Booking(string userName, string userEmail, string className, string day, string hours)
        {
            this.userName = userName;
            this.userEmail = userEmail;
            this.className = className;
            this.day = day;
            this.hours = hours;
        }

        public Booking()
        {
        }
    }
}
