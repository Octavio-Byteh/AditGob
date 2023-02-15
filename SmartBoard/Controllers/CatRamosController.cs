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
    public class CatRamosController : Controller
    {
        private readonly SmartBoardContext _context;

        public CatRamosController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: CatRamos
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatRamos.ToListAsync());
        }

        // GET: CatRamos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catRamo = await _context.CatRamos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catRamo == null)
            {
                return NotFound();
            }

            return View(catRamo);
        }

        // GET: CatRamos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatRamos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Activo")] CatRamo catRamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catRamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catRamo);
        }

        // GET: CatRamos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catRamo = await _context.CatRamos.FindAsync(id);
            if (catRamo == null)
            {
                return NotFound();
            }
            return View(catRamo);
        }

        // POST: CatRamos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Activo")] CatRamo catRamo)
        {
            if (id != catRamo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catRamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatRamoExists(catRamo.Id))
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
            return View(catRamo);
        }

        // GET: CatRamos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catRamo = await _context.CatRamos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catRamo == null)
            {
                return NotFound();
            }

            return View(catRamo);
        }

        // POST: CatRamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catRamo = await _context.CatRamos.FindAsync(id);
            _context.CatRamos.Remove(catRamo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatRamoExists(int id)
        {
            return _context.CatRamos.Any(e => e.Id == id);
        }
    }
}
