using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyUrl.Common;
using TinyUrl.Entity;
using TinyUrl.Resources;

namespace TinyUrl.Services
{
    public class UrlService : IUrlService
    {
        private TinyDbContext _dbContext;
        public UrlService(TinyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<TinyActionResult<Url>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TinyActionResult<List<Url>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TinyActionResult<Url>> GetByIdAsync(string TinyCode, bool doHit)
        {
            TinyActionResult<Url> res = new TinyActionResult<Url>();
            res.Data = null;
            res.IsSuccess = false;
            try
            {
                var TinyObj = await _dbContext.Urls.Where(o => o.TinyCode == TinyCode).SingleOrDefaultAsync();
                if (TinyObj != null)
                {
                    res.Data = TinyObj;
                    res.IsSuccess = true;
                    res.Message = Messages.SuccessfullyFind;
                    if (doHit)
                    {
                        try
                        {
                            var item = _dbContext.Urls.Where(o => o.TinyCode == TinyCode).SingleOrDefault();
                            item.Hit++;
                            await _dbContext.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            //Log
                            throw;
                        }
                    }
                }
                else
                    res.Message = Messages.NoItemFound;
                return res;
            }
            catch (Exception ex)
            {
                //Log
                res.Data = null;
                res.IsSuccess = false;
                res.Message = ex.Message;
                return res;
            }
        }

        public async Task<TinyActionResult<Url>> InsertAsync(string MainUrl)
        {
            TinyActionResult<Url> res = new TinyActionResult<Url>();
            res.Data = null;
            res.IsSuccess = false;
            try
            {
                if (Helper.IsValidURL(MainUrl))
                {
                    //you can use your algorithm to generate uniqe code
                    string generateCode = Guid.NewGuid().ToString();
                    Url u = new Url()
                    {
                        TinyCode = generateCode,
                        SourceUrl = MainUrl
                    };
                    await _dbContext.AddAsync(u);
                    var dbRes = await _dbContext.SaveChangesAsync();
                    if (dbRes > 0)
                    {
                        res.Data = u;
                        res.Message = Messages.SuccessfullyAdd;
                        res.IsSuccess = true;
                    }
                    else
                        res.Message = Messages.Error;
                }
                else
                    res.Message = Messages.NotValidUrl;
                return res;
            }
            catch (Exception ex)
            {
                //Log
                res.Message = ex.Message;
                return res;
            }
        }

        public Task<TinyActionResult<Url>> UpdateAsync(Url model)
        {
            throw new NotImplementedException();
        }
    }
}
