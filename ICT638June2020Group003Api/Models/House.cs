using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT638June2020Group003Api.Models
{
    public class House
    {
        public int id { get; set; }
        public float rent { get; set; }

        public string bedroomnumber { get; set; }

        public string bathroomnumber { get; set; }

        public string Address { get; set; }
    }
}
