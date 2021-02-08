using System;
using System.Collections.Generic;
using InstaDev_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev_MVC.Controllers
{
    
    public class LoginController : Controller
    {
        [TempData]
      public string Mensagem { get; set; }

        
        Usuario UsuarioModel = new Usuario();
       
        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            List<string> csv = UsuarioModel.ReadAllLinesCSV("Database/Usuario.csv");

            
            var logado =
            csv.Find(
                x =>
                x.Split(";")[0] == form["Email"] &&
                x.Split(";")[3] == form["Senha"]
            );

            Console.WriteLine($"Usuario - {logado}");
            

            
            if (logado != null)
            {
                HttpContext.Session.SetString("_Username", logado.Split(";")[2]);

                return LocalRedirect("~/Feed/Listar");
            }

            Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/");
            

        }

    }
}