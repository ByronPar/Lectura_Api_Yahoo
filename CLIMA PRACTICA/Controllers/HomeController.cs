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


        [Route("{woeid}")]
        

        public IActionResult Ciudad(string woeid)
        {
            if (woeid != "algo")
            {
                DataClima datos = new DataClima(woeid);
                string DatosCompletos = datos.Datos();
                ViewBag.temperatura = datos.Temperatura(DatosCompletos);
                ViewBag.humedad = datos.Humedad(DatosCompletos);
                ViewBag.presion = datos.Presion(DatosCompletos);
                ViewBag.direccion = datos.DireccionVi(DatosCompletos);
                ViewBag.velocidad = datos.VelocidadVi(DatosCompletos);
                return View();
            }
            else {
                ViewBag.temperatura = "";
                ViewBag.humedad = "";
                ViewBag.presion = "";
                ViewBag.direccion = "";
                ViewBag.velocidad = "";
                return View();
            }


        }

        [Route("{latitud}")]
        [Route("{longitud}")]
        public IActionResult Latitud( string latitud, string longitud)
        {
            //if (woeid != "algo")
            //{
            //    DataClima datos = new DataClima(woeid);
            //    string DatosCompletos = datos.Datos();
            //    ViewBag.temperatura = datos.Temperatura(DatosCompletos);
            //    ViewBag.humedad = datos.Humedad(DatosCompletos);
            //    ViewBag.presion = datos.Presion(DatosCompletos);
            //    ViewBag.direccion = datos.DireccionVi(DatosCompletos);
            //    ViewBag.velocidad = datos.VelocidadVi(DatosCompletos);
            //    return View();
            //}
            //else
            //{
            //    ViewBag.temperatura = "";
            //    ViewBag.humedad = "";
            //    ViewBag.presion = "";
            //    ViewBag.direccion = "";
            //    ViewBag.velocidad = "";
            //    return View();
            //}
            return View();

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
