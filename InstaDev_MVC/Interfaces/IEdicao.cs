using InstaDev_MVC.Models;

namespace fake.Interfaces
{
    public interface IEdicao
    {
        void CadastrarUsuario(Usuario e);
        void EditarUsuario(Usuario e);
        void DeleteUsuario(int id); 
    }
}