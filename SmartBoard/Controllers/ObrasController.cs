using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartBoard.Data.Models.SmartBoard;
using SmartBoard.Models;
using SmartBoard.Services;

namespace SmartBoard.Controllers
{
    public class ObrasController : Controller
    {
        private readonly SmartBoardContext _context;

        public ObrasController(SmartBoardContext context)
        {
            _context = context;
        }

        // GET: Obras
        public async Task<IActionResult> Index()
        {
            var obras2021Context = _context.TblObras.Where(a=>a.Year == 2021).Include(o => o.IddependenciaNavigation).Include(o => o.IdestadoobraNavigation).Include(o => o.IdestadorevisionNavigation).Include(o => o.IdmunicipioNavigation);
            return View(await obras2021Context.ToListAsync());
        }
        // GET: Obras Get data      
        [HttpGet]
        public IActionResult GetObrasByYear(int year, int IdtipoObra) => Json(new RecordsService(_context).getObrasbyYear(year,IdtipoObra));

        [HttpGet]
        public IActionResult GetObrasByYearToPivot(int year) => Json(new RecordsService(_context).getObrasbyYearToPivot(year));




        // GET: Obras/DetailsBack/5
        public async Task<IActionResult> DetalleObraByNoObraBack(int noobra, int year)
        {
            if (noobra == null)
            {
                return NotFound();
            }

            var obra = await _context.TblObras
                .Include(o => o.IddependenciaNavigation)
                .Include(o => o.IdestadoobraNavigation)
                .Include(o => o.IdestadorevisionNavigation)
                .Include(o => o.IdmunicipioNavigation)
                .Include(o => o.IdvertienteNavigation)
                .Include(o => o.IdsubvertienteNavigation)
                .Include(o => o.IdprogsogNavigation)
                .FirstOrDefaultAsync(m => m.Numeroobra == noobra && m.Year == year);
            if (obra == null)
            {
                return NotFound();
            }

            List<ObrasImagenesMetadata> lista = new ImagesService().GetImagenesByNoObra(obra.Numeroobra);


            ViewData["imagenes"] = lista;

            return View(obra);
        }
        // GET: Obras/Details/5
        public async Task<IActionResult> DetalleObraByNoObra(string noobra,int year)
        {
            if (noobra == null)
            {
                return NotFound();
            }

            var obra = await _context.TblObras
                .Include(o => o.IddependenciaNavigation)
                .Include(o => o.IdestadoobraNavigation)
                .Include(o => o.IdestadorevisionNavigation)
                .Include(o => o.IdmunicipioNavigation)
                 .Include(o => o.IdvertienteNavigation)
                .Include(o => o.IdsubvertienteNavigation)
                .Include(o => o.IdprogsogNavigation)
                .FirstOrDefaultAsync(m => m.Numeroobraexterno == noobra && m.Year ==year);
            if (obra == null)
            {
                return NotFound();
            }

            //List<ObrasImagenesMetadata> lista = new ImagesService().GetImagenesByNoObra(obra.Numeroobra);
            List<ObrasImagenesMetadata> lista = new ImagesService().GetImagenesByNoObra(obra.Numeroobraexterno);


            ViewData["imagenes"] = lista;

            return View(obra);
        }


        public async Task<IActionResult> DetalleObraByExpediente(int? id, int year)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.TblObras
                .Include(o => o.IddependenciaNavigation)
                .Include(o => o.IdestadoobraNavigation)
                .Include(o => o.IdestadorevisionNavigation)
                .Include(o => o.IdmunicipioNavigation)
                 .Include(o => o.IdvertienteNavigation)
                .Include(o => o.IdsubvertienteNavigation)
                .Include(o => o.IdprogsogNavigation)
                .FirstOrDefaultAsync(m => m.Id == id.Value );
            if (obra == null)
            {
                return NotFound();
            }

            //List<ObrasImagenesMetadata> lista = new ImagesService().GetImagenesByNoObra(obra.Numeroobra);
            List<ObrasImagenesMetadata> lista = new ImagesService().GetImagenesByNoObra(obra.Id.ToString());


