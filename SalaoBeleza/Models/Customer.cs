using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalaoBeleza.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        [Phone]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string Observations { get; set; }

        [StringLength(14)]
        public string CPF { get; set; }

        public DateTime DtRegister { get; set; }
        public DateTime DtBirthDay { get; set; }

    }
}