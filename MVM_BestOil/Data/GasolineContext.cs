using MVM_BestOil.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVM_BestOil.Data
{
    class GasolineContext: DbContext
    {
      public  GasolineContext():base("GasolineDb") { 
        }
        public DbSet<Oil> Oils { get; set; }
        public DbSet<Refuiler> Refuilers { get; set; }


    }
}
