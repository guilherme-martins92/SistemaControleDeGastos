using ControleDeGastos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeGastos.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ControleDeGastosContext _context;

        public CategoriasController(ControleDeGastosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Categoria.ToList();
            return View(list);
        }

        public IActionResult Cadastrar()
        {
            return View(new Categoria());
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categoria.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        public IActionResult Atualizar(int id)
        {
            Categoria categoria = _context.Categoria.Find(id);

            return View("Cadastrar", categoria);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Categoria categoria)
        {
            _context.Categoria.Update(categoria);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Excluir(int id)
        {
            Categoria categoria = _context.Categoria.Find(id);

            return View("Excluir", categoria);
        }

        [HttpPost]
        public IActionResult Excluir([FromForm] Categoria categoria)
        {
            _context.Categoria.Remove(categoria);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
