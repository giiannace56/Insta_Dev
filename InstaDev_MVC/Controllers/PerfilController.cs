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
            ViewBag.Foto = user.Foto;
            ViewBag.COMMENTS = comentario.ListarComentarios();
            ViewBag.NumeroDePublicacoes = pub.ContarPublicacoes();
            ViewBag.USER = HttpContext.Session.GetString("_Username");
            return View();
        }


        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/Login");
        }


        public IActionResult Comentar(IFormCollection form)
        {
            Comentario c = new Comentario();
            c.IdComentario = c.GerarCodigo();
            c.Mensagem = form["comentario"];
            c.IdPublicacao = int.Parse(form["idPublicacao"]);
            
            
            comentario.CriarComentario(c);            
            ViewBag.COMMENTS = comentario.ListarComentarios();

            return LocalRedirect("~/Perfil/Listar");
        }

        [Route("{id}")]
        public IActionResult DeletePost(int id)
        {   
            pub.Delete(id);
            ViewBag.Publicacoes = pub.ReadAll();
            return LocalRedirect("~/Perfil/Listar");
        }

        [Route("Perfil/{id}")]
        public IActionResult DeletarComentario(int id){
            comentario.DeletarComentarioPost(id);

            return LocalRedirect("~/Perfil/Listar");
        }

    }
}