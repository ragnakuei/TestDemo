using System.Web.Http;
using WebWithDI.BL;

namespace WebWithDI.Controllers
{
    public class BaseTypeController : ApiController
    {
        private readonly BaseType1BL _baseType1BL;
        private readonly BaseType2BL _baseType2BL;
        private readonly BaseType3BL _baseType3BL;

        public BaseTypeController(BaseType1BL baseType1BL, BaseType2BL baseType2BL, BaseType3BL baseType3BL)
        {
            _baseType1BL = baseType1BL;
            _baseType2BL = baseType2BL;
            _baseType3BL = baseType3BL;
        }        
        
        [HttpGet, Route("api/basetype")]
        public IHttpActionResult Get()
        {
            var result = new
                         {
                             BaseType1BL = _baseType1BL.GetValue(),
                             BaseType2BL = _baseType2BL.GetValue(),
                             BaseType3BL = _baseType3BL.GetValue(),
                         };
            return Ok(result);
        }
    }
}