﻿using ControleDeGastos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeGastos.Controllers
{
    public class LoginController : Controller
    {
        private readonly ControleDeGastosContext _context;

        public LoginController(ControleDeGastosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Recebe as informações do formulário de login.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([FromForm] Usuario usuario)
        {

            if (ModelState.IsValid)
            {
                var login = _context.Usuario.Where(u => u.Nome == usuario.Nome && u.Senha == usuario.Senha).ToList();


                if (login.Count() != 0)
                {
                    // Inseri os dados do usuário na session.
                    usuario = (Usuario)login.First();
                    HttpContext.Session.SetString("_Nome", usuario.Nome);
                    HttpContext.Session.SetInt32("_Id", usuario.Id);

                    return RedirectToAction("Index", "Contas");
                }
                else
                {
                    TempData["MensagemErroLogin"] = "Usuário não encontrado.";
                }
            }

            return View("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return View("Index");
        }
    }
}
