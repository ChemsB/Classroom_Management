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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginWPF
{


    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UsersController userController;
        private ClassRoomController classController;
        private Users userValidate = new Users();
        private AdminPanel adminPanel;

        public MainWindow()
        {
            InitializeComponent();
            userController = new Controllers.UsersController();
            classController = new ClassRoomController();
        }

        


        /// <summary>
        /// Valida si un usuario existe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validate(object sender, RoutedEventArgs e)
        {

            String user = usuari.Text;
            String pass = contrasenya.Password;

            if (user.Equals("") || pass.Equals(""))
            {

                lb3.Content = "Campo vacio, por favor rellene los campos correctamente";
            }
            else
            {

                userValidate = userController.validate(user, pass);
                if (userValidate != null){

                    //Si existe y es admin, abre panel admin
                    if (userValidate.Rol.Equals("admin") || userValidate.Rol.Equals("Admin"))
                    {
                        adminPanel = new AdminPanel(userController);
                        adminPanel.Show();

                    }
                    else
                    {
                        //Si existe y es profesor, abre panel profesor
                        TeacherPanel teacherPanel = new TeacherPanel(classController, userValidate);
                        teacherPanel.Show();

                    }
                }
                else
                {
                    MessageBox.Show("No existe el usuario");
                }

                cleanFields();

            }
        }

        private void cleanFields()
        {
            usuari.Text = "";
            contrasenya.Password = "";

        }
    }
}
