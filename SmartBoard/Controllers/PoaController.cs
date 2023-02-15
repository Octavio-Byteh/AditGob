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
    public class PoaController : Controller
    {
        private readonly SmartBoardContext _context;

        public PoaController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: Poa
        public async Task<IActionResult> Index()
        {
            var smartBoardContext = _context.TblPoas.Include(t => t.IdtipoprogramaNavigation);
            return View(await smartBoardContext.ToListAsync());
        }


        private static List<YearViewModal> GetYears()
        {
            List<YearViewModal> years = new List<YearViewModal>();
            int maxyear = 2018;

            while (maxyear <= 2040)
            {
                years.Add(new YearViewModal() { id = maxyear, year = maxyear });
                maxyear++;
            }
            return years;
        }

        // GET: Poa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoa = await _context.TblPoas
                .Include(t => t.IdtipoprogramaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPoa == null)
            {
                return NotFound();
            }

            return View(tblPoa);
        }

        // GET: Poa/Create
        public IActionResult Create()
        {

            var tblpoa = _context.TblPoas.Where(a => a.Activo == 1)
                .Select(a=> new PoaViewModal() { 
                    Id = a.Id,
                    Activo = a.Activo,
                    Comentarios = a.Comentarios,
                    Fechaactualizacion = a.Fechaactualizacion,
                    Fechaelabora = a.Fechaelabora,
                    Fecharegistro = a.Fecharegistro,
                    Ideje = a.Ideje,
                    Idestrategia = a.Idestrategia,
                    Idlineaaccion = a.Idlineaaccion,
                    Idobjetivo = a.Idobjetivo,
                    Idtipoprograma = a.Idtipoprograma,
                    Nombre = a.Nombre,
                    Years = a.Year,
                    PoaDetalle = a.TblPoadetalles.Select(b => new TblPoadetalleViewModal()
                    {
                        IdProgramaoperativo = b.IdProgramaoperativo,
                        Fechainicio = b.Fechainicio,
                        Fechatermino = b.Fechatermino,
                        Iddependencia = b.Iddependencia,
                        Objetivo = b.Objetivo,
                        Actividades = b.Actividades,
                        Fecharegistro = b.Fecharegistro,
                        Activo = b.Activo,
                        Fechaactividad = b.Fechaactividad,
                        Year = b.Year,
                        Nombre = b.Nombre,
                        Id = b.Id,
                       
                    }).ToList()
                    
                    
                })
                .FirstOrDefault();


            ViewData["Years"] = new SelectList(GetYears(), "id", "year");
            ViewData["Ideje"] = new SelectList(_context.CatEjes, "Id", "Nombre");
            ViewData["Idobjetivo"] = new SelectList(_context.CatObjetivos, "Id", "Nombre");
            ViewData["Idestrategia"] = new SelectList(_context.CatEstrategia, "Id", "Nombre");
            ViewData["Idlineaaccion"] = new SelectList(_context.CatLineaaccions, "Id", "Nombre");
            ViewData["Idtipoprograma"] = new SelectList(_context.CatTipoprogramas, "Id", "Nombre");

            return View(tblpoa);
        }


        // POST: Poa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PoaViewModal tblPoa)
        {
            //if (ModelState.IsValid)
            //{


            //    _context.Add(tblPoa);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            ViewData["Years"] = new SelectList(GetYears(), "id", "year", tblPoa.Years);
            ViewData["Ideje"] = new SelectList(_context.CatEjes, "Id", "Nombre", tblPoa.Ideje);
            ViewData["Idobjetivo"] = new SelectList(_context.CatObjetivos, "Id", "Nombre", tblPoa.Idobjetivo);
            ViewData["Idestrategia"] = new SelectList(_context.CatEstrategia, "Id", "Nombre", tblPoa.Idestrategia);
            ViewData["Idlineaaccion"] = new SelectList(_context.CatLineaaccions, "Id", "Nombre", tblPoa.Idlineaaccion);
            ViewData["Idtipoprograma"] = new SelectList(_context.CatTipoprogramas, "Id", "Nombre", tblPoa.Idtipoprograma);

            ViewData["Idtipoprograma"] = new SelectList(_context.CatTipoprogramas, "Id", "Nombre", tblPoa.Idtipoprograma);
            return View(tblPoa);
        }

        // GET: Poa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoa = await _context.TblPoas.FindAsync(id);
            if (tblPoa == null)
            {
                return NotFound();
            }
            ViewData["Idtipoprograma"] = new SelectList(_context.CatTipoprogramas, "Id", "Nombre", tblPoa.Idtipoprograma);
            return View(tblPoa);
        }

        // POST: Poa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Idtipoprograma,Fechaelabora,Nombre,Fecharegistro,Comentarios,Activo")] TblPoa tblPoa)
        {
            if (id != tblPoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPoaExists(tblPoa.Id))
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
            ViewData["Idtipoprograma"] = new SelectList(_context.CatTipoprogramas, "Id", "Nombre", tblPoa.Idtipoprograma);
            return View(tblPoa);
        }

        // GET: Poa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPoa = await _context.TblPoas
                .Include(t => t.IdtipoprogramaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPoa == null)
            {
                return NotFound();
            }

            return View(tblPoa);
        }

        // POST: Poa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPoa = await _context.TblPoas.FindAsync(id);
            _context.TblPoas.Remove(tblPoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPoaExists(int id)
        {
            return _context.TblPoas.Any(e => e.Id == id);
        }

        #region Jsons

        public JsonResult getEjes()
        {
            return Json(new SelectList(_context.CatEjes, "Id", "Nombre"));
        }

        public JsonResult getObjetivos(int ideje)
        {
            return Json(new SelectList(_context.CatObjetivos.Where(a=>a.Ideje == ideje), "Id", "Nombre"));
        }

        //public JsonResult getEstrategia(int idobjetivo)
        //{
        //    return Json(new SelectList(_context.CatEstrategia.Where(a=>a.Idobjetivo == idobjetivo), "Id", "Nombre"));
        //}

        public JsonResult getLineaAccion(int idestrategia)
        {
            return Json(new SelectList(_context.CatLineaaccions.Where(a=>a.Idestrategia ==idestrategia), "Id", "Nombre"));
        }

        #endregion

    }
}
