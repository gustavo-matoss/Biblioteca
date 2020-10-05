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
    public class LivrosController : Controller
    {
        public IEnumerable<Livro> Livros { get; set; }


        
        [Authorize]
        public IActionResult Biblioteca()
        {
            var _repo = new LivroRepositorio();
            ViewBag.Livros = _repo.Livros.Livros;
            return View("lista");
        }

        public string Alugar(Livro livro)
        {
           
            var repo = new LivroRepositorio();
            string resp = repo.Alugar(livro);
            return resp;
        }

        [Authorize]
        public string Detalhes(int id)
        {
            var repo = new LivroRepositorio();
            var livro = repo.Biblioteca.First(l => l.Id == id);
            return livro.Detalhes();
        }
    }
}
