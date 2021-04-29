﻿using ControleDeGastos.Models;
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
            var list = _context.Conta
                .Include("Categoria")
                .Include("TipoConta")
                .Include("Usuario").ToList();

            return View(list);
        }

        public IActionResult Cadastrar()
        {
            var categorias = _context.Categoria.ToList();
            var tipoContas = _context.TipoConta.ToList();
            var viewModel = new ContaFormViewModel { Categorias = categorias, TipoContas = tipoContas };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Conta conta)
        {
            conta.UsuarioId = 1;
            _context.Conta.Add(conta);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
