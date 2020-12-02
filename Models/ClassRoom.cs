using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ClassRoom
    {

        //Atributos
        private int id;
        private String name;
        private String description;
        private int timeZoneId;

        //Accesores
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int TimeZoneId { get => timeZoneId; set => timeZoneId = value; }

        //Constructores
        public ClassRoom(int id, string name, string description, int timeZoneId)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.timeZoneId = timeZoneId;
        }

        public ClassRoom()
        {
        }



    }
}
