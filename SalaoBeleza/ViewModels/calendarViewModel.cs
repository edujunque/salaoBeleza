using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalaoBeleza.Models;

namespace SalaoBeleza.ViewModels
{
    public class calendarViewModel
    {
        public string strHorario { get; set; }
        public string nomeUsuario { get; set; }
        public bool blnAgendado { get; set; }
        public string descricao { get; set; }
        public List<Employees> funcionarios { get; set; }
    }
}