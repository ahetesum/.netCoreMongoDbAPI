using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BannerMongoApp.Models;
using BannerMongoApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BannerMongoApp.Controllers
{
    [Route("api/Banner")]
    public class BannerController :ControllerBase
    {
        private readonly IBannerRepository _bannerRepository = null;

        public BannerController(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        [HttpGet]
        public Task<string> Get()
        {
            return this.GetAllBanner();
        }

        private async Task<string> GetAllBanner()
        {
            var banners = await _bannerRepository.Get();
            return JsonConvert.SerializeObject(banners);
        }

        [HttpPost]
        public async Task<string> Post(Banner banner)
        {
             await _bannerRepository.Add(banner);
            return "";
        }
    }
}
