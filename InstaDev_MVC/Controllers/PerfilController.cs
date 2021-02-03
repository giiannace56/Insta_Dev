using InstaDev_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev_MVC.Controllers
{   
    [Route("Perfil")]
    public class PerfilController : Controller
    {   
        Publicacao pub = new Publicacao();
        
        [Route("Listar")]
        public IActionResult Index(){

            ViewBag.Publicacoes = pub.ReadAll();
            return View();
        }
        

    }
}