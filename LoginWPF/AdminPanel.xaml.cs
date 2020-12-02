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
    /// Lógica de interacción para AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {

        private UsersController controller;
        private List<Users> listWithUsers = new List<Users>();
        private Users userToModify = new Users();

        private int pos;

        private String newPass;
        private String newEmail;
        public AdminPanel(Controllers.UsersController userController)
        {
            InitializeComponent();
            this.controller = userController;
            loadAllUsers();
        }

        /// <summary>
        /// Carga todos los usuarios en el listview
        /// </summary>
        private void loadAllUsers()
        {

            listWithUsers.Clear();
            listWithUsers = controller.loadListDb();
            
            String[] cadenaDatos = new string[5];


            dataTable.Items.Clear();
            foreach (Users user in listWithUsers)
            {
                var row = new { user.Username, user.Password,user.Rol,user.Email};
                dataTable.Items.Add(row);
            }

        }

        /// <summary>
        /// Instroduce un nuevo usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNewUser(object sender, RoutedEventArgs e)
        {

            Boolean res = true;
            String name = initName.Text;
            String pass = initPass.Text;
            String rol = initRol.Text;
            String mail = initEmail.Text;

            if (name.Equals("")|| pass.Equals("") || rol.Equals("") || mail.Equals(""))
            {
                MessageBox.Show("Por favor rellene todos los campos");
            }
            else
            {
                Users user = new Users(name,pass,rol,mail);


                foreach (Users us in listWithUsers)
                {
                    if (us.Email.Equals(user.Email) || us.Equals(user))
                    {
                        res = false;
                    }
                }

                if (res)
                {
                    if (controller.insertData(user))
                    {
                        MessageBox.Show("Usuario introducido con exito");
                        loadAllUsers();
                    }
                    else
                    {
                        MessageBox.Show("Ha habido un error");
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe este correo o usuario");
                }
            }
        }


        /// <summary>
        /// Busca un usuario a modificar mediante su nombre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void FindUserToModify(object sender, RoutedEventArgs e)
        {

            String name = "";

            name = initFind.Text;

            userToModify = controller.findToModify(name);

            if (userToModify != null)
            {
                MessageBox.Show("Usuario encontrado");
                modifyBox.IsEnabled = true;


                initNewEmail.Text = userToModify.Email;
                initNewPass.Text = userToModify.Password;

            }
            else
            {
                MessageBox.Show("No existe un usuario con ese nombre");
            }
        }




        /// <summary>
        /// Modifica un usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifyButtonUser(object sender, RoutedEventArgs e)
        {
            Boolean exitsEmail = false;

            newPass = initNewPass.Text;
            newEmail = initNewEmail.Text;

            userToModify.Email = newEmail;
            userToModify.Password = newPass;

            foreach (Users us in listWithUsers)
            {

                if (us.Email.Equals(newEmail) && !us.Username.Equals(userToModify.Username))
                {
                    exitsEmail = true;
                }
            }

            if (!exitsEmail)
            {
                Boolean res = controller.modifyUser(userToModify);

                if (res)
                {
                    loadAllUsers();
                    MessageBox.Show("Usuario modificado");
                }
                else
                {
                    MessageBox.Show("Usuario no modificado");
                }

            }
            else
            {
                MessageBox.Show("Actualmente este correo ya existe");
            }


        }

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeUser(object sender, RoutedEventArgs e)
        {

           Boolean res= controller.deleteUser(userToModify);

            if (res)
            {
                MessageBox.Show("Usuario eliminado");
                modifyBox.IsEnabled = false;
                loadAllUsers();//refrescamos la lista de usuarios y la mostramos
            }
            else
            {
                MessageBox.Show("Usuario no eliminado");
            }

        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
