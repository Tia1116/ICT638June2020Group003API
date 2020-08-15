using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT638June2020Group003Api.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}
