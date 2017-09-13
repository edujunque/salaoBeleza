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
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Horario Inicio")]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtAgendamentoInicio { get; set; }

        [Required]
        [Display(Name = "Horario Fim")]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtAgendamentoFim { get; set; }

        [Display(Name = "Data do Registro")]
        public DateTime DtRegistro { get; set; }

        [Display(Name = "Cliente")]
        public Customer Customer { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public byte CustomerId { get; set; }

        [Display(Name = "Funcionário")]
        public Employees Employee { get; set; }

        [Required]
        [Display(Name = "Funcionário")]
        public byte EmployeesId { get; set; }
    }
}