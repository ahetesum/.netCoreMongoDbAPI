using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BannerMongoApp.Models
{
    public class Banner
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Html { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
