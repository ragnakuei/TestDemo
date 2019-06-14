using System.Web.Http ;
using WebWithDI.BL ;
using WebWithDI.DAL ;
using WebWithDI.VO ;

namespace WebWithDI.Controllers
{
    [RoutePrefix("api/PaRecord")]
    public class PaRecordController : ApiController
    {
        private readonly IPaRecordBL _paRecordBL ;

        public PaRecordController(IPaRecordBL paRecordBL)
        {
            _paRecordBL = paRecordBL ;
        }

        [HttpGet]
        [Route("List")]
        public IHttpActionResult List()
        {
            var result = _paRecordBL.GetAll() ;
            return Ok(result) ;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(PaRecordVO vo)
        {
            _paRecordBL.Create(vo) ;
            return Ok() ;
        }
    }
}