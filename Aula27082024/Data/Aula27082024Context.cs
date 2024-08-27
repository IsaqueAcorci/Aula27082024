using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aula27082024.Models;

namespace Aula27082024.Data
{
    public class Aula27082024Context : DbContext
    {
        public Aula27082024Context (DbContextOptions<Aula27082024Context> options)
            : base(options)
        {
        }

        public DbSet<Aula27082024.Models.Logradouro> Logradouro { get; set; }

        public DbSet<Aula27082024.Models.Aluno> Aluno { get; set; }
    }
}
