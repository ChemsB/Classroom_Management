using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class UsersController
    {
        private UsersDAO model;
        public UsersController()
        {
            model = new UsersDAO();
        }

        /// <summary>
        /// Valida que el usuario exista en la base de datos
        /// </summary>
        /// <param name="username">nombre del usuario</param>
        /// <param name="password">conraseña del usuario</param>
        /// <returns>el usuario, en caso de error nulo</returns>
        public Users validate(string username, string password)
        {
            Users us = new Users();
            //no hace falta validar
            Users u = new Users(username, password);
            us = model.login(u);
            if (us==null)
            {
                us = null;
            }
            return us;
        }


        /// <summary>
        /// Iserta un usuario nuevo
        /// </summary>
        /// <param name="user">usuario a insertar</param>
        /// <returns>retorna true si ha ido bien,false en caso de error</returns>
        public Boolean insertData (Users user)
        {
            Boolean res = false;
            res = model.insertData(user);
            return res;

        }

        /// <summary>
        /// Modifica un usuario
        /// </summary>
        /// <param name="user">usuario a modificar con nuevos datos</param>
        /// <returns>ttrue en caso de modificacion, false en caso de error</returns>
        public Boolean modifyUser(Users user)
        {
            Boolean res = false;

            res=model.modifyData(user);
            return res;


        }


        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="user">usuario a eliminar</param>
        /// <returns>true si es eliminado, false en caso de error</returns>
        public Boolean deleteUser(Users user)
        {
            Boolean res = false;

            res = model.deleteUser(user);
            return res;
        }


        /// <summary>
        /// Carga toda la lista de usuarios
        /// </summary>
        /// <returns>lista con usuarios, nulo en caso de error</returns>
        public List<Users> loadListDb()
        {
            List<Users> listWithUsers = new List<Users>();
            listWithUsers = model.loadAllUsers();
            return listWithUsers;
        }


        /// <summary>
        /// Busca un usuario por el nombre para odificarlo posteriormente
        /// </summary>
        /// <param name="name">nombre a buscar</param>
        /// <returns>Usuario si lo ha encontrado, nulo en caso de error</returns>
        public Users findToModify(String name)
        {

            Users user = new Users();

            user = model.findUserByName(name);

            return user;

        }

    }
}
