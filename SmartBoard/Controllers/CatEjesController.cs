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
    public class CatEjesController : Controller
    {
        private readonly SmartBoardContext _context;

        public CatEjesController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: CatEjes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatEjes.ToListAsync());
        }

        // GET: CatEjes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catEje = await _context.CatEjes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catEje == null)
            {
                return NotFound();
            }

            return View(catEje);
        }

        // GET: CatEjes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatEjes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Activo,Clasifica,Clave")] CatEje catEje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catEje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catEje);
        }

        // GET: CatEjes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catEje = await _context.CatEjes.FindAsync(id);
            if (catEje == null)
            {
                return NotFound();
            }
            return View(catEje);
        }

        // POST: CatEjes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Activo,Clasifica,Clave")] CatEje catEje)
        {
            if (id != catEje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catEje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatEjeExists(catEje.Id))
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
            return View(catEje);
        }

        // GET: CatEjes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catEje = await _context.CatEjes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catEje == null)
            {
                return NotFound();
            }

            return View(catEje);
        }

        // POST: CatEjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catEje = await _context.CatEjes.FindAsync(id);
            _context.CatEjes.Remove(catEje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatEjeExists(int id)
        {
            return _context.CatEjes.Any(e => e.Id == id);
        }
    }
}
