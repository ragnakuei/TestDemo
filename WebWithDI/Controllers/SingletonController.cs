using System.Web.Http;
using WebWithDI.BL;

namespace WebWithDI.Controllers
{
    public class SingletonController : ApiController
    {
        private readonly ISingletonBL _singletonBL;

        public SingletonController(ISingletonBL singletonBL)
        {
            _singletonBL = singletonBL;
        }

        /// <summary>
        /// 每次呼叫都 + 1
        /// </summary>
        [HttpGet, Route("api/singleton")]
        public IHttpActionResult Get()
        {
            return Ok(_singletonBL.GetValue());
        }
    }
}