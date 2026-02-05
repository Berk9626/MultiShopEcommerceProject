using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService //redis tarafında configürasyon
    {
        public string _host { get; set; }
        public int _port { get; set; }
        private ConnectionMultiplexer _connectionmultiplexer;

        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }
        public void Connect() => _connectionmultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        //connect methodunu çağırdığımda host ve perta erişir olacağım.
        public IDatabase GetDb(int db = 1)=> _connectionmultiplexer.GetDatabase(0); // bana veri tabanını getirdi
        //biz redisle ilgili ilk bağlantıyı yaptığımızda karşımıza onla ilgili 16 adet db örneği çıkıyor. Sen diyo bu 16 tane db örneği içerisinde
        //mesela 0. sıradakini production için kullan, 1. sıradakini development için kullan, 2.sıradakini test için kullan, 3. sıradaki deploy
        //bunların her birini farklı bir domain işlemi için kullan anlamına geliyor. Bende burda 1 ataması yaptım.
    }
}
