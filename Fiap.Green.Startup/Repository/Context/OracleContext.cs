using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Oracle.EntityFrameworkCore;
using Microsoft.Extensions;
using Microsoft.EntityFrameworkCore;
using Fiap.Green.Startup.Models;

namespace Fiap.Green.Startup.Repository.Context
{
    public class OracleContext : DbContext
    {


private readonly IConfiguration _configuration;

public OracleContext()
{
    
}
 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

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
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<TipoPagamento> TipoPagamento { get; set; }
        public DbSet<TipoProduto> TipoProduto { get; set; }
        public DbSet<Venda> Venda { get; set; }

        
    }
}