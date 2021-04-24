using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyUrl.Common;
using TinyUrl.Entity;
using TinyUrl.Services;
using TinyUrl.ViewModels;

namespace TinyUrl.Controllers
{
    public class HomeController : Controller
    {
        private IUrlService _urlService;
        public HomeController(IUrlService urlService)
        {
            _urlService = urlService;
        }
        public async Task<IActionResult> Index(string tinyCode)
        {
            TinyActionResult<Url> res = new TinyActionResult<Url>();
            res = await _urlService.GetByIdAsync(tinyCode, true);
            if (res.IsSuccess)
                return Redirect(res.Data.SourceUrl);
            else
                return View("404");
        }
    }
}
