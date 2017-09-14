using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalaoBeleza.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required]
        [StringLength(30)]
        public string SKU { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public string Price { get; set; }

        [Required]
        [Display(Name = "Estoque")]
        public int Stock { get; set; }
    }
}