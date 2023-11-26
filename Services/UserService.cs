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

            //Don't register the user if another user has the same email
            if (GetUserByMail(user.GetMail()) != null)
                return new Tuple<bool, string>(false, "Ha ocurrido un error: Este email ya se encuentra registrado");

            dummyUsersDatabase.Add(user);

            //Log user when success
            loggedUser = user;

            return new Tuple<bool, string>(true, "Registro completado!");
        }

        public Tuple<bool, String> TryLoginUser(User user) {

            User? retrievedUser = GetUserByMail(user.GetMail());

            if (retrievedUser == null)
                return new Tuple<bool, string>(false, "Ha ocurrido un error: No existe ningún usuario con este correo");

            if (!user.GetPassword().Equals(retrievedUser.GetPassword()))
                return new Tuple<bool, string>(false, "Ha ocurrido un error: La contraseña es incorrecta");

            //Log user when success
            loggedUser = user;

            return new Tuple<bool, string>(true, "Sesión iniciada!");
        }
    }
}
