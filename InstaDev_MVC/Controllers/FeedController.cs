using System;
using InstaDev_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev_MVC.Controllers
{

    [Route("Feed")]
    public class FeedController : Controller
    {
        
        Publicacao Post = new Publicacao();
        Comentario Comment = new Comentario();

        
        
        [Route("Publicar")]
        public IActionResult Index()
        {
            ViewBag.POSTS = Post.ReadAll();
            return View();
        }
        
        
        public IActionResult Postar(IFormCollection form)
        {
            
            Publicacao post   = new Publicacao();
            post.IdPublicacao = Int32.Parse(form["IdPublicacao"]);
            post.IdUsuario = Int32.Parse(form["IdUsuario"]);
            post.Legenda = form["Legenda"];
            post.Imagem = form["Imagem"];
            post.Likes = Int32.Parse(form["IdPublicacao"]);
            
            Post.Create(post);            
            ViewBag.POSTS = Post.ReadAll();

            return LocalRedirect("Publicar");
        }
        
        
        [Route("Comentar")]

        // public IActionResult Index2()
        // {
        //     ViewBag.COMMENTS = Comment.ListarComentarios();
        //     return View();
        // }
        
        
        
        public IActionResult Comentar(IFormCollection form)
        {
            Comentario comment = new Comentario();
            comment.IdUsuario = Int32.Parse(form["IdUsuario"]);
            comment.IdComentario = Int32.Parse(form["IdComentario"]);
            comment.Mensagem = form["Mensagem"];
            
            Comment.CriarComentario(comment);            
            ViewBag.COMMENTS = Comment.ListarComentarios();

            return LocalRedirect("~/Feed/Comentar");
        }
        
    
    
    }
}