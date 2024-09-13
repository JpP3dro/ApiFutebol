using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiFutebol.Models;

namespace ApiFutebol.Data
{
    public class DbJogadoresContext : DbContext
    {
        public DbJogadoresContext (DbContextOptions<DbJogadoresContext> options)
            : base(options)
        {
        }

        public DbSet<ApiFutebol.Models.JogadorFutebol> JogadorFutebol { get; set; } = default!;
    }
}
