using Microsoft.EntityFrameworkCore;

namespace WebMVC.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)//criando o construtor da classe pra receber o Option das configuração de conexão com o banco do app set
        : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
