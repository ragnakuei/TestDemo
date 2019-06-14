using System.Collections.Generic;
using WebNoDI.DTO;
using WebNoDI.Entity;

namespace WebNoDI.DAL
{
    internal interface IPaRecordDAO
    {
        IEnumerable<PaRecordDTO> GetAll();
        void Create(PaRecord entity);
    }
}