using System.Collections.Generic;
using InstaDev_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev_MVC.Controllers
{   
    [Route("Perfil")]
    public class PerfilController : Controller
    {   
        Publicacao pub = new Publicacao();

        Comentario comentario = new Comentario();
        Usuario user = new Usuario();
        
        [Route("Listar")]
        public IActionResult Index(){
            
            ViewBag.Usuario = user.ReadAll();
            ViewBag.Publicacoes = pub.ReadAll();
            // ViewBag.Comentarios = comentario.ListarComentarios();
            return View();
        }

        [Route("Comentario")]
        public IActionResult Comentar(IFormCollection form){
            
            List<Comentario> ListaComentarios = new List<Comentario>();

            Comentario coment = new Comentario();
            coment.Mensagem = form["comentario"];
            coment.IdComentario = 1;
            coment.IdPublicacao = 2;

            comentario.CriarComentario(coment);
            // ViewBag.Comentarios = comentario.ListarComentarios();

            return LocalRedirect("~/Perfil/Listar");
        }

    }
}