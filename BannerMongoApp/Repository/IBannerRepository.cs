using BannerMongoApp.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BannerMongoApp.Repository
{
    public interface IBannerRepository
    {
        Task<IEnumerable<Banner>> Get();
        Task<Banner> Get(string id);
        Task Add(Banner banner);
        Task Update(string id, Banner banner);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();
    }
}
