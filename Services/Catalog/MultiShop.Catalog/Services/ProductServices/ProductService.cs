using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDto;
using MultiShop.Catalog.Dtos.ProductDto;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _categoryCollection;
        public ProductService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);//client içi bağlanstı
            var database = client.GetDatabase(databaseSettings.DatabaseName);//db ye gittim
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName); //tablo
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductAsync(CreateProductDto createproductDto)
        {
          var values = _mapper.Map<Product>(createproductDto);
          await _productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x=>x.ProductId == id);

        }

        public async Task<List<ResultProductDto>> GetAll()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
           var values =await  _productCollection.Find<Product>(x=>x.ProductId==id).FirstOrDefaultAsync();
            return  _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
        {
           var values = await _productCollection.Find(x=>true).ToListAsync();

            foreach (var item in values) 
            { 
                item.Category = await _categoryCollection.Find<Category>(x=>x.CategoryID == item.CategoryId).FirstAsync();
                
            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateproductDto)
        {
            var values = _mapper.Map<Product>(updateproductDto);
            await _productCollection.FindOneAndReplaceAsync(x=>x.ProductId == updateproductDto.ProductId, values);
        }
    }
}
