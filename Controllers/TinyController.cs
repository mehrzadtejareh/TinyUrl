using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyUrl.Common;
using TinyUrl.Resources;
using TinyUrl.Services;
using TinyUrl.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TinyUrl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinyController : ControllerBase
    {
        private IUrlService _urlService;
        public TinyController(IUrlService urlService)
        {
            _urlService = urlService;
        }
        [HttpGet("{TinyCode}")]
        public async Task<TinyActionResult<UrlViewModel>> Get(string TinyCode)
        {
            var res = await _urlService.GetByIdAsync(TinyCode, false);
            return new TinyActionResult<UrlViewModel>()
            {
                Data = (res.Data != null) ? new UrlViewModel() {
                    Hit = res.Data.Hit,
                    id = res.Data.id,
                    SourceUrl = res.Data.SourceUrl,
                    TinyCode = res.Data.TinyCode,
                    TinyUrl = String.Format(BasicInfo.HostAddress, res.Data.TinyCode)
                } : null,
                IsSuccess = res.IsSuccess,
                Message = res.Message
            };
        }

        [HttpPost]
        public async Task<TinyActionResult<UrlViewModel>> Post([FromBody] string MainUrl)
        {
            var res = await _urlService.InsertAsync(MainUrl);
            return new TinyActionResult<UrlViewModel>()
            {
                Data = (res.Data != null) ? new UrlViewModel
                {
                    Hit = res.Data.Hit,
                    id = res.Data.id,
                    SourceUrl = res.Data.SourceUrl,
                    TinyCode = res.Data.TinyCode,
                    TinyUrl = String.Format(BasicInfo.HostAddress, res.Data.TinyCode)
                } : null,
                IsSuccess = res.IsSuccess,
                Message=res.Message
            };
        }

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
