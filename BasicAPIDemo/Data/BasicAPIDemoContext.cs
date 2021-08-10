using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BasicAPIDemo.Models;

namespace BasicAPIDemo.Data
{
    public class BasicAPIDemoContext : DbContext
    {
        public BasicAPIDemoContext (DbContextOptions<BasicAPIDemoContext> options)
            : base(options)
        {
        }

        public DbSet<BasicAPIDemo.Models.Employee> Employee { get; set; }

        public DbSet<BasicAPIDemo.Models.Bored> Bored { get; set; }
    }
}
