using System;

namespace BicyleRentalsApp.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDatetime { get; set; } = DateTime.Now;
        public int Score { get; set; }
    }
}
