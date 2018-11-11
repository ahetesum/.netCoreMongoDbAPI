using System.Collections.Generic;
using System.Threading.Tasks;
using BannerMongoApp.Models;
using BannerMongoApp.Repository;
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

        [HttpGet("{id}")]
        public Task<string> Get(string id)
        {
            return this.GetBannerWithId(id);
        }

        private async Task<string> GetBannerWithId(string id)
        {
            var banner = await _bannerRepository.Get(id);
            return JsonConvert.SerializeObject(banner);
        }


        [HttpPost]
        public async void Post([FromBody] Banner banner)
        {
             await _bannerRepository.Add(banner);
            return ;
        }

        [HttpPut("api/banner/{id}")]
        public async void Put(string id, [FromBody] Banner banner)
        {
            await _bannerRepository.Update(id,banner);
            return;
        }

        [HttpDelete("api/banner/{id}")]
        public async void Delete(string id)
        {
           await _bannerRepository.Remove(id);
        }
    }
}
