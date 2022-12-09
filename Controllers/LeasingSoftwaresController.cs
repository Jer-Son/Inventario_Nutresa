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
    public class LeasingSoftwaresController : Controller
    {
        private readonly Sitio_Web_Core_MVC_CRUD_EFContext _context;

        public LeasingSoftwaresController(Sitio_Web_Core_MVC_CRUD_EFContext context)
        {
            _context = context;
        }

        // GET: LeasingSoftwares
        public async Task<IActionResult> Index()
        {
            var sitio_Web_Core_MVC_CRUD_EFContext = _context.LeasingSoftware.Include(l => l.Leasing).Include(l => l.Software);
            return View(await sitio_Web_Core_MVC_CRUD_EFContext.ToListAsync());
        }

        // GET: LeasingSoftwares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LeasingSoftware == null)
            {
                return NotFound();
            }

            var leasingSoftware = await _context.LeasingSoftware
                .Include(l => l.Leasing)
                .Include(l => l.Software)
                .FirstOrDefaultAsync(m => m.IdLeasingSoftware == id);
            if (leasingSoftware == null)
            {
                return NotFound();
            }

            return View(leasingSoftware);
        }

        // GET: LeasingSoftwares/Create
        public IActionResult Create()
        {
            ViewData["LeasingId"] = new SelectList(_context.Leasing, "IdLeasing", "UsuarioRed");
            ViewData["SoftwareId"] = new SelectList(_context.Software, "IdSoftware", "SoftwareName");
            return View();
        }

        // POST: LeasingSoftwares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLeasingSoftware,SoftwareId,LeasingId")] LeasingSoftware leasingSoftware)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leasingSoftware);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeasingId"] = new SelectList(_context.Leasing, "IdLeasing", "UsuarioRed", leasingSoftware.LeasingId);
            ViewData["SoftwareId"] = new SelectList(_context.Software, "IdSoftware", "SoftwareName", leasingSoftware.SoftwareId);
            return View(leasingSoftware);
        }

        // GET: LeasingSoftwares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeasingSoftware == null)
            {
                return NotFound();
            }

            var leasingSoftware = await _context.LeasingSoftware.FindAsync(id);
            if (leasingSoftware == null)
            {
                return NotFound();
            }
            ViewData["LeasingId"] = new SelectList(_context.Leasing, "IdLeasing", "UsuarioRed", leasingSoftware.LeasingId);
            ViewData["SoftwareId"] = new SelectList(_context.Software, "IdSoftware", "SoftwareName", leasingSoftware.SoftwareId);
            return View(leasingSoftware);
        }

        // POST: LeasingSoftwares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLeasingSoftware,SoftwareId,LeasingId")] LeasingSoftware leasingSoftware)
        {
            if (id != leasingSoftware.IdLeasingSoftware)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leasingSoftware);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeasingSoftwareExists(leasingSoftware.IdLeasingSoftware))
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
            ViewData["LeasingId"] = new SelectList(_context.Leasing, "IdLeasing", "UsuarioRed", leasingSoftware.LeasingId);
            ViewData["SoftwareId"] = new SelectList(_context.Software, "IdSoftware", "SoftwareName", leasingSoftware.SoftwareId);
            return View(leasingSoftware);
        }

        // GET: LeasingSoftwares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LeasingSoftware == null)
            {
                return NotFound();
            }

            var leasingSoftware = await _context.LeasingSoftware
                .Include(l => l.Leasing)
                .Include(l => l.Software)
                .FirstOrDefaultAsync(m => m.IdLeasingSoftware == id);
            if (leasingSoftware == null)
            {
                return NotFound();
            }

            return View(leasingSoftware);
        }

        // POST: LeasingSoftwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LeasingSoftware == null)
            {
                return Problem("Entity set 'Sitio_Web_Core_MVC_CRUD_EFContext.LeasingSoftware'  is null.");
            }
            var leasingSoftware = await _context.LeasingSoftware.FindAsync(id);
            if (leasingSoftware != null)
            {
                _context.LeasingSoftware.Remove(leasingSoftware);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeasingSoftwareExists(int id)
        {
          return _context.LeasingSoftware.Any(e => e.IdLeasingSoftware == id);
        }
    }
}
