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
    public class NormativaAplicableController : Controller
    {
        private readonly SmartBoardContext _context;

        public NormativaAplicableController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: NormativaAplicable
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatNormativaAplicables.ToListAsync());
        }

        // GET: NormativaAplicable/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catNormativaAplicable = await _context.CatNormativaAplicables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catNormativaAplicable == null)
            {
                return NotFound();
            }

            return View(catNormativaAplicable);
        }

        // GET: NormativaAplicable/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NormativaAplicable/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Activo")] CatNormativaAplicable catNormativaAplicable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catNormativaAplicable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catNormativaAplicable);
        }

        // GET: NormativaAplicable/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catNormativaAplicable = await _context.CatNormativaAplicables.FindAsync(id);
            if (catNormativaAplicable == null)
            {
                return NotFound();
            }
            return View(catNormativaAplicable);
        }

        // POST: NormativaAplicable/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Activo")] CatNormativaAplicable catNormativaAplicable)
        {
            if (id != catNormativaAplicable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catNormativaAplicable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatNormativaAplicableExists(catNormativaAplicable.Id))
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
            return View(catNormativaAplicable);
        }

        // GET: NormativaAplicable/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catNormativaAplicable = await _context.CatNormativaAplicables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catNormativaAplicable == null)
            {
                return NotFound();
            }

            return View(catNormativaAplicable);
        }

        // POST: NormativaAplicable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catNormativaAplicable = await _context.CatNormativaAplicables.FindAsync(id);
            _context.CatNormativaAplicables.Remove(catNormativaAplicable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatNormativaAplicableExists(int id)
        {
            return _context.CatNormativaAplicables.Any(e => e.Id == id);
        }
    }
}
