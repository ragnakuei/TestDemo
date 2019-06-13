using System.Web.Http;
using WebWithDI.BL;

namespace WebWithDI.Controllers
{
    public class NamedController : ApiController
    {
        private readonly INamedBL _namedBL;

        public NamedController(INamedBL namedBL)
        {
            _namedBL = namedBL;
        }

        [HttpGet, Route("api/named")]
        public IHttpActionResult Get()
        {
            return Ok(_namedBL.GetValue());
        }
    }
}