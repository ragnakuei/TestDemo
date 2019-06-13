using System.Web.Http;
using WebWithDI.BL;

namespace WebWithDI.Controllers
{
    public class KeyedController : ApiController
    {
        private readonly IKeyedBL _keyedBL;

        public KeyedController(IKeyedBL keyedBL)
        {
            _keyedBL = keyedBL;
        }

        [HttpGet, Route("api/keyed")]
        public IHttpActionResult Get()
        {
            return Ok(_keyedBL.GetValue());
        }
    }
}