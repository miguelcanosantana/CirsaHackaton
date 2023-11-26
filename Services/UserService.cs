using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CirsaHackaton.Services
{
    public class UserService
    {
        private List<User> dummyUsersDatabase = new List<User>();
        private User? loggedUser;


        //Getters
        public List<User> GetUsers() { return dummyUsersDatabase; }
        public User? GetLoggedUser() { return loggedUser; }
        public User? GetUserById(String uid) { return dummyUsersDatabase.Find(user => user.GetId().Equals(uid)); }
        public User? GetUserByMail(String mail) { return dummyUsersDatabase.Find(user => user.GetMail().Equals(mail)); }

        //Profile functions
        public Tuple<bool, String> TryRegisterUser(User user)
        {
            //Validations 
            if (String.IsNullOrEmpty(user.GetName())) 
                return new Tuple<bool, string>(false, "Ha ocurrido un error: No se ha proporcionado un nombre");

            if (String.IsNullOrEmpty(user.GetSurnames()))
                return new Tuple<bool, string>(false, "Ha ocurrido un error: No se ha proporcionado ningún apellido");

            if (String.IsNullOrEmpty(user.GetMail()))
                return new Tuple<bool, string>(false, "Ha ocurrido un error: No se ha proporcionado ningún correo electrónico");

            if (!IsMailValid(user.GetMail()))
                return new Tuple<bool, string>(false, "Ha ocurrido un error: No se ha proporcionado un correo electrónico váido");

            if (GetUserByMail(user.GetMail()) != null)
                return new Tuple<bool, string>(false, "Ha ocurrido un error: Este email ya se encuentra registrado");

            if (String.IsNullOrEmpty(user.GetPassword()))
                return new Tuple<bool, string>(false, "Ha ocurrido un error: No se ha proporcionado ninguna contraseña");

            if (user.GetPassword().Length < 8)
                return new Tuple<bool, string>(false, "Ha ocurrido un error: La contraseña debe de tener al menos 8 caracteres");

            dummyUsersDatabase.Add(user);

            //Log user when success
            loggedUser = user;

            return new Tuple<bool, string>(true, "Registro completado!");
        }

        public Tuple<bool, String> TryLoginUser(String mail, String password) {

            if (String.IsNullOrEmpty(mail))
                return new Tuple<bool, string>(false, "Ha ocurrido un error: No se ha proporcionado ningún correo electrónico");

            User? retrievedUser = GetUserByMail(mail);

            if (retrievedUser == null)
                return new Tuple<bool, string>(false, "Ha ocurrido un error: No existe ningún usuario con este correo");

            if (String.IsNullOrEmpty(password))
                return new Tuple<bool, string>(false, "Ha ocurrido un error: No se ha proporcionado ninguna contraseña");

            if (password.Length < 8)
                return new Tuple<bool, string>(false, "Ha ocurrido un error: La contraseña debe de tener al menos 8 caracteres");

            if (!password.Equals(retrievedUser.GetPassword()))
                return new Tuple<bool, string>(false, "Ha ocurrido un error: La contraseña es incorrecta");

            //Log user when success
            loggedUser = retrievedUser;

            return new Tuple<bool, string>(true, "Sesión iniciada!");
        }


        //Tools
        private static bool IsMailValid(String email)
        {
            var attr = new EmailAddressAttribute();
            return attr.IsValid(email);
        }
    }
}
