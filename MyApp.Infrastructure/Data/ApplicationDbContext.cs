using Microsoft.EntityFrameworkCore;
using MyApp.Core.Entities;
using MyApp.Core.Entities.EmployeeMasterEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CSharpCornerArticle> CSharpCornerArticles { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
