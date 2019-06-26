using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using webapicore.Domain.Entities;
using webapicore.Infra.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace webapicore.Infra.Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(){}
        public MySqlContext(DbContextOptions<MySqlContext> options)
            : base(options){}

        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                //optionsBuilder.UseSqlServer(@"Server=SES17110\SQLEXPRESS;Database=Db;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\ProjetoDotNet\modelo-api-master\Infra\AppData\Database1.mdf;Integrated Security=True");

            //<add name="CustodiaAtivosContext" connectionString="data source=srvsede0157;initial catalog=CustomizacoesHD;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
        }
    }
}
