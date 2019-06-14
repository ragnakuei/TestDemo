using System ;
using System.Collections.Generic ;
using System.Linq ;
using WebNoDI.DAL ;
using WebNoDI.DTO ;
using WebNoDI.Entity ;
using WebNoDI.VO ;

namespace WebNoDI.BL
{
    internal class PaRecordBL
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