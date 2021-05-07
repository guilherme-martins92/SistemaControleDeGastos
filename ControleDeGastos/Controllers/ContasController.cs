using ControleDeGastos.Models;
using ControleDeGastos.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeGastos.Controllers
{
    public class ContasController : Controller
    {
        private readonly ControleDeGastosContext _context;

        public ContasController(ControleDeGastosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var month = DateTime.Now.Month;
            var query = _context.Conta.ToList().Where(c => c.Data.Month == month);

            
            var list = _context.Conta
                .Include("Categoria")
                .Include("TipoConta")
                .Include("Usuario")
                .OrderBy(x => x.Data).ToList();
                //.OrderBy(x => x.TipoContaId).ToList()

            return View(query);


        }

        public IActionResult Cadastrar()
        {
            var categorias = _context.Categoria.ToList();
            var tipoContas = _context.TipoConta.ToList();
            var viewModel = new ContaFormViewModel { Categorias = categorias, TipoContas = tipoContas };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastrar(Conta conta)
        {
            conta.UsuarioId = 2;
            _context.Conta.Add(conta);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Atualizar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Conta conta = _context.Conta.Find(id);

            if (conta == null)
            {
                return NotFound();
            }

            var categorias = _context.Categoria.ToList();
            var tipoContas = _context.TipoConta.ToList();
            var viewModel = new ContaFormViewModel { Conta = conta, Categorias = categorias, TipoContas = tipoContas };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Conta conta)
        {
            _context.Conta.Update(conta);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Conta conta = _context.Conta.Find(id);

            if (conta == null)
            {
                return NotFound();
            }

            var categorias = _context.Categoria.ToList();
            var tipoContas = _context.TipoConta.ToList();
            var viewModel = new ContaFormViewModel { Conta = conta, Categorias = categorias, TipoContas = tipoContas };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete([FromForm] Conta conta)
        {
            _context.Conta.Remove(conta);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
