using ControleDeGastos.Library.Validation;
using ControleDeGastos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeGastos.Controllers
{
    [Login]
    public class CategoriasController : Controller
    {
        private readonly ControleDeGastosContext _context;

        public CategoriasController(ControleDeGastosContext context)
        {
            _context = context;
        }

        // Chama a página Index do TipoConta e lista todos as categorias cadastradas.
        public IActionResult Index()
        {
            var list = _context.Categoria.ToList();
            return View(list);
        }

        // Chama a página de cadastro de categoria.
        public IActionResult Create()
        {
            return View(new Categoria());
        }

        //Envia os dados do formulário de cadastro p/ a base de dados.
        [HttpPost]
        public IActionResult Create([FromForm] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categoria.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        // Chama a tela de update informando o id do item que deverá ser alterado.
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categoria categoria = _context.Categoria.Find(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View("Create", categoria);
        }

        //Envia os dados do formulário de update p/ a base de dados.
        [HttpPost]
        public IActionResult Update([FromForm] Categoria categoria)
        {
            _context.Categoria.Update(categoria);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // Chama a tela de delete informando o id do item que deverá ser deletado.
        public IActionResult Delete(int id)
        {
            Categoria categoria = _context.Categoria.Find(id);

            return View("Delete", categoria);
        }

        //Envia os dados do formulário de delete p/ base de dados.
        [HttpPost]
        public IActionResult Delete([FromForm] Categoria categoria)
        {
            _context.Categoria.Remove(categoria);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
