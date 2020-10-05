using System;
using System.Collections.Generic;
using System.Text;
using Biblioteca.ListaLeitura.App.Negocio;
using System.IO;
using System.Linq;
using System.Data.SqlClient;

namespace Biblioteca.ListaLeitura.App.Repositorio
{
    public class LivroRepositorio : ILivroRepositorio
    {

        private ListaDeLeitura _livros;
        public SqlConnection sqlConnection = new SqlConnection("Data Source = (local); Initial Catalog = AdventureWorks;"+ "Integrated Security=SSPI;");
        public LivroRepositorio()
        {
           
            var arrayLivros = new List<Livro>();

            sqlConnection.Open();
            SqlCommand command = new SqlCommand("select*from  biblioteca (nolock) ", sqlConnection);
        
            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    
                    var livro = new Livro
                    {
                        Id = Convert.ToInt32(reader[1]),
                        Titulo = Convert.ToString(reader[2]),
                        Autor = Convert.ToString(reader[3]),
                        Alugado = Convert.ToBoolean(reader[4])
                    };
                    
                    arrayLivros.Add(livro);

                }
            }

            _livros = new ListaDeLeitura("Livros", arrayLivros.ToArray());
            sqlConnection.Close();
        }

       
        public ListaDeLeitura Livros => _livros;

        public IEnumerable<Livro> Biblioteca => _livros.Livros;

        public void Incluir(Livro livro)
        {
            var id = Biblioteca.Select(l => l.Id).Max();
            
            string sql = "INSERT INTO Aluno(nome, endereco, numero, RG) VALUES(@id, @Titulo, @Autor, @Alugado)";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            command.Parameters.Add(new SqlParameter("@id", livro.Id));
            command.Parameters.Add(new SqlParameter("@Titulo",livro.Titulo));
            command.Parameters.Add(new SqlParameter("@Autor", livro.Autor));
            command.Parameters.Add(new SqlParameter("@Alugado", false));

            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();
            
        }
        public string Alugar(Livro livro)
        {
            string sql = "update biblioteca set alugado=true where id= @id";
            var id = Biblioteca.Select(l => l.Id).Max();
            if (livro.Alugado == true)
                return "livro ja alugado";
            else
            {

                SqlCommand command = new SqlCommand(sql, sqlConnection);
                command.Parameters.Add(new SqlParameter("@id", livro.Id));

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
            return "livro alugado com sucesso"; 
               

        }
    }
}
