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
    public class CatEstrategiasController : Controller
    {
        private readonly SmartBoardContext _context;

        public CatEstrategiasController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: CatEstrategias
        public async Task<IActionResult> Index()
        {
            var smartBoardContext = _context.CatEstrategia.Include(c => c.IdejeNavigation);
            return View(await smartBoardContext.ToListAsync());
        }

        // GET: CatEstrategias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catEstrategium = await _context.CatEstrategia
                .Include(c => c.IdejeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catEstrategium == null)
            {
                return NotFound();
            }

            return View(catEstrategium);
        }

        // GET: CatEstrategias/Create
        public IActionResult Create()
        {
            ViewData["Ideje"] = new SelectList(_context.CatEjes, "Id", "Clave");
            return View();
        }

        // POST: CatEstrategias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Activo,Clasifica,Clave,Ideje")] CatEstrategium catEstrategium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catEstrategium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Ideje"] = new SelectList(_context.CatEjes, "Id", "Clave", catEstrategium.Ideje);
            return View(catEstrategium);
        }

        // GET: CatEstrategias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catEstrategium = await _context.CatEstrategia.FindAsync(id);
            if (catEstrategium == null)
            {
                return NotFound();
            }
            ViewData["Ideje"] = new SelectList(_context.CatEjes, "Id", "Clave", catEstrategium.Ideje);
            return View(catEstrategium);
        }

        // POST: CatEstrategias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Activo,Clasifica,Clave,Ideje")] CatEstrategium catEstrategium)
        {
            if (id != catEstrategium.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catEstrategium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatEstrategiumExists(catEstrategium.Id))
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
            ViewData["Ideje"] = new SelectList(_context.CatEjes, "Id", "Clave", catEstrategium.Ideje);
            return View(catEstrategium);
        }

        // GET: CatEstrategias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catEstrategium = await _context.CatEstrategia
                .Include(c => c.IdejeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catEstrategium == null)
            {
                return NotFound();
            }

            return View(catEstrategium);
        }

        // POST: CatEstrategias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catEstrategium = await _context.CatEstrategia.FindAsync(id);
            _context.CatEstrategia.Remove(catEstrategium);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatEstrategiumExists(int id)
        {
            return _context.CatEstrategia.Any(e => e.Id == id);
        }
    }
}
