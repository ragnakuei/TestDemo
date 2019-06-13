using System.Web;
using WebWithDI.Enums;

namespace WebWithDI.BL
{
    public class KeyedTypeProvider
    {
        private const string HeaderKey = "keyedType";

        private readonly HttpRequest _request;
        public KeyedTypeProvider(HttpRequest request)
        {
            _request = request;
        }

        public KeyedType GetKeyedType()
        {
            return _request.Headers[HeaderKey] != null 
                       ? KeyedType.Keyed1 
                       : KeyedType.Keyed2;
        }
    }
}