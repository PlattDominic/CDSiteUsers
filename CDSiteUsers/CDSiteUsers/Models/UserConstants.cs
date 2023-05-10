namespace CDSiteUsers.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "Joshy3432", Password = "1234@Password", Email = "JoshUpchurch343@gmail.com", Role = "regular", GivenName = "Josh", Surname = "Upchurch"},
            new UserModel() { Username = "AlexSulk34", Password = "1234@Password", Email = "Alextheone3@gmail.com", Role = "seller", GivenName = "Alex", Surname = "Sulkis" },
            new UserModel() { Username = "Joesph", Password = "1234@Password", Email = "joesphgomez@gmail.com", Role = "admin", GivenName = "Joesph", Surname = "Gomez" }
        };

        private static List<CDModel> Cd = new List<CDModel>()
        {
            new() { Title = "The tiger in time", Artist = "Ramirez", Tracks = 5, Duration = "20:34" },
            new() { Title = "The tiger in time", Artist = "Ramirez", Tracks = 5, Duration = "20:34" },
            new() { Title = "The tiger in time", Artist = "Ramirez", Tracks = 5, Duration = "20:34" },
            new() { Title = "The tiger in time", Artist = "Ramirez", Tracks = 5, Duration = "20:34" }
        };
    }
}
