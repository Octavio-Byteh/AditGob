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
    public class CatRubrosController : Controller
    {
        private readonly SmartBoardContext _context;

        public CatRubrosController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: CatRubros
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatRubros.ToListAsync());
        }

        // GET: CatRubros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catRubro = await _context.CatRubros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catRubro == null)
            {
                return NotFound();
            }

            return View(catRubro);
        }

        // GET: CatRubros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatRubros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Activo")] CatRubro catRubro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catRubro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catRubro);
        }

        // GET: CatRubros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catRubro = await _context.CatRubros.FindAsync(id);
            if (catRubro == null)
            {
                return NotFound();
            }
            return View(catRubro);
        }

        // POST: CatRubros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Activo")] CatRubro catRubro)
        {
            if (id != catRubro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catRubro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatRubroExists(catRubro.Id))
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
            return View(catRubro);
        }

        // GET: CatRubros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catRubro = await _context.CatRubros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catRubro == null)
            {
                return NotFound();
            }

            return View(catRubro);
        }

        // POST: CatRubros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catRubro = await _context.CatRubros.FindAsync(id);
            _context.CatRubros.Remove(catRubro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatRubroExists(int id)
        {
            return _context.CatRubros.Any(e => e.Id == id);
        }
    }
}
