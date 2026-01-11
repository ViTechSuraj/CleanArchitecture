using Microsoft.EntityFrameworkCore;
using MyApp.Core.Entities;
using MyApp.Core.Entities.CenterMasterEntites;
using MyApp.Core.Entities.EmployeeMasterEntites;
using MyApp.Core.Entities.RoleMasterEntites;
using System;
using System.Collections.Generic;
using System.Data;
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
        public DbSet<Roles> RoleMaster { get; set; }
        public DbSet<Center> CenterMaster { get; set; }
    }
}
