using System.Collections.Generic ;
using WebWithDI.DTO ;
using WebWithDI.Entity ;

namespace WebWithDI.DAL
{
    public interface IPaRecordDAO
    {
        IEnumerable<PaRecordDTO> GetAll();
        
        void Create(PaRecord entity);
    }
}