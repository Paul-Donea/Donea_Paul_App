using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Donea_Paul_App.Models
{
    public class Truck
    {
        public int ID { get; set; }
        [Display(Name = "Truck Name")]
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Cabin { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime MakingDate { get; set; }
        public int MakerID { get; set; }
        public Maker Maker { get; set; } //navigation property
        public ICollection<TruckCategory> Categories { get; set; }
    }
}

