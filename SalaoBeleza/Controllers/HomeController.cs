using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalaoBeleza.Models;
using SalaoBeleza.ViewModels;


namespace SalaoBeleza.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            CarregaCalendario();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CarregaCalendario()
        {
            //TODO - Alterar data abaixo para parametro recebido na controller
            DateTime strFiltroData = DateTime.Today;

            //Monta Logica para carregar a view
            //obtem o maior e menor horario daquele dia
            Booking menorHorarioDia = db.Bookings.Where(c => c.DtAgendamentoInicio.Year == strFiltroData.Year && c.DtAgendamentoInicio.Month == strFiltroData.Month && c.DtAgendamentoInicio.Day == strFiltroData.Day).OrderBy(c => c.DtAgendamentoInicio).Take(1).FirstOrDefault();
            Booking maiorHorarioDia = db.Bookings.Where(c => c.DtAgendamentoFim.Year == strFiltroData.Year && c.DtAgendamentoFim.Month == strFiltroData.Month && c.DtAgendamentoFim.Day == strFiltroData.Day).OrderByDescending(c => c.DtAgendamentoFim).Take(1).FirstOrDefault();

            //Adiciona e subtrai uma hora de cada extremo para que o calendario tenha um "respiro" de visualização
            menorHorarioDia.DtAgendamentoInicio = menorHorarioDia.DtAgendamentoInicio.AddHours(-1);
            maiorHorarioDia.DtAgendamentoFim = maiorHorarioDia.DtAgendamentoFim.AddHours(1);

            List<Employees> listaFuncionarios = db.Employees.OrderBy(c => c.Name).ToList();

            //cria instancia da viewModel
            List<calendarViewModel> calendario = new List<calendarViewModel>();
            //While que percorre todos os horarios que precisam ser listados naquele dia.
            while (menorHorarioDia.DtAgendamentoInicio <= maiorHorarioDia.DtAgendamentoFim)
            {

                //Percorre Listagem de funcionarios para criar todas as linhas daquele horario
                foreach (var item in listaFuncionarios)
                {
                    calendarViewModel auxCalendario = new calendarViewModel();
                    auxCalendario.strHorario = menorHorarioDia.DtAgendamentoInicio.ToShortTimeString();
                    auxCalendario.nomeUsuario = item.Name;
                    
                    //verifica se o esse usuario esta com esse horario agendado, filtra pelo ID do usuario, dia selecionado no filtro e horario.
                   List<Booking> agendamentoPorUsuario = db.Bookings.Where(c => c.EmployeesId == item.Id && c.DtAgendamentoInicio.Year == menorHorarioDia.DtAgendamentoInicio.Year && c.DtAgendamentoInicio.Month == menorHorarioDia.DtAgendamentoInicio.Month && c.DtAgendamentoInicio.Day == menorHorarioDia.DtAgendamentoInicio.Day).ToList();

                    //Filtro Hora
                    //&& ((c.DtAgendamentoInicio.Hour >= menorHorarioDia.DtAgendamentoInicio.Hour && c.DtAgendamentoInicio.Minute >= menorHorarioDia.DtAgendamentoInicio.Minute) && (c.DtAgendamentoFim.Hour <= menorHorarioDia.DtAgendamentoInicio.Hour && c.DtAgendamentoFim.Minute <= menorHorarioDia.DtAgendamentoInicio.Minute))
                  var auxAgendamentoPorUsuario =  agendamentoPorUsuario.Where(c => c.DtAgendamentoInicio.TimeOfDay <= menorHorarioDia.DtAgendamentoInicio.TimeOfDay && c.DtAgendamentoFim.TimeOfDay >= menorHorarioDia.DtAgendamentoInicio.TimeOfDay).FirstOrDefault();
                    //Verifica se existe agendamento para aquele dia, caso não já adiciona a flag false para não marcar essa data no calendario.
                    if (auxAgendamentoPorUsuario == null)
                    {
                        auxCalendario.blnAgendado = false;
                        auxCalendario.descricao = "";
                    }
                    else
                    {
                        auxCalendario.blnAgendado = true;
                        auxCalendario.descricao = auxAgendamentoPorUsuario.Descricao;
                    }
                    calendario.Add(auxCalendario);
                }

                //System.Diagnostics.Debug.WriteLine(menorHorarioDia.DtAgendamentoInicio.ToShortTimeString());
                menorHorarioDia.DtAgendamentoInicio = menorHorarioDia.DtAgendamentoInicio.AddMinutes(30);
            }
            calendarAuxViewModel calendarAux = new calendarAuxViewModel();
            calendarAux.funcionarios = db.Employees.ToList();
            //calendario = calendario.OrderBy(c => c.nomeUsuario).ToList();
            calendarAux.itensCalendario = calendario;

            return PartialView("_PartialView_Calendar", calendarAux);
        }


    }
}