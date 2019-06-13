using System.Collections.Generic;
using WebWithDI.VO;

namespace WebWithDI.BL
{
    internal interface IOrgRecordBL
    {
        List<OrgRecordVO> GetAll();
    }
}