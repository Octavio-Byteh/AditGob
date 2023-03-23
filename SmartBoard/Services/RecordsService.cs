using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartBoard.Data.Models.SmartBoard;
using SmartBoard.Models;

namespace SmartBoard.Services
{
    public class RecordsService
    {
        public readonly SmartBoardContext _context;

        public RecordsService(SmartBoardContext ctx) {
            _context = ctx;
        }

        public List<ObrasViewModel> getObrasbyYear(int year,int IdtipoObra)
        {
            var listaObras = _context.TblObras
                .Where(a => a.IdtipoObra == IdtipoObra)
                //.Where(a => a.Year == year)
                //.OrderByDescending(a=>a.Id)
                .Select(a => new ObrasViewModel()
                {
                    id = a.Id,
                    Year = a.Year,
                    Region = a.Region,
                    Municipio = a.IdmunicipioNavigation.Municipio, // a.MunicipioNavigation.Municipio1,
                    //NumeroDeObra = a.Numeroobraexterno,
                    NumeroDeObra = a.Expediente,
                    NombreDeLaObra = a.Nombreobra,
                    Descripcion = a.Descripcion,
                    Inversion = (a.Inversion.HasValue ? a.Inversion.Value.ToString("c2") : "0.0"),
                    InversionMunicipal = (a.InversionMunicipal.HasValue ? a.InversionMunicipal.Value.ToString("c2") : "0"),
                    strcoordenadax = a.Coordenadax,
                    strcoordenaday = a.Coordenaday,
                    idestatusobra = (a.Idestadoobra.HasValue ? a.Idestadoobra.Value : 2)

                }).ToList();

            double numberX, numbreY;
            listaObras.ForEach(a=> {
                numberX = 16.897564379807672;
                numbreY = -99.97349078830298;
                if (string.IsNullOrWhiteSpace(a.strcoordenaday))
                {
                    numbreY = -99.97349078830298;
                }
                else
                {
                    if (!Double.TryParse(a.strcoordenaday, out numbreY))
                    {
                        numbreY = -99.97349078830298;
                    }
                }

                if (string.IsNullOrWhiteSpace(a.strcoordenadax))
                {
                    numberX = 16.897564379807672;
                }
                else
                {
                    if (!Double.TryParse(a.strcoordenadax, out numberX))
                    {
                        numberX = 16.897564379807672;
                    }
                }

                a.coordenadax = numberX;
                a.coordenaday = numbreY;

            });

            return listaObras.OrderByDescending(a=>a.id).ToList();
        }


        public string GetMarkers(int year)
        {
            var obras = _context.TblObras
                .Select(a=> new { 
                Coordenaday = a.Coordenaday, 
                Coordenadax = a.Coordenadax,
                Id = a.Id, 
                Year = a.Year, 
                //Descripcion = a.Descripcion,
                Region = a.Region,
                    Idestadoobra = a.Idestadoobra,
                    Numeroobraexterno=a.Numeroobraexterno
                })
                .Where(a => a.Year == year).ToList();
            string markers = "";
            if (obras != null && obras.Count > 0)
            {
                double numberX, numbreY;
                int i = 0;
                markers = "[";

                //if (!string.IsNullOrWhiteSpace(nombredependencia))
                //{
                //    obras = obras.Where(a => a.nombreDependenciaShort.Contains(nombredependencia)).ToList();
                //}

                foreach (var item in obras)
                {
                    if (string.IsNullOrWhiteSpace(item.Coordenaday))
                    {
                        numbreY = -99.97349078830298;
                    }
                    else
                    {
                        if (!Double.TryParse(item.Coordenaday, out numbreY))
                        {
                            numbreY = -99.97349078830298;
                        }
                    }

                    if (string.IsNullOrWhiteSpace(item.Coordenadax))
                    {
                        numberX = 16.897564379807672;
                    }
                    else
                    {
                        if (!Double.TryParse(item.Coordenadax, out numberX))
                        {
                            numberX = 16.897564379807672;
                        }
                    }


                    if (numberX == 16.897564379807672 && numbreY == -99.97349078830298)
                    {




                        switch (item.Region.Trim().ToUpper().Replace(" ", ""))
                        {
                            case "NORTE":
                                numberX = 18.234105036932686;
                                numbreY = -99.65694162191646;
                                break;
                            case "TIERRACALIENTE":
                                numberX = 18.285873698428258;
                                numbreY = -100.68480303438535;
                                break;
                            case "LAMONTAÑA":

                                numberX = 17.592888931348273;
                                numbreY = -100.05362144732534;
                                break;
                            case "COSTAGRANDE":

                                numberX = 17.886451821484876;
                                numbreY = -101.5885153042062;
                                break;
                            case "COSTACHICA":
                                numberX = 16.818961889167394;
                                numbreY = -99.22772878246427;
                                break;
                            case "ACAPULCO":


                                numberX = 16.892946209366997;
                                numbreY = -99.8262623994756;
                                break;

                            case "CENTRO":
                                numberX = 17.546160848733773;
                                numbreY = -99.51986545656602;
                                break;
                            default:
                                break;
                        }
                    }


                    markers += "{";
                    markers += string.Format("'title': '{0}',", "");
                    markers += string.Format("'lat': '{0}',", numberX);
                    markers += string.Format("'lng': '{0}',", numbreY);
                    markers += string.Format("'id': '{0}',", item.Id);
               
                    markers += string.Format("'status': '{0}',", item.Idestadoobra ?? 0);

                    markers += string.Format("'description': '{0}'",
                       String.Concat(
                              "No. obra:" + item.Numeroobraexterno
                       )
                       );


                    markers += "},";

                    i++;
                }
                markers += "];";
            }
            else
            {
                markers = "[";

                markers += "{";
                markers += string.Format("'title': '{0}',", "Demo");
                markers += string.Format("'lat': '{0}',", 17.468056478);
                markers += string.Format("'lng': '{0}',", -98.593176329);
                markers += string.Format("'id': '{0}',", 0);

                markers += string.Format("'status': '{0}',", 0);
                markers += string.Format("'description': '{0}'", "Demo");

                markers += "},";


                markers += "];";
            }

            return markers;
        }




        public List<ObrasViewModel> getObrasbyYearToPivot(int year)
        {
            var listaObras = 
                _context.TblObras
                //.Where(a => a.Year == year)
                //.OrderByDescending(a => a.Id)
                .Select(a => new ObrasViewModel()
                {
                    id = a.Id,
                    Year = a.Year,
                    Region = a.Region,
                    Municipio = a.IdmunicipioNavigation.Municipio, // a.MunicipioNavigation.Municipio1,
                    NumeroDeObra = a.Numeroobraexterno,
                    NombreDeLaObra = a.Nombreobra,
                    Descripcion = a.Descripcion,
                    Inversion = (a.Inversion.HasValue ? a.Inversion.Value.ToString("c2") : "0.0"),
                    InversionMunicipal = (a.InversionMunicipal.HasValue ? a.InversionMunicipal.Value.ToString("c2") : "0")

                }).ToList();

            listaObras.ForEach(b => {
                decimal temp;
                decimal tempMun;
                b.totalInversion = 0;
                b.totalInversionMunicipal = 0;

                if (decimal.TryParse(b.Inversion, out temp))
                    b.totalInversion = temp;

                if (decimal.TryParse(b.InversionMunicipal, out tempMun))
                    b.totalInversionMunicipal = tempMun;

            });

            var listaObrasAgrupada =
                listaObras
                .GroupBy(l => new { l.Region, l.Year })
                .Select(la => new ObrasViewModel()
                {
                    Year = la.Key.Year,
                    Region = la.Key.Region,
                    cantidad = la.Count(),
                    totalInversion = la.Sum(s => s.totalInversion),
                    totalInversionMunicipal = la.Sum(s => s.totalInversionMunicipal)

                }).ToList();

            return listaObrasAgrupada;
        }

        public int otieneProgramados(int year, int IdtipoObra)
        {
            int data = 0;

            data = _context.TblObras.Where(a => a.IdtipoObra == IdtipoObra && (a.Idestadoobra == 3 || a.Idestadoobra == 4) ).Count();

            return data;
        }

        public int otieneTotal(int year, int IdtipoObra)
        {
            int data = 0;

            data = _context.TblObras.Where(a => a.IdtipoObra == IdtipoObra  ).Count();

            return data;
        }

        public int otienePendientes(int year, int IdtipoObra)
        {
            int data = 0;

            data = _context.TblObras.Where(a => a.IdtipoObra == IdtipoObra && a.Idestadoobra == 2 ).Count();

            return data;
        }

        public int otieneTerminadas(int year,int IdtipoObra)
        {
            int data = 0;

            data = _context.TblObras.Where(a => a.IdtipoObra == IdtipoObra && a.Idestadoobra == 1).Count();

            return data;
        }

    }
}
