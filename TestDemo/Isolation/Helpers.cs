namespace TestDemo.Isolation
{
    public static class Helpers
    {
        public static VO ToVO(this DTO dto)
        {
            return new VO
                   {
                       Id   = dto.Id
                     , Name = dto.Name
                   };
        }
    }
}