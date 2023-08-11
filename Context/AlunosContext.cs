using TreinoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace TreinoAPI.Context
{
    public class AlunosContext : DbContext 
    {
        public AlunosContext(DbContextOptions<AlunosContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Aluno{ get; set; }
    }
}