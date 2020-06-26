using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CLIMA_PRACTICA.Models;
using System.Globalization;

namespace CLIMA_PRACTICA.Controllers
{
    public class HomeController : Controller
    {


        
        
        
        public IActionResult Ciudad(string woeid)
        {
            if (!string.IsNullOrEmpty(woeid))
            {
                DataClima datos = new DataClima(woeid);
                return View(datos);
            }
            else {
                DataClima datos = new DataClima();
                return View(datos);
            }


        }

        public IActionResult Latitud(string latitud,string longitud)
        {
            if (!string.IsNullOrEmpty(latitud) && !string.IsNullOrEmpty(longitud))
            {
                LatitudLon datos = new LatitudLon(latitud,longitud);
                return View(datos);
            }
            else
            {
                LatitudLon datos = new LatitudLon();
                return View(datos);
            }


        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
