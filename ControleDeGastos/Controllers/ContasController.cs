﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeGastos.Controllers
{
    public class ContasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
