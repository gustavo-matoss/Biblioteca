using Biblioteca.ListaLeitura.App.HTML;
using Biblioteca.ListaLeitura.App.Negocio;
using Biblioteca.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.ListaLeitura.App.Logica
{
    public class CadastroController
    {
        
        [Authorize]
        public string Incluir(Livro livro)
        {
            var repo = new LivroRepositorio();
            repo.Incluir(livro);
            return "O livro foi adicionado com sucesso";
        }
        [Authorize]
        public IActionResult ExibeFormulario()
        {
            var html = new ViewResult { ViewName = "formulario" };
            return html;
        }
    }
}
