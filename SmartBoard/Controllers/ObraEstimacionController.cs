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
    public class ObraEstimacionController : Controller
    {
        private readonly SmartBoardContext _context;

        public ObraEstimacionController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: ObraEstimacion
        public async Task<IActionResult> Index()
        {
            var smartBoardContext = _context.TblObraEstimacions.Include(t => t.IdTblobraNavigation);
            return View(await smartBoardContext.ToListAsync());
        }

        // GET: ObraEstimacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblObraEstimacion = await _context.TblObraEstimacions
                .Include(t => t.IdTblobraNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblObraEstimacion == null)
            {
                return NotFound();
            }

            return View(tblObraEstimacion);
        }

        // GET: ObraEstimacion/Create
        public IActionResult Create(int IdTblobra)
        {
            ViewData["IdTblobra"] = new SelectList(_context.TblObras, "Id", "Id", IdTblobra);
            ViewData["miIdObra"] = IdTblobra;
            return View();
        }

        // POST: ObraEstimacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblObraEstimacion tblObraEstimacion)
        {
            tblObraEstimacion.Activo = true;
            tblObraEstimacion.Registro = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(tblObraEstimacion);
                await _context.SaveChangesAsync();
                return RedirectToAction("EditExpediente", "TblObras", new { id = tblObraEstimacion.IdTblobra });
                //return RedirectToAction(nameof(Index));
            }
            ViewData["IdTblobra"] = new SelectList(_context.TblObras, "Id", "Id", tblObraEstimacion.IdTblobra);
            ViewData["miIdObra"] = tblObraEstimacion.IdTblobra;
            //return View("Create", "ObraEstimacion", tblObraEstimacion);
            //return RedirectToAction("Create", "ObraEstimacion", new { id = tblObraEstimacion.IdTblobra, tblObraEstimacion = tblObraEstimacion });
            return View(tblObraEstimacion);
        }

        // GET: ObraEstimacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblObraEstimacion = await _context.TblObraEstimacions.FindAsync(id);
            if (tblObraEstimacion == null)
            {
                return NotFound();
            }
            ViewData["IdTblobra"] = new SelectList(_context.TblObras, "Id", "Id", tblObraEstimacion.IdTblobra);
            return View(tblObraEstimacion);
        }

        // POST: ObraEstimacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTblobra,IdFactura,Numero,NumFactura,FechaFactura,FechaEstimacion,MontoPagarSinIva,AmortizadoSinIva,Subtotal,SubtotalConIva,CincoMillarSinIva,MontoNetoPagar,Retencion,Devolucion,AvenceFisicoProgramado,AvanceFisicoReal,AvanceFinancieron,FechaPago,Pagado,Activo,Registro")] TblObraEstimacion tblObraEstimacion)
        {
            if (id != tblObraEstimacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblObraEstimacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblObraEstimacionExists(tblObraEstimacion.Id))
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
            ViewData["IdTblobra"] = new SelectList(_context.TblObras, "Id", "Id", tblObraEstimacion.IdTblobra);
            return View(tblObraEstimacion);
        }

        // GET: ObraEstimacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblObraEstimacion = await _context.TblObraEstimacions
                .Include(t => t.IdTblobraNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblObraEstimacion == null)
            {
                return NotFound();
            }

            return View(tblObraEstimacion);
        }

        // POST: ObraEstimacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblObraEstimacion = await _context.TblObraEstimacions.FindAsync(id);
            _context.TblObraEstimacions.Remove(tblObraEstimacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblObraEstimacionExists(int id)
        {
            return _context.TblObraEstimacions.Any(e => e.Id == id);
        }
    }
}
