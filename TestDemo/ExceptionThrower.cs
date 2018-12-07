namespace TestDemo
{
    public class ExceptionThrower
    {
        public void ThrowException(string message) { throw new CustomException(message); }
    }
}