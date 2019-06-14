using System.Collections.Generic ;
using WebWithDI.VO ;

namespace WebWithDI.BL
{
    public interface IPaRecordBL
    {
        List<PaRecordVO> GetAll() ;

        void Create(PaRecordVO vo) ;
    }
}