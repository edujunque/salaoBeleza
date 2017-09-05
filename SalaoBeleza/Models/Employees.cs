using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalaoBeleza.Models
{
    public class Employees
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        [Phone]
        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }

    }
}