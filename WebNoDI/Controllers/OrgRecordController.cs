using System.Web.Http;
using WebNoDI.BL;

namespace WebNoDI.Controllers
{
    public class OrgRecordController : ApiController
    {
        private readonly OrgRecordBL _orgRecordBl;

        public OrgRecordController()
        {
            _orgRecordBl = new OrgRecordBL();
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