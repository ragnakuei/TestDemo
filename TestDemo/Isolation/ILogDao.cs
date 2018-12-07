namespace TestDemo.Isolation
{
    public interface ILogDao
    {
        void Debug<T>(T vos);
        void DebugObject<T>(T obj);
    }

    public class LogImpl : ILogDao
    {
        public void Debug<T>(T vos) { throw new System.NotImplementedException(); }
        public void DebugObject<T>(T obj) { throw new System.NotImplementedException(); }
    }
}