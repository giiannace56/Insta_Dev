using System;
using System.Collections.Generic;
using System.IO;
using InstaDev_MVC.Interfaces;
using fake.Interfaces;

namespace InstaDev_MVC.Models 
{
    public class Usuario : InstaDev_base, IEdicao
    {
        public int IdUsuario { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Foto { get; set; }
        
        

        public string Username { get; set; }
        
        public string Senha { get; set; }

        
        private const string PATH = "Database/Usuario.csv";

        Random idRandom = new Random();

         private string PrepararLinha(Usuario user){
            return $"{user.Email};{user.Nome};{user.Username};{user.Senha};{user.IdUsuario}";
        }

        public int IdGenerator(){
            
            Random idRandom = new Random();
            return idRandom.Next();
        }
        public void CadastrarUsuario(Usuario e)
        {
            string[] linhas = {Prepare(e)};
            File.AppendAllLines(PATH, linhas);
        }
        public void MostrarUsuario()
        {
            
        }
        private const string PATHedit = "Database/Editar.csv";

        public Usuario()
        {
            CreateFolderAndFile(PATHedit);

        }            

        private string Prepare(Usuario e)
        {
            return $"{e.Nome};{e.Username}; {e.Email}; {e.Foto};";
        }

            public void EditarUsuario(Usuario e)

        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            // Removemos a linha que tenha o código a ser alterado
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdUsuario.ToString());

            linhas.Add( Prepare(e));

            RewriteCSV(PATH, linhas);

            idRandom.Next();
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
        public void Logar(Usuario userC)
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
                usuario.IdUsuario   = int.Parse(linha[4]);

                usuarios.Add(usuario);
            }
            return usuarios;
        }
    }
}
