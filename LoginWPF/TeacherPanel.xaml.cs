using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LoginWPF
{
    /// <summary>
    /// Lógica de interacción para TeacherPanel.xaml
    /// </summary>
    public partial class TeacherPanel : Window
    {


        private ClassRoomController controllerClassRoom;
        private TimeZoneController controllerTimeZone;
        private BookingController controllerBooking;


        private List<ClassRoom> listWithClassRooms = new List<ClassRoom>();
        private List<TimeZones> listWithTimeZones = new List<TimeZones>();
        private List<String> listWithNames = new List<String>();
        private List<Booking> listWithBookings = new List<Booking>();

        private Users user = new Users();

      

        public TeacherPanel(ClassRoomController controller, Users user)
        {
            this.controllerClassRoom=controller;
            controllerTimeZone = new TimeZoneController();
            controllerBooking = new BookingController();
            this.user = user;

            InitializeComponent();
            loadAllClassRooms();
            loadReservePanel();
            loadBookingPanel();
        }

        /// <summary>
        /// Refresca lista de reservas
        /// </summary>
        private void loadBooking()
        {
            listWithBookings.Clear();
            listWithBookings =controllerBooking.listAllBookings();
        }

        /// <summary>
        /// Añade las reservas al listview
        /// </summary>
        private void loadBookingPanel()
        {
            // reservePan
            loadBooking();

            reservePan.Items.Clear();

            if (listWithBookings != null)
            {

                foreach (Booking reserve in listWithBookings)
                {

                    var row = new { reserve.IdBooking, reserve.UserName, reserve.UserEmail, reserve.ClassName, reserve.Day, reserve.Hours };
                    reservePan.Items.Add(row);

                }

            }



        }

        /// <summary>
        /// muestra las aulas reservables con su horario y dia disponibles
        /// </summary>
        private void loadReservePanel()
        {
            loadAllTimes();
            bookPan.Items.Clear();
            foreach (ClassRoom cs in listWithClassRooms)
            {

                foreach (TimeZones timeZone in listWithTimeZones)
                {
                    if (cs.TimeZoneId == timeZone.TimeZoneId)
                    {
                        var row = new { cs.Id, cs.Name, timeZone.Day, timeZone.Hours};
                        bookPan.Items.Add(row);
                    }
                }
            }
        }

        /// <summary>
        /// Carga todas las zonas horarias
        /// </summary>
        private void loadAllTimes()
        {
            listWithTimeZones.Clear();
            listWithTimeZones = controllerTimeZone.loadAllZones();
        }

        /// <summary>
        /// muetra todas las clases en el listview y genera radiobuttons dependiendo de cuantas hay
        /// </summary>
        private void loadAllClassRooms()
        {

            listWithClassRooms.Clear();
            listWithClassRooms = controllerClassRoom.loadAllClass();

            tableClassRoom.Items.Clear();
            foreach (ClassRoom cs in listWithClassRooms)
            {
                if (!listWithNames.Contains(cs.Name))
                {
                    var row = new { cs.Id, cs.Name, cs.Description };
                    tableClassRoom.Items.Add(row);

                    RadioButton button = new RadioButton();
                    button.Name = cs.Name;
                    button.Content = cs.Name;
                    button.Margin = new Thickness(20, 0, 0, 0);


                    listWithNames.Add(cs.Name);
                    buttonClasses.Children.Add(button);
                }

            }

        }

        /// <summary>
        /// Reserva un aula
        /// Comprueba que no se ha reservado ante y que el dia seleccionado es el correcto para dicha aula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bookingClass(object sender, RoutedEventArgs e)
        {
            Boolean exist = false; //existe aula
            String nameClassSelected=null;
            ClassRoom classSelected = new ClassRoom();
            TimeZones timeZone = new TimeZones();
            String date = Convert.ToDateTime(datePicker.SelectedDate).ToString("yyyy-MM-dd"); //Selecciona dia y lo pasamos a un formato mas comodo

            
            //Comprobamos que radioButton ha seleccionado
            foreach (Control control in buttonClasses.Children)
            {

                RadioButton button = control as RadioButton;

                if (button != null && button.IsChecked==true)
                {

                    nameClassSelected = button.Name;
           
                }
            }


            //comprueba si la clase seleccionada existe en la lista
            if (nameClassSelected != null)
            {

                foreach (ClassRoom classRoom in listWithClassRooms)
                {
                    if (nameClassSelected.Equals(classRoom.Name))
                    {
                        classSelected = classRoom;

                    }
                }

                //comprueba que existe un horario con el dia seleccionado
                timeZone = controllerTimeZone.searchTimeZone(date);

                //Si existe la clase y el horario seleccionado comprobamos que no haya sido reservada antes
                if (timeZone != null)
                {
                    listWithBookings.Clear();
                    listWithBookings = controllerBooking.listAllBookings();
                    Booking booking = new Booking(user.Username, user.Email, nameClassSelected, date, timeZone.Hours);

                    foreach (Booking prorder in listWithBookings)
                    {
                        if (prorder.ClassName.Equals(booking.ClassName) && prorder.Day.Equals(booking.Day) && prorder.Hours.Equals(booking.Hours))
                        {
                            exist = true;
                        }

                    }

                    if (exist)
                    {
                        MessageBox.Show("Reserva no disponible");
                    }
                    else
                    {

                        if (controllerBooking.insertBooking(booking))
                        {
                            loadBookingPanel();
                            MessageBox.Show("Reserva con exito");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Horario no disponible para esta clase");

                }
            }

        }
    }
}
