using Biblioteca.ListaLeitura.App.Negocio;
using System.Collections.Generic;

namespace Biblioteca.ListaLeitura.App.Repositorio
{
    interface ILivroRepositorio
    {
        ListaDeLeitura ParaLer { get; }
        ListaDeLeitura Lendo { get; }
        ListaDeLeitura Lidos { get; }
        IEnumerable<Livro> Todos { get; }
        void Incluir(Livro livro);
    }
}
