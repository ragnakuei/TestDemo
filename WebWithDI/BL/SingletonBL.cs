namespace WebWithDI.BL
{
    public class SingletonBL : ISingletonBL
    {
        private int _value = 0;
        
        public int GetValue()
        {
            return _value++;
        }
    }
}