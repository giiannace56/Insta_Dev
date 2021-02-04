using System.Collections.Generic;
using InstaDev_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstaDev_MVC.Controllers
{
    public class HomeController : Controller
    {   
      public string Mensagem { get; set; }


        Usuario UsuarioModel = new Usuario();
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            List<string> csv = UsuarioModel.ReadAllLinesCSV("Database/Usuario.csv");

            // Verificamos se as informações passadas existe na lista de string
            var logado =
            csv.Find(
                x =>
                x.Split(";")[2] == form["Email"] &&
                x.Split(";")[3] == form["Senha"]
            );


            // Redirecionamos o usuário logado caso encontrado
            if (logado != null)
            {
                HttpContext.Session.SetString("_Username", logado.Split(";")[1]);

                return LocalRedirect("~/");
            }

           


            Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Home");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}