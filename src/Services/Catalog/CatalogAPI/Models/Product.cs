using CatalogAPI.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Models
{
    public class Product : Entity
    {
        public int ID { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Nom obligatoire.")]
        public int Name { get; set; }

        public int Description { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        [Required]
        public decimal Price { get; set; }
    }
}
