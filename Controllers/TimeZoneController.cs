using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class TimeZoneController
    {

        private TimeZoneDAO model;
        public TimeZoneController()
        {
            model = new TimeZoneDAO();
        }

        /// <summary>
        /// Carga todos los horarios
        /// </summary>
        /// <returns>lista con todos los horarios</returns>
        public List<TimeZones> loadAllZones()
        {
            List<TimeZones> listWithTimeZones = new List<TimeZones>();

            listWithTimeZones = model.loadAllTimeZones();

            return listWithTimeZones;

        }

        /// <summary>
        /// Busca el horario respecto un dia especificado
        /// </summary>
        /// <param name="day">dia a buscar</param>
        /// <returns>retorna el horario, nulo en caso de error</returns>
        public TimeZones searchTimeZone(String day)
        {
            TimeZones timeZone = new TimeZones();
            timeZone = model.searchTimeZone(day);
            return timeZone;


        }

    }
}
