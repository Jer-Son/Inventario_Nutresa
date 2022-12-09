using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sitio_Web_Core_MVC_CRUD_EF.Data;
using Sitio_Web_Core_MVC_CRUD_EF.Models;

namespace Sitio_Web_Core_MVC_CRUD_EF.Controllers
{
    public class SoftwaresController : Controller
    {
        private readonly Sitio_Web_Core_MVC_CRUD_EFContext _context;

        public SoftwaresController(Sitio_Web_Core_MVC_CRUD_EFContext context)
        {
            _context = context;
        }

        // GET: Softwares
        public async Task<IActionResult> Index()
        {
              return View(await _context.Software.ToListAsync());
        }

        // GET: Softwares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Software == null)
            {
                return NotFound();
            }

            var software = await _context.Software
                .FirstOrDefaultAsync(m => m.IdSoftware == id);
            if (software == null)
            {
                return NotFound();
            }

            return View(software);
        }

        // GET: Softwares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Softwares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSoftware,SoftwareName,Softwarelicencia,SoftwareVersion")] Software software)
        {
            if (ModelState.IsValid)
            {
                _context.Add(software);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(software);
        }

        // GET: Softwares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Software == null)
            {
                return NotFound();
            }

            var software = await _context.Software.FindAsync(id);
            if (software == null)
            {
                return NotFound();
            }
            return View(software);
        }

        // POST: Softwares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSoftware,SoftwareName,Softwarelicencia,SoftwareVersion")] Software software)
        {
            if (id != software.IdSoftware)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(software);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoftwareExists(software.IdSoftware))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(software);
        }

        // GET: Softwares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Software == null)
            {
                return NotFound();
            }

            var software = await _context.Software
                .FirstOrDefaultAsync(m => m.IdSoftware == id);
            if (software == null)
            {
                return NotFound();
            }

            return View(software);
        }

        // POST: Softwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Software == null)
            {
                return Problem("Entity set 'Sitio_Web_Core_MVC_CRUD_EFContext.Software'  is null.");
            }
            var software = await _context.Software.FindAsync(id);
            if (software != null)
            {
                _context.Software.Remove(software);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoftwareExists(int id)
        {
          return _context.Software.Any(e => e.IdSoftware == id);
        }
    }
}
