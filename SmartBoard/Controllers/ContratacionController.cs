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
    public class ContratacionController : Controller
    {
        private readonly SmartBoardContext _context;

        public ContratacionController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: Contratacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatContratacions.ToListAsync());
        }

        // GET: Contratacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catContratacion = await _context.CatContratacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catContratacion == null)
            {
                return NotFound();
            }

            return View(catContratacion);
        }

        // GET: Contratacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contratacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Activo")] CatContratacion catContratacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catContratacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catContratacion);
        }

        // GET: Contratacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catContratacion = await _context.CatContratacions.FindAsync(id);
            if (catContratacion == null)
            {
                return NotFound();
            }
            return View(catContratacion);
        }

        // POST: Contratacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Activo")] CatContratacion catContratacion)
        {
            if (id != catContratacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catContratacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatContratacionExists(catContratacion.Id))
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
            return View(catContratacion);
        }

        // GET: Contratacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catContratacion = await _context.CatContratacions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catContratacion == null)
            {
                return NotFound();
            }

            return View(catContratacion);
        }

        // POST: Contratacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catContratacion = await _context.CatContratacions.FindAsync(id);
            _context.CatContratacions.Remove(catContratacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatContratacionExists(int id)
        {
            return _context.CatContratacions.Any(e => e.Id == id);
        }
    }
}
