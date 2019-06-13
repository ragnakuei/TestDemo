namespace WebWithDI.BL
{
    public interface IBaseTypeBL
    {
        int GetValue();
    }

    public class BaseType1BL : IBaseTypeBL
    {
        public int GetValue()
        {
            return 1;
        }
    }
    
    public class BaseType2BL : IBaseTypeBL
    {
        public int GetValue()
        {
            return 2;
        }
    }
    
    public class BaseType3BL : IBaseTypeBL
    {
        public int GetValue()
        {
            return 3;
        }
    }
}