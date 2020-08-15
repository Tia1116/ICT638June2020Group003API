using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICT638June2020Group003Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ICT638June2020Group003Api.Models
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
          : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
