using System.Collections.Generic;
using WebNoDI.DTO;
using WebNoDI.Entity;

namespace WebNoDI.DAL
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