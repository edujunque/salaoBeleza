using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalaoBeleza.Models;
using SalaoBeleza.ViewModels;

namespace SalaoBeleza.Controllers
{
    public class BookingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bookings
        public async Task<ActionResult> Index()
        {

            //popula os dados do cliente para mostrar o nome na listagem
            var agendamentos = await db.Bookings.Include(c => c.Customer).Include(c => c.Employee).OrderBy(c=> c.DtAgendamentoInicio).ToListAsync();
            foreach (var item in agendamentos)
            {
               item.Customer = await db.Customers.Where(c => c.Id == item.CustomerId).FirstOrDefaultAsync();
               item.Employee = await db.Employees.Where(c => c.Id == item.EmployeesId).FirstOrDefaultAsync();
            }

            return View(agendamentos);
        }

        // GET: Bookings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = await db.Bookings.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            //incluir o customer no objeto da view
            booking.Customer = await db.Customers.Where(c => c.Id == booking.CustomerId).FirstOrDefaultAsync();
            booking.Employee = await db.Employees.Where(c => c.Id == booking.EmployeesId).FirstOrDefaultAsync();
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            var viewModel = new NewBookingViewModel();
            viewModel.Customers = db.Customers.ToList();
            viewModel.Employees = db.Employees.ToList();
            return View(viewModel);
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NewBookingViewModel booking)
        {
            if (ModelState.IsValid)
            {
                //formatando data para uo formato do banco de dados.
                //booking.Bookings.DtAgendamento = booking.Bookings.DtAgendamento.ToUniversalTime();
                booking.Bookings.DtRegistro = DateTime.Now;
                db.Bookings.Add(booking.Bookings);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = await db.Bookings.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewBookingViewModel();
            viewModel.Customers = db.Customers.ToList();
            viewModel.Employees = db.Employees.ToList();
            viewModel.Bookings = booking;
            return View(viewModel);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(NewBookingViewModel booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking.Bookings).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = await db.Bookings.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            //incluir o customer no objeto da view
            booking.Customer = await db.Customers.Where(c => c.Id == booking.CustomerId).FirstOrDefaultAsync();
            booking.Employee = await db.Employees.Where(c => c.Id == booking.EmployeesId).FirstOrDefaultAsync();
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Booking booking = await db.Bookings.FindAsync(id);
            db.Bookings.Remove(booking);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
