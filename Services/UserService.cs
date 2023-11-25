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

        //Data modifiers
        public void AddUser(User user) { dummyUsersDatabase.Add(user); }
    }
}
