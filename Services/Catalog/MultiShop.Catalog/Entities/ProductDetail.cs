using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId] //mongo db'de string değerde id tutlır
        [BsonRepresentation(BsonType.ObjectId)]//benzersiz olduğunu bildirmek için
        public string ProductDetailId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }
        public string ProductId { get; set; }
        [BsonIgnore]//

        public Product Product { get; set; }


    }
}
