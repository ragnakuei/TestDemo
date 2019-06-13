using System.Collections.Generic;
using WebWithDI.DTO;

namespace WebWithDI.DAL
{
    public interface IOrgRecordDAO
    {
        IEnumerable<OrgRecordDTO> GetAll();
    }
}