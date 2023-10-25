using Application.Core.DTO.Models;
using Application.Core.DTO.Request;
using Application.Core.Helpers;
using Application.Core.Interface;
using Code.Challenge.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using X.PagedList;

namespace Code.Challenge.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHome _home;

        public HomeController(ILogger<HomeController> logger, IHome home)
        {
            _logger = logger;
            _home = home;
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
        public async Task<IActionResult> Calculate(CalculateViewModel model)
        {
            var result = default(IActionResult);

            try
            {
                if (!ModelState.IsValid)
                {
                    PostMessage(MessageType.Error, "Please correct the errors in your input.");

                    return RedirectToAction("Index");
                }

                ResultViewModel viewModel = new();
                viewModel.FirstInput = model.FirstInput;
                viewModel.SecondInput = model.SecondInput;
                viewModel.SampleSize = model.SampleSize;

                result = RedirectToAction("Result", viewModel);
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, "Unexpected error.");

                return RedirectToAction("Index");
            }

            return result;
        }

        [HttpGet]
        public async Task<IActionResult> Result(ResultViewModel model)
        {
            var result = default(IActionResult);

            try
            {
                int page = model.page ?? 1;
                int pageSize = 10;

                CalculateRequest request = new(model.FirstInput, model.SecondInput, model.SampleSize);

                model.Results = _home.Calculate(request).Results.ToPagedList(page, pageSize);
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, "Unexpected error.");

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}