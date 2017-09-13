using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalaoBeleza.Models;
using SalaoBeleza.ViewModels;

namespace SalaoBeleza.ViewModels
{
    public class calendarAuxViewModel
    {
        public List<calendarViewModel> itensCalendario { get; set; }
        public List<Employees> funcionarios { get; set; }
    }
}