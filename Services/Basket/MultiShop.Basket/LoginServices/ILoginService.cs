namespace MultiShop.Basket.LoginServices
{
    //giriş yapan kullanıcının bilgisini tutmak
    public interface ILoginService
    {
        public string GetUserId { get; } //direk erişim atama yok
    }
}
