using System;
using System.Collections.Generic;
using System.IO;
using fake.Interfaces;

namespace InstaDev_MVC.Models 
{
    public class Usuario : InstaDev_base , IEdicao
    {
        public int IdUsuario { get; set; }

        public string Nome { get; set; }

        public string Foto { get; set; }

        public DateTime DataNascimento { get; set; }

        public int[] Seguidos { get; set; }

        public string Email { get; set; }

        

        public string Username { get; set; }
        
        public string Senha { get; set; }


        public void CadastrarUsuario(Usuario e)
        {
            string[] linha = { Prepare(e) };
            File.AppendAllLines(PATH, linha);
        }
        public void MostrarUsuario()
        {
            
        }
        private const string PATH = "Database/Editar.csv";

        public Usuario()
        {
            CreateFolderAndFile(PATH);

        }            

        private string Prepare(Usuario e)
        {
            return $"{e.Nome};{e.Username}; {e.Email}; {e.Foto}";
        }

        public List<Usuario> ReadAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            // Ler todas as linhas
            string[] linhas = File.ReadAllLines(PATH);

            // Percorrer as linhas e  equipes adicionar na lista decada elemento
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                // Criamos o objeto equipe
                
                Usuario user = new Usuario();

                // Alimentamos o objeto equipe
                user.Nome       = linha[0];
                user.Username   = linha[1];
                user.Email      = linha[2];
                user.Foto       = linha[3];

                // Adicionamos o usuário na lista de usuarios
                usuarios.Add(user);
                
            }  
            return usuarios;
        }
            public void EditarUsuario(Usuario e)

        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            // Removemos a linha que tenha o código a ser alterado
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdUsuario.ToString());

            linhas.Add( Prepare(e));

            RewriteCSV(PATH, linhas);

        }

        public void DeleteUsuario(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            // Removemos a linha que tinha o código a ser alterado
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            // Reescreve o csv com as alterações
            RewriteCSV(PATH, linhas);
        }
        public void ListarUsuario()
        {
                
        }
        public void Logar()
        {

        }
        public void Seguir()
        {

        }

    }
}
