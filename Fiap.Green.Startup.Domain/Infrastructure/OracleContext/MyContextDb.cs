using Fiap.Green.Startup.Domain.Entitidades;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Oracle.EntityFrameworkCore;
using Microsoft.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Green.Startup.Domain.Infrastructure.OracleContext
{
    public class MyContextDb : DbContext
    {

        //IConfiguration Config;


        public MyContextDb()
        {
          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Config.GetSection("ConnectionStrings").GetSection("FiapConnection");
                //var config = Config.GetSection("ConnectionStrings");
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = oracle.fiap.com.br)(PORT = 1521)))(CONNECT_DATA = (SID = orcl)));Persist Security Info=True;User ID=RM81792;Password=021293;Pooling=True;Connection Timeout=60;");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)=> modelBuilder.HasDefaultSchema("RM81792");
  
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Produto> Produto { get; set; }
    }
}