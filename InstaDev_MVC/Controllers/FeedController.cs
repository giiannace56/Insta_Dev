using System;
using System.IO;
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

        
        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.POSTS = Post.ReadAll();
            ViewBag.COMMENTS = Comment.ListarComentarios();
            return View();
        }
        
        
        
        
        [Route("Publicar")]
        public IActionResult Postar(IFormCollection form)
        {
            
            Publicacao newpost   = new Publicacao();
            newpost.IdPublicacao = Post.GerarCodigo();
            
            
            if(form.Files.Count > 0)
            {
                
                var file    = form.Files[0];
                var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img_publicacao");

                if(!Directory.Exists(folder)){
                    
                    Directory.CreateDirectory(folder);
                }
                
        
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img_publicacao", folder, file.FileName);
                
                
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                
                newpost.Imagem   = file.FileName;                
            
            }
            
            else
            {
                newpost.Imagem   = "padrao.png";
            }
            
            
            newpost.Legenda = form["Legenda"];
            
            newpost.IdUsuario = 1019343930;
            
            Post.Create(newpost);
            
            ViewBag.POSTS = Post.ReadAll();
            
            return LocalRedirect("~/Feed");
        }
        
        
        
        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            
            Post.Delete(id);
            ViewBag.POSTS = Post.ReadAll();
            return LocalRedirect("~/Feed/Listar");
        
        }


        
        
        // [Route("Comentar")]
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

            return LocalRedirect("~/Feed/Listar");
        }




    
    }
}