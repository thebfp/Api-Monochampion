using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api_One_Trick_Pony_Br.Models;

namespace Api_One_Trick_Pony_Br.Data
{
    public class Api_One_Trick_Pony_BrContext : DbContext
    {
        public Api_One_Trick_Pony_BrContext (DbContextOptions<Api_One_Trick_Pony_BrContext> options)
            : base(options)
        {
        }

        public DbSet<Api_One_Trick_Pony_Br.Models.Pony> Pony { get; set; } = default!;
        public DbSet<Api_One_Trick_Pony_Br.Models.Comment> Comment { get; set; } = default!;
    }
}
