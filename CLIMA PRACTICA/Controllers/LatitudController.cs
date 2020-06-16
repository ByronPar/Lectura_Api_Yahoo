using System;
using System.Diagnostics;
using CLIMA_PRACTICA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CLIMA_PRACTICA.Controllers
{
    public class LatitudController : Controller
    {


        public IActionResult Latitud()
        {
            var datos = new LatitudLon();
            return View(datos);
        }

        [HttpPost]
        public IActionResult Latitud(LatitudLon data)
        {
            var datos = new LatitudLon();
            return View(data);
        }


        private readonly ILogger<LatitudController> _logger;

        public LatitudController(ILogger<LatitudController> logger)
        {
            _logger = logger;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


}
