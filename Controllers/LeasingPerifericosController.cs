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
    public class LeasingPerifericosController : Controller
    {
        private readonly Sitio_Web_Core_MVC_CRUD_EFContext _context;

        public LeasingPerifericosController(Sitio_Web_Core_MVC_CRUD_EFContext context)
        {
            _context = context;
        }

        // GET: LeasingPerifericos
        public async Task<IActionResult> Index()
        {
            var sitio_Web_Core_MVC_CRUD_EFContext = _context.LeasingPerifericos.Include(l => l.Leasing).Include(l => l.Periferico);
            return View(await sitio_Web_Core_MVC_CRUD_EFContext.ToListAsync());
        }

        // GET: LeasingPerifericos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LeasingPerifericos == null)
            {
                return NotFound();
            }

            var leasingPerifericos = await _context.LeasingPerifericos
                .Include(l => l.Leasing)
                .Include(l => l.Periferico)
                .FirstOrDefaultAsync(m => m.IdLeasingPerifericos == id);
            if (leasingPerifericos == null)
            {
                return NotFound();
            }

            return View(leasingPerifericos);
        }

        // GET: LeasingPerifericos/Create
        public IActionResult Create()
        {
            ViewData["LeasingId"] = new SelectList(_context.Leasing, "IdLeasing", "UsuarioRed");
            ViewData["PerifericoId"] = new SelectList(_context.Periferico, "IdPeriferico", "PerifericoName");
            return View();
        }

        // POST: LeasingPerifericos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLeasingPerifericos,PerifericoId,LeasingId")] LeasingPerifericos leasingPerifericos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leasingPerifericos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeasingId"] = new SelectList(_context.Leasing, "IdLeasing", "UsuarioRed", leasingPerifericos.LeasingId);
            ViewData["PerifericoId"] = new SelectList(_context.Periferico, "IdPeriferico", "PerifericoName", leasingPerifericos.PerifericoId);
            return View(leasingPerifericos);
        }

        // GET: LeasingPerifericos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeasingPerifericos == null)
            {
                return NotFound();
            }

            var leasingPerifericos = await _context.LeasingPerifericos.FindAsync(id);
            if (leasingPerifericos == null)
            {
                return NotFound();
            }
            ViewData["LeasingId"] = new SelectList(_context.Leasing, "IdLeasing", "UsuarioRed", leasingPerifericos.LeasingId);
            ViewData["PerifericoId"] = new SelectList(_context.Periferico, "IdPeriferico", "PerifericoName", leasingPerifericos.PerifericoId);
            return View(leasingPerifericos);
        }

        // POST: LeasingPerifericos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLeasingPerifericos,PerifericoId,LeasingId")] LeasingPerifericos leasingPerifericos)
        {
            if (id != leasingPerifericos.IdLeasingPerifericos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leasingPerifericos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeasingPerifericosExists(leasingPerifericos.IdLeasingPerifericos))
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
            ViewData["LeasingId"] = new SelectList(_context.Leasing, "IdLeasing", "UsuarioRed", leasingPerifericos.LeasingId);
            ViewData["PerifericoId"] = new SelectList(_context.Periferico, "IdPeriferico", "PerifericoName", leasingPerifericos.PerifericoId);
            return View(leasingPerifericos);
        }

        // GET: LeasingPerifericos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LeasingPerifericos == null)
            {
                return NotFound();
            }

            var leasingPerifericos = await _context.LeasingPerifericos
                .Include(l => l.Leasing)
                .Include(l => l.Periferico)
                .FirstOrDefaultAsync(m => m.IdLeasingPerifericos == id);
            if (leasingPerifericos == null)
            {
                return NotFound();
            }

            return View(leasingPerifericos);
        }

        // POST: LeasingPerifericos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LeasingPerifericos == null)
            {
                return Problem("Entity set 'Sitio_Web_Core_MVC_CRUD_EFContext.LeasingPerifericos'  is null.");
            }
            var leasingPerifericos = await _context.LeasingPerifericos.FindAsync(id);
            if (leasingPerifericos != null)
            {
                _context.LeasingPerifericos.Remove(leasingPerifericos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeasingPerifericosExists(int id)
        {
          return _context.LeasingPerifericos.Any(e => e.IdLeasingPerifericos == id);
        }
    }
}
