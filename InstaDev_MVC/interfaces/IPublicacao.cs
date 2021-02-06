using System.Collections.Generic;
using InstaDev_MVC.Models;

namespace InstaDev_MVC.Interfaces
{
    public interface IPublicacao
    {
        void Create(Publicacao p);

        List<Publicacao> ReadAll();
            
        void Update(Publicacao p);

        void Delete(int IdPublicacao);
    }
}