using DBChoose.Business.Services.Interfaces;
using DBChoose.Models;
using Microsoft.AspNetCore.Mvc;

namespace DBChoose.Controllers
{
    public class MainController : Controller
    {
        private readonly IProviderInfoService _providerInfoService;
        public MainController(IProviderInfoService providerInfoService)
        {
            _providerInfoService = providerInfoService;
        }

        public IActionResult Index()
        {
            return View(new MainVM() { DatabaseEngine = _providerInfoService.GetProviderInfo() });
        }
    }
}