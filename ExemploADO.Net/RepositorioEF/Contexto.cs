using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RepositorioEF
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("Exemplo")
        {

        }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Aluno>().Property(x => x.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            modelBuilder.Entity<Aluno>().Property(x => x.Mae).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            modelBuilder.Entity<Aluno>().Property(x => x.DataNascimento).IsRequired().HasColumnType("date");
        }
    }
}
