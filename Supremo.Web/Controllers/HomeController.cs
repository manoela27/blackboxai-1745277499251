using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Supremo.Web.Models;

namespace Supremo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Appointments");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            _logger.LogError($"An error occurred while processing the request. RequestId: {requestId}");
            
            return View(new ErrorViewModel 
            { 
                RequestId = requestId,
                Message = "Ocorreu um erro ao processar sua solicitação."
            });
        }
    }
}
