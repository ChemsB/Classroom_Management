using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TimeZones
    {
        //Atributos
        private int timeZoneId;
        private String day;
        private String hours;

        //Constructores
        public TimeZones()
        {
        }

        public TimeZones(int timeZoneId, string day, string hours)
        {
            this.timeZoneId = timeZoneId;
            this.day = day;
            this.hours = hours;
        }

        //Accesores
        public int TimeZoneId { get => timeZoneId; set => timeZoneId = value; }
        public string Day { get => day; set => day = value; }
        public string Hours { get => hours; set => hours = value; }
    }
}
