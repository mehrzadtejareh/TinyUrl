using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyUrl.Common;
using TinyUrl.Entity;

namespace TinyUrl.Services
{
    public interface IUrlService
    {
        Task<TinyActionResult<List<Url>>> GetAllAsync();
        Task<TinyActionResult<Url>> GetByIdAsync(string TinyCode, bool doHit);
        Task<TinyActionResult<Url>> InsertAsync(string MainUrl);
        Task<TinyActionResult<Url>> UpdateAsync(Url model);
        Task<TinyActionResult<Url>> DeleteAsync(int id);
    }
}
