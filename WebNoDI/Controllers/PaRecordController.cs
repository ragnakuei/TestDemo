using System.Web.Http ;
using WebNoDI.BL ;
using WebNoDI.DAL ;
using WebNoDI.VO ;

namespace WebNoDI.Controllers
{
    [RoutePrefix("api/PaRecord")]
    public class PaRecordController : ApiController
    {
        private readonly PaRecordBL _paRecordBL ;

        public PaRecordController()
        {
            IPaRecordValidateBL paRecordValidateBL = new PaRecordValidateBL() ;
            IPaRecordDAO        paRecordDao        = new PaRecordImpl() ;

            _paRecordBL = new PaRecordBL(paRecordValidateBL, paRecordDao) ;
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