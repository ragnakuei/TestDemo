using System.Collections.Generic ;
using System.Linq ;
using WebWithDI.DAL ;
using WebWithDI.DTO ;
using WebWithDI.Entity ;
using WebWithDI.VO ;

namespace WebWithDI.BL
{
    public class PaRecordBL : IPaRecordBL
    {
        private readonly IPaRecordValidateBL _paRecordValidateBl ;
        private readonly IPaRecordDAO        _paRecordDao ;

        public PaRecordBL(IPaRecordValidateBL paRecordValidateBL, IPaRecordDAO paRecordDao)
        {
            _paRecordValidateBl = paRecordValidateBL ;
            _paRecordDao        = paRecordDao ;
        }

        public List<PaRecordVO> GetAll()
        {
            var dtos = _paRecordDao.GetAll() ;
            return dtos.Select(dto => ToPaRecordVO(dto)).ToList() ;
        }

        private PaRecordVO ToPaRecordVO(PaRecordDTO dto)
        {
            return new PaRecordVO { Id = dto.Id } ;
        }

        public void Create(PaRecordVO vo)
        {
            _paRecordValidateBl.ValidateCreate(vo) ;

            var entity = ToPaRecord(vo) ;
            _paRecordDao.Create(entity) ;
        }

        private PaRecord ToPaRecord(PaRecordVO vo)
        {
            return new PaRecord { Id = vo.Id } ;
        }
    }
}