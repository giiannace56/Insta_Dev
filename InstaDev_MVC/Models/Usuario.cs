using System;

namespace InstaDev_MVC.Models
{
    public class Usuario : EdicaoBase
    {
        public int IdUsuario { get; set; }

        public string Nome { get; set; }

        public string Foto { get; set; }

        public DateTime DataNascimento { get; set; }

        public int[] Seguidos { get; set; }

        public string Email { get; set; }
        
        public string Username { get; set; }
        
        public string Senha { get; set; }


        public void CadastrarUsuario(){

        }
        public void MostrarUsuario()
        {

        }

        private const string PATH = "Database/Editar.csv";

        //Arquivo csv abaixo
        public Editar()
        {
            CreateFolderAndFile(PATH);
        }

        public string Prepare()
        {
            return $"{e.Nome};{e.NomeDeUsuario}; {e.Email}";
        }

        public void EditarUsuario()
        {
            List<string> linhas = ReadAllLinesCSV(PATH);


            // Removemos a linha que tenha o código a ser alterado
            linhas.RemoveAll(x => x.Split(";")[0] == IdUsuario.ToString());

        }

        public void DeletarUsuario()
        {
        
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