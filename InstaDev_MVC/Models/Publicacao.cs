using System;
using System.Collections.Generic;
using System.IO;
using InstaDev_MVC.Interfaces;

namespace InstaDev_MVC.Models
{
    public class Publicacao : InstaDev_base , IPublicacao
    {
        public int IdPublicacao { get; set; }
        public string Imagem { get; set; }
        public string Legenda { get; set; }
        public int IdUsuario { get; set; }
        public int Likes { get; set; }
        
        
        public string FotoUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeUsuario { get; set; }

        
        public const string PATH = "Database/Publicacao.csv";

        
        Usuario user = new Usuario();

        public Publicacao()
        {
            CreateFolderAndFile(PATH);
        }

        
        public string PrepareCsv(Publicacao p)
        {
            return $"{p.IdPublicacao};{p.Imagem};{p.Legenda};{p.IdUsuario}";
        }

        
        public int GerarCodigo()
        {
            var posts = ReadAll();

            if (posts.Count == 0)
            {
                return 1;
            }

            var code = posts[posts.Count - 1].IdPublicacao;

            code++;

            return code;
        }
        

        public void Create(Publicacao p)
        {
            string[] linhas = { PrepareCsv(p) };
            File.AppendAllLines(PATH, linhas);
        }


        public List<Publicacao> ReadAll()
        {
            
            List<Publicacao> ListaPublicacoes = new List<Publicacao>();

            string[] linhas = File.ReadAllLines(PATH); 

            foreach (var item in linhas)
            {
                string[] atributos = item.Split(";");

                Publicacao Publicacao = new Publicacao();
                Publicacao.IdPublicacao = Int32.Parse(atributos[0]);
                Publicacao.Imagem = atributos[1];
                Publicacao.Legenda = atributos[2];
                Publicacao.IdUsuario = Int32.Parse(atributos[3]);
                // Publicacao.Likes = int.Parse(atributos[4]);

                List<String> CSV = user.ReadAllLinesCSV("Database/Cadastro.csv");
                
                var linhaBusca =
                CSV.Find (
                    x =>
                    x.Split(";")[0] == atributos[3]
                );

                var usuarioLinha = linhaBusca.Split(";");
                // Publicacao.FotoUsuario = usuarioLinha[6].ToString();
                Publicacao.NomeUsuario = usuarioLinha[3].ToString();
                Publicacao.NomeCompleto = usuarioLinha[2].ToString();

                ListaPublicacoes.Add(Publicacao);
            }

            ListaPublicacoes.Reverse();

            return ListaPublicacoes;
        }


        public List<Publicacao> LerPublicacoes(int id)
        {
            List<Publicacao> posts = ReadAll();

            posts = posts.FindAll(post => post.IdPublicacao == id);
            posts.Reverse();

            return posts;
        }


        public void Update(Publicacao p)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll( x => x.Split(";")[0] == p.IdPublicacao.ToString() );

            linhas.Add( PrepareCsv(p) );

            RewriteCSV(PATH, linhas);
        }
        

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll( x => x.Split(";")[0] == id.ToString() );

            RewriteCSV(PATH, linhas);
        }


<<<<<<< HEAD
        // public int Like(){

        // }

=======

        public int Curtir()
        {
            return 7;
        }

        
       
>>>>>>> Feed


        
        
    
    
    
    }
}