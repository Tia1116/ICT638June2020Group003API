using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ICT638June2020Group003Api.Models
{
    public class Agent_Context: DbContext
    {
        public Agent_Context(DbContextOptions<Agent_Context> options)
            : base(options)
        {
        }

        public DbSet<Agent> Agents { get; set; }
    }
}
