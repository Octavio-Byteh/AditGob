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
    public class TipoAdjudicacionController : Controller
    {
        private readonly SmartBoardContext _context;

        public TipoAdjudicacionController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: TipoAdjudicacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatTipoAdjudicacions.ToListAsync());
        }

        // GET: TipoAdjudicacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoAdjudicacion = await _context.CatTipoAdjudicacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catTipoAdjudicacion == null)
            {
                return NotFound();
            }

            return View(catTipoAdjudicacion);
        }

        // GET: TipoAdjudicacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoAdjudicacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Activo")] CatTipoAdjudicacion catTipoAdjudicacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catTipoAdjudicacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catTipoAdjudicacion);
        }

        // GET: TipoAdjudicacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoAdjudicacion = await _context.CatTipoAdjudicacions.FindAsync(id);
            if (catTipoAdjudicacion == null)
            {
                return NotFound();
            }
            return View(catTipoAdjudicacion);
        }

        // POST: TipoAdjudicacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Activo")] CatTipoAdjudicacion catTipoAdjudicacion)
        {
            if (id != catTipoAdjudicacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catTipoAdjudicacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoAdjudicacionExists(catTipoAdjudicacion.Id))
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
            return View(catTipoAdjudicacion);
        }

        // GET: TipoAdjudicacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoAdjudicacion = await _context.CatTipoAdjudicacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catTipoAdjudicacion == null)
            {
                return NotFound();
            }

            return View(catTipoAdjudicacion);
        }

        // POST: TipoAdjudicacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTipoAdjudicacion = await _context.CatTipoAdjudicacions.FindAsync(id);
            _context.CatTipoAdjudicacions.Remove(catTipoAdjudicacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoAdjudicacionExists(int id)
        {
            return _context.CatTipoAdjudicacions.Any(e => e.Id == id);
        }
    }
}
