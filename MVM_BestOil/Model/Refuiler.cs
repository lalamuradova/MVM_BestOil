using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVM_BestOil.Model
{
    public class Refuiler
    {
        
        public int RefuilerID { get; set; }
        public string Gasoline { get; set; }
        public double Price { get; set; }
        public double Pay { get; set; }
        public double Money { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{Gasoline} - {Price} - {Pay} ";
        }
    }
}
