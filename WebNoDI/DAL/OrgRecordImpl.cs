using System.Collections.Generic;
using WebNoDI.DTO;

namespace WebNoDI.DAL
{
    internal class OrgRecordImpl : IOrgRecordDAO
    {
        public IEnumerable<OrgRecordDTO> GetAll()
        {
            return new[]
                   {
                       new OrgRecordDTO { Id = 1, },
                       new OrgRecordDTO { Id = 2, },
                       new OrgRecordDTO { Id = 3, },
                       new OrgRecordDTO { Id = 4, },
                       new OrgRecordDTO { Id = 5, },
                   };
        }
    }
}