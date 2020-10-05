using Biblioteca.ListaLeitura.App.HTML;
using Biblioteca.ListaLeitura.App.Negocio;
using Biblioteca.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ListaLeitura.App.Logica
{
 
    public class HomeController: Controller
    {
        
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View("login");
        }
        public string TryLogin()
        {
            
            return "login com sucesso";
        }
    }
}
