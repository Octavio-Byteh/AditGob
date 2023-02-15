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
    public class CatSubprogramasController : Controller
    {
        private readonly SmartBoardContext _context;

        public CatSubprogramasController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: CatSubprogramas
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatSubprogramas.ToListAsync());
        }

        // GET: CatSubprogramas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catSubprograma = await _context.CatSubprogramas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catSubprograma == null)
            {
                return NotFound();
            }

            return View(catSubprograma);
        }

        // GET: CatSubprogramas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatSubprogramas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Activo")] CatSubprograma catSubprograma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catSubprograma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catSubprograma);
        }

        // GET: CatSubprogramas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catSubprograma = await _context.CatSubprogramas.FindAsync(id);
            if (catSubprograma == null)
            {
                return NotFound();
            }
            return View(catSubprograma);
        }

        // POST: CatSubprogramas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Activo")] CatSubprograma catSubprograma)
        {
            if (id != catSubprograma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catSubprograma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatSubprogramaExists(catSubprograma.Id))
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
            return View(catSubprograma);
        }

        // GET: CatSubprogramas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catSubprograma = await _context.CatSubprogramas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catSubprograma == null)
            {
                return NotFound();
            }

            return View(catSubprograma);
        }

        // POST: CatSubprogramas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catSubprograma = await _context.CatSubprogramas.FindAsync(id);
            _context.CatSubprogramas.Remove(catSubprograma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatSubprogramaExists(int id)
        {
            return _context.CatSubprogramas.Any(e => e.Id == id);
        }
    }
}
