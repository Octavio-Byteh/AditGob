using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SmartBoard.Data.Models.SmartBoard;
using SmartBoard.Models;
using SmartBoard.Services;

namespace SmartBoard.Controllers
{
    public class TblObrasController : Controller
    {
        private readonly SmartBoardContext _context;

        public TblObrasController(SmartBoardContext context)
        {
            _context = context;
        }

        #region Archivos

        
        public ActionResult MostrarFile(int IdDocObra, int IdDoc, int idObra, string fileName)
        {
            //Build the File Path.
            var pathUpload = Path.Combine(
                      Directory.GetCurrentDirectory(),
                      "wwwroot", "img", "expediente", IdDocObra.ToString(), IdDoc.ToString());

           

            //var docObra = _context.TblObradocumentoprocesos.Where(a => a.IdTblobra == idObra && a.Id == IdDoc).FirstOrDefault();
            //if (docObra != null)
            //{
            //    if (!string.IsNullOrWhiteSpace(docObra.Nombrearchivo))
            //    {


            //        fileName = docObra.Nombrearchivo;


            //    }
            //}

            var mypath = pathUpload;

            string path = mypath + @"\" + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            var cd = new System.Net.Mime.ContentDisposition
            {
                // for example foo.bak
                FileName = fileName,

                // always prompt the user for downloading, set to true if you want 
                // the browser to try to show the file inline
                Inline = false,
            };
            Response.Headers["CustomHeader1"] = new[] { "Content-Disposition", cd.ToString() };

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult MostrarFileEstimacion(int IdDocObra, int IdDoc, int idObra, string fileName, bool factura)
        {
            //Build the File Path.
            var pathUpload = Path.Combine(
                      Directory.GetCurrentDirectory(),
                      "wwwroot", "img", "expediente", IdDocObra.ToString(), "estimacion", IdDoc.ToString(), (factura ? "factura" : "evidencia"));


            var mypath = pathUpload;

            string path = mypath + @"\" + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            var cd = new System.Net.Mime.ContentDisposition
            {
                // for example foo.bak
                FileName = fileName,

                // always prompt the user for downloading, set to true if you want 
                // the browser to try to show the file inline
                Inline = false,
            };
            Response.Headers["CustomHeader1"] = new[] { "Content-Disposition", cd.ToString() };

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }

        public FileResult DownloadFile(int IdDocObra, int IdDoc, int idObra, string fileName)
        {
            //Build the File Path.
            var pathUpload = Path.Combine(
                      Directory.GetCurrentDirectory(),
                      "wwwroot", "img", "expediente", IdDocObra.ToString(), IdDoc.ToString());

            //var mypath = pathUpload.Replace(Path.Combine(
            //        Directory.GetCurrentDirectory(),
            //        "wwwroot", "img"), "").Replace("/", @"\");

            //var docObra = _context.TblObradocumentoprocesos.Where(a => a.IdTblobra == idObra && a.Id == IdDoc).FirstOrDefault();
            //if (docObra != null)
            //{
            //    if (!string.IsNullOrWhiteSpace(docObra.Nombrearchivo))
            //    {


            //        fileName = docObra.Nombrearchivo;


            //    }
            //}

            var mypath = pathUpload;

            string path = mypath + @"\" + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }

        public FileResult DownloadFileEstimacion(int IdDocObra, int IdDoc, int idObra, string fileName,bool factura)
        {
            //Build the File Path.
            var pathUpload = Path.Combine(
                      Directory.GetCurrentDirectory(),
                      "wwwroot", "img", "expediente", IdDocObra.ToString(), "estimacion", IdDoc.ToString(), (factura ? "factura" : "evidencia"));

           

            var mypath = pathUpload;

            string path = mypath + @"\" + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }


        [HttpPost]
        public ActionResult BorrarArchivo(int id)
        {
            var docsObra =
                            _context
                            .TblObradocumentoprocesos
                            .Where(a => a.Id == id)
                            .FirstOrDefault();
            if (docsObra != null)
            {
                docsObra.Rutaarchivo = "";
                docsObra.Nombrearchivo = "";
                docsObra.Estatus = "red";
                docsObra.Observaciones = "";


                _context.Update(docsObra);
                _context.SaveChangesAsync();

                return Json("1");
            }
            return Json("0");
        }


        [HttpPost]
        public ActionResult BorrarArchivoFactura(int id,string file)
        {
            var docsObra =
                            _context
                            .TblObraEstimacions
                            .Where(a => a.Id == id)
                            .FirstOrDefault();
            if (docsObra != null)
            {
                docsObra.RutaArchivoFactura = "";
                docsObra.NombreArchivoFactura = "";
               
                _context.Update(docsObra);
                _context.SaveChangesAsync();

                try
                {
                    var pathUpload = Path.Combine(
                   Directory.GetCurrentDirectory(),
                   "wwwroot", "img", "expediente", docsObra.IdTblobra.ToString(), "estimacion", docsObra.Id.ToString(), "factura");
                    //"wwwroot", "img", "expediente", IdDocObra.ToString(), "estimacion", IdDoc.ToString(), (factura ? "factura" : "evidencia"));

                    var mypath = pathUpload;
                    string path = mypath + @"\" + file;
                    System.IO.File.Delete(path);
                }
                catch (Exception)
                {
                    return Json("0");
                }              

                return Json("1");
            }
            return Json("0");
        }



        [HttpPost]
        public ActionResult BorrarArchivoEvidencia(int id, string file)
        {
            var docsObra =
                            _context
                            .TblObraEstimacions
                            .Where(a => a.Id == id)
                            .FirstOrDefault();
            if (docsObra != null)
            {
                docsObra.RutaArchivoEvidencia = "";
                docsObra.NombreArchivoEvidencia = "";

                _context.Update(docsObra);
                _context.SaveChangesAsync();

                try
                {
                    var pathUpload = Path.Combine(
                   Directory.GetCurrentDirectory(),
                   "wwwroot", "img", "expediente", docsObra.IdTblobra.ToString(), "estimacion", docsObra.Id.ToString(), "evidencia");
                    //"wwwroot", "img", "expediente", IdDocObra.ToString(), "estimacion", IdDoc.ToString(), (factura ? "factura" : "evidencia"));

                    var mypath = pathUpload;
                    string path = mypath + @"\" + file;
                    System.IO.File.Delete(path);
                }
                catch (Exception)
                {
                    return Json("0");
                }

                return Json("1");
            }
            return Json("0");
        }


        [HttpPost]
        public ActionResult BorrarArchivoName(int id,string file)
        {
            var docsObra =
                            _context
                            .TblObradocumentoprocesos
                            .Where(a => a.Id == id)
                            .FirstOrDefault();
            if (docsObra != null)
            {
                docsObra.Rutaarchivo = "";
                docsObra.Nombrearchivo = "";
                docsObra.Estatus = "red";
                docsObra.Observaciones = "";


                _context.Update(docsObra);
                _context.SaveChangesAsync();

                try
                {
                    var pathUpload = Path.Combine(
                   Directory.GetCurrentDirectory(),
                   "wwwroot", "img", "expediente", docsObra.IdTblobra.ToString(), docsObra.Id.ToString());

                    var mypath = pathUpload;
                    string path = mypath + @"\" + file;
                    System.IO.File.Delete(path);
                }
                catch (Exception)
                {

                    return Json("0");
                }
               

                return Json("1");
            }
            return Json("0");
        }


        [HttpPost]
        public ActionResult ObservacionArchivo(int id,string observacion)
        {
            var docsObra =
                            _context
                            .TblObradocumentoprocesos
                            .Where(a => a.Id == id)
                            .FirstOrDefault();
            if (docsObra != null)
            {
                docsObra.Observaciones = observacion;
                docsObra.Estatus = "red";
                
                _context.Update(docsObra);
                _context.SaveChangesAsync();

                return Json("1");
            }
            return Json("0");
        }


         [HttpPost]
        public ActionResult guardarAprobacion(int id)
        {
            var docsObra =
                            _context
                            .TblObradocumentoprocesos
                            .Where(a => a.Id == id)
                            .FirstOrDefault();
            if (docsObra != null)
            {

                docsObra.Aprobado = true;
                docsObra.Estatus = "green";

                _context.Update(docsObra);
                _context.SaveChangesAsync();

                return Json("1");
            }
            return Json("0");
        }


        [HttpPost]
        public ActionResult UploadFiles(int idObra, List<IFormFile> files)
        {
            //if (Request.Files.Count > 0)
            //{

            //}

            int IdDocObra = int.Parse(HttpContext.Request.Form["IdDocObra"]);
            int IdObra = int.Parse(HttpContext.Request.Form["IdObra"]);
            int IdDoc = int.Parse(HttpContext.Request.Form["IdDoc"]);

            //int IdDocObra = 25693;
            //int IdDoc = 1;

            bool hasFiles = false;
            string mimeType = "";
            var fileName = "demo.jpg";
            string rutaArchivo = "";

            files = HttpContext.Request.Form.Files.ToList();

            if (files.Count() > 0)
            {
                hasFiles = true;



                var pathUpload = Path.Combine(
                      Directory.GetCurrentDirectory(),
                      "wwwroot", "img", "expediente", IdDocObra.ToString(), IdDoc.ToString());

                if (!Directory.Exists(pathUpload))
                {
                    Directory.CreateDirectory(pathUpload);
                }




                long size = files.Sum(f => f.Length);

                List<string> uploadedFiles = new List<string>();
                foreach (IFormFile postedFile in files)
                {
                    mimeType = postedFile.ContentType;

                    // Se obtien el dia del campo, se inclue en el files desde la vista con la etiqueta name="Id_Files_***"


                    fileName = DateTime.Now.Ticks + Path.GetFileName(postedFile.FileName);
                    rutaArchivo = Path.Combine(pathUpload, fileName);

                    using (FileStream stream = new FileStream(Path.Combine(pathUpload, fileName), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                        uploadedFiles.Add(fileName);
                        ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                    }

                    // Inluimos la lista de Documentos adjuntos
                    if (hasFiles == true)
                    {
                        var docsObra =
                            _context
                            .TblObradocumentoprocesos
                            .Where(a => a.IdTblobra == IdObra && a.Id == IdDoc)
                            .FirstOrDefault();
                        docsObra.Rutaarchivo = rutaArchivo;
                        docsObra.Nombrearchivo = fileName;
                        docsObra.Estatus = "yellow";
                        docsObra.Observaciones = "";



                        _context.Update(docsObra);
                        _context.SaveChangesAsync();

                        //var Adjuntos = new DocumentosAdjunto
                        //{
                        //    Activo = true,
                        //    IdCampo = id_Campo,
                        //    MimeType = mimeType,
                        //    Ruta = rutaArchivo,

                        //};

                        //Resultado.DocumentosAdjuntos.Add(Adjuntos);
                    }

                }
                return Json("1");
            }
            else
            {
                return Json("0");
            }


        }


        [HttpPost]
        public ActionResult UploadFilesEVFactura(int idObra, List<IFormFile> files)
        {
            //if (Request.Files.Count > 0)
            //{

            //}

            int IdDocObra = int.Parse(HttpContext.Request.Form["IdDocObra"]);
            int IdObra = int.Parse(HttpContext.Request.Form["IdObra"]);
            int IdDoc = int.Parse(HttpContext.Request.Form["IdDoc"]);

            //int IdDocObra = 25693;
            //int IdDoc = 1;

            bool hasFiles = false;
            string mimeType = "";
            var fileName = "demo.jpg";
            string rutaArchivo = "";

            files = HttpContext.Request.Form.Files.ToList();

            if (files.Count() > 0)
            {
                hasFiles = true;



                var pathUpload = Path.Combine(
                      Directory.GetCurrentDirectory(),
                      "wwwroot", "img", "expediente", IdDocObra.ToString(),"estimacion", IdDoc.ToString(), "factura");

                if (!Directory.Exists(pathUpload))
                {
                    Directory.CreateDirectory(pathUpload);
                }




                long size = files.Sum(f => f.Length);

                List<string> uploadedFiles = new List<string>();
                foreach (IFormFile postedFile in files)
                {
                    mimeType = postedFile.ContentType;

                    // Se obtien el dia del campo, se inclue en el files desde la vista con la etiqueta name="Id_Files_***"


                    fileName = DateTime.Now.Ticks + Path.GetFileName(postedFile.FileName);
                    rutaArchivo = Path.Combine(pathUpload, fileName);

                    using (FileStream stream = new FileStream(Path.Combine(pathUpload, fileName), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                        uploadedFiles.Add(fileName);
                        ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                    }

                    // Inluimos la lista de Documentos adjuntos
                    if (hasFiles == true)
                    {
                        var docsObra =
                            _context
                            .TblObraEstimacions
                            .Where(a => a.IdTblobra == IdObra && a.Id == IdDoc)
                            .FirstOrDefault();
                        docsObra.RutaArchivoFactura = rutaArchivo;
                        docsObra.NombreArchivoFactura = fileName;
                        //docsObra.Estatus = "yellow";
                        //docsObra.Observaciones = "";



                        _context.Update(docsObra);
                        _context.SaveChangesAsync();

                    }

                }
                return Json("1");
            }
            else
            {
                return Json("0");
            }


        }



        [HttpPost]
        public ActionResult UploadFilesEvidencia(int idObra, List<IFormFile> files)
        {
            //if (Request.Files.Count > 0)
            //{

            //}

            int IdDocObra = int.Parse(HttpContext.Request.Form["IdDocObra"]);
            int IdObra = int.Parse(HttpContext.Request.Form["IdObra"]);
            int IdDoc = int.Parse(HttpContext.Request.Form["IdDoc"]);

            //int IdDocObra = 25693;
            //int IdDoc = 1;

            bool hasFiles = false;
            string mimeType = "";
            var fileName = "demo.jpg";
            string rutaArchivo = "";

            files = HttpContext.Request.Form.Files.ToList();

            if (files.Count() > 0)
            {
                hasFiles = true;



                var pathUpload = Path.Combine(
                      Directory.GetCurrentDirectory(),
                      "wwwroot", "img", "expediente", IdDocObra.ToString(), "estimacion", IdDoc.ToString(), "evidencia");

                if (!Directory.Exists(pathUpload))
                {
                    Directory.CreateDirectory(pathUpload);
                }




                long size = files.Sum(f => f.Length);

                List<string> uploadedFiles = new List<string>();
                foreach (IFormFile postedFile in files)
                {
                    mimeType = postedFile.ContentType;

                    // Se obtien el dia del campo, se inclue en el files desde la vista con la etiqueta name="Id_Files_***"


                    fileName = DateTime.Now.Ticks + Path.GetFileName(postedFile.FileName);
                    rutaArchivo = Path.Combine(pathUpload, fileName);

                    using (FileStream stream = new FileStream(Path.Combine(pathUpload, fileName), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                        uploadedFiles.Add(fileName);
                        ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                    }

                    // Inluimos la lista de Documentos adjuntos
                    if (hasFiles == true)
                    {
                        var docsObra =
                            _context
                            .TblObraEstimacions
                            .Where(a => a.IdTblobra == IdObra && a.Id == IdDoc)
                            .FirstOrDefault();
                        docsObra.RutaArchivoEvidencia = rutaArchivo;
                        docsObra.NombreArchivoEvidencia = fileName;
                        //docsObra.Estatus = "yellow";
                        //docsObra.Observaciones = "";



                        _context.Update(docsObra);
                        _context.SaveChangesAsync();

                    }

                }
                return Json("1");
            }
            else
            {
                return Json("0");
            }


        }


        [HttpPost]
        public ActionResult UploadFilesFotos(int idObra, List<IFormFile> files)
        {
            //if (Request.Files.Count > 0)
            //{

            //}

            int IdDocObra = int.Parse(HttpContext.Request.Form["IdDocObra"]);
            int IdObra = int.Parse(HttpContext.Request.Form["IdObra"]);
            int IdDoc = int.Parse(HttpContext.Request.Form["IdDoc"]);

            //int IdDocObra = 25693;
            //int IdDoc = 1;

            bool hasFiles = false;
            string mimeType = "";
            var fileName = "demo.jpg";
            string rutaArchivo = "";

            files = HttpContext.Request.Form.Files.ToList();

            if (files.Count() > 0)
            {
                hasFiles = true;



                var pathUpload = Path.Combine(
                      Directory.GetCurrentDirectory(),
                      "wwwroot", "img", "fotos", IdDocObra.ToString());

                if (!Directory.Exists(pathUpload))
                {
                    Directory.CreateDirectory(pathUpload);
                }




                long size = files.Sum(f => f.Length);

                List<string> uploadedFiles = new List<string>();
                foreach (IFormFile postedFile in files)
                {
                    mimeType = postedFile.ContentType;

                    // Se obtien el dia del campo, se inclue en el files desde la vista con la etiqueta name="Id_Files_***"


                    fileName = DateTime.Now.Ticks + Path.GetFileName(postedFile.FileName);
                    rutaArchivo = Path.Combine(pathUpload, fileName);

                    using (FileStream stream = new FileStream(Path.Combine(pathUpload, fileName), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                        uploadedFiles.Add(fileName);
                        ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                    }

                    // Inluimos la lista de Documentos adjuntos
                    if (hasFiles == true)
                    {
                        //var docsObra =
                        //    _context
                        //    .TblObradocumentoprocesos
                        //    .Where(a => a.IdTblobra == IdObra && a.Id == IdDoc)
                        //    .FirstOrDefault();
                        //docsObra.Rutaarchivo = rutaArchivo;
                        //docsObra.Nombrearchivo = fileName;



                        //_context.Update(docsObra);
                        //_context.SaveChangesAsync();

                        //var Adjuntos = new DocumentosAdjunto
                        //{
                        //    Activo = true,
                        //    IdCampo = id_Campo,
                        //    MimeType = mimeType,
                        //    Ruta = rutaArchivo,

                        //};

                        //Resultado.DocumentosAdjuntos.Add(Adjuntos);
                    }

                }
                return Json("1");
            }
            else
            {
                return Json("0");
            }


        }
        
        
        #endregion

        #region Jsons



        [HttpGet]
        public ActionResult GetPlantilla()
        {

            var listaPlantillas = new List<ExpedientePlantillaViewModel>()
            {
                new ExpedientePlantillaViewModel(){id =1, nombre = "RESOLUTIVO DE MANIFESTACIÓN DE IMPACTO AMBIENTAL O EL OFICIO DE EXENCIÓN CORRESPONDIENTE, EMITIDA(O) POR LA DEPENDENCIA NORMATIVA MUNICIPAL, ESTATAL Y/O FEDERAL CORRESPONDIENTE.",administracion = true, adjudicacion=true, invitacion = false, licitacion = true },
                new ExpedientePlantillaViewModel(){id =2, nombre = "PROYECTO EJECUTIVO DE LA OBRA (Y MODIFICACIONES, EN SU CASO), DEBIDAMENTE SIGNADO POR EL CONTRATISTA DE LA OBRA Y LOS SERVIDORES PÚBLICOS  RESPONSABLES",administracion = true, adjudicacion=true, invitacion = false, licitacion = true },
                new ExpedientePlantillaViewModel(){id =3, nombre = "MEMORIA DE CÁLCULO ESTRUCTURAL DEBIDAMENTE SIGNADA POR EL CALCULISTA, EL CONTRATISTA DE LA OBRA Y LOS SERVIDORES PÚBLICOS MUNICIPALES RESPONSABLES. (ESTRUCTURAL, HIDRÁULICA, SANITARIA, ELÉCTRICA, ETC.).",administracion = true, adjudicacion=true, invitacion = false, licitacion = true },
                new ExpedientePlantillaViewModel(){id =4, nombre = "INVITACIONES A LAS EMPRESAS A PARTICIPAR EN EL CONCURSO POR INVITACIÓN PARA LA EJECUCIÓN DE LA OBRA OBSERVADA Y SUS CONTESTACIONES.",administracion = true, adjudicacion=true, invitacion = false, licitacion = true },
                new ExpedientePlantillaViewModel(){id =5, nombre = "BASES DE LICITACIÓN DEL CONCURSO POR INVITACIÓN.",administracion = true, adjudicacion=true, invitacion = false, licitacion = true },
                new ExpedientePlantillaViewModel(){id =6, nombre = "ACTA DE LA JUNTA DE ACLARACIONES DEL CONCURSO POR INVITACIÓN, DEBIDAMENTE SIGNADA POR LOS CONTRATISTAS PARTICIPANTES Y LOS FUNCIONARIOS PÚBLICOS RESPONSABLES QUE EN ELLA INTERVINIERON",administracion = true, adjudicacion=true, invitacion = false, licitacion = true },
                new ExpedientePlantillaViewModel(){id =7, nombre = "PROPUESTAS INTERNAS",administracion = true, adjudicacion=true, invitacion = false, licitacion = true }
            }.ToList();


            return Json(listaPlantillas);
        }


        public JsonResult FetchEje()
        {
            return Json(new SelectList(_context.CatEjes, "Id", "Nombre"));
        }

        public JsonResult FetchEstrategia(int ideje)
        {
            return Json(new SelectList(_context.CatEstrategia.Where(a => a.Ideje == ideje), "Id", "Nombre"));
        }


        public JsonResult FetchLineaAccion(int idestrategia)
        {
            return Json(new SelectList(_context.CatLineaaccions.Where(a => a.Idestrategia == idestrategia), "Id", "Nombre"));
        }


        public JsonResult FetchVertientes()
        {
            return Json(new SelectList(_context.CatVertientes, "Id", "Nombre"));
        }


        public JsonResult FetchSubVertientes(int idVertiente)
        {
            return Json(new SelectList(_context.CatSubvertientes.Where(a => a.Idvertiente == idVertiente), "Id", "Nombre"));
        }

        public JsonResult FetchCatProgSoc()
        {
            return Json(new SelectList(_context.CatProgsocs, "Id", "Descripcion"));
        }


        public JsonResult FetchCategoria()
        {
            return Json(new SelectList(_context.CatCategoria, "Id", "Nombre"));
        }

        public JsonResult FetchRegion()
        {
            return Json(new SelectList(_context.CatRegions, "Id", "Nombre"));
        }

        public JsonResult FetchLocalidades(int urllocalidad)
        {
            return Json(new SelectList(_context.CatLocalidads.Where(a => a.Idmunicipio == urllocalidad), "Id", "Clave"));
        }
        public JsonResult FetchMunucipios(int idregion)
        {
            return Json(new SelectList(_context.CatMunicipios.Where(a => a.Idregion == idregion), "Id", "Municipio"));
        }

        public JsonResult FetchGradoMarginacion()
        {
            return Json(new SelectList(_context.CatGradomarginals.Where(a => a.Activo==true), "Id", "Nombre"));
        }
        
        public JsonResult FetchNormativaAplicable()
        {
            return Json(new SelectList(_context.CatNormativaAplicables.Where(a => a.Activo==true), "Id", "Nombre"));
        } 
        
        public JsonResult FetchModalidadEjecucion()
        {
            return Json(new SelectList(_context.CatModalidadEjecucions.Where(a => a.Activo==true), "Id", "Nombre"));
        }

        public JsonResult FetchAdjudicacionByNormativa(int idnormativa, int idtipoobra)
        {
            if (idnormativa == 1 && idtipoobra == 2)
            {
                return Json(new SelectList(_context.CatTipoAdjudicacions.Where(a => a.Idtipoobra == idtipoobra && a.Activo == true && a.Id != 6), "Id", "Nombre"));
            }
            if (idnormativa == 1 && idtipoobra == 1)
            {
                return Json(new SelectList(_context.CatTipoAdjudicacions.Where(a => a.Idtipoobra == idtipoobra && a.Activo == true && a.Id != 2), "Id", "Nombre"));
            }
            else if (idnormativa == 0)
            {
                return Json(new SelectList(_context.CatTipoAdjudicacions.Where(a => a.Idtipoobra == idtipoobra &&  a.Activo == true && a.Id == 0), "Id", "Nombre"));
            }
            else
            {
                return Json(new SelectList(_context.CatTipoAdjudicacions.Where(a => a.Idtipoobra == idtipoobra &&  a.Activo == true), "Id", "Nombre"));
            }
            //return Json(new SelectList(_context.CatLocalidads.Where(a => a.Idmunicipio == idnormativa), "Id", "Clave"));
        }

        #endregion


        #region Puebla Catalogos

        public JsonResult FetchGrado()
        {
            return Json(new SelectList(
            new List<SelectListItem>
            {
        //new SelectListItem { Selected = true, Text = string.Empty, Value = "-1"},
        new SelectListItem { Selected = false, Text = "Muy -baja", Value = "1"},
        new SelectListItem { Selected = false, Text = "Baja", Value = "2"},
        new SelectListItem { Selected = false, Text = "Media", Value = "3"},
        new SelectListItem { Selected = false, Text = "Alta", Value = "4"},
        new SelectListItem { Selected = false, Text = "Muy alta", Value = "5"},
            }
            , "Value", "Text"));
        }

        public SelectList grados(int? id)
        {
            return new SelectList(_context.CatGradomarginals.Where(a => a.Activo == true).ToList(), "Id", "Nombre", id);

            //    return new SelectList(
            //    new List<SelectListItem>
            //    {
            ////new SelectListItem { Selected = true, Text = string.Empty, Value = "-1"},
            //new SelectListItem { Selected = false, Text = "Muy -baja", Value = "1"},
            //new SelectListItem { Selected = false, Text = "Baja", Value = "2"},
            //new SelectListItem { Selected = false, Text = "Media", Value = "3"},
            //new SelectListItem { Selected = false, Text = "Alta", Value = "4"},
            //new SelectListItem { Selected = false, Text = "Muy alta", Value = "5"},
            //    }
            //    , "Value", "Text");



        }

        public SelectList zap(int? id)
        {
            return new SelectList(_context.CatCattipomunicipios.Where(a => a.Activo == true).ToList(), "Id", "Nombre", id);

        }

        public SelectList normativa(int? id)
        {
            return new SelectList(_context.CatNormativaAplicables.Where(a => a.Activo == true).ToList(), "Id", "Nombre", id);


        }


        public SelectList modelidadejecucion(int? id)
        {
            return new SelectList(_context.CatModalidadEjecucions.Where(a => a.Activo == true).ToList(), "Id", "Nombre", id);

        }

        public SelectList contratacion(int? id)
        {
            return new SelectList(_context.CatContratacions.Where(a => a.Activo == true).ToList(), "Id", "Nombre", id);
        }



        public SelectList adjudicacion(int? id)
        {
            return new SelectList(_context.CatTipoAdjudicacions.Where(a => a.Activo == true).ToList(), "Id", "Nombre", id);
        }



        public SelectList tipoContrato(int? id, int idTipoObra)
        {
            return new SelectList(_context.CatTipoDeContratos.Where(a => a.Idtipoobra == idTipoObra && a.Activo == true).ToList(), "Id", "Nombre", id);
        }


        #endregion


        public async Task<IActionResult> getArchivos(int iddoc)
        {
            var lista = await _context.TblObradocumentoprocesos
                .Where(a => a.Id == iddoc)
                .Select(a => new ObraChkDocumento { multiplefile = a.ArchivoMultiple, idObra = a.IdTblobra, id = a.Id, path = a.Rutaarchivo, filename = a.Nombrearchivo })
                .ToListAsync();

            List<ObraChkDocumento> lista2 = new List<ObraChkDocumento>();

            foreach (var item in lista)
            {
                if (item.multiplefile == true)
                {
                    var listFiles =
                    (
                     new ImagesService().GetDocuments(item.idObra, item.id)
                    );
                    foreach (var itemFile in listFiles)
                    {
                        lista2.Add(new ObraChkDocumento()
                        {
                            id = item.id,
                            idObra = item.idObra,
                            filename = itemFile.filename,
                            path = itemFile.Pathimagen
                        });
                    }
                }
                else
                {
                    lista2.Add(new ObraChkDocumento()
                    {
                        id = item.id,
                        idObra = item.idObra,
                        filename = item.filename,
                        path = item.path
                    });
                }
                
            }


            return View(lista2);
        }
          public async Task<IActionResult> getArchivosEVFactura(int iddoc)
        {
            var lista = await _context.TblObraEstimacions
                .Where(a => a.Id == iddoc)
                .Select(a => new ObraChkDocumento { multiplefile = false, idObra = a.IdTblobra, id = a.Id, path = a.RutaArchivoFactura, filename = a.NombreArchivoFactura })
                .ToListAsync();

            List<ObraChkDocumento> lista2 = new List<ObraChkDocumento>();

            foreach (var item in lista)
            {
                if (item.multiplefile == true)
                {
                    var listFiles =
                    (
                     new ImagesService().GetEstimacionesDocs(item.idObra, item.id,true)
                    );
                    foreach (var itemFile in listFiles)
                    {
                        lista2.Add(new ObraChkDocumento()
                        {
                            id = item.id,
                            idObra = item.idObra,
                            filename = itemFile.filename,
                            path = itemFile.Pathimagen
                        });
                    }
                }
                else
                {
                    lista2.Add(new ObraChkDocumento()
                    {
                        id = item.id,
                        idObra = item.idObra,
                        filename = item.filename,
                        path = item.path
                    });
                }
                
            }


            return View(lista2);
        }
           public async Task<IActionResult> getArchivosEvidencia(int iddoc)
        {
            var lista = await _context.TblObraEstimacions
                .Where(a => a.Id == iddoc)
                .Select(a => new ObraChkDocumento { multiplefile = false, idObra = a.IdTblobra, id = a.Id, path = a.RutaArchivoEvidencia, filename = a.NombreArchivoEvidencia })
                .ToListAsync();

            List<ObraChkDocumento> lista2 = new List<ObraChkDocumento>();

            foreach (var item in lista)
            {
                if (item.multiplefile == true)
                {
                    var listFiles =
                    (
                     new ImagesService().GetEstimacionesDocs(item.idObra, item.id,false)
                    );
                    foreach (var itemFile in listFiles)
                    {
                        lista2.Add(new ObraChkDocumento()
                        {
                            id = item.id,
                            idObra = item.idObra,
                            filename = itemFile.filename,
                            path = itemFile.Pathimagen
                        });
                    }
                }
                else
                {
                    lista2.Add(new ObraChkDocumento()
                    {
                        id = item.id,
                        idObra = item.idObra,
                        filename = item.filename,
                        path = item.path
                    });
                }
                
            }


            return View(lista2);
        }

        // GET: TblObras
        public async Task<IActionResult> Index()
        {
            var smartBoardContext = _context.TblObras.Include(t => t.IdcategoriaNavigation).Include(t => t.IddependenciaNavigation).Include(t => t.IdejeNavigation).Include(t => t.IdejecutorNavigation).Include(t => t.IdestadoobraNavigation).Include(t => t.IdestadorevisionNavigation).Include(t => t.IdlocalidadNavigation).Include(t => t.IdmunicipioNavigation).Include(t => t.IdpoadetalleNavigation).Include(t => t.IdprogsogNavigation).Include(t => t.IdsubvertienteNavigation).Include(t => t.IdunidadmedidaNavigation).Include(t => t.IdvertienteNavigation);
            return View(await smartBoardContext.ToListAsync());
        }

        // GET: TblObras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblObra = await _context.TblObras
                .Include(t => t.IdcategoriaNavigation)
                .Include(t => t.IddependenciaNavigation)
                .Include(t => t.IdejeNavigation)
                .Include(t => t.IdejecutorNavigation)
                .Include(t => t.IdestadoobraNavigation)
                .Include(t => t.IdestadorevisionNavigation)
                .Include(t => t.IdlocalidadNavigation)
                .Include(t => t.IdmunicipioNavigation)
                .Include(t => t.IdpoadetalleNavigation)
                .Include(t => t.IdprogsogNavigation)
                .Include(t => t.IdsubvertienteNavigation)
                .Include(t => t.IdunidadmedidaNavigation)
                .Include(t => t.IdvertienteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblObra == null)
            {
                return NotFound();
            }

            return View(tblObra);
        }

        // GET: TblObras/Create
        public IActionResult CreateExpediente(int IdtipoObra)
        {
            ViewData["MyIdtipoObra"] = IdtipoObra;
            ViewData["Ideje"] = new SelectList(_context.CatEjes, "Id", "Nombre");
            ViewData["Idestrategia"] = new SelectList(_context.CatEstrategia, "Id", "Nombre");
            ViewData["Idlineaaccion"] = new SelectList(_context.CatLineaaccions, "Id", "Nombre");
            
            ViewData["Idcategoria"] = new SelectList(_context.CatCategoria, "Id", "Nombre");
            ViewData["Idregion"] = new SelectList(_context.CatRegions, "Id", "Nombre");
            ViewData["Idlocalidad"] = new SelectList(_context.CatLocalidads, "Id", "Clave");
            ViewData["Idmunicipio"] = new SelectList(_context.CatMunicipios, "Id", "Municipio");
            ViewData["Idpoadetalle"] = new SelectList(_context.TblPoadetalles, "Id", "Actividades");

            ViewData["Idgradomarginal"] = grados(null);
            ViewData["Idzap"] = zap(null);
            ViewData["IdnormativaAplicable"] = normativa(null);
            ViewData["IdmodalidadEjecicion"] = modelidadejecucion((IdtipoObra == 2 ? 1 :null));
            ViewData["Idcontratacion"] = contratacion(null);
            ViewData["IdtipoAdjudicacion"] = adjudicacion(null);
            ViewData["IdtipoContrato"] = tipoContrato(null, IdtipoObra);

            ViewData["IdEjercicio"] = new SelectList(_context.CatEjercicios, "Id", "Nombre");

            return View();
        }

        // POST: TblObras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateExpediente(ExpedienteViewModal Obra)
        {
            
            if (ModelState.IsValid)
            {

                string lat = "", longitud = "";
                if (!string.IsNullOrWhiteSpace(Obra.Coordenadas))
                {
                    if (Obra.Coordenadas.Contains(",") && Obra.Coordenadas.Contains("."))
                    {
                        //tiene datos de cordenadas
                        string[] words = Obra.Coordenadas.Split(",");
                        if (words != null && words.Count() >= 1)
                        {
                            lat = words[0];
                            longitud = words[1];
                        }
                    }
                    else
                    {
                        lat = Obra.Coordenadas;
                        longitud = Obra.Coordenadas;
                    }
                }

                var categoriaCheck = _context.CatNormativaAplicables.Where(a => a.Id == Obra.IdnormativaAplicable).FirstOrDefault().Nombre;
                var tipoCheck = _context.CatTipoAdjudicacions.Where(a => a.Id == Obra.IdtipoAdjudicacion).FirstOrDefault();

                string tipo = "ADMON";
                if (tipoCheck != null)
                {

                    if (tipoCheck.Nombre.ToUpper().Contains("LICITA"))
                    {
                        tipo = "LP";
                    }
                    else if (tipoCheck.Nombre.ToUpper().Contains("ADJUDICA"))
                    {
                        tipo = "AD-";
                    }
                    else if (tipoCheck.Nombre.ToUpper().Contains("CONCURSO"))
                    {
                        tipo = "CI-";
                    }
                    else if (tipoCheck.Nombre.Contains("5") || tipoCheck.Nombre.Contains("3"))
                    {
                        tipo = "INV";
                    }
                }

                var listaPlantillas =
                    _context
                    .CatChecklists
                    .Where(a => 
                    a.Idtipoobra == Obra.IdtipoObra &&
                    a.IdcategoriachecklistNavigation.Nombre.Contains(categoriaCheck) &&
                    a.IdtipochecklistNavigation.Nombre.ToUpper().Contains(tipo)
                    ).AsEnumerable()
                    .Select((a, i) => new TblObrachecklist()
                    {
                        Activo = true,
                        Fecharegistro = DateTime.Now,
                        Nombre = a.Nombre,
                        Administracion = false,
                        Adjudicacion = false,
                        Invitacion = false,
                        Licitacion = false,
                        Estitulo = a.Estitilo,
                        Numero = i + 1,
                        Titulo = a.Titulo,
                        Norma = a.Norma,
                        TituloShort = (string.IsNullOrWhiteSpace(a.Titulo) ? "TBD" : a.Titulo.Replace(" ", "").Substring(1, 4)),
                        ArchivoExtensions = a.ArchivoExtensions,
                        ArchivoMultiple = a.ArchivoMultiple,
                        ArchivoPermite = a.ArchivoPermite,
                        HexColor = a.HexColor,
                        Secuencia = a.Secuencia

                    }).OrderBy(a => a.Numero).ToList();


                var listaDocumentos =
                    //_context
                    //.CatChecklists
                    //.Where(a =>
                    //a.IdcategoriachecklistNavigation.Nombre.Contains(categoriaCheck) &&
                    //a.IdtipochecklistNavigation.Nombre.ToUpper().Contains(tipo)
                    //)
                    listaPlantillas
                    .Select(a => new TblObradocumentoproceso()
                    {
                        Rutaarchivo = "",
                        Categoria = a.Titulo,
                        Activo = true,
                        Fecharegistro = DateTime.Now,
                        Estatus = "red",
                        Nombre = a.Nombre,
                        Aprobado = false,
                        Numero = a.Numero,
                        Titulo = a.Titulo,
                        TituloShort = a.TituloShort,
                        Estitulo = a.Estitulo,
                        Norma = a.Norma,
                        ArchivoExtensions = a.ArchivoExtensions,
                        ArchivoMultiple = a.ArchivoMultiple,
                        ArchivoPermite = a.ArchivoPermite,
                        HexColor = a.HexColor,
                        Secuencia = a.Secuencia

                        //Numero = 

                    }).OrderBy(a => a.Numero).ToList();
                
                int numberYear;
                string StringYear = _context.CatEjercicios.Where(a => a.Id == Obra.IdEjercicio).FirstOrDefault().Nombre;

                bool success = int.TryParse(StringYear, out numberYear);

                TblObra expediente = new TblObra()
                {
                    
                    Numeroobra = int.Parse(DateTime.Now.Ticks.ToString().Substring(1, 5)),
                    Numeroobraexterno = Obra.folio,
                    Nombreobra = Obra.Nombreobra,
                    Idmunicipio = Obra.Idmunicipio,
                    //Idlocalidad = Obra.Idlocalidad,
                    Coordenadax = lat,
                    Coordenaday = longitud,
                    Descripcion = Obra.Nombreobra,
                    Expediente = Obra.Expediente,
                    Idestadoobra = 2,
                    Idestadorevision = 1,

                    Region = _context.CatMunicipios.Where(a => a.Id == Obra.Idmunicipio).FirstOrDefault().Region,
                    Fecharegistro = DateTime.Now,
                    Year = success ? numberYear : DateTime.Now.Year,


                };

                expediente.Idgradomarginal = Obra.Idgradomarginal;
                expediente.IdnormativaAplicable = Obra.IdnormativaAplicable;
                expediente.IdmodalidadEjecicion = Obra.IdmodalidadEjecicion;
                expediente.Idcontratacion = Obra.Idcontratacion;
                expediente.IdtipoAdjudicacion = Obra.IdtipoAdjudicacion;
                expediente.IdtipoContrato = Obra.IdtipoContrato;
                //expediente.Idzap = Obra.Idzap;
                expediente.Idzap = Obra.Idzap;
                expediente.BeneficiarioNombre = Obra.BeneficiarioNombre;
                expediente.EntidadEjecutora = Obra.EntidadEjecutora;
                expediente.ContratistaNombre = Obra.ContratistaNombre;
                expediente.Porcentajeavance = Obra.Porcentajeavance;
                expediente.AvanceFinanciero = Obra.AvanceFinanciero;
                expediente.Localidad = Obra.Localidad;

                expediente.Ideje = Obra.Ideje;
                expediente.Idestrategia = Obra.Idestrategia;
                expediente.Idlineaacion = Obra.Idlineaaccion;

                expediente.EoPrograInicio = Obra.EoPrograInicio;
                expediente.EoPrograFin = Obra.EoPrograFin;
                expediente.EoReprograInicio = Obra.EoReprograInicio;
                expediente.EoReprograFin = Obra.EoReprograFin;
                expediente.EoRealInicio = Obra.EoRealInicio;
                expediente.EoRealFin = Obra.EoRealFin;
                expediente.IdtipoObra = Obra.IdtipoObra;
                expediente.ProveedorAdjudicado = Obra.ProveedorAdjudicado;
                expediente.EntidadRequiriente = Obra.EntidadRequiriente;


                expediente.TblObrachecklists = listaPlantillas;
                expediente.TblObradocumentoprocesos = listaDocumentos;

                _context.Add(expediente);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("EditExpediente", "TblObras", new { id = expediente.Id });
                //return RedirectPermanent("~/TblObras/EditExpediente?id=" + expediente.Id);
            }

            ViewData["MyIdtipoObra"] = Obra.IdtipoObra;

            ViewData["Ideje"] = new SelectList(_context.CatEjes, "Id", "Nombre",Obra.Ideje);
            ViewData["Idestrategia"] = new SelectList(_context.CatEstrategia, "Id", "Nombre",Obra.Idestrategia);
            ViewData["Idlineaaccion"] = new SelectList(_context.CatLineaaccions, "Id", "Nombre", Obra.Idlineaaccion);

            ViewData["Idregion"] = new SelectList(_context.CatRegions, "Id", "Nombre", Obra.Idregion);
            
            ViewData["Idmunicipio"] = new SelectList(_context.CatMunicipios, "Id", "Municipio", Obra.Idmunicipio);
            ViewData["Idpoadetalle"] = new SelectList(_context.TblPoadetalles, "Id", "Actividades", Obra.Idpoadetalle);

            ViewData["Idgradomarginal"] = grados(Obra.Idgradomarginal);
            ViewData["Idzap"] = zap(Obra.Idzap);
            ViewData["IdnormativaAplicable"] = normativa(Obra.IdnormativaAplicable);
            ViewData["IdmodalidadEjecicion"] = modelidadejecucion((Obra.IdtipoObra == 2 ? 1 : Obra.IdmodalidadEjecicion));
            ViewData["Idcontratacion"] = contratacion(Obra.Idcontratacion);
            ViewData["IdtipoAdjudicacion"] = adjudicacion(Obra.IdtipoAdjudicacion);
            ViewData["IdtipoContrato"] = tipoContrato(Obra.IdtipoContrato,Obra.IdtipoObra);

            ViewData["IdEjercicio"] = new SelectList(_context.CatEjercicios, "Id", "Nombre", Obra.IdEjercicio);

            return View(Obra);
        }

        // GET: TblObras/Edit/5
        public async Task<IActionResult> EditExpediente(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           

            var tblObra = await _context.TblObras
                .Select(a =>
                new ExpedienteViewModalDetalle()
                {
                    Id = a.Id,
                    Coordenadas = string.Concat(a.Coordenadax, ",", a.Coordenaday),
                    
                    folio = a.Numeroobraexterno,
                    year = a.Year,
                    //Idvertiente = a.Idvertiente,
                    //Idsubvertiente = a.Idsubvertiente,
                    //Idprogsoc = a.Idprogsog,
                    Idmunicipio = a.Idmunicipio ?? 0,
                    Idregion = a.IdmunicipioNavigation.Idregion,
                    Region = a.IdmunicipioNavigation.Region, // _context.CatMunicipios.Where(a => a.Id == Obra.Idmunicipio).FirstOrDefault().Region,
                    Coordenadax = a.Coordenadax,
                    Coordenaday = a.Coordenaday,
                    Nombreobra = a.Nombreobra,
                    Inversion = a.Inversion,
                    InversionBeneficiario = a.InversionBeneficiario,
                    InversionEstatal = a.InversionEstatal,
                    InversionFederal = a.InversionFederal,
                    InversionMunicipal = a.InversionMunicipal,

                    Expediente = a.Expediente,
                    Idgradomarginal = a.Idgradomarginal,
                    IdnormativaAplicable = a.IdnormativaAplicable,
                    IdmodalidadEjecicion = a.IdmodalidadEjecicion,
                    Idcontratacion = a.Idcontratacion,
                    IdtipoAdjudicacion = a.IdtipoAdjudicacion,
                    IdtipoContrato = a.IdtipoContrato,
                    Idzap = a.Idzap,
                    BeneficiarioNombre = a.BeneficiarioNombre,
                    EntidadEjecutora = a.EntidadEjecutora,
                    ContratistaNombre = a.ContratistaNombre,
                    Porcentajeavance = a.Porcentajeavance,
                    AvanceFinanciero = a.AvanceFinanciero,
                    Localidad = a.Localidad,
                    Ideje =a.Ideje,
                    Idestrategia = a.Idestrategia,
                    Idlineaaccion = a.Idlineaacion,
                    EoPrograInicio = a.EoPrograInicio,
                    EoRealFin = a.EoPrograFin,
                    EoPrograFin= a.EoPrograFin,
                    EoRealInicio = a.EoRealInicio,
                    EoReprograFin = a.EoReprograFin,
                    EoReprograInicio = a.EoReprograInicio,
                    IdtipoObra = a.IdtipoObra,
                    ProveedorAdjudicado = a.ProveedorAdjudicado,
                    EntidadRequiriente = a.EntidadRequiriente,


                    checklist = a.TblObrachecklists.Select(b => new ExpedientePlantillaViewModel()
                    {
                        id = b.Id,
                        idObra = b.IdTblobra,
                        nombre = b.Nombre,
                        activo = b.Activo,
                        adjudicacion = b.Adjudicacion,
                        administracion = b.Administracion,
                        licitacion = b.Licitacion,
                        invitacion = b.Invitacion,
                        Estitulo = b.Estitulo,
                        Numero = b.Numero ?? 0,
                        Observaciones = b.Observaciones,
                        PaginaFinal = b.PaginaFinal,
                        PaginaInicio = b.PaginaInicio,
                        TituloShort = b.TituloShort,
                        Titulo = b.Titulo,
                        Norma = b.Norma,
                        ArchivoExtensions = b.ArchivoExtensions,
                        ArchivoMultiple = b.ArchivoMultiple,
                        ArchivoPermite = b.ArchivoPermite ?? false,
                        Secuencia = b.Secuencia ?? 1,
                        HexColor = b.HexColor


                    }).OrderBy(c => c.Numero).ToList(),
                    documentoproceso = a.TblObradocumentoprocesos.Select(b => new ExpedienteDocumentoViewModel()
                    {
                        id = b.Id,
                        idObra = b.IdTblobra,
                        categoria = b.Categoria,
                        documento = b.Nombre,
                        estatus = b.Estatus,
                        rutaarchivo = b.Rutaarchivo,
                        nombrearchivo = b.Nombrearchivo,
                        aprobado = b.Aprobado,
                        Estitulo = b.Estitulo,
                        Numero = b.Numero ?? 0,
                        Observaciones = b.Observaciones,
                        PaginaInicio = b.PaginaInicio,
                        PaginaFinal = b.PaginaFinal,
                        Titulo = b.Titulo,
                        TituloShort = b.TituloShort,
                        activo = b.Activo,
                        Norma = b.Norma,
                        ArchivoExtensions = b.ArchivoExtensions,
                        ArchivoMultiple = b.ArchivoMultiple,
                        ArchivoPermite = b.ArchivoPermite ?? false,
                        Secuencia = b.Secuencia ?? 1,
                        HexColor = b.HexColor,
                        

                    }).OrderBy(c => c.Numero).ToList(),
                    pagos = a.TblObraPagos.Select(b => new PagosViewModal()
                    {
                        Id = b.Id,
                        Activo = b.Activo,
                        FechaFactura = b.FechaFactura,
                        FechaPago = b.FechaPago,
                        IdTblobra = b.IdTblobra,
                        IdFactura = b.IdFactura,
                        ImporteTotal = b.ImporteTotal,
                        NombreArchivoEvidencia = b.NombreArchivoEvidencia,
                        NombreArchivoFactura = b.NombreArchivoFactura,
                        Numero = b.Numero,
                        NumFactura= b.NumFactura,
                        OrdenPago = b.OrdenPago,
                        Pago = b.Pago,
                        Registro = b.Registro,
                        RutaArchivoEvidencia = b.RutaArchivoEvidencia,
                        RutaArchivoFactura = b.RutaArchivoFactura,
                        SolicitudPago = b.SolicitudPago                        
                    }).ToList(),
                    recursos = a.TblObraRecursos.Select(b => new RecursosViewModal() {
                        Id = b.Id,
                        IdTblobra = b.IdTblobra,
                        Activo = b.Activo,
                        Autorizados = b.Autorizados,
                        IdEjercicio = b.IdEjercicio,
                        Ejercicio = b.IdEjercicioNavigation.Nombre,
                        IdPrograma = b.IdPrograma,
                        Programa = b.IdProgramaNavigation.Nombre,
                        IdRecurso = b.IdRecurso,
                        Recurso = b.IdRecursoNavigation.Nombre,
                        IdSubprograma = b.IdSubprograma,
                        Subprograma = b.IdSubprogramaNavigation.Nombre,
                        ImporteContratado = b.ImporteContratado,
                        ImporteEjercido = b.ImporteEjercido,
                        ImporteModificado = b.ImporteModificado,
                        ImportePorEjercer = b.ImportePorEjercer,
                        Registro = b.Registro,
                        IdClasificacion = b.IdClasificacion,
                        Clasificacion = b.IdClasificacionNavigation.Nombre,
                        IdFondo = b.IdFondo,
                        Fondo = b.IdFondoNavigation.Nombre,
                        IdRamo = b.IdRamo,
                        Ramo = b.IdRamoNavigation.Nombre,
                        IdRubro = b.IdRubro,
                        Rubro = b.IdRubroNavigation.Nombre,
                        IdTiporecurso = b.IdTiporecurso,
                        Tiporecurso = b.IdTiporecursoNavigation.Nombre,
                        IdClasificadorN1 = b.IdClasificadorN1,
                        IdClasificadorN2 = b.IdClasificadorN2,
                        IdClasificadorN3 = b.IdClasificadorN3,
                        ClasificadorN1 = b.IdClasificadorN1Navigation.Nombre,
                        ClasificadorN2 = b.IdClasificadorN2Navigation.Nombre,
                        ClasificadorN3 = b.IdClasificadorN3Navigation.Nombre,
                        ImporteContratadoMaximo = b.ImporteContratadoMaximo,
                        ImporteContratadoMinimo = b.ImporteContratadoMinimo
                    }).ToList(),

                    estimaciones = a.TblObraEstimacions.Select(b => new EstimacionesViewModal()
                    {
                        Activo = b.Activo,
                        AmortizadoSinIva = b.AmortizadoSinIva,
                        AvanceFinancieron = b.AvanceFinancieron,
                        AvanceFisicoReal = b.AvanceFisicoReal,
                        AvenceFisicoProgramado = b.AvenceFisicoProgramado,
                        CincoMillarSinIva = b.CincoMillarSinIva,
                        Devolucion = b.Devolucion,
                        FechaEstimacion = b.FechaEstimacion,
                        FechaFactura = b.FechaFactura,
                        FechaPago = b.FechaPago,
                        Id = b.Id,
                        IdFactura = b.IdFactura,
                        IdTblobra = b.IdTblobra,
                        MontoNetoPagar = b.MontoNetoPagar,
                        MontoPagarSinIva = b.MontoPagarSinIva,
                        Numero = b.Numero,
                        NumFactura = b.NumFactura,
                        Pagado = b.Pagado,
                        Registro = b.Registro,
                        Retencion = b.Retencion,
                        Subtotal = b.Subtotal,
                        SubtotalConIva = b.SubtotalConIva
                    }).ToList(),

                    conceptos = a.TblObraconceptos.Select(b => new ObraconceptoViewModal()
                    {
                        Activo = b.Activo,
                        Cantidad = b.Cantidad,
                        Fecha = b.Fecha,
                        IdTblobra = b.IdTblobra,
                        Id = b.Id,
                        Importe = b.Importe,
                        Observaciones = b.Observaciones,
                        Idtipoconcepto = b.Idtipoconcepto,
                        Clave = b.Clave,
                        Concepto = b.Concepto,
                        PrecioUnitario = b.PrecioUnitario,
                        Unidad = b.Unidad
                    }).ToList()

                })
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();


           
            if (tblObra == null)
            {
                return NotFound();
            }

            List<ObrasImagenesMetadata> listaImagenes = new ImagesService().GetImagenesByNoObra(id);
            tblObra.obrasImagenesMetadata = listaImagenes;


            ViewData["MyIdtipoObra"] = tblObra.IdtipoObra;

            ViewData["Ideje"] = new SelectList(_context.CatEjes, "Id", "Nombre", tblObra.Ideje);
            ViewData["Idestrategia"] = new SelectList(_context.CatEstrategia.Where(a => a.Ideje == tblObra.Ideje), "Id", "Nombre", tblObra.Idestrategia);
            ViewData["Idlineaaccion"] = new SelectList(_context.CatLineaaccions.Where(a => a.Idestrategia == tblObra.Idestrategia), "Id", "Nombre", tblObra.Idlineaaccion);

            //ViewData["Idvertiente"] = new SelectList(_context.CatVertientes, "Id", "Nombre", tblObra.Idvertiente);
            //ViewData["Idsubvertiente"] = new SelectList(_context.CatSubvertientes, "Id", "Nombre", tblObra.Idsubvertiente);

            //ViewData["Idprogsoc"] = new SelectList(_context.CatProgsocs, "Id", "Descripcion", tblObra.Idprogsoc);

            
            ViewData["Idregion"] = new SelectList(_context.CatRegions, "Id", "Nombre", tblObra.Idregion);
            //ViewData["Idlocalidad"] = new SelectList(_context.CatLocalidads, "Id", "Clave", tblObra.Idlocalidad);
            ViewData["Idmunicipio"] = new SelectList(_context.CatMunicipios, "Id", "Municipio", tblObra.Idmunicipio);
            ViewData["Idpoadetalle"] = new SelectList(_context.TblPoadetalles, "Id", "Actividades", tblObra.Idpoadetalle);

            ViewData["Idgradomarginal"] = grados(tblObra.Idgradomarginal);
            ViewData["Idzap"] = zap(tblObra.Idzap);
            ViewData["IdnormativaAplicable"] = normativa(tblObra.IdnormativaAplicable);
            ViewData["IdmodalidadEjecicion"] = modelidadejecucion(tblObra.IdmodalidadEjecicion);
            ViewData["Idcontratacion"] = contratacion(tblObra.Idcontratacion);
            ViewData["IdtipoAdjudicacion"] = adjudicacion(tblObra.IdtipoAdjudicacion);
            ViewData["IdtipoContrato"] = tipoContrato(tblObra.IdtipoContrato,tblObra.IdtipoObra);

            var ejercicio = _context.CatEjercicios.Where(a => a.Nombre.Equals(tblObra.year.ToString())).FirstOrDefault();
            if (ejercicio != null)
            {
                tblObra.IdEjercicio = ejercicio.Id;
            }
            

            ViewData["IdEjercicio"] = new SelectList(_context.CatEjercicios, "Id", "Nombre", tblObra.IdEjercicio);

            return View(tblObra);
        }

        // POST: TblObras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditExpediente(int id, ExpedienteViewModalDetalle Obra)
        {
            if (id != Obra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string lat = "", longitud = "";
                    if (!string.IsNullOrWhiteSpace(Obra.Coordenadas))
                    {
                        if (Obra.Coordenadas.Contains(",") && Obra.Coordenadas.Contains("."))
                        {
                            //tiene datos de cordenadas
                            string[] words = Obra.Coordenadas.Split(",");
                            if (words != null && words.Count() >= 1)
                            {
                                lat = words[0];
                                longitud = words[1];
                            }
                        }
                        else
                        {
                            lat = Obra.Coordenadas;
                            longitud = Obra.Coordenadas;
                        }
                    }

                    TblObra expediente = _context.TblObras.Where(a => a.Id == id).FirstOrDefault();
                    List<TblObrachecklist> checklist = _context.TblObrachecklists.Where(a => a.IdTblobra == id).ToList();

                    if (Obra.checklist != null)
                    {
                        if (Obra.checklist.Count > 0)
                        {
                            foreach (var item in Obra.checklist)
                            {
                                checklist.ForEach(b =>
                                {
                                    if (b.Id == item.id)
                                    {
                                        //b.Adjudicacion = item.adjudicacion;
                                        //b.Administracion = item.administracion;
                                        //b.Licitacion = item.licitacion;
                                        //b.Invitacion = item.invitacion;
                                        //b.Fecharegistro = DateTime.Now;
                                        b.Activo = item.activo;
                                    }
                                });
                            }
                        }
                    }


                    List<TblObradocumentoproceso> documentos = _context.TblObradocumentoprocesos.Where(a => a.IdTblobra == id).ToList();

                    if (checklist != null)
                    {
                        if (checklist.Count > 0)
                        {
                            foreach (var chk in checklist)
                            {
                                documentos.ForEach(b =>
                                {
                                    if (b.Numero == chk.Numero)
                                    {
                                        b.Estitulo = chk.Estitulo;
                                        b.Fecharegistro = DateTime.Now;
                                        b.Activo = chk.Activo;
                                        b.Estatus = !chk.Activo ? "gray" :  (!string.IsNullOrWhiteSpace(b.Rutaarchivo) ? "yellow":"red");
                                    }
                                });
                            }
                        }
                    }

                    if (Obra.documentoproceso != null)
                    {
                        if (Obra.documentoproceso.Count > 0) {
                            foreach (var dp in Obra.documentoproceso)
                            {
                                documentos.ForEach(b =>
                                {
                                    if (b.Numero == dp.Numero)
                                    {
                                        b.Observaciones = dp.Observaciones;
                                        if (!string.IsNullOrWhiteSpace(dp.Observaciones))
                                        {
                                            b.Observaciones = "";
                                            b.Estatus = !b.Activo ? "gray" : "red";
                                        }
                                    }
                                });
                            }
                        }
                        
                    }

                    int numberYear;
                    string StringYear = _context.CatEjercicios.Where(a => a.Id == Obra.IdEjercicio.Value).FirstOrDefault().Nombre;

                    bool success = int.TryParse(StringYear, out numberYear);

                    expediente.Localidad = Obra.Localidad;
                    expediente.Idgradomarginal = Obra.Idgradomarginal;
                    expediente.IdnormativaAplicable = Obra.IdnormativaAplicable;
                    expediente.IdmodalidadEjecicion = Obra.IdmodalidadEjecicion;
                    expediente.Idcontratacion = Obra.Idcontratacion;
                    expediente.IdtipoAdjudicacion = Obra.IdtipoAdjudicacion;
                    expediente.IdtipoContrato = Obra.IdtipoContrato;
                    expediente.Idzap = Obra.Idzap;
                    expediente.BeneficiarioNombre = Obra.BeneficiarioNombre;
                    expediente.EntidadEjecutora = Obra.EntidadEjecutora;
                    expediente.ContratistaNombre = Obra.ContratistaNombre;
                    expediente.Porcentajeavance = Obra.Porcentajeavance;
                    expediente.AvanceFinanciero = Obra.AvanceFinanciero;

                    expediente.Ideje = Obra.Ideje;
                    expediente.Idestrategia = Obra.Idestrategia;
                    expediente.Idlineaacion = Obra.Idlineaaccion;
                    
                    expediente.EoPrograInicio = Obra.EoPrograInicio;
                    expediente.EoPrograFin = Obra.EoPrograFin;
                    expediente.EoReprograInicio = Obra.EoReprograInicio;
                    expediente.EoReprograFin = Obra.EoReprograFin;
                    expediente.EoRealInicio = Obra.EoRealInicio;
                    expediente.EoRealFin = Obra.EoRealFin;

                    expediente.ProveedorAdjudicado = Obra.ProveedorAdjudicado;
                    expediente.EntidadRequiriente = Obra.EntidadRequiriente;


                    expediente.Numeroobra = int.Parse(DateTime.Now.Ticks.ToString().Substring(1, 5));
                    expediente.Numeroobraexterno = Obra.folio;
                    expediente.Nombreobra = Obra.Nombreobra;
                    expediente.Idmunicipio = Obra.Idmunicipio;
                    //expediente.Idlocalidad = Obra.Idlocalidad;
                    expediente.Coordenadax = lat;
                    expediente.Coordenaday = longitud;
                    expediente.Descripcion = Obra.Nombreobra;
                    expediente.Expediente = Obra.Expediente;

                    expediente.Region = _context.CatMunicipios.Where(a => a.Id == Obra.Idmunicipio).FirstOrDefault().Region;
                    expediente.Fecharegistro = DateTime.Now;
                    expediente.Year = success ? numberYear : DateTime.Now.Year;

                    expediente.Inversion = Obra.Inversion;
                    expediente.InversionEstatal = Obra.InversionEstatal;
                    expediente.InversionFederal = Obra.InversionFederal;
                    expediente.InversionMunicipal = Obra.InversionMunicipal;
                    expediente.InversionBeneficiario = Obra.InversionBeneficiario;
                    

                    expediente.TblObrachecklists = checklist;
                    expediente.TblObradocumentoprocesos = documentos;


                    _context.Update(expediente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblObraExists(Obra.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("EditExpediente", "TblObras", new { id = Obra.Id });
                //return RedirectToAction(nameof(Index));
            }


            ViewData["MyIdtipoObra"] = Obra.IdtipoObra;

            ViewData["Ideje"] = new SelectList(_context.CatEjes, "Id", "Nombre", Obra.Ideje);
            ViewData["Idestrategia"] = new SelectList(_context.CatEstrategia.Where(a => a.Ideje == Obra.Ideje), "Id", "Nombre", Obra.Idestrategia);
            ViewData["Idlineaaccion"] = new SelectList(_context.CatLineaaccions.Where(a => a.Idestrategia == Obra.Idestrategia), "Id", "Nombre", Obra.Idlineaaccion);

            //ViewData["Idprogsoc"] = new SelectList(_context.CatProgsocs, "Id", "Descripcion", Obra.Idprogsoc);
            //ViewData["Idcategoria"] = new SelectList(_context.CatCategoria, "Id", "Nombre", Obra.Idcategoria);
            ViewData["Idregion"] = new SelectList(_context.CatRegions, "Id", "Nombre", Obra.Idregion);
            //ViewData["Idlocalidad"] = new SelectList(_context.CatLocalidads, "Id", "Clave", Obra.Idlocalidad);
            ViewData["Idmunicipio"] = new SelectList(_context.CatMunicipios, "Id", "Municipio", Obra.Idmunicipio);
            ViewData["Idpoadetalle"] = new SelectList(_context.TblPoadetalles, "Id", "Actividades", Obra.Idpoadetalle);

            ViewData["Idgradomarginal"] = grados(Obra.Idgradomarginal);
            ViewData["Idzap"] = zap(Obra.Idzap);
            ViewData["IdnormativaAplicable"] = normativa(Obra.IdnormativaAplicable);
            ViewData["IdmodalidadEjecicion"] = modelidadejecucion(Obra.IdmodalidadEjecicion);
            ViewData["Idcontratacion"] = contratacion(Obra.Idcontratacion);
            ViewData["IdtipoAdjudicacion"] = adjudicacion(Obra.IdtipoAdjudicacion);
            ViewData["IdtipoContrato"] = tipoContrato(Obra.IdtipoContrato, Obra.IdtipoObra);

            ViewData["IdEjercicio"] = new SelectList(_context.CatEjercicios, "Id", "Nombre", Obra.IdEjercicio);

            return View(Obra);
        }


        public IActionResult ObraCreatePartial()
        {
            ViewData["IdEjercicio"] = new SelectList(_context.CatEjercicios, "Id", "Nombre");
            ViewData["IdPrograma"] = new SelectList(_context.CatProgramas, "Id", "Nombre");
            ViewData["IdRecurso"] = new SelectList(_context.CatOrigenrecursos, "Id", "Nombre");
            ViewData["IdSubprograma"] = new SelectList(_context.CatSubprogramas, "Id", "Nombre");
            ViewData["IdTblobra"] = new SelectList(_context.TblObras, "Id", "Id");
            return View();
        }

        // GET: TblObras/Create
        public IActionResult Create()
        {
            ViewData["Idcategoria"] = new SelectList(_context.CatCategoria, "Id", "Nombre");
            ViewData["Iddependencia"] = new SelectList(_context.CatDependencia, "Id", "Nombre");
            ViewData["Ideje"] = new SelectList(_context.CatEjes, "Id", "Clave");
            ViewData["Idejecutor"] = new SelectList(_context.CatEjecutors, "Id", "Nombre");
            ViewData["Idestadoobra"] = new SelectList(_context.CatEstadoobras, "Id", "Id");
            ViewData["Idestadorevision"] = new SelectList(_context.CatEstadorevisions, "Id", "Id");
            ViewData["Idlocalidad"] = new SelectList(_context.CatLocalidads, "Id", "Clave");
            ViewData["Idmunicipio"] = new SelectList(_context.CatMunicipios, "Id", "Municipio");
            ViewData["Idpoadetalle"] = new SelectList(_context.TblPoadetalles, "Id", "Actividades");
            ViewData["Idprogsog"] = new SelectList(_context.CatProgsocs, "Id", "Descripcion");
            ViewData["Idsubvertiente"] = new SelectList(_context.CatSubvertientes, "Id", "Id");
            ViewData["Idunidadmedida"] = new SelectList(_context.CatUnidadmedida, "Id", "Nombre");
            ViewData["Idvertiente"] = new SelectList(_context.CatVertientes, "Id", "Clave");
            return View();
        }

        // POST: TblObras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Idpoadetalle,Year,Region,Idmunicipio,Idlocalidad,Iddependencia,Idestadoobra,Idestadorevision,Idprogsog,Idvertiente,Idsubvertiente,Idcategoria,Idunidadmedida,Idejecutor,Ideje,Numeroobra,Nombreobra,Descripcion,Inversion,Fuentefinanciamiento,Coordenadax,Coordenaday,Inaguracion,PeriodoInforme,Porcentajeavance,Fechainicio,Fechatermino,Posibleconflicto,Observaciones,Georeferenciado,NumeroreferenciaCiceco,Imagenobra,Observacionesrevision,Fecharegistro,BeneficiarioNombre,BeneficiarioDomicilio,Numeroobraexterno,InversionFederal,InversionEstatal,InversionMunicipal,InversionBeneficiario,CantidadBeneficioHombre,CantidadBeneficioMujer,CantidadUnidadmedida,Expediente,AvanceFinanciero")] TblObra tblObra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblObra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcategoria"] = new SelectList(_context.CatCategoria, "Id", "Nombre", tblObra.Idcategoria);
            ViewData["Iddependencia"] = new SelectList(_context.CatDependencia, "Id", "Nombre", tblObra.Iddependencia);
            ViewData["Ideje"] = new SelectList(_context.CatEjes, "Id", "Clave", tblObra.Ideje);
            ViewData["Idejecutor"] = new SelectList(_context.CatEjecutors, "Id", "Nombre", tblObra.Idejecutor);
            ViewData["Idestadoobra"] = new SelectList(_context.CatEstadoobras, "Id", "Id", tblObra.Idestadoobra);
            ViewData["Idestadorevision"] = new SelectList(_context.CatEstadorevisions, "Id", "Id", tblObra.Idestadorevision);
            ViewData["Idlocalidad"] = new SelectList(_context.CatLocalidads, "Id", "Clave", tblObra.Idlocalidad);
            ViewData["Idmunicipio"] = new SelectList(_context.CatMunicipios, "Id", "Municipio", tblObra.Idmunicipio);
            ViewData["Idpoadetalle"] = new SelectList(_context.TblPoadetalles, "Id", "Actividades", tblObra.Idpoadetalle);
            ViewData["Idprogsog"] = new SelectList(_context.CatProgsocs, "Id", "Descripcion", tblObra.Idprogsog);
            ViewData["Idsubvertiente"] = new SelectList(_context.CatSubvertientes, "Id", "Id", tblObra.Idsubvertiente);
            ViewData["Idunidadmedida"] = new SelectList(_context.CatUnidadmedida, "Id", "Nombre", tblObra.Idunidadmedida);
            ViewData["Idvertiente"] = new SelectList(_context.CatVertientes, "Id", "Clave", tblObra.Idvertiente);
            return View(tblObra);
        }

        // GET: TblObras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblObra = await _context.TblObras.FindAsync(id);
            if (tblObra == null)
            {
                return NotFound();
            }
            ViewData["Idcategoria"] = new SelectList(_context.CatCategoria, "Id", "Nombre", tblObra.Idcategoria);
            ViewData["Iddependencia"] = new SelectList(_context.CatDependencia, "Id", "Nombre", tblObra.Iddependencia);
            ViewData["Ideje"] = new SelectList(_context.CatEjes, "Id", "Clave", tblObra.Ideje);
            ViewData["Idejecutor"] = new SelectList(_context.CatEjecutors, "Id", "Nombre", tblObra.Idejecutor);
            ViewData["Idestadoobra"] = new SelectList(_context.CatEstadoobras, "Id", "Id", tblObra.Idestadoobra);
            ViewData["Idestadorevision"] = new SelectList(_context.CatEstadorevisions, "Id", "Id", tblObra.Idestadorevision);
            ViewData["Idlocalidad"] = new SelectList(_context.CatLocalidads, "Id", "Clave", tblObra.Idlocalidad);
            ViewData["Idmunicipio"] = new SelectList(_context.CatMunicipios, "Id", "Clave", tblObra.Idmunicipio);
            ViewData["Idpoadetalle"] = new SelectList(_context.TblPoadetalles, "Id", "Actividades", tblObra.Idpoadetalle);
            ViewData["Idprogsog"] = new SelectList(_context.CatProgsocs, "Id", "Descripcion", tblObra.Idprogsog);
            ViewData["Idsubvertiente"] = new SelectList(_context.CatSubvertientes, "Id", "Id", tblObra.Idsubvertiente);
            ViewData["Idunidadmedida"] = new SelectList(_context.CatUnidadmedida, "Id", "Nombre", tblObra.Idunidadmedida);
            ViewData["Idvertiente"] = new SelectList(_context.CatVertientes, "Id", "Clave", tblObra.Idvertiente);
            return View(tblObra);
        }

        // POST: TblObras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Idpoadetalle,Year,Region,Idmunicipio,Idlocalidad,Iddependencia,Idestadoobra,Idestadorevision,Idprogsog,Idvertiente,Idsubvertiente,Idcategoria,Idunidadmedida,Idejecutor,Ideje,Numeroobra,Nombreobra,Descripcion,Inversion,Fuentefinanciamiento,Coordenadax,Coordenaday,Inaguracion,PeriodoInforme,Porcentajeavance,Fechainicio,Fechatermino,Posibleconflicto,Observaciones,Georeferenciado,NumeroreferenciaCiceco,Imagenobra,Observacionesrevision,Fecharegistro,BeneficiarioNombre,BeneficiarioDomicilio,Numeroobraexterno,InversionFederal,InversionEstatal,InversionMunicipal,InversionBeneficiario,CantidadBeneficioHombre,CantidadBeneficioMujer,CantidadUnidadmedida,Expediente,AvanceFinanciero")] TblObra tblObra)
        {
            if (id != tblObra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblObra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblObraExists(tblObra.Id))
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
            ViewData["Idcategoria"] = new SelectList(_context.CatCategoria, "Id", "Nombre", tblObra.Idcategoria);
            ViewData["Iddependencia"] = new SelectList(_context.CatDependencia, "Id", "Nombre", tblObra.Iddependencia);
            ViewData["Ideje"] = new SelectList(_context.CatEjes, "Id", "Clave", tblObra.Ideje);
            ViewData["Idejecutor"] = new SelectList(_context.CatEjecutors, "Id", "Nombre", tblObra.Idejecutor);
            ViewData["Idestadoobra"] = new SelectList(_context.CatEstadoobras, "Id", "Id", tblObra.Idestadoobra);
            ViewData["Idestadorevision"] = new SelectList(_context.CatEstadorevisions, "Id", "Id", tblObra.Idestadorevision);
            ViewData["Idlocalidad"] = new SelectList(_context.CatLocalidads, "Id", "Clave", tblObra.Idlocalidad);
            ViewData["Idmunicipio"] = new SelectList(_context.CatMunicipios, "Id", "Clave", tblObra.Idmunicipio);
            ViewData["Idpoadetalle"] = new SelectList(_context.TblPoadetalles, "Id", "Actividades", tblObra.Idpoadetalle);
            ViewData["Idprogsog"] = new SelectList(_context.CatProgsocs, "Id", "Descripcion", tblObra.Idprogsog);
            ViewData["Idsubvertiente"] = new SelectList(_context.CatSubvertientes, "Id", "Id", tblObra.Idsubvertiente);
            ViewData["Idunidadmedida"] = new SelectList(_context.CatUnidadmedida, "Id", "Nombre", tblObra.Idunidadmedida);
            ViewData["Idvertiente"] = new SelectList(_context.CatVertientes, "Id", "Clave", tblObra.Idvertiente);
            return View(tblObra);
        }

        // GET: TblObras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblObra = await _context.TblObras
                .Include(t => t.IdcategoriaNavigation)
                .Include(t => t.IddependenciaNavigation)
                .Include(t => t.IdejeNavigation)
                .Include(t => t.IdejecutorNavigation)
                .Include(t => t.IdestadoobraNavigation)
                .Include(t => t.IdestadorevisionNavigation)
                .Include(t => t.IdlocalidadNavigation)
                .Include(t => t.IdmunicipioNavigation)
                .Include(t => t.IdpoadetalleNavigation)
                .Include(t => t.IdprogsogNavigation)
                .Include(t => t.IdsubvertienteNavigation)
                .Include(t => t.IdunidadmedidaNavigation)
                .Include(t => t.IdvertienteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblObra == null)
            {
                return NotFound();
            }

            return View(tblObra);
        }

        // POST: TblObras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblObra = await _context.TblObras.FindAsync(id);
            _context.TblObras.Remove(tblObra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblObraExists(int id)
        {
            return _context.TblObras.Any(e => e.Id == id);
        }
    }
}
