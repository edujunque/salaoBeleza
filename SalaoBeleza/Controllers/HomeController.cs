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

        [OutputCache(Duration = 0)]
        public ActionResult CarregaCalendario(string dataFiltro = "")
        {
            //TODO - Alterar data abaixo para parametro recebido na controller
            DateTime strFiltroData = DateTime.Today;
            if (dataFiltro == "")
            {
                //não precisa atualizar a data.
                //DateTime strFiltroData = DateTime.Today;
            }
            else
            {
                strFiltroData = Convert.ToDateTime(dataFiltro);
            }

            //Monta Logica para carregar a view
            //obtem o maior e menor horario daquele dia
            Booking menorHorarioDia = db.Bookings.Where(c => c.DtAgendamentoInicio.Year == strFiltroData.Year && c.DtAgendamentoInicio.Month == strFiltroData.Month && c.DtAgendamentoInicio.Day == strFiltroData.Day).OrderBy(c => c.DtAgendamentoInicio).Take(1).FirstOrDefault();
            Booking maiorHorarioDia = db.Bookings.Where(c => c.DtAgendamentoFim.Year == strFiltroData.Year && c.DtAgendamentoFim.Month == strFiltroData.Month && c.DtAgendamentoFim.Day == strFiltroData.Day).OrderByDescending(c => c.DtAgendamentoFim).Take(1).FirstOrDefault();

            //Adiciona e subtrai uma hora de cada extremo para que o calendario tenha um "respiro" de visualização
            //menorHorarioDia.DtAgendamentoInicio = menorHorarioDia.DtAgendamentoInicio.AddHours(-1);
            //maiorHorarioDia.DtAgendamentoFim = maiorHorarioDia.DtAgendamentoFim.AddHours(1);

            //Verifica se existe algum registro para o dia filtrado
            if (menorHorarioDia == null || maiorHorarioDia == null)
            {
                //não há registros, retorna model vazia para tratar na view
                calendarAuxViewModel calendarEmpty = new calendarAuxViewModel();
                return PartialView("_PartialView_Calendar", calendarEmpty);
            }
            DateTime auxMenorHorario = menorHorarioDia.DtAgendamentoInicio.AddHours(-1);
            DateTime auxMaiorHorario = maiorHorarioDia.DtAgendamentoFim.AddHours(1);

            List<Employees> listaFuncionarios = db.Employees.OrderBy(c => c.Name).ToList();

            //cria instancia da viewModel
            List<calendarViewModel> calendario = new List<calendarViewModel>();
            //While que percorre todos os horarios que precisam ser listados naquele dia.
            while (auxMenorHorario <= auxMaiorHorario)
            {

                //Percorre Listagem de funcionarios para criar todas as linhas daquele horario
                foreach (var item in listaFuncionarios)
                {
                    calendarViewModel auxCalendario = new calendarViewModel();
                    auxCalendario.strHorario = auxMenorHorario.ToShortTimeString();
                    auxCalendario.nomeUsuario = item.Name;

                    //verifica se o esse usuario esta com esse horario agendado, filtra pelo ID do usuario, dia selecionado no filtro e horario.
                    List<Booking> agendamentoPorUsuario = new List<Booking>();
                    agendamentoPorUsuario = db.Bookings.Where(c => c.EmployeesId == item.Id && c.DtAgendamentoInicio.Year == auxMenorHorario.Year && c.DtAgendamentoInicio.Month == auxMenorHorario.Month && c.DtAgendamentoInicio.Day == auxMenorHorario.Day).ToList();
                    //agendamentoPorUsuario = db.Bookings.Where(c => c.EmployeesId == item.Id).ToList();
                    //Filtro Hora
                    //&& ((c.DtAgendamentoInicio.Hour >= auxMenorHorario.Hour && c.DtAgendamentoInicio.Minute >= auxMenorHorario.Minute) && (c.DtAgendamentoFim.Hour <= auxMenorHorario.Hour && c.DtAgendamentoFim.Minute <= auxMenorHorario.Minute))
                    var auxAgendamentoPorUsuario =  agendamentoPorUsuario.Where(c => c.DtAgendamentoInicio.TimeOfDay <= auxMenorHorario.TimeOfDay && c.DtAgendamentoFim.TimeOfDay > auxMenorHorario.TimeOfDay).FirstOrDefault();
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

                //System.Diagnostics.Debug.WriteLine(auxMenorHorario.ToShortTimeString());
                auxMenorHorario = auxMenorHorario.AddMinutes(30);
            }
            calendarAuxViewModel calendarAux = new calendarAuxViewModel();
            calendarAux.funcionarios = db.Employees.ToList();
            //calendario = calendario.OrderBy(c => c.nomeUsuario).ToList();
            calendarAux.itensCalendario = calendario;

            return PartialView("_PartialView_Calendar", calendarAux);
        }


    }
}