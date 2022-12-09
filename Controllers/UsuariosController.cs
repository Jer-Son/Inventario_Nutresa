using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Exceptions.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Sitio_Web_Core_MVC_CRUD_EF.Data;
using Sitio_Web_Core_MVC_CRUD_EF.Models;

namespace Sitio_Web_Core_MVC_CRUD_EF.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Sitio_Web_Core_MVC_CRUD_EFContext _context;

        public UsuariosController(Sitio_Web_Core_MVC_CRUD_EFContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index(string buscar)
        {

           // var Sitio_Web_Core_MVC_CRUD_EFContext = _context.Usuario.Include(u => u.Cargo).Include(u => u.Operacion).Include(u => u.Sede);
            var usuarios = from usuario in _context.Usuario.Include(u => u.Cargo).Include(u => u.Operacion).Include(u => u.Sede) select usuario;
           
            if (!string.IsNullOrEmpty(buscar))
            {
                usuarios=usuarios.Where(u => u.Name!.Contains(buscar));
            }
           
            return View(await usuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.Cargo)
                .Include(u => u.Operacion)
                .Include(u => u.Sede)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["CargoId"] = new SelectList(_context.Cargo, "IdCargo", "NameCargo");
            ViewData["OperacionId"] = new SelectList(_context.Operacion, "IdOperacion", "OperacionName");
            ViewData["SedeId"] = new SelectList(_context.Sede, "IdSede", "Nombre");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Cedula,Name,Correo,celular,extenseion,OperacionId,SedeId,CargoId")] Usuario usuario)
        {
           
                if (ModelState.IsValid)
                {
                try
                {
                    _context.Add(usuario);
                    
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    ModelState.AddModelError("", "Error al Registrar Usuario por que la cedula ya existe");
                }


            }

                ViewData["CargoId"] = new SelectList(_context.Cargo, "IdCargo", "NameCargo", usuario.CargoId);
                ViewData["OperacionId"] = new SelectList(_context.Operacion, "IdOperacion", "OperacionName", usuario.OperacionId);
                ViewData["SedeId"] = new SelectList(_context.Sede, "IdSede", "Nombre", usuario.SedeId);
                return View(usuario);
           
           
        }
        public virtual void HandleException(Exception exception)
        {
            if (exception is DbUpdateConcurrencyException concurrencyEx)
            {
                // A custom exception of yours for concurrency issues
                throw new DBConcurrencyException();
            }
            else if (exception is DbUpdateException dbUpdateEx)
            {
                if (dbUpdateEx.InnerException != null
                        && dbUpdateEx.InnerException.InnerException != null)
                {
                    if (dbUpdateEx.InnerException.InnerException is SqlException sqlException)
                    {
                        switch (sqlException.Number)
                        {
                            case 2627:  // Unique constraint error
                            case 547:   // Constraint check violation
                            case 2601:  // Duplicated key row error
                                        // Constraint violation exception
                                        // A custom exception of yours for concurrency issues
                                throw new DBConcurrencyException();
                            default:
                                // A custom exception of yours for other DB issues
                                throw new DBConcurrencyException(
                                  dbUpdateEx.Message, dbUpdateEx.InnerException);
                        }
                    }

                    throw new Exception(dbUpdateEx.Message, dbUpdateEx.InnerException);
                }
            }

            // If we're here then no exception has been thrown
            // So add another piece of code below for other exceptions not yet handled...
        }
        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["CargoId"] = new SelectList(_context.Cargo, "IdCargo", "NameCargo", usuario.CargoId);
            ViewData["OperacionId"] = new SelectList(_context.Operacion, "IdOperacion", "OperacionName", usuario.OperacionId);
            ViewData["SedeId"] = new SelectList(_context.Sede, "IdSede", "Nombre", usuario.SedeId);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Cedula,Name,Correo,celular,extenseion,OperacionId,SedeId,CargoId")] Usuario usuario)
        {

            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {

                        _context.Update(usuario);
                        await _context.SaveChangesAsync();
                    }

                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UsuarioExists(usuario.IdUsuario))
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
            }
            catch (Exception ex)
            {
                HandleException(ex);
                ModelState.AddModelError("", "Error al Registrar Usuario por que la cedula ya existe");
            }

            ViewData["CargoId"] = new SelectList(_context.Cargo, "IdCargo", "NameCargo", usuario.CargoId);
            ViewData["OperacionId"] = new SelectList(_context.Operacion, "IdOperacion", "OperacionName", usuario.OperacionId);
            ViewData["SedeId"] = new SelectList(_context.Sede, "IdSede", "Nombre", usuario.SedeId);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.Cargo)
                .Include(u => u.Operacion)
                .Include(u => u.Sede)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'Sitio_Web_Core_MVC_CRUD_EFContext.Usuario'  is null.");
            }
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return _context.Usuario.Any(e => e.IdUsuario == id);
        }
    }
}
