﻿namespace MessangerClientApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool Authorization(string login, string password)
        {
            return true;
        }
        public bool Registration(string login, string email, string password)
        {
            return true;
        }
    }
}
