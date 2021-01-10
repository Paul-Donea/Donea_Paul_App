using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donea_Paul_App.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<TruckCategory> TruckCategories { get; set; }
    }
}
