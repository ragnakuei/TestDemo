using System.Collections.Generic;
using WebNoDI.DTO;

namespace WebNoDI.DAL
{
    internal interface IOrgRecordDAO
    {
        IEnumerable<OrgRecordDTO> GetAll();
    }
}