using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;
using System.Security.Claims;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            
             var existbasket = await _redisService.GetDb().StringGetAsync(userId);//kullanıcı id'sine göre sepet geldi.
            return JsonSerializer.Deserialize<BasketTotalDto>(existbasket);


        }

        public async Task SaveBasket(BasketTotalDto baskettotaldto)
        {
            await _redisService.GetDb().StringSetAsync(baskettotaldto.UserId, JsonSerializer.Serialize(baskettotaldto));
        }
    }
}
