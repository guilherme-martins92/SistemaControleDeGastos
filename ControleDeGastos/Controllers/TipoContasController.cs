using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleDeGastos.Models;

namespace ControleDeGastos.Controllers
{
    public class TipoContasController : Controller
    {
        private readonly ControleDeGastosContext _context;

        public TipoContasController(ControleDeGastosContext context)
        {
            _context = context;
        }

        // GET: TipoContas
        public IActionResult Index()
        {
            var list = _context.TipoConta.ToList();
            return View(list);
        }

        // GET: TipoContas/Cadastrar
        public IActionResult Create()
        {
            TipoConta tipoConta = new TipoConta();
            return View(tipoConta);
        }

        [HttpPost]
        public IActionResult Create([FromForm] TipoConta tipoConta)
        {
            if (ModelState.IsValid)
            {
                _context.TipoConta.Update(tipoConta);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(tipoConta);
        }

        // GET: TipoContas/Edit/5
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

        [HttpPost]
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

        // GET: TipoContas/Delete/5

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

        [HttpPost]
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
