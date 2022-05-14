using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BestPracticesCsharp.Models
{
    public partial class BestPracticesContext : DbContext
    {
        public BestPracticesContext()
        {
        }

        public BestPracticesContext(DbContextOptions<BestPracticesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeesArchieve> EmployeesArchieves { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
