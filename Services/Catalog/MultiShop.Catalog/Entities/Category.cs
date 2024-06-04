using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        [BsonId] //mongo db'de string değerde id tutlır
        [BsonRepresentation(BsonType.ObjectId)]//benzersiz olduğunu bildirmek için
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }

    }
}
