using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVM_BestOil.Model
{
    public class Oil
    {
        public int OilId { get ; set; }
        public string Name { get ; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return Name; 
        }

    }
}
