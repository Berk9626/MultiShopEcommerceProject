namespace MultiShop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _httpcontextAccessor = contextAccessor;
        }

        public string GetUserId => _httpcontextAccessor.HttpContext.User.FindFirst("sub").Value;
            //giriş yapan kullanıcının valuesunu yakalıyorum.
            //subın içerisinde id var ve tokendan gelecek.
    }
}
