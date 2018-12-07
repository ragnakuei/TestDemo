using System.Collections.Generic;

namespace TestDemo.Isolation
{
    public interface IDao
    {
        IEnumerable<DTO> Query();
    }

    public class DaoImpl : IDao
    {
        public IEnumerable<DTO> Query() { throw new System.NotImplementedException(); }
    }
}