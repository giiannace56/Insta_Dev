using System;
using System.Collections.Generic;
using System.IO;
using InstaDev_MVC.interfaces;

namespace InstaDev_MVC.Models
{
    public class Comentario : InstaDev_base , IComentario
    {
        
        public int IdComentario { get; set; }


        public string Mensagem { get; set; }


        public int IdUsuario { get; set; }


        
        public int IdPublicacao { get; set; }


        
        
        public const string path = "Database/Comentario.csv";

        
        public Comentario()
        {
            CreateFolderAndFile(path);
        }


        public int GerarCodigo()
        {
            var comments = ListarComentarios();

            if (comments.Count == 0)
            {
                return 1;
            }

            var code = comments[comments.Count - 1].IdComentario;

            code++;

            return code;
        }


        
        public string PrepareCsv(Comentario c)
        {
            return $"{c.IdComentario};{c.Mensagem};{c.IdPublicacao}";
        }


        public void CriarComentario(Comentario c)
        {
            
            string[] linhas = { PrepareCsv(c) };
            File.AppendAllLines(path, linhas);

        }

        
        public void EditarComentario(Comentario c)
        {
            
            List<string> linhas = ReadAllLinesCSV(path);

            linhas.RemoveAll( x => x.Split(";")[0] == c.IdUsuario.ToString() );

            linhas.Add( PrepareCsv(c) );

            RewriteCSV(path, linhas);
        
        }

        
        
        
        public void ExcluirComentario(int IdComentario)
        {
            
            List<string> linhas = ReadAllLinesCSV(path);

            linhas.RemoveAll( x => x.Split(";")[0] == IdUsuario.ToString() );

            RewriteCSV(path, linhas);

        }

        
        
        
        
        public List<Comentario> ListarComentarios()
        {
            
            List<Comentario> ListaComentarios = new List<Comentario>();


            string[] linhasCsv = File.ReadAllLines(path); 

            foreach (var item in linhasCsv)
            {
                string[] atributos = item.Split(";");

                Comentario Comentario = new Comentario();
                Comentario.IdComentario = Int32.Parse(atributos[0]);
                Comentario.Mensagem = atributos[1];
                Comentario.IdPublicacao = Int32.Parse(atributos[2]);
            
                
                ListaComentarios.Add(Comentario);
            }

            return ListaComentarios;
        
        }

        public void DeletarComentarioPost(int id)
        {

            List<string> linhas = ReadAllLinesCSV(path);

            linhas.RemoveAll( x => x.Split(";")[0] == id.ToString() );

            RewriteCSV(path, linhas);

        }
    
        
    
    
    
    }
}