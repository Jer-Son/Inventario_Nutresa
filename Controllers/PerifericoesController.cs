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
    public class PerifericoesController : Controller
    {
        private readonly Sitio_Web_Core_MVC_CRUD_EFContext _context;

        public PerifericoesController(Sitio_Web_Core_MVC_CRUD_EFContext context)
        {
            _context = context;
        }

        // GET: Perifericoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Periferico.ToListAsync());
        }

        // GET: Perifericoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Periferico == null)
            {
                return NotFound();
            }

            var periferico = await _context.Periferico
                .FirstOrDefaultAsync(m => m.IdPeriferico == id);
            if (periferico == null)
            {
                return NotFound();
            }

            return View(periferico);
        }

        // GET: Perifericoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perifericoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeriferico,PerifericoName,Serial")] Periferico periferico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(periferico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(periferico);
        }

        // GET: Perifericoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Periferico == null)
            {
                return NotFound();
            }

            var periferico = await _context.Periferico.FindAsync(id);
            if (periferico == null)
            {
                return NotFound();
            }
            return View(periferico);
        }

        // POST: Perifericoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPeriferico,PerifericoName,Serial")] Periferico periferico)
        {
            if (id != periferico.IdPeriferico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periferico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerifericoExists(periferico.IdPeriferico))
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
            return View(periferico);
        }

        // GET: Perifericoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Periferico == null)
            {
                return NotFound();
            }

            var periferico = await _context.Periferico
                .FirstOrDefaultAsync(m => m.IdPeriferico == id);
            if (periferico == null)
            {
                return NotFound();
            }

            return View(periferico);
        }

        // POST: Perifericoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Periferico == null)
            {
                return Problem("Entity set 'Sitio_Web_Core_MVC_CRUD_EFContext.Periferico'  is null.");
            }
            var periferico = await _context.Periferico.FindAsync(id);
            if (periferico != null)
            {
                _context.Periferico.Remove(periferico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerifericoExists(int id)
        {
          return _context.Periferico.Any(e => e.IdPeriferico == id);
        }
    }
}
