using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using A24_420CW6_TP3_6280636.Models;

namespace A24_420CW6_TP3_6280636.Data
{
    public class A24_420CW6_TP3_6280636Context : DbContext
    {
        public A24_420CW6_TP3_6280636Context (DbContextOptions<A24_420CW6_TP3_6280636Context> options)
            : base(options)
        {
        }

        public DbSet<A24_420CW6_TP3_6280636.Models.Score> Score { get; set; } = default!;
    }
}
