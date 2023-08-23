using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreModel
{
    public class Context:DbContext
    {
        public DbSet<EventInfo> EventInfos { get; set; }

        // 数据库链接
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                       @"Data Source=ASDC-20220713ET;Initial Catalog=meeting;User ID = sa;Password=malongfei1;TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
