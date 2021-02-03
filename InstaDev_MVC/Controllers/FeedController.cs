using Microsoft.AspNetCore.Mvc;

namespace InstaDev_MVC.Controllers
{

    [Route("Feed")]
    public class FeedController : Controller
    {
        
        public IActionResult Index()
        {


            return View();
        }
    
    
    }
}