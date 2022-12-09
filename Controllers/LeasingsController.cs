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
    public class LeasingsController : Controller
    {
        private readonly Sitio_Web_Core_MVC_CRUD_EFContext _context;

        public LeasingsController(Sitio_Web_Core_MVC_CRUD_EFContext context)
        {
            _context = context;
        }

        // GET: Leasings
        public async Task<IActionResult> Index()
        {
            var sitio_Web_Core_MVC_CRUD_EFContext = _context.Leasing.Include(l => l.Equipo).Include(l => l.Usuario);
            return View(await sitio_Web_Core_MVC_CRUD_EFContext.ToListAsync());
        }

        // GET: Leasings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Leasing == null)
            {
                return NotFound();
            }

            var leasing = await _context.Leasing
                .Include(l => l.Equipo)
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.IdLeasing == id);
            if (leasing == null)
            {
                return NotFound();
            }

            return View(leasing);
        }

        // GET: Leasings/Create
        public IActionResult Create()
        {
            ViewData["EquipoId"] = new SelectList(_context.Equipo, "IdEquipo", "NombreMaquina");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "IdUsuario", "Name");
            return View();
        }

        // POST: Leasings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLeasing,Analista,FechaInicio,FechaFinal,Propiedad,Estado,UsuarioRed,Fecha,Observacion,UsuarioId,EquipoId")] Leasing leasing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leasing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipoId"] = new SelectList(_context.Equipo, "IdEquipo", "NombreMaquina", leasing.EquipoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "IdUsuario", "Name", leasing.UsuarioId);
            return View(leasing);
        }

        // GET: Leasings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Leasing == null)
            {
                return NotFound();
            }

            var leasing = await _context.Leasing.FindAsync(id);
            if (leasing == null)
            {
                return NotFound();
            }
            ViewData["EquipoId"] = new SelectList(_context.Equipo, "IdEquipo", "NombreMaquina", leasing.EquipoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "IdUsuario", "Name", leasing.UsuarioId);
            return View(leasing);
        }

        // POST: Leasings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLeasing,Analista,FechaInicio,FechaFinal,Propiedad,Estado,UsuarioRed,Fecha,Observacion,UsuarioId,EquipoId")] Leasing leasing)
        {
            if (id != leasing.IdLeasing)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leasing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeasingExists(leasing.IdLeasing))
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
            ViewData["EquipoId"] = new SelectList(_context.Equipo, "IdEquipo", "NombreMaquina", leasing.EquipoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "IdUsuario", "Name", leasing.UsuarioId);
            return View(leasing);
        }

        // GET: Leasings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Leasing == null)
            {
                return NotFound();
            }

            var leasing = await _context.Leasing
                .Include(l => l.Equipo)
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.IdLeasing == id);
            if (leasing == null)
            {
                return NotFound();
            }

            return View(leasing);
        }

        // POST: Leasings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Leasing == null)
            {
                return Problem("Entity set 'Sitio_Web_Core_MVC_CRUD_EFContext.Leasing'  is null.");
            }
            var leasing = await _context.Leasing.FindAsync(id);
            if (leasing != null)
            {
                _context.Leasing.Remove(leasing);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeasingExists(int id)
        {
          return _context.Leasing.Any(e => e.IdLeasing == id);
        }
    }
}
