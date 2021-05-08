using ControleDeGastos.Library.Validation;
using ControleDeGastos.Models;
using ControleDeGastos.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeGastos.Controllers
{
    [Login]
    public class ContasController : Controller
    {
        private readonly ControleDeGastosContext _context;

        public ContasController(ControleDeGastosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Atribui o mes vigente para o ViewData "Mês" que é usada na tela de listagem de contas.
            ViewData["Mes"] = DateTime.Now.ToString("MMMM");

            //Busca as contas do mês vigente.
            var query = _context.Conta
                .Include("Usuario")
                .Include("Categoria")
                .Include("TipoConta").ToList()
                .Where(c => c.Data.Month == DateTime.Now.Month && c.Data.Year == DateTime.Now.Year)
                .OrderBy(c => c.Data)
                .OrderBy(c => c.TipoContaId);
           

            return View(query);
        }

        public IActionResult Create()
        {
            var categorias = _context.Categoria.ToList();
            var tipoContas = _context.TipoConta.ToList();
            var viewModel = new ContaFormViewModel { Categorias = categorias, TipoContas = tipoContas };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Conta conta)
        {
            var idUsuario = HttpContext.Session.GetInt32("_Id");
            conta.UsuarioId = (int)idUsuario;
            _context.Conta.Add(conta);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int? id)
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
        public IActionResult Update([FromForm] Conta conta)
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

        public IActionResult ContasPorMes(DateTime? data)
        {
            //Filtra as contas pelo mês informado.
            var query = _context.Conta
                .Include("Usuario")
                .Include("Categoria")
                .Include("TipoConta").ToList()
                .Where(c => c.Data.Month == data.Value.Month && c.Data.Year == data.Value.Year)
                .OrderBy(c => c.Data)
                .OrderBy(c => c.TipoContaId);

            // Atualiza o mês informados na ViewData "Mês".
            ViewData["Mes"] = data.Value.ToString("MMMM");
            return View("Index", query);
        }
    }
}
