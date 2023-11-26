﻿namespace CirsaHackaton.Model
{
    public class User
    {
        private String id;
        private String name;
        private String surnames;
        private String email;
        private String password;

        public User(String name, String surnames, String email, String password)
        {
            id = Guid.NewGuid().ToString();
            this.name = name;
            this.surnames = surnames;
            this.email = email;
            this.password = password;
        }

        //Getters
        public String GetId() { return id; }
    }
}
