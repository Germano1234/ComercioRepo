using Comercio.Domain;
using Comercio.Repository.Configurations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Comercio.Repository.Contexts
{
    public class Context : DbContext
    {
        private readonly string _connectionString = "Server=.\\SQLEXPRESS;Database=Comercio;UID=sa;PWD=123;TrustServerCertificate=True;";
        private SqlConnection _sqlConnection;
        public DbSet<Produto> Produtos {get; set;}
        public DbSet<Pedido> Pedidos {get; set;}
        public DbSet<PedidoProduto> PedidosProdutos {get; set;}

        public Context(){ }
        public Context(DbContextOptions<Context> options) : base(options){ }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoProdutoConfiguration());
        }
    
        public SqlConnection Connection(){
            if (_sqlConnection == null){
                _sqlConnection = new SqlConnection(_connectionString);
                _sqlConnection.Open();
                return _sqlConnection;
            } else{
                if (_sqlConnection.State == ConnectionState.Open)
                {
                    return _sqlConnection;
                } else {
                    _sqlConnection.Open();
                    return _sqlConnection;
                }
            }
        }
    }
}