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
    public class SedesController : Controller
    {
        private readonly Sitio_Web_Core_MVC_CRUD_EFContext _context;

        public SedesController(Sitio_Web_Core_MVC_CRUD_EFContext context)
        {
            _context = context;
        }

        // GET: Sedes
        public async Task<IActionResult> Index()
        {
            var sitio_Web_Core_MVC_CRUD_EFContext = _context.Sede.Include(s => s.Empresa);
            return View(await sitio_Web_Core_MVC_CRUD_EFContext.ToListAsync());
        }

        // GET: Sedes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sede == null)
            {
                return NotFound();
            }

            var sede = await _context.Sede
                .Include(s => s.Empresa)
                .FirstOrDefaultAsync(m => m.IdSede == id);
            if (sede == null)
            {
                return NotFound();
            }

            return View(sede);
        }

        // GET: Sedes/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "IdEmpresa", "Nombre");
            return View();
        }

        // POST: Sedes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSede,Nombre,Ciudad,ResponsableTI,Contacto,Pa,OrdenInt,Cuenta,EmpresaId")] Sede sede)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sede);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "IdEmpresa", "Nombre", sede.EmpresaId);
            return View(sede);
        }

        // GET: Sedes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sede == null)
            {
                return NotFound();
            }

            var sede = await _context.Sede.FindAsync(id);
            if (sede == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "IdEmpresa", "Nombre", sede.EmpresaId);
            return View(sede);
        }

        // POST: Sedes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSede,Nombre,Ciudad,ResponsableTI,Contacto,Pa,OrdenInt,Cuenta,EmpresaId")] Sede sede)
        {
            if (id != sede.IdSede)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sede);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SedeExists(sede.IdSede))
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "IdEmpresa", "Nombre", sede.EmpresaId);
            return View(sede);
        }

        // GET: Sedes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sede == null)
            {
                return NotFound();
            }

            var sede = await _context.Sede
                .Include(s => s.Empresa)
                .FirstOrDefaultAsync(m => m.IdSede == id);
            if (sede == null)
            {
                return NotFound();
            }

            return View(sede);
        }

        // POST: Sedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sede == null)
            {
                return Problem("Entity set 'Sitio_Web_Core_MVC_CRUD_EFContext.Sede'  is null.");
            }
            var sede = await _context.Sede.FindAsync(id);
            if (sede != null)
            {
                _context.Sede.Remove(sede);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SedeExists(int id)
        {
          return _context.Sede.Any(e => e.IdSede == id);
        }
    }
}
