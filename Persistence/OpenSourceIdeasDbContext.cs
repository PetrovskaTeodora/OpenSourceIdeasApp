using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
  public class OpenSourceIdeasDbContext :  DbContext
    {
        public OpenSourceIdeasDbContext(DbContextOptions<OpenSourceIdeasDbContext> options) : base(options)
        {

        }
        public DbSet<Idea> Ideas { get; set; }
    }
}
