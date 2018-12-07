namespace TestDemo.Isolation
{
    public interface ILogDao
    {
        void Debug<T>(T vos);
    }

    public class LogImpl : ILogDao
    {
        public void Debug<T>(T vos) { throw new System.NotImplementedException(); }
    }
}