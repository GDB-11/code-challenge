using Code.Challenge.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Code.Challenge.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async IActionResult Calculate(CalculateViewModel model)
        {
            var result = default(IActionResult);

            try
            {
                ValidateModel(model);

                ResultViewModel viewModel = new ResultViewModel();

                _clienteBL.RegistrarCliente(dtoRequest);
                _ = AddLogTraceAsync(dtoRequest, null, user);
                result = View(viewModel);
            }
            catch (Exception ex)
            {
                result = await ErrorResponseAsync(ex, null);
            }

            return result;
        }

        public IActionResult Result(ResultViewModel model)
        {
            return View(model);
        }
    }
}