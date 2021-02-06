using InstaDev_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev_MVC.Controllers
{
    [Route("Cadastrar")]
    public class CadastroController : Controller
    {
        Usuario usuarioModel = new Usuario();

        public IActionResult Index()
        {
            return View();
        }

        [Route("Cadastro")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Usuario novoUsuario     = new Usuario();

            novoUsuario.Email       = form["Email"];
            novoUsuario.Nome        = form["Nome"];
            novoUsuario.Username    = form["Username"];
            novoUsuario.Senha       = form["Senha"];

            novoUsuario.IdUsuario = usuarioModel.IdGenerator();
            
            usuarioModel.CadastrarUsuario(novoUsuario);
            ViewBag.Cadastrar = usuarioModel.ReadAll();

            return LocalRedirect("~/Cadastrar");

        }
        
    }
}
