using System.Collections.Generic;
using System.Linq;
using WebWithDI.DAL;
using WebWithDI.DTO;
using WebWithDI.VO;

namespace WebWithDI.BL
{
    public class OrgRecordBL : IOrgRecordBL
    {
        private readonly IOrgRecordDAO _orgRecordDao;

        public OrgRecordBL(IOrgRecordDAO orgRecordDao)
        {
            _orgRecordDao = orgRecordDao;
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