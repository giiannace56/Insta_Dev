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

        public const string PATH = "Database/Publicacao.csv";

        public Publicacao()
        {
            CreateFolderAndFile(PATH);
        }


        public string PrepareCsv(Publicacao p)
        {
            return $"{p.IdPublicacao};{p.Imagem};{p.Legenda};{p.IdUsuario};{p.Likes}";
        }
        

        public void Create(Publicacao p)
        {
            string[] linhas = { PrepareCsv(p) };
            File.AppendAllLines(PATH, linhas);
        }


        public List<Publicacao> ReadAll()
        {
            List<Publicacao> ListaPublicacoes = new List<Publicacao>();

            string[] linhasCsv = File.ReadAllLines(PATH); 

            foreach (var item in linhasCsv)
            {
                string[] atributos = item.Split(";");

                Publicacao Publicacao = new Publicacao();
                Publicacao.IdPublicacao = Int32.Parse(atributos[0]);
                Publicacao.Imagem = atributos[1];
                Publicacao.Legenda = atributos[2];
                Publicacao.IdUsuario = Int32.Parse(atributos[3]);
                Publicacao.Likes = int.Parse(atributos[4]);

                ListaPublicacoes.Add(Publicacao);
            }

            return ListaPublicacoes;
        }


        public void Update(Publicacao p)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll( x => x.Split(";")[0] == p.IdPublicacao.ToString() );

            linhas.Add( PrepareCsv(p) );

            RewriteCSV(PATH, linhas);
        }
        

        public void Delete(int IdPublicacao)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll( x => x.Split(";")[0] == IdPublicacao.ToString() );

            RewriteCSV(PATH, linhas);
        }


        // public int Like(){
            
        // }



    }
}