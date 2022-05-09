using CadastroImuno.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

namespace CadastroImuno.Data
{
    public class ImunizanteDbContext : DbContext
    {
        public DbSet<Imunizante> Imunizantes { get; set; }
        public ImunizanteDbContext(DbContextOptions options):base(options)
        {

        }
    }
}
