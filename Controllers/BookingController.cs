using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class BookingController
    {

        private BookingDAO model;
        public BookingController()
        {
            model = new BookingDAO();
        }


        /// <summary>
        /// Lista todas las reservas
        /// </summary>
        /// <returns>listas con las reservas</returns>
        public List<Booking> listAllBookings()
        {
            List<Booking> listWithBookings = new List<Booking>();

            listWithBookings = model.loadAllBookings();

            return listWithBookings;


        }

        /// <summary>
        /// Inserta nueva reserva
        /// </summary>
        /// <param name="booking">reserva a añadir</param>
        /// <returns>true en caso de ir bien, false en caso de error</returns>
        public Boolean insertBooking(Booking booking)
        {

            Boolean res = false;

            res = model.insertBooking(booking);

            return res;
        }

    }
}
