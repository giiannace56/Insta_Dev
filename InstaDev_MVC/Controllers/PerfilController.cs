using InstaDev_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev_MVC.Controllers
{   
    [Route("Perfil")]
    public class PerfilController : Controller
    {   
        Publicacao pub = new Publicacao();

        Usuario user = new Usuario();
        
        [Route("Listar")]
        public IActionResult Index(){
            
            ViewBag.Usuario = user.ReadAll();
            ViewBag.Publicacoes = pub.ReadAll();
            return View();
        }

    }
}