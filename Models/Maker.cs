using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donea_Paul_App.Models
{
    public class Maker
    {
        public int ID { get; set; }
        public string MakerName { get; set; }
        public ICollection<Truck> Trucks { get; set; } //navigation property
    }
}
