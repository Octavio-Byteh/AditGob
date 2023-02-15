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
    public class CatFondosController : Controller
    {
        private readonly SmartBoardContext _context;

        public CatFondosController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: CatFondos
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatFondos.ToListAsync());
        }

        // GET: CatFondos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catFondo = await _context.CatFondos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catFondo == null)
            {
                return NotFound();
            }

            return View(catFondo);
        }

        // GET: CatFondos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatFondos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Activo")] CatFondo catFondo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catFondo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catFondo);
        }

        // GET: CatFondos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catFondo = await _context.CatFondos.FindAsync(id);
            if (catFondo == null)
            {
                return NotFound();
            }
            return View(catFondo);
        }

        // POST: CatFondos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Activo")] CatFondo catFondo)
        {
            if (id != catFondo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catFondo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatFondoExists(catFondo.Id))
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
            return View(catFondo);
        }

        // GET: CatFondos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catFondo = await _context.CatFondos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catFondo == null)
            {
                return NotFound();
            }

            return View(catFondo);
        }

        // POST: CatFondos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catFondo = await _context.CatFondos.FindAsync(id);
            _context.CatFondos.Remove(catFondo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatFondoExists(int id)
        {
            return _context.CatFondos.Any(e => e.Id == id);
        }
    }
}
