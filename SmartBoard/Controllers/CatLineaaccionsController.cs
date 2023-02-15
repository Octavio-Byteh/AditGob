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
    public class CatLineaaccionsController : Controller
    {
        private readonly SmartBoardContext _context;

        public CatLineaaccionsController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: CatLineaaccions
        public async Task<IActionResult> Index()
        {
            var smartBoardContext = _context.CatLineaaccions.Include(c => c.IdestrategiaNavigation);
            return View(await smartBoardContext.ToListAsync());
        }

        // GET: CatLineaaccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catLineaaccion = await _context.CatLineaaccions
                .Include(c => c.IdestrategiaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catLineaaccion == null)
            {
                return NotFound();
            }

            return View(catLineaaccion);
        }

        // GET: CatLineaaccions/Create
        public IActionResult Create()
        {
            ViewData["Idestrategia"] = new SelectList(_context.CatEstrategia, "Id", "Clave");
            return View();
        }

        // POST: CatLineaaccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Activo,Clasifica,Clave,Idestrategia")] CatLineaaccion catLineaaccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catLineaaccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idestrategia"] = new SelectList(_context.CatEstrategia, "Id", "Clave", catLineaaccion.Idestrategia);
            return View(catLineaaccion);
        }

        // GET: CatLineaaccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catLineaaccion = await _context.CatLineaaccions.FindAsync(id);
            if (catLineaaccion == null)
            {
                return NotFound();
            }
            ViewData["Idestrategia"] = new SelectList(_context.CatEstrategia, "Id", "Clave", catLineaaccion.Idestrategia);
            return View(catLineaaccion);
        }

        // POST: CatLineaaccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Activo,Clasifica,Clave,Idestrategia")] CatLineaaccion catLineaaccion)
        {
            if (id != catLineaaccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catLineaaccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatLineaaccionExists(catLineaaccion.Id))
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
            ViewData["Idestrategia"] = new SelectList(_context.CatEstrategia, "Id", "Clave", catLineaaccion.Idestrategia);
            return View(catLineaaccion);
        }

        // GET: CatLineaaccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catLineaaccion = await _context.CatLineaaccions
                .Include(c => c.IdestrategiaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catLineaaccion == null)
            {
                return NotFound();
            }

            return View(catLineaaccion);
        }

        // POST: CatLineaaccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catLineaaccion = await _context.CatLineaaccions.FindAsync(id);
            _context.CatLineaaccions.Remove(catLineaaccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatLineaaccionExists(int id)
        {
            return _context.CatLineaaccions.Any(e => e.Id == id);
        }
    }
}
