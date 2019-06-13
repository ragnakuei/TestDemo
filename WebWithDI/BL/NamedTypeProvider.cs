using System;
using System.Web;
using WebWithDI.Enums;

namespace WebWithDI.BL
{
    public class NamedTypeProvider
    {
        private const string HeaderKey = "namedType";

        private readonly HttpRequest _request;
        public NamedTypeProvider(HttpRequest request)
        {
            _request = request;
        }

        public NamedType GetNamedType()
        {
            var headerValue = _request?.Headers[HeaderKey];

            if (headerValue?.Equals(NamedType.A.ToString(), StringComparison.CurrentCultureIgnoreCase) ?? false)
                return NamedType.A;
            
            if (headerValue?.Equals(NamedType.B.ToString(), StringComparison.CurrentCultureIgnoreCase) ?? false)
                return NamedType.B;

            return NamedType.None;
        }
    }
}