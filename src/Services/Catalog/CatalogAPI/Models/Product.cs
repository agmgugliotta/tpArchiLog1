using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Models
{
    public class Product
    {
        public int ID { get; set; }

        public int Name { get; set; }

        public int Description { get; set; }

        public decimal Price { get; set; }
    }
}
