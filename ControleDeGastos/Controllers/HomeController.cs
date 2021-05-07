using ControleDeGastos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeGastos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ControleDeGastosContext _context;

        public HomeController(ILogger<HomeController> logger, ControleDeGastosContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            var result = from obj in _context.Conta select obj;
            result = result.Where(x => x.Valor != 0);
            result
                .Include(x => x.Usuario)
                .GroupBy(x => x.UsuarioId);

            return View(result);
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
