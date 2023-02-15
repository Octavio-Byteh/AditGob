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
    public class ModalidadEjecucionController : Controller
    {
        private readonly SmartBoardContext _context;

        public ModalidadEjecucionController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: ModalidadEjecucion
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatModalidadEjecucions.ToListAsync());
        }

        // GET: ModalidadEjecucion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catModalidadEjecucion = await _context.CatModalidadEjecucions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catModalidadEjecucion == null)
            {
                return NotFound();
            }

            return View(catModalidadEjecucion);
        }

        // GET: ModalidadEjecucion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModalidadEjecucion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Activo")] CatModalidadEjecucion catModalidadEjecucion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catModalidadEjecucion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catModalidadEjecucion);
        }

        // GET: ModalidadEjecucion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catModalidadEjecucion = await _context.CatModalidadEjecucions.FindAsync(id);
            if (catModalidadEjecucion == null)
            {
                return NotFound();
            }
            return View(catModalidadEjecucion);
        }

        // POST: ModalidadEjecucion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Activo")] CatModalidadEjecucion catModalidadEjecucion)
        {
            if (id != catModalidadEjecucion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catModalidadEjecucion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatModalidadEjecucionExists(catModalidadEjecucion.Id))
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
            return View(catModalidadEjecucion);
        }

        // GET: ModalidadEjecucion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catModalidadEjecucion = await _context.CatModalidadEjecucions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catModalidadEjecucion == null)
            {
                return NotFound();
            }

            return View(catModalidadEjecucion);
        }

        // POST: ModalidadEjecucion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catModalidadEjecucion = await _context.CatModalidadEjecucions.FindAsync(id);
            _context.CatModalidadEjecucions.Remove(catModalidadEjecucion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatModalidadEjecucionExists(int id)
        {
            return _context.CatModalidadEjecucions.Any(e => e.Id == id);
        }
    }
}
