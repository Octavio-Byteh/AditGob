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
    public class CatProgramasController : Controller
    {
        private readonly SmartBoardContext _context;

        public CatProgramasController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: CatProgramas
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatProgramas.ToListAsync());
        }

        // GET: CatProgramas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catPrograma = await _context.CatProgramas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catPrograma == null)
            {
                return NotFound();
            }

            return View(catPrograma);
        }

        // GET: CatProgramas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatProgramas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Activo")] CatPrograma catPrograma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catPrograma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catPrograma);
        }

        // GET: CatProgramas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catPrograma = await _context.CatProgramas.FindAsync(id);
            if (catPrograma == null)
            {
                return NotFound();
            }
            return View(catPrograma);
        }

        // POST: CatProgramas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Activo")] CatPrograma catPrograma)
        {
            if (id != catPrograma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catPrograma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatProgramaExists(catPrograma.Id))
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
            return View(catPrograma);
        }

        // GET: CatProgramas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catPrograma = await _context.CatProgramas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catPrograma == null)
            {
                return NotFound();
            }

            return View(catPrograma);
        }

        // POST: CatProgramas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catPrograma = await _context.CatProgramas.FindAsync(id);
            _context.CatProgramas.Remove(catPrograma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatProgramaExists(int id)
        {
            return _context.CatProgramas.Any(e => e.Id == id);
        }
    }
}
