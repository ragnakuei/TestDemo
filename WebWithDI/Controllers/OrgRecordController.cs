using System.Web.Http;
using WebWithDI.BL;

namespace WebWithDI.Controllers
{
    public class OrgRecordController : ApiController
    {
        private readonly IOrgRecordBL _orgRecordBl;

        public OrgRecordController(IOrgRecordBL orgRecordBl)
        {
            _orgRecordBl = orgRecordBl;
        }

        [HttpGet]
        [Route("api/OrgRecord/List")]
        public IHttpActionResult List()
        {
            var result = _orgRecordBl.GetAll();
            return Ok(result);
        }
    }
}