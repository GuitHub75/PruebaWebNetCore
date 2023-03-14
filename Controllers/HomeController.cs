using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using web_net_core.Models;
using web_net_core.Aplicacion;

namespace web_net_core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UsuariosApp usuariosApp;

        public HomeController(ILogger<HomeController> logger, UsuariosApp _usuariosApp)
        {
            _logger = logger;
            usuariosApp = _usuariosApp;
        }

        public IActionResult Index()
        {
            List<UsuariosEN> _USER = new List<UsuariosEN>();
            _USER = usuariosApp.GetAll();
            return View(_USER);
        }

        public IActionResult Privacy()
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
