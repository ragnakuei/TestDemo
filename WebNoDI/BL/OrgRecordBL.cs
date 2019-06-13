using System.Collections.Generic;
using System.Linq;
using WebNoDI.DAL;
using WebNoDI.DTO;
using WebNoDI.VO;

namespace WebNoDI.BL
{
    internal class OrgRecordBL
    {
        private readonly IOrgRecordDAO _orgRecordDao;

        public OrgRecordBL()
        {
            _orgRecordDao = new OrgRecordImpl();
        }

        public List<OrgRecordVO> GetAll()
        {
            var dtos = _orgRecordDao.GetAll();
            return dtos.Select( dto => ToOrgRecordVO(dto)).ToList();
        }

        private OrgRecordVO ToOrgRecordVO(OrgRecordDTO dto)
        {
            return new OrgRecordVO
                   {
                       Id = dto.Id
                   };
        }
    }
}