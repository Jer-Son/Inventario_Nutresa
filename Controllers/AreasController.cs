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
    public class AreasController : Controller
    {
        private readonly Sitio_Web_Core_MVC_CRUD_EFContext _context;

        public AreasController(Sitio_Web_Core_MVC_CRUD_EFContext context)
        {
            _context = context;
        }

        // GET: Areas
        public async Task<IActionResult> Index(string buscar)
        {
            var areas = from Area in _context.Area select Area;

            if (!string.IsNullOrEmpty(buscar))
            {
                areas = areas.Where(u => u.AreaName!.Contains(buscar));
            }
            return View(await _context.Area.ToListAsync());
        }

        // GET: Areas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null || _context.Area == null)
            {
                return NotFound();
            }
            var areas = from Area in _context.Area.Include(u => u.Operaciones) select Area;
            var Operaciones = _context.Area
                        .Include("Operaciones")
                        .ToList();
            // var area = await _context.Area
            //  .FirstOrDefaultAsync(m => m.IdArea == id);
            if (areas == null)
            {
                return NotFound();
            }
            else
            {
                foreach (var Operacion in Operaciones)
                {
                    Console.WriteLine(Operacion.ToString());
                }
            }
   
          
           
            return View(areas);
        }

        // GET: Areas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Areas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArea,AreaName")] Area area)
        {
            if (ModelState.IsValid)
            {
                _context.Add(area);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(area);
        }

        // GET: Areas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Area == null)
            {
                return NotFound();
            }

            var area = await _context.Area.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }
            return View(area);
        }

        // POST: Areas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArea,AreaName")] Area area)
        {
            if (id != area.IdArea)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(area);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaExists(area.IdArea))
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
            return View(area);
        }

        // GET: Areas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Area == null)
            {
                return NotFound();
            }

            var area = await _context.Area
                .FirstOrDefaultAsync(m => m.IdArea == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Area == null)
            {
                return Problem("Entity set 'Sitio_Web_Core_MVC_CRUD_EFContext.Area'  is null.");
            }
            var area = await _context.Area.FindAsync(id);
            if (area != null)
            {
                _context.Area.Remove(area);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaExists(int id)
        {
          return _context.Area.Any(e => e.IdArea == id);
        }
    }
}
