using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalaoBeleza.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Descricao { get; set; }

        [Required]
        public DateTime DtAgendamento { get; set; }

        public DateTime DtRegistro { get; set; }

        [Required]
        public Customer Customer { get; set; }

        public byte CustomerId { get; set; }
    }
}