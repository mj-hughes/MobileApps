
namespace PersonalityQuizWithAPI
{
    public class Constants
    {
       
        public static string BaseAddress = "https://gateway.marvel.com:443/";
        public static string RequestAddress = "v1/public/characters?id=";
        public static string Handshake = "&apikey=081260a5a5619f17c114faba365d9eab&ts=315&hash=383fc15716277251f788770700dbedd1";
        public static string HeroInfoUrl = BaseAddress + RequestAddress;   
    }
}
