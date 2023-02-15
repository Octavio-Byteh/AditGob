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
    public class GradomarginalController : Controller
    {
        private readonly SmartBoardContext _context;

        public GradomarginalController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: Gradomarginal
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatGradomarginals.ToListAsync());
        }

        // GET: Gradomarginal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catGradomarginal = await _context.CatGradomarginals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catGradomarginal == null)
            {
                return NotFound();
            }

            return View(catGradomarginal);
        }

        // GET: Gradomarginal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gradomarginal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Activo")] CatGradomarginal catGradomarginal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catGradomarginal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catGradomarginal);
        }

        // GET: Gradomarginal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catGradomarginal = await _context.CatGradomarginals.FindAsync(id);
            if (catGradomarginal == null)
            {
                return NotFound();
            }
            return View(catGradomarginal);
        }

        // POST: Gradomarginal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Activo")] CatGradomarginal catGradomarginal)
        {
            if (id != catGradomarginal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catGradomarginal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatGradomarginalExists(catGradomarginal.Id))
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
            return View(catGradomarginal);
        }

        // GET: Gradomarginal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catGradomarginal = await _context.CatGradomarginals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catGradomarginal == null)
            {
                return NotFound();
            }

            return View(catGradomarginal);
        }

        // POST: Gradomarginal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catGradomarginal = await _context.CatGradomarginals.FindAsync(id);
            _context.CatGradomarginals.Remove(catGradomarginal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatGradomarginalExists(int id)
        {
            return _context.CatGradomarginals.Any(e => e.Id == id);
        }
    }
}
