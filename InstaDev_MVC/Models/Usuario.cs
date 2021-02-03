using System;
using System.Collections.Generic;
using System.IO;
using InstaDev_MVC.Interfaces;

namespace InstaDev_MVC.Models
{
    public class Usuario : InstaDev_base, IUsuario
    {
        public int IdUsuario { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }
        
        public string Username { get; set; }
        
        public string Senha { get; set; }

        private const string PATH = "Database/Cadastro";

        Random idRandom = new Random();

         private string PrepararLinha(Usuario user){
            return $"{user.IdUsuario};{user.Email};{user.Nome};{user.Username};{user.Senha}";
        }

        public int IdGenerator(){
            
            Random idRandom = new Random();

            return idRandom.Next();
        }

        public Usuario(){
        
            CreateFolderAndFile(PATH);
        
        }

        public void Create(Usuario userC)
        {
            string[] linha = { PrepararLinha (userC) };
            File.AppendAllLines(PATH, linha);
        }

        public List<Usuario> ReadAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha      = item.Split(";");
                Usuario usuario     = new Usuario();
                
                usuario.Email       = linha[0];
                usuario.Nome        = linha[1];
                usuario.Username    = linha[2];
                usuario.Senha       = linha[3];

                usuarios.Add(usuario);
            }
            return usuarios;
        }
    }
}