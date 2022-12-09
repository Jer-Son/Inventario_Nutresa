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
    public class OperacionsController : Controller
    {
        private readonly Sitio_Web_Core_MVC_CRUD_EFContext _context;

        public OperacionsController(Sitio_Web_Core_MVC_CRUD_EFContext context)
        {
            _context = context;
        }

        // GET: Operacions
        public async Task<IActionResult> Index()
        {
            var sitio_Web_Core_MVC_CRUD_EFContext = _context.Operacion.Include(o => o.Area);
            return View(await sitio_Web_Core_MVC_CRUD_EFContext.ToListAsync());
        }

        // GET: Operacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Operacion == null)
            {
                return NotFound();
            }

            var operacion = await _context.Operacion
                .Include(o => o.Area)
                .FirstOrDefaultAsync(m => m.IdOperacion == id);
            if (operacion == null)
            {
                return NotFound();
            }

            return View(operacion);
        }

        // GET: Operacions/Create
        public IActionResult Create()
        {
            ViewData["AreaId"] = new SelectList(_context.Area, "IdArea", "AreaName");
            return View();
        }

        // POST: Operacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOperacion,OperacionName,AreaId")] Operacion operacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_context.Area, "IdArea", "AreaName", operacion.AreaId);
            return View(operacion);
        }

        // GET: Operacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Operacion == null)
            {
                return NotFound();
            }

            var operacion = await _context.Operacion.FindAsync(id);
            if (operacion == null)
            {
                return NotFound();
            }
            ViewData["AreaId"] = new SelectList(_context.Area, "IdArea", "AreaName", operacion.AreaId);
            return View(operacion);
        }

        // POST: Operacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOperacion,OperacionName,AreaId")] Operacion operacion)
        {
            if (id != operacion.IdOperacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperacionExists(operacion.IdOperacion))
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
            ViewData["AreaId"] = new SelectList(_context.Area, "IdArea", "AreaName", operacion.AreaId);
            return View(operacion);
        }

        // GET: Operacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Operacion == null)
            {
                return NotFound();
            }

            var operacion = await _context.Operacion
                .Include(o => o.Area)
                .FirstOrDefaultAsync(m => m.IdOperacion == id);
            if (operacion == null)
            {
                return NotFound();
            }

            return View(operacion);
        }

        // POST: Operacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Operacion == null)
            {
                return Problem("Entity set 'Sitio_Web_Core_MVC_CRUD_EFContext.Operacion'  is null.");
            }
            var operacion = await _context.Operacion.FindAsync(id);
            if (operacion != null)
            {
                _context.Operacion.Remove(operacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperacionExists(int id)
        {
          return _context.Operacion.Any(e => e.IdOperacion == id);
        }
    }
}
