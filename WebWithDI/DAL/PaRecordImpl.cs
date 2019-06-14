using System.Collections.Generic ;
using WebWithDI.DTO ;
using WebWithDI.Entity ;

namespace WebWithDI.DAL
{
    internal class PaRecordImpl : IPaRecordDAO
    {
        public IEnumerable<PaRecordDTO> GetAll()
        {
            return new[]
                   {
                       new PaRecordDTO { Id = 1, },
                       new PaRecordDTO { Id = 2, },
                       new PaRecordDTO { Id = 3, },
                       new PaRecordDTO { Id = 4, },
                       new PaRecordDTO { Id = 5, },
                   };
        }

        public void Create(PaRecord entity)
        {
            
        }
    }
}