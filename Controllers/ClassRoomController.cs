using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ClassRoomController
    {

        private ClassRoomDAO model;
        public ClassRoomController()
        {
            model = new ClassRoomDAO();
        }

        /// <summary>
        /// Carga todas las clases
        /// </summary>
        /// <returns>lista con las clases, nulo en caso de error</returns>
        public List<ClassRoom> loadAllClass()
        {

            List<ClassRoom> listWithClassRooms = new List<ClassRoom>();
            listWithClassRooms = model.loadAllClassRooms();
            return listWithClassRooms;

        }




    }
}
