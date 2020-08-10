using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleRentalsApp.Models
{
    public class User 
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public int Score { get; set; }
    }
}
