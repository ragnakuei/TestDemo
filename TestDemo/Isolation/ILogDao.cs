using System.Collections.Generic;

namespace TestDemo.Isolation
{
    public interface ILogDao
    {
        void Debug<T>(T vos);

        void DebugObject<T>(T obj);

        void DebugCollection<T>(IEnumerable<T> condition);
    }

    public class LogImpl : ILogDao
    {
        public void Debug<T>(T vos) { throw new System.NotImplementedException(); }

        public void DebugObject<T>(T obj) { throw new System.NotImplementedException(); }

        public void DebugCollection<T>(IEnumerable<T> condition) { throw new System.NotImplementedException(); }
    }
}