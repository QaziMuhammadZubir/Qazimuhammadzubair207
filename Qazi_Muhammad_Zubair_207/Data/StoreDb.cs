using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Qazi_Muhammad_Zubair_207.Models;

namespace Qazi_Muhammad_Zubair_207.Data
{
    public class StoreDb : DbContext
    {
        public StoreDb (DbContextOptions<StoreDb> options)
            : base(options)
        {
        }

        public DbSet<Qazi_Muhammad_Zubair_207.Models.Ordermodel> Ordermodel { get; set; }
    }
}
