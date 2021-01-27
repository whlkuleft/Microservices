using System;

namespace WhlMicroservices.AuthenticationCenter
{
    /// <summary>
    /// ToDo   DTOUser
    /// </summary>
    public class User
    {
        public int id { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string phone { get; set; }

        public DateTime created { get; set; }

        public string salt { get; set; }
    }
}
