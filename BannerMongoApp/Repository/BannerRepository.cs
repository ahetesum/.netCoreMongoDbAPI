using BannerMongoApp.Data;
using BannerMongoApp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BannerMongoApp.Repository
{
    public class BannerRepository : IBannerRepository
    {
        private readonly ObjectContext _context = null;

        public BannerRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);
        }

        public async Task<IEnumerable<Banner>> Get()
        {
            return await _context.Banners.Find(x => true).ToListAsync();
        }

        public async Task<Banner> Get(string id)
        {
            var banner = Builders<Banner>.Filter.Eq("Id", id);
            return await _context.Banners.Find(banner).FirstOrDefaultAsync();
        }

        public async Task Add(Banner banner)
        {
            await _context.Banners.InsertOneAsync(banner);
        }

        public async Task Update(string id, Banner banner)
        {
            await _context.Banners.ReplaceOneAsync(b => b.Id == id, banner);
        }

        public async Task<DeleteResult> Remove(string id)
        {
            return await _context.Banners.DeleteOneAsync(Builders<Banner>.Filter.Eq("Id", id));
        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await _context.Banners.DeleteManyAsync(new BsonDocument());
        }


    }
}