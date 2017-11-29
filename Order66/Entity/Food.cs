using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order66.Entity
{
    public class Food
    {
        public int ID { get; set; }
        public int ID_typu { get; set; }
        public int Cena { get; set; }
        public DateTime Datum { get; set; }
    }
}
