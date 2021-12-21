using apiRest.Models;
using Microsoft.EntityFrameworkCore;

namespace apiRest.Data
{
    public class FilmeContext : DbContext
    {
        //Tabela filmes
        public DbSet<Filme> Filmes { get; set; }
        //apenas respeitando a herança
        public FilmeContext(DbContextOptions<FilmeContext> opcoes) : base(opcoes)
        {

        }

        //mais nenhuma configuração


    }
}