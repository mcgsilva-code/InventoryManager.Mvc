using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CrudMVCApp.Models
{
    // AppDbContext herda de DbContext, que é a ferramenta do EF Core
    public class AppDbContext : DbContext
    {
        // Construtor necessário para configurar a conexão
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Isso representa a tabela 'Itens' no seu banco de dados
        public DbSet<Item> Itens { get; set; }
    }
}

