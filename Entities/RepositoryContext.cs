using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Purchase>? purchases { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<UserApiKey>? UserApiKey { get; set; }
    }
}
