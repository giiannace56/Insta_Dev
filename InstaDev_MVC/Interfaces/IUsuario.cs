using System.Collections.Generic;
using InstaDev_MVC.Models;

namespace InstaDev_MVC.Interfaces
{
    public interface IUsuario
    {
         void Create(Usuario user);

         List<Usuario> ReadAll();

         void Update(Usuario user);

         void Delete(int id);
    }
}