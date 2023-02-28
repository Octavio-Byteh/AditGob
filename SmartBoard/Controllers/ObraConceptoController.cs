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
    public class ObraConceptoController : Controller
    {
        private readonly SmartBoardContext _context;

        public ObraConceptoController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: ObraConcepto
        public async Task<IActionResult> Index()
        {
            var smartBoardContext = _context.TblObraconceptos.Include(t => t.IdTblobraNavigation);
            return View(await smartBoardContext.ToListAsync());
        }

        // GET: ObraConcepto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblObraconcepto = await _context.TblObraconceptos
                .Include(t => t.IdTblobraNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblObraconcepto == null)
            {
                return NotFound();
            }

            return View(tblObraconcepto);
        }

        // GET: ObraConcepto/Create
        public IActionResult Create(int IdTblobra, int tipo)
        {
            ViewData["Idtipoconcepto"] = new SelectList(_context.CatTipoConceptos.Where(a=>a.Id == tipo), "Id", "Nombre", tipo);
            ViewData["miIdObra"] = IdTblobra;
            ViewData["tipo"] = tipo;
            ViewData["IdTblobra"] = new SelectList(_context.TblObras, "Id", "Id",IdTblobra);
            return View();
        }

        // POST: ObraConcepto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblObraconcepto tblObraconcepto)
        {
            //tblObraconcepto.Cantidad = 1;
            tblObraconcepto.Fecha = DateTime.Now;
            tblObraconcepto.Activo = true;
            tblObraconcepto.Idtipoconcepto = tblObraconcepto.Idtipoconcepto;
            tblObraconcepto.Importe = tblObraconcepto.PrecioUnitario * tblObraconcepto.Cantidad;


            if (ModelState.IsValid)
            {
                _context.Add(tblObraconcepto);
                await _context.SaveChangesAsync();
                return RedirectToAction("EditExpediente", "TblObras", new { id = tblObraconcepto.IdTblobra });
                //return RedirectToAction(nameof(Index));
            }
            ViewData["Idtipoconcepto"] = new SelectList(_context.CatTipoConceptos, "Id", "Nombre", tblObraconcepto.Idtipoconcepto);
            ViewData["IdTblobra"] = new SelectList(_context.TblObras, "Id", "Id", tblObraconcepto.IdTblobra);
            ViewData["miIdObra"] = tblObraconcepto.IdTblobra;
            ViewData["tipo"] = tblObraconcepto.Idtipoconcepto;
            return View(tblObraconcepto);
        }

        // GET: ObraConcepto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblObraconcepto = await _context.TblObraconceptos.FindAsync(id);
            if (tblObraconcepto == null)
            {
                return NotFound();
            }
            ViewData["IdTblobra"] = new SelectList(_context.TblObras, "Id", "Id", tblObraconcepto.IdTblobra);
            return View(tblObraconcepto);
        }

        // POST: ObraConcepto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTblobra,Cantidad,Importe,Activo,Fecha,Observaciones,Tipo")] TblObraconcepto tblObraconcepto)
        {
            if (id != tblObraconcepto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblObraconcepto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblObraconceptoExists(tblObraconcepto.Id))
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
            ViewData["IdTblobra"] = new SelectList(_context.TblObras, "Id", "Id", tblObraconcepto.IdTblobra);
            return View(tblObraconcepto);
        }

        // GET: ObraConcepto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblObraconcepto = await _context.TblObraconceptos
                .Include(t => t.IdTblobraNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblObraconcepto == null)
            {
                return NotFound();
            }

            return View(tblObraconcepto);
        }

        // POST: ObraConcepto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblObraconcepto = await _context.TblObraconceptos.FindAsync(id);
            _context.TblObraconceptos.Remove(tblObraconcepto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblObraconceptoExists(int id)
        {
            return _context.TblObraconceptos.Any(e => e.Id == id);
        }
    }
}
