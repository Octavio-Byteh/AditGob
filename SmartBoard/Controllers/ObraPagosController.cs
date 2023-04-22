using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartBoard.Data.Models.SmartBoard;

namespace SmartBoard.Controllers
{
    public class ObraPagosController : Controller
    {
        private readonly SmartBoardContext _context;

        public ObraPagosController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: ObraPagos
        public async Task<IActionResult> Index()
        {
            var smartBoardContext = _context.TblObraPagos.Include(t => t.IdTblobraNavigation);
            return View(await smartBoardContext.ToListAsync());
        }

        // GET: ObraPagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblObraPagos == null)
            {
                return NotFound();
            }

            var tblObraPago = await _context.TblObraPagos
                .Include(t => t.IdTblobraNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblObraPago == null)
            {
                return NotFound();
            }

            return View(tblObraPago);
        }

        // GET: ObraPagos/Create
        public IActionResult Create(int? IdTblobra)
        {
            if (IdTblobra == null)
            {
                return NotFound();
            }

            ViewData["IdTblobra"] = new SelectList(_context.TblObras, "Id", "Id", IdTblobra);
            ViewData["miIdObra"] = IdTblobra;
            return View();
        }

        // POST: ObraPagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( TblObraPago tblObraPago)
        {
            tblObraPago.Activo = true;
            tblObraPago.Registro = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(tblObraPago);
                await _context.SaveChangesAsync();
                return RedirectToAction("EditExpediente", "TblObras", new { id = tblObraPago.IdTblobra });
                //return RedirectToAction(nameof(Index));
            }
            ViewData["IdTblobra"] = new SelectList(_context.TblObras, "Id", "Id", tblObraPago.IdTblobra);
            ViewData["miIdObra"] = tblObraPago.IdTblobra;
            return View(tblObraPago);
        }

        // GET: ObraPagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblObraPagos == null)
            {
                return NotFound();
            }

            var tblObraPago = await _context.TblObraPagos.FindAsync(id);
            if (tblObraPago == null)
            {
                return NotFound();
            }
            ViewData["IdTblobra"] = new SelectList(_context.TblObras, "Id", "Id", tblObraPago.IdTblobra);
            return View(tblObraPago);
        }

        // POST: ObraPagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTblobra,IdFactura,Numero,NumFactura,FechaFactura,SolicitudPago,OrdenPago,ImporteTotal,Pago,FechaPago,Activo,Registro,RutaArchivoFactura,RutaArchivoEvidencia,NombreArchivoFactura,NombreArchivoEvidencia")] TblObraPago tblObraPago)
        {
            if (id != tblObraPago.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblObraPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblObraPagoExists(tblObraPago.Id))
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
            ViewData["IdTblobra"] = new SelectList(_context.TblObras, "Id", "Id", tblObraPago.IdTblobra);
            return View(tblObraPago);
        }

        // GET: ObraPagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblObraPagos == null)
            {
                return NotFound();
            }

            var tblObraPago = await _context.TblObraPagos
                .Include(t => t.IdTblobraNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblObraPago == null)
            {
                return NotFound();
            }

            return View(tblObraPago);
        }

        // POST: ObraPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblObraPagos == null)
            {
                return Problem("Entity set 'SmartBoardContext.TblObraPagos'  is null.");
            }
            var tblObraPago = await _context.TblObraPagos.FindAsync(id);
            if (tblObraPago != null)
            {
                _context.TblObraPagos.Remove(tblObraPago);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblObraPagoExists(int id)
        {
          return _context.TblObraPagos.Any(e => e.Id == id);
        }
    }
}
