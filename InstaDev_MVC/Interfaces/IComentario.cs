using System.Collections.Generic;
using InstaDev_MVC.Models;

namespace InstaDev_MVC.interfaces
{
    public interface IComentario 
    {
         
        void CriarComentario(Comentario c);
    
        List<Comentario> ListarComentarios();
        
        void EditarComentario(Comentario c);
        
        void ExcluirComentario(int IdComentario);
        
    
    }
}