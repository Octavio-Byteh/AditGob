using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using SmartBoard.Data.Models.SmartBoard;
using SmartBoard.Services;

namespace SmartBoard.WebUI.Controllers
{
    public class IntelController : Controller
    {
        private readonly ILogger<IntelController> _logger;
        private readonly SmartBoardContext _context;
        private IConfiguration configuration;

        public IntelController(ILogger<IntelController> logger, SmartBoardContext ctx, IConfiguration iConfig)
        {
            _logger = logger;
            _context = ctx;
            configuration = iConfig;
            //configuration = iConfig;
        }
        public IActionResult BIPivot() => View();
        public IActionResult BIDashboard() => View();
        public IActionResult AnalyticsDashboard() => View();
        public IActionResult Introduction() => View();
        public IActionResult MarketingDashboard() => View();
        //public IActionResult RecordsDashboard() => View();

        public IActionResult RecordsDashboard(int IdtipoObra) {

            ViewData["MyIdtipoObra"] = IdtipoObra;
            //string year = configuration.GetValue<string>("SmartSettings:CurrentYear");
            //if (year == "0")
            //{
            //    year = DateTime.Now.Year.ToString();
            //}

            //RecordsService Service = new RecordsService(_context);
            //ViewData["Markers"] = Service.GetMarkers(int.Parse(year));

            return View();
        }
        public IActionResult RecordsAdmon() => View();
        //public IActionResult RecordsDashboard()
        //{

        //    return View();
        //}
        public IActionResult Privacy() => View();


        [HttpGet]
        public IActionResult ObtieneObrasPendientes(int year, int IdtipoObra)
        {

            

            RecordsService chartService = new RecordsService(_context);
            
            return Json(chartService.otienePendientes(year, IdtipoObra));
        }

        [HttpGet]
        public IActionResult ObtieneObrasTerminadas(int year, int IdtipoObra) => Json(new RecordsService(_context).otieneTerminadas(year, IdtipoObra));


        [HttpGet]
        public IActionResult ObtieneObrasTotal(int year, int IdtipoObra) => Json(new RecordsService(_context).otieneTotal(year, IdtipoObra));



        [HttpGet]
        public IActionResult ObtieneObrasProgramados(int year, int IdtipoObra) => Json(new RecordsService(_context).otieneProgramados(year,IdtipoObra));



    }
}
