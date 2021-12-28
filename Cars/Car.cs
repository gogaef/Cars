using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; } 
        public string Color { get; set; }
        public string Type { get; set; } 
        public decimal Price { get; set; }
        public DateTime Released{ get; set; }
        public bool IsSold{ get; set; }
    }
}
