using System.Collections.Generic;
using WebWithDI.VO;

namespace WebWithDI.BL
{
    public interface IOrgRecordBL
    {
        List<OrgRecordVO> GetAll();
    }
}