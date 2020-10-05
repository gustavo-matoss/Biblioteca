using Biblioteca.ListaLeitura.App.Negocio;
using System.Collections.Generic;

namespace Biblioteca.ListaLeitura.App.Repositorio
{
    interface ILivroRepositorio
    {

        ListaDeLeitura Livros { get; }
        IEnumerable<Livro> Biblioteca { get; }
        void Incluir(Livro livro);
    }
}
