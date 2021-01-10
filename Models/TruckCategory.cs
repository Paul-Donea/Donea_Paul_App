using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donea_Paul_App.Models
{
    public class TruckCategory
    {
        public int ID { get; set; }
        public int TruckID { get; set; }
        public Truck Book { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