            ViewData["imagenes"] = lista;

            return View(obra);
        }


        public async Task<IActionResult> DetalleObraByNoObraBotonera(string noobra, int year)
        {
            if (noobra == null)
            {
                return NotFound();
            }

            var obra = await _context.TblObras
                   .FirstOrDefaultAsync(m => m.Numeroobraexterno == noobra && m.Year == year);
            if (obra == null)
            {
                return NotFound();
            }

       

            return View(obra);
        }


        public async Task<IActionResult> DetalleObraByExpedienteBotonera(int? id, int year)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.TblObras
                   .FirstOrDefaultAsync(m => m.Id == id.Value );
            if (obra == null)
            {
                return NotFound();
            }



            return View(obra);
        }



        // GET: Obras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.TblObras
                .Include(o => o.IddependenciaNavigation)
                .Include(o => o.IdestadoobraNavigation)
                .Include(o => o.IdestadorevisionNavigation)
                .Include(o => o.IdmunicipioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obra == null)
            {
                return NotFound();
            }

            return View(obra);
        }

        // GET: Obras/Create
        public IActionResult Create()
        {
            ViewData["Dependencia"] = new SelectList(_context.CatDependencia, "Id", "Nombre");
            ViewData["EstatusDeLaObra"] = new SelectList(_context.CatEstadoobras, "Id", "Nombre");
            ViewData["EstatusDeRevisión"] = new SelectList(_context.CatEstadorevisions, "Id", "Nombre");
            ViewData["Municipio"] = new SelectList(_context.CatMunicipios, "Id", "Nombre");
            return View();
        }

        // POST: Obras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblObra obra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Dependencia"] = new SelectList(_context.CatDependencia, "Id", "Id", obra.Iddependencia);
            ViewData["EstatusDeLaObra"] = new SelectList(_context.CatEstadoobras, "Id", "Id", obra.Idestadoobra);
            ViewData["EstatusDeRevisión"] = new SelectList(_context.CatEstadorevisions, "Id", "Id", obra.Idestadorevision);
            ViewData["Municipio"] = new SelectList(_context.CatMunicipios, "Id", "Id", obra.Idmunicipio);
            return View(obra);
        }

        // GET: Obras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.TblObras.FindAsync(id);
            if (obra == null)
            {
                return NotFound();
            }
            ViewData["Dependencia"] = new SelectList(_context.CatDependencia, "Id", "Id", obra.Iddependencia);
            ViewData["EstatusDeLaObra"] = new SelectList(_context.CatEstadoobras, "Id", "Id", obra.Idestadoobra);
            ViewData["EstatusDeRevisión"] = new SelectList(_context.CatEstadorevisions, "Id", "Id", obra.Idestadorevision);
            ViewData["Municipio"] = new SelectList(_context.CatMunicipios, "Id", "Id", obra.Idmunicipio);
            return View(obra);
        }

        // POST: Obras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,TblObra obra)
        {
            if (id != obra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObraExists(obra.Id))
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
            ViewData["Dependencia"] = new SelectList(_context.CatDependencia, "Id", "Id", obra.Iddependencia);
            ViewData["EstatusDeLaObra"] = new SelectList(_context.CatEstadoobras, "Id", "Id", obra.Idestadoobra);
            ViewData["EstatusDeRevisión"] = new SelectList(_context.CatEstadorevisions, "Id", "Id", obra.Idestadorevision);
            ViewData["Municipio"] = new SelectList(_context.CatMunicipios, "Id", "Id", obra.Idmunicipio);
            return View(obra);
        }

        // GET: Obras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.TblObras
                .Include(o => o.IddependenciaNavigation)
                .Include(o => o.IdestadoobraNavigation)
                .Include(o => o.IdestadorevisionNavigation)
                .Include(o => o.IdmunicipioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obra == null)
            {
                return NotFound();
            }

            return View(obra);
        }

        // POST: Obras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obra = await _context.TblObras.FindAsync(id);
            _context.TblObras.Remove(obra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObraExists(int id)
        {
            return _context.TblObras.Any(e => e.Id == id);
        }
    }
}
