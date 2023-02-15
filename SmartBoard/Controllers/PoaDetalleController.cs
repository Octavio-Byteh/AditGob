using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartBoard.Data.Models.SmartBoard;
using SmartBoard.Models;

namespace SmartBoard.Controllers
{
    public class PoaDetalleController : Controller
    {
        private readonly SmartBoardContext _context;

        public PoaDetalleController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: PoaDetalle
        public async Task<IActionResult> Index()
        {
            var smartBoardContext = _context.TblPoadetalles.Include(t => t.IdProgramaoperativoNavigation).Include(t => t.IddependenciaNavigation);
            return View(await smartBoardContext.ToListAsync());
        }

        // GET: PoaDetalle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoadetalle = await _context.TblPoadetalles
                .Include(t => t.IdProgramaoperativoNavigation)
                .Include(t => t.IddependenciaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPoadetalle == null)
            {
                return NotFound();
            }

            return View(tblPoadetalle);
        }

        // GET: PoaDetalle/Create
        public IActionResult Create()
        {
            ViewData["IdProgramaoperativo"] = new SelectList(_context.TblPoas, "Id", "Comentarios");
            ViewData["Iddependencia"] = new SelectList(_context.CatDependencia, "Id", "Nombre");
            return View();
        }

        // POST: PoaDetalle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProgramaoperativo,Fechainicio,Fechatermino,Iddependencia,Objetivo,Actividades,Fecharegistro,Activo,Fechaactividad")] TblPoadetalle tblPoadetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPoadetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProgramaoperativo"] = new SelectList(_context.TblPoas, "Id", "Comentarios", tblPoadetalle.IdProgramaoperativo);
            ViewData["Iddependencia"] = new SelectList(_context.CatDependencia, "Id", "Nombre", tblPoadetalle.Iddependencia);
            return View(tblPoadetalle);
        }

        // GET: PoaDetalle/Create
        public IActionResult CreatePartial(int idpoa)
        {
            var poa = _context.TblPoas.Where(a => a.Id == idpoa).FirstOrDefault();

            TblPoadetalleViewModal detalle = new TblPoadetalleViewModal {
                IdProgramaoperativo = idpoa,
                Fechainicio = DateTime.Now,
                Fechatermino = DateTime.Now,
                Iddependencia = poa.Iddependencia,
                Year = (poa.Year.HasValue ? poa.Year.Value : DateTime.Now.Year),
                Activo = true,                
            };

            ViewData["IdProgramaoperativo"] = new SelectList(_context.TblPoas, "Id", "Nombre", idpoa);
            ViewData["Iddependencia"] = new SelectList(_context.CatDependencia, "Id", "Nombre");
            return View(detalle);
        }

        // POST: PoaDetalle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePartial(TblPoadetalleViewModal tblPoadetalle)
        {
            if (ModelState.IsValid)
            {

                TblPoadetalle detalle = new TblPoadetalle
                {

                    IdProgramaoperativo = tblPoadetalle.IdProgramaoperativo,
                    Fechainicio = tblPoadetalle.Fechainicio,
                    Fechatermino = tblPoadetalle.Fechatermino,
                    Iddependencia = tblPoadetalle.Iddependencia,
                    Objetivo = tblPoadetalle.Objetivo,
                    Actividades = tblPoadetalle.Actividades,
                    Fecharegistro = DateTime.Now,
                    Activo = tblPoadetalle.Activo,
                    Fechaactividad = DateTime.Now,
                    Year = tblPoadetalle.Year,
                    Nombre = tblPoadetalle.Nombre

                };

                _context.Add(detalle);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("EditPartial", "PoaDetalle", new { id = detalle.Id });
            }
            ViewData["IdProgramaoperativo"] = new SelectList(_context.TblPoas, "Id", "Nombre", tblPoadetalle.IdProgramaoperativo);
            ViewData["Iddependencia"] = new SelectList(_context.CatDependencia, "Id", "Nombre", tblPoadetalle.Iddependencia);
            return View(tblPoadetalle);
        }

        // GET: PoaDetalle/Edit/5
        public async Task<IActionResult> EditPartial(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoadetalle = await _context.TblPoadetalles
                .Select(a=> new TblPoadetalleViewModal {
                    IdProgramaoperativo = a.IdProgramaoperativo,
                    Fechainicio = a.Fechainicio,
                    Fechatermino = a.Fechatermino,
                    Iddependencia = a.Iddependencia,
                    Objetivo = a.Objetivo,
                    Actividades = a.Actividades,
                    Fecharegistro = DateTime.Now,
                    Activo = a.Activo,
                    Fechaactividad = DateTime.Now,
                    Year = a.Year,
                    Nombre = a.Nombre,
                    Id = a.Id
                } )
                .Where(a=>a.Id == id)
                .FirstOrDefaultAsync();
            if (tblPoadetalle == null)
            {
                return NotFound();
            }



            ViewData["IdProgramaoperativo"] = new SelectList(_context.TblPoas, "Id", "Comentarios", tblPoadetalle.IdProgramaoperativo);
            ViewData["Iddependencia"] = new SelectList(_context.CatDependencia, "Id", "Nombre", tblPoadetalle.Iddependencia);
            return View(tblPoadetalle);
        }

        // POST: PoaDetalle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPartial(int id, TblPoadetalleViewModal tblPoadetalle)
        {
            if (id != tblPoadetalle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TblPoadetalle poadetalle = _context.TblPoadetalles.Where(a => a.Id == id).FirstOrDefault();
                    poadetalle.Objetivo = tblPoadetalle.Objetivo;
                    poadetalle.Actividades = tblPoadetalle.Actividades;
                    poadetalle.Nombre = tblPoadetalle.Nombre;
                    poadetalle.Fechainicio = tblPoadetalle.Fechainicio;
                    poadetalle.Fechatermino = tblPoadetalle.Fechatermino;


                    _context.Update(poadetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPoadetalleExists(tblPoadetalle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("EditPartial", "PoaDetalle", new { id = tblPoadetalle.Id });
                //return RedirectToAction(nameof(Index));
            }
            ViewData["IdProgramaoperativo"] = new SelectList(_context.TblPoas, "Id", "Comentarios", tblPoadetalle.IdProgramaoperativo);
            ViewData["Iddependencia"] = new SelectList(_context.CatDependencia, "Id", "Nombre", tblPoadetalle.Iddependencia);
            return View(tblPoadetalle);
        }


        // GET: PoaDetalle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoadetalle = await _context.TblPoadetalles.FindAsync(id);
            if (tblPoadetalle == null)
            {
                return NotFound();
            }
            ViewData["IdProgramaoperativo"] = new SelectList(_context.TblPoas, "Id", "Comentarios", tblPoadetalle.IdProgramaoperativo);
            ViewData["Iddependencia"] = new SelectList(_context.CatDependencia, "Id", "Nombre", tblPoadetalle.Iddependencia);
            return View(tblPoadetalle);
        }

        // POST: PoaDetalle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProgramaoperativo,Fechainicio,Fechatermino,Iddependencia,Objetivo,Actividades,Fecharegistro,Activo,Fechaactividad")] TblPoadetalle tblPoadetalle)
        {
            if (id != tblPoadetalle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPoadetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPoadetalleExists(tblPoadetalle.Id))
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
            ViewData["IdProgramaoperativo"] = new SelectList(_context.TblPoas, "Id", "Comentarios", tblPoadetalle.IdProgramaoperativo);
            ViewData["Iddependencia"] = new SelectList(_context.CatDependencia, "Id", "Nombre", tblPoadetalle.Iddependencia);
            return View(tblPoadetalle);
        }

        // GET: PoaDetalle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoadetalle = await _context.TblPoadetalles
                .Include(t => t.IdProgramaoperativoNavigation)
                .Include(t => t.IddependenciaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPoadetalle == null)
            {
                return NotFound();
            }

            return View(tblPoadetalle);
        }

        // POST: PoaDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPoadetalle = await _context.TblPoadetalles.FindAsync(id);
            _context.TblPoadetalles.Remove(tblPoadetalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPoadetalleExists(int id)
        {
            return _context.TblPoadetalles.Any(e => e.Id == id);
        }
    }
}
