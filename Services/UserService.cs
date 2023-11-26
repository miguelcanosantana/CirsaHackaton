using CirsaHackaton.Model;

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


        //Data modifiers
        public Tuple<bool, String> TryRegisterUser(User user) {

            //Don't register the user if another user has the same email
            if (GetUserByMail(user.GetMail()) != null)
                return new Tuple<bool, string>(false, "Ha ocurrido un error: Este email ya se encuentra registrado");

            dummyUsersDatabase.Add(user);
            return new Tuple<bool, string>(true, "Registro completado!");
        }
    }
}
