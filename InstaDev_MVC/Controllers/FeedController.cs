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
        Usuario user = new Usuario();

        
        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.USER = HttpContext.Session.GetString("_Username");
            ViewBag.POSTS = Post.ReadAll();
            ViewBag.COMMENTS = Comment.ListarComentarios();
            ViewBag.FOTO = user.Foto;
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
            
            newpost.IdUsuario = 948985665;
            
            Post.Create(newpost);
            
            ViewBag.POSTS = Post.ReadAll();
            
            return LocalRedirect("~/Feed/Listar");
        }
        
        
        
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            
            Post.Delete(id);
            Comment.DeletarComentarioPost(id);
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
            comment.IdComentario = comment.GerarCodigo();
            comment.Mensagem = form["Mensagem"];
            comment.IdPublicacao = int.Parse(form["idPublicacao"]);
            
            
            Comment.CriarComentario(comment);            
            ViewBag.COMMENTS = Comment.ListarComentarios();

            return LocalRedirect("~/Feed/Listar");
        }




    
    }
}