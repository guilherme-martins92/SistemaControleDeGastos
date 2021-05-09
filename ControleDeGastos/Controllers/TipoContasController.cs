using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleDeGastos.Models;
using ControleDeGastos.Library.Validation;

namespace ControleDeGastos.Controllers
{
    [Login]
    public class TipoContasController : Controller
    {
        private readonly ControleDeGastosContext _context;

        public TipoContasController(ControleDeGastosContext context)
        {
            _context = context;
        }

        // Chama a página Index do TipoConta e lista todos os TipoConta cadastrados.
        public IActionResult Index()
        {
            var list = _context.TipoConta.ToList();
            return View(list);
        }

        // Chama a página de cadastro do TipoContas.
        public IActionResult Create()
        {
            TipoConta tipoConta = new TipoConta();
            return View(tipoConta);
        }

        //Envia os dados do formulário de cadastro p/ a base de dados.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] TipoConta tipoConta)
        {
            if (ModelState.IsValid)
            {
                _context.TipoConta.Add(tipoConta);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(tipoConta);
        }

        // Chama a tela de update informando o id do item que deverá ser alterado.
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoConta tipoConta = _context.TipoConta.Find(id);

            if (tipoConta == null)
            {
                return NotFound();
            }

            return View("Create", tipoConta);
        }

        //Envia os dados do formulário de update p/ a base de dados.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] TipoConta tipoConta)
        {
            if (tipoConta == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(tipoConta);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoConta);
        }

        // Chama a tela de delete informando o id do item que deverá ser deletado.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoConta tipoConta = _context.TipoConta.Find(id);

            if (tipoConta == null)
            {
                return NotFound();
            }

            return View("Delete", tipoConta);
        }

        //Envia os dados do formulário de delete p/ base de dados.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromForm] TipoConta tipoConta)
        {
            if (tipoConta == null)
            {
                return NotFound();
            }

            _context.TipoConta.Remove(tipoConta);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
