using Microsoft.AspNetCore.Mvc;
using Supremo.Domain.Entities;
using Supremo.Domain.Interfaces;

namespace Supremo.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentsController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var appointments = await _appointmentRepository.GetAllAsync();
            return View(appointments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                await _appointmentRepository.CreateAsync(appointment);
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _appointmentRepository.UpdateAsync(appointment);
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _appointmentRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
