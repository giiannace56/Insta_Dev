using System;
using System.Collections.Generic;

namespace InstaDev_MVC.Models
{
    public class Usuario
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

        internal List<string> ReadAllLinesCSV(string v)
        {
            throw new NotImplementedException();
        }

        public void EditarUsuario()
        {

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