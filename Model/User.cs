namespace CirsaHackaton.Model
{
    public class User
    {
        private String id;
        private String name;
        private String email;
        private String password;

        public User(String name, String email, String password)
        {
            id = Guid.NewGuid().ToString();
            this.name = name;
            this.email = email;
            this.password = password;
        }

        //Getters
        public String GetId() { return id; }
    }
}
