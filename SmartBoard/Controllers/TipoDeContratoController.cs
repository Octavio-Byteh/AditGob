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
    public class TipoDeContratoController : Controller
    {
        private readonly SmartBoardContext _context;

        public TipoDeContratoController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: TipoDeContrato
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatTipoDeContratos.ToListAsync());
        }

        // GET: TipoDeContrato/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoDeContrato = await _context.CatTipoDeContratos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catTipoDeContrato == null)
            {
                return NotFound();
            }

            return View(catTipoDeContrato);
        }

        // GET: TipoDeContrato/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeContrato/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Activo")] CatTipoDeContrato catTipoDeContrato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catTipoDeContrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catTipoDeContrato);
        }

        // GET: TipoDeContrato/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoDeContrato = await _context.CatTipoDeContratos.FindAsync(id);
            if (catTipoDeContrato == null)
            {
                return NotFound();
            }
            return View(catTipoDeContrato);
        }

        // POST: TipoDeContrato/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Activo")] CatTipoDeContrato catTipoDeContrato)
        {
            if (id != catTipoDeContrato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catTipoDeContrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoDeContratoExists(catTipoDeContrato.Id))
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
            return View(catTipoDeContrato);
        }

        // GET: TipoDeContrato/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoDeContrato = await _context.CatTipoDeContratos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catTipoDeContrato == null)
            {
                return NotFound();
            }

            return View(catTipoDeContrato);
        }

        // POST: TipoDeContrato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTipoDeContrato = await _context.CatTipoDeContratos.FindAsync(id);
            _context.CatTipoDeContratos.Remove(catTipoDeContrato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoDeContratoExists(int id)
        {
            return _context.CatTipoDeContratos.Any(e => e.Id == id);
        }
    }
}
