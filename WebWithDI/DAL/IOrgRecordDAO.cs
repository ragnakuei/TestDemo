using System.Collections.Generic;
using WebWithDI.DTO;

namespace WebWithDI.DAL
{
    internal interface IOrgRecordDAO
    {
        IEnumerable<OrgRecordDTO> GetAll();
    }
}