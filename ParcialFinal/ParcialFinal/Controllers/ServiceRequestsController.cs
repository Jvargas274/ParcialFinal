using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParcialFinal.DAL;
using ParcialFinal.DAL.Entities;

namespace ParcialFinal.Controllers
{
    public class ServiceRequestsController : Controller
    {
        private readonly DataBaseContext _context;

        public ServiceRequestsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: ServiceRequests/ListUser
        public async Task<IActionResult> ListUser()
        {
            var dataBaseContext = _context.ServiceRequest.Include(s => s.SelectedService);
            return View(await dataBaseContext.ToListAsync());
        }

        // GET: ServiceRequests/ListAdmin
        public async Task<IActionResult> ListAdmin()
        {
            var dataBaseContext = _context.ServiceRequest.Include(s => s.SelectedService);
            return View(await dataBaseContext.ToListAsync());
        }

        // GET: ServiceRequests/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ServiceRequest == null)
            {
                return NotFound();
            }

            var serviceRequest = await _context.ServiceRequest
                .Include(s => s.SelectedService)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceRequest == null)
            {
                return NotFound();
            }

            return View(serviceRequest);
        }

        // GET: ServiceRequests/Create
        public IActionResult Create()
        {
            ViewData["SelectedServiceId"] = new SelectList(_context.Services, "Id", "Name");
            return View();
        }

        // POST: ServiceRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerName,CarId,SelectedServiceId,Id,CreateDate,ModifiedDate")] ServiceRequest serviceRequest)
        {   
            serviceRequest.Id = Guid.NewGuid();
            serviceRequest.CreateDate = DateTime.Now;
            serviceRequest.ModifiedDate = DateTime.Now;

            _context.Add(serviceRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction("ListUser", "ServiceRequests");
        }

        // GET: ServiceRequests/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ServiceRequest == null)
            {
                return NotFound();
            }

            var serviceRequest = await _context.ServiceRequest.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound();
            }
            ViewData["SelectedServiceId"] = new SelectList(_context.Services, "Id", "Name", serviceRequest.SelectedServiceId);
            return View(serviceRequest);
        }

        // POST: ServiceRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CustomerName,CarId,SelectedServiceId,Id,CreateDate,ModifiedDate,DeliveryDate")] ServiceRequest serviceRequest)
        {
            if (id != serviceRequest.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(serviceRequest);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceRequestExists(serviceRequest.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("ListAdmin", "ServiceRequests");
        }

        // GET: ServiceRequests/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ServiceRequest == null)
            {
                return NotFound();
            }

            var serviceRequest = await _context.ServiceRequest
                .Include(s => s.SelectedService)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceRequest == null)
            {
                return NotFound();
            }

            return View(serviceRequest);
        }

        // POST: ServiceRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ServiceRequest == null)
            {
                return Problem("Entity set 'DataBaseContext.ServiceRequest'  is null.");
            }
            var serviceRequest = await _context.ServiceRequest.FindAsync(id);
            if (serviceRequest != null)
            {
                _context.ServiceRequest.Remove(serviceRequest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceRequestExists(Guid id)
        {
          return (_context.ServiceRequest?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
