using System;
using System.Collections.Generic;
using System.IO;
using InstaDev_MVC.Interfaces;
using fake.Interfaces;

namespace InstaDev_MVC.Models 
{
    public class Usuario : InstaDev_base , IEdicao
    {
        public int IdUsuario { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        

        public string Username { get; set; }
        
        public string Senha { get; set; }

        
        private const string PATH = "Database/Usuario.csv";

        Random idRandom = new Random();

         private string PrepararLinha(Usuario user){
            return $"{user.Email};{user.Nome};{user.Username};{user.Senha};{user.IdUsuario}";
        }

        public int IdGenerator(){
            
            Random idRandom = new Random();}
        public void CadastrarUsuario(Usuario e)
        {
            string[] linhas = {Prepare(e)};
            File.AppendAllLines(PATH, linhas);
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
            return $"{e.Nome};{e.Username}; {e.Email}; {e.Foto};";
        }

        public List<Usuario> ReadAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            // Ler todas as linhas
            string[] linhas = File.ReadAllLines(PATH);

            // Percorrer as linhas e usuario adicionar na lista decada elemento
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                // Criamos o objeto usuario
                
                Usuario user = new Usuario();

                // Alimentamos o objeto usuario
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

            return idRandom.Next();
        }

        public Usuario(){
        
            CreateFolderAndFile(PATH);
        
        }

        public void Create(Usuario userC);
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
