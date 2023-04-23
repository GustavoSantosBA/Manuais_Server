using Manuais_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manuais_Data.Context
{
    public class ManuaisContext : DbContext
    {
        public ManuaisContext(DbContextOptions<ManuaisContext> options) : base(options)
        {

        }

        public DbSet<Manuais> Manuais { get; set; }
    }
}
