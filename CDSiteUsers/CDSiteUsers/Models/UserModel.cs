﻿namespace CDSiteUsers.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }  
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
    }
}
