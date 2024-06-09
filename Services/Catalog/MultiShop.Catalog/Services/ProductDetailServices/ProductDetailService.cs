using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDto;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService: IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _ProductDetailCollection;
        private readonly IMapper _mapper;
        public ProductDetailService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);//client içi bağlanstı
            var database = client.GetDatabase(databaseSettings.DatabaseName);//db ye gittim
            _ProductDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.CategoryCollectionName); //tablo
            _mapper = mapper;


        }
        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var values = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _ProductDetailCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _ProductDetailCollection.DeleteOneAsync(x => x.ProductDetailId == id);

        }

        public async Task<ResultProductDetailDto> GetAll()
        {
            var values = await _ProductDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<ResultProductDetailDto>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var values = await _ProductDetailCollection.Find<ProductDetail>(x => x.ProductDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(values);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _ProductDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, values);
        }
    }
}
