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
    public class ObraRecursosController : Controller
    {
        private readonly SmartBoardContext _context;

        public ObraRecursosController(SmartBoardContext context)
        {
            _context = context;
        }

        #region JsonResults


        public JsonResult FetchTipoRecurso()
        {
            return Json(new SelectList(_context.CatTipoRecursos, "Id", "Nombre"));
        }

        public JsonResult FetchOrigenRecurso(int IdTiporecurso)
        {

            return Json(new SelectList(_context.CatOrigenrecursos.Where(a => a.Nombre.StartsWith(IdTiporecurso.ToString())), "Id", "Nombre"));
        }

        public JsonResult FetchRamo(int iddrecurso)
        {
            if (iddrecurso == 6)
            {
                return Json(new SelectList(_context.CatRamos.Where(a => a.Nombre.StartsWith("28")), "Id", "Nombre"));
            }
            else if (iddrecurso == 10)
            {
                return Json(new SelectList(_context.CatRamos.Where(a => !a.Nombre.StartsWith("28")), "Id", "Nombre"));
            }
            else
            {
                return Json(new SelectList(_context.CatOrigenrecursos.Where(a => a.Nombre.StartsWith("***")), "Id", "Nombre"));

            }

        }

        public JsonResult FetchRubro(int idramo)
        {

            return Json(new SelectList(_context.CatRubros.Where(a => a.IdRamo == idramo), "Id", "Nombre"));
        }

        public JsonResult FetchFondo(int idramo, int? idrubro)
        {
            if (idrubro == null)
            {
                return Json(new SelectList(_context.CatFondos.Where(a => a.IdRamo == idramo), "Id", "Nombre"));

            }
            else
            {
                return Json(new SelectList(_context.CatFondos.Where(a => a.IdRamo == idramo && a.IdRubro == idrubro.Value), "Id", "Nombre"));

            }

            //return Json(new SelectList(_context.CatRubros.Where(a => a.IdRamo == idramo), "Id", "Nombre"));
        }



        public List<stgProgModel> stg_prog()
        {
            List<stgProgModel> lista = new List<stgProgModel>();
            lista =
                _context.StgProgs
                .Select(a =>
                new stgProgModel()
                {
                    clasificacion = a.Clasificación,
                    fondo = a.Fondo,
                    programa = a.Programa,
                    ramo = a.Ramos,
                    rubro = a.Rubros,
                    subprograma = a.Subprograma
                })
                .ToList();

            lista.ForEach(b =>
            {
                if (!string.IsNullOrWhiteSpace(b.clasificacion))
                {


                    var clasifica = _context.CatClasificacions.Where(a => a.Nombre == b.clasificacion).FirstOrDefault();
                    if (clasifica != null)
                    {
                        b.idclasificacion = clasifica.Id;
                    }
                    else
                    {
                        CatClasificacion obj = new CatClasificacion()
                        {
                            Nombre = b.clasificacion,
                            Descripcion = b.clasificacion,
                            Activo = true
                        };
                        _context.Add(obj);
                        _context.SaveChanges();
                        b.idclasificacion = obj.Id;
                    }
                }

                if (!string.IsNullOrWhiteSpace(b.subprograma))
                {
                    var subProg = _context.CatSubprogramas.Where(a => a.Nombre == b.subprograma).FirstOrDefault();
                    if (subProg != null)
                    {
                        b.idsubprograma = subProg.Id;
                    }
                    else
                    {
                        CatSubprograma obj = new CatSubprograma()
                        {
                            Nombre = b.subprograma,
                            Descripcion = b.subprograma,
                            Activo = true
                        };
                        _context.Add(obj);
                        _context.SaveChanges();
                        b.idsubprograma = obj.Id;
                    }
                }

                if (!string.IsNullOrWhiteSpace(b.programa))
                {


                    var Prog = _context.CatProgramas.Where(a => a.Nombre == b.programa).FirstOrDefault();
                    if (Prog != null)
                    {
                        b.idprograma = Prog.Id;
                    }
                    else
                    {
                        CatPrograma obj = new CatPrograma()
                        {
                            Nombre = b.programa,
                            Descripcion = b.programa,
                            Activo = true
                        };
                        _context.Add(obj);
                        _context.SaveChanges();
                        b.idprograma = obj.Id;
                    }

                }
                if (!string.IsNullOrWhiteSpace(b.fondo))
                {


                    var fondo = _context.CatFondos.Where(a => a.Nombre == b.fondo).FirstOrDefault();
                    if (fondo != null)
                    {
                        b.idfondo = fondo.Id;
                    }
                    else
                    {
                        CatFondo obj = new CatFondo()
                        {
                            Nombre = b.fondo,
                            Descripcion = b.fondo,
                            Activo = true
                        };
                        _context.Add(obj);
                        _context.SaveChanges();
                        b.idfondo = obj.Id;
                    }
                }

                if (!string.IsNullOrWhiteSpace(b.rubro))
                {


                    var rubro = _context.CatRubros.Where(a => a.Nombre == b.rubro).FirstOrDefault();
                    if (rubro != null)
                    {
                        b.idrubro = rubro.Id;
                    }
                    else
                    {
                        CatRubro obj = new CatRubro()
                        {
                            Nombre = b.rubro,
                            Descripcion = b.rubro,
                            Activo = true
                        };
                        _context.Add(obj);
                        _context.SaveChanges();
                        b.idrubro = obj.Id;
                    }
                }

                if (!string.IsNullOrWhiteSpace(b.ramo))
                {



                    var ramo = _context.CatRamos.Where(a => a.Nombre == b.ramo).FirstOrDefault();
                    if (ramo != null)
                    {
                        b.idramo = ramo.Id;
                    }
                    else
                    {
                        CatRamo obj = new CatRamo()
                        {
                            Nombre = b.ramo,
                            Descripcion = b.ramo,
                            Activo = true
                        };
                        _context.Add(obj);
                        _context.SaveChanges();
                        b.idramo = obj.Id;
                    }
                }
            });


            return lista;
        }

        public JsonResult FetchPrograma(int idramo, int? idrubro, int? idfondo)
        {

            List<stgProgModel> listaCompleta = stg_prog();



            List<stgProgModel> lista = new List<stgProgModel>();
            if (idrubro == null && idfondo == null)
            {
                lista = listaCompleta.Where(a => a.idramo == idramo).ToList();
            }
            else if (idrubro !=null && idfondo != null )
            {
                lista = listaCompleta.Where(a => a.idramo == idramo && a.idrubro == idrubro && a.idfondo == idfondo).ToList();
            }
            else if (idrubro != null && idfondo == null)
            {
                lista = listaCompleta.Where(a => a.idramo == idramo && a.idrubro == idrubro).ToList();
            }
            else if (idrubro == null && idfondo != null)
            {
                lista = listaCompleta.Where(a => a.idramo == idramo && a.idfondo == idfondo).ToList();
            }

           
            List<stgProgModel> listaFinal =
                lista
                .ToList();


            return Json(new SelectList(listaFinal.Where(a=>a.idprograma != null).Select(a => new { Id = a.idprograma, Nombre = a.programa }).Distinct(), "Id", "Nombre"));
        }

        public JsonResult FetchSubPrograma(int idprograma)
        {

            List<stgProgModel> listaCompleta = stg_prog();



            List<stgProgModel> lista = listaCompleta.Where(a => a.idprograma == idprograma).ToList();
            

            List<stgProgModel> listaFinal =
                lista
                .ToList();


            return Json(new SelectList(listaFinal.Where(a => a.idsubprograma != null).Select(a => new { Id = a.idsubprograma, Nombre = a.subprograma }).Distinct(), "Id", "Nombre"));
        }


        public JsonResult FetchClasificacion(int idSubprograma)
        {

            List<stgProgModel> listaCompleta = stg_prog();



            List<stgProgModel> lista = listaCompleta.Where(a => a.idsubprograma == idSubprograma).ToList();


            List<stgProgModel> listaFinal =
                lista
                .ToList();


            return Json(new SelectList(listaFinal.Where(a => a.idclasificacion != null).Select(a => new { Id = a.idclasificacion, Nombre = a.clasificacion }).Distinct(), "Id", "Nombre"));
        }


        #endregion

        // GET: ObraRecursos
        public async Task<IActionResult> Index()
        {
            var smartBoardContext = _context.TblObraRecursos.Include(t => t.IdEjercicioNavigation).Include(t => t.IdProgramaNavigation).Include(t => t.IdRecursoNavigation).Include(t => t.IdSubprogramaNavigation).Include(t => t.IdTblobraNavigation);
            return View(await smartBoardContext.ToListAsync());
        }

        // GET: ObraRecursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblObraRecurso = await _context.TblObraRecursos
                .Include(t => t.IdEjercicioNavigation)
                .Include(t => t.IdProgramaNavigation)
                .Include(t => t.IdRecursoNavigation)
                .Include(t => t.IdSubprogramaNavigation)
                .Include(t => t.IdTblobraNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblObraRecurso == null)
            {
                return NotFound();
            }

            return View(tblObraRecurso);
        }

        // GET: ObraRecursos/Create
        public IActionResult Create(int IdTblobra)
        {
            ViewData["IdTiporecurso"] = new SelectList(_context.CatTipoRecursos, "Id", "Nombre");
            ViewData["IdRamo"] = new SelectList(_context.CatRamos, "Id", "Nombre");
            ViewData["IdRubro"] = new SelectList(_context.CatRubros, "Id", "Nombre");
            ViewData["IdFondo"] = new SelectList(_context.CatFondos, "Id", "Nombre");
            ViewData["IdClasificacion"] = new SelectList(_context.CatClasificacions, "Id", "Nombre");


            ViewData["IdEjercicio"] = new SelectList(_context.CatEjercicios, "Id", "Nombre");
            ViewData["IdPrograma"] = new SelectList(_context.CatProgramas, "Id", "Nombre");
            ViewData["IdRecurso"] = new SelectList(_context.CatOrigenrecursos, "Id", "Nombre");
            ViewData["IdSubprograma"] = new SelectList(_context.CatSubprogramas, "Id", "Nombre");
            ViewData["IdTblobra"] = new SelectList(_context.TblObras, "Id", "Id", IdTblobra);
            ViewData["miIdObra"] = IdTblobra;
            return View();
        }

        // POST: ObraRecursos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblObraRecurso tblObraRecurso)
        {
            tblObraRecurso.Activo = true;
            tblObraRecurso.Registro = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(tblObraRecurso);
                await _context.SaveChangesAsync();
                return RedirectToAction("EditExpediente", "TblObras", new { id = tblObraRecurso.IdTblobra });
                //return RedirectToAction(nameof(Index));
            }
            ViewData["IdEjercicio"] = new SelectList(_context.CatEjercicios, "Id", "Nombre", tblObraRecurso.IdEjercicio);
            ViewData["IdPrograma"] = new SelectList(_context.CatProgramas, "Id", "Nombre", tblObraRecurso.IdPrograma);
            ViewData["IdRecurso"] = new SelectList(_context.CatOrigenrecursos, "Id", "Nombre", tblObraRecurso.IdRecurso);
            ViewData["IdSubprograma"] = new SelectList(_context.CatSubprogramas, "Id", "Nombre", tblObraRecurso.IdSubprograma);
            ViewData["IdTblobra"] = new SelectList(_context.TblObras, "Id", "Id", tblObraRecurso.IdTblobra);
            ViewData["miIdObra"] = tblObraRecurso.IdTblobra;

            ViewData["IdTiporecurso"] = new SelectList(_context.CatTipoRecursos, "Id", "Nombre", tblObraRecurso.IdTiporecurso);
            ViewData["IdRamo"] = new SelectList(_context.CatRamos, "Id", "Nombre", tblObraRecurso.IdRamo);
            ViewData["IdRubro"] = new SelectList(_context.CatRubros, "Id", "Nombre", tblObraRecurso.IdRubro);
            ViewData["IdFondo"] = new SelectList(_context.CatFondos, "Id", "Nombre", tblObraRecurso.IdFondo);
            ViewData["IdClasificacion"] = new SelectList(_context.CatClasificacions, "Id", "Nombre", tblObraRecurso.IdClasificacion);


            return View(tblObraRecurso);
        }


        // GET: ObraRecursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblObraRecurso = await _context.TblObraRecursos.FindAsync(id);
            if (tblObraRecurso == null)
            {
                return NotFound();
            }
            ViewData["IdEjercicio"] = new SelectList(_context.CatEjercicios, "Id", "Nombre", tblObraRecurso.IdEjercicio);
            ViewData["IdPrograma"] = new SelectList(_context.CatProgramas, "Id", "Nombre", tblObraRecurso.IdPrograma);
            ViewData["IdRecurso"] = new SelectList(_context.CatOrigenrecursos, "Id", "Nombre", tblObraRecurso.IdRecurso);
            ViewData["IdSubprograma"] = new SelectList(_context.CatSubprogramas, "Id", "Nombre", tblObraRecurso.IdSubprograma);
            ViewData["IdTblobra"] = new SelectList(_context.TblObras, "Id", "Id", tblObraRecurso.IdTblobra);
            return View(tblObraRecurso);
        }

        // POST: ObraRecursos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTblobra,IdRecurso,IdEjercicio,IdPrograma,IdSubprograma,Autorizados,ImporteContratado,ImporteModificado,ImporteEjercido,ImportePorEjercer,Activo,Registro")] TblObraRecurso tblObraRecurso)
        {
            if (id != tblObraRecurso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblObraRecurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblObraRecursoExists(tblObraRecurso.Id))
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
            ViewData["IdEjercicio"] = new SelectList(_context.CatEjercicios, "Id", "Nombre", tblObraRecurso.IdEjercicio);
            ViewData["IdPrograma"] = new SelectList(_context.CatProgramas, "Id", "Nombre", tblObraRecurso.IdPrograma);
            ViewData["IdRecurso"] = new SelectList(_context.CatOrigenrecursos, "Id", "Nombre", tblObraRecurso.IdRecurso);
            ViewData["IdSubprograma"] = new SelectList(_context.CatSubprogramas, "Id", "Nombre", tblObraRecurso.IdSubprograma);
            ViewData["IdTblobra"] = new SelectList(_context.TblObras, "Id", "Id", tblObraRecurso.IdTblobra);
            return View(tblObraRecurso);
        }

        // GET: ObraRecursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblObraRecurso = await _context.TblObraRecursos
                .Include(t => t.IdEjercicioNavigation)
                .Include(t => t.IdProgramaNavigation)
                .Include(t => t.IdRecursoNavigation)
                .Include(t => t.IdSubprogramaNavigation)
                .Include(t => t.IdTblobraNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblObraRecurso == null)
            {
                return NotFound();
            }

            return View(tblObraRecurso);
        }

        // POST: ObraRecursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblObraRecurso = await _context.TblObraRecursos.FindAsync(id);
            _context.TblObraRecursos.Remove(tblObraRecurso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblObraRecursoExists(int id)
        {
            return _context.TblObraRecursos.Any(e => e.Id == id);
        }
    }
}
