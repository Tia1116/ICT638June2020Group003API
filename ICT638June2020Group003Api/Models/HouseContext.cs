using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ICT638June2020Group003Api.Models
{
    public class HouseContext:DbContext
    {
        //Agent Api Tia
        public HouseContext(DbContextOptions<HouseContext> options)
           : base(options)
        {
        }

        public DbSet<House> TodoItems { get; set; }
    }
}
