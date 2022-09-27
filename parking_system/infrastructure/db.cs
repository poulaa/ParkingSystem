using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using parking_system.Models;

namespace parking_system.infrastructure
{
    public class db:DbContext
    {
        public db(DbContextOptions<db> options)
           : base(options)
        {

        }

        public DbSet<car_owner> car_owner { get; set; }
        public DbSet<park_slot> park_slot { get; set; }
    }
}
