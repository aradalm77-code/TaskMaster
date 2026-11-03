using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TaskMasterEntity.src.Core.Domain.Entities;

namespace TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance
{
    public class UserReposetory : DbContext
    {
        public UserReposetory() : base("name=DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }

    }
}