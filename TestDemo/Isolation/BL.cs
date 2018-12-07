using System.Linq;

namespace TestDemo.Isolation
{
    public class BL
    {
        private readonly IDao    _dao;
        private readonly ILogDao _logDao;

        public BL(IDao dao , ILogDao logDao)
        {
            _dao    = dao;
            _logDao = logDao;
        }

        public VO[] Query()
        {
            var dtos = _dao?.Query();
            var vos  = dtos?.Select(d => d.ToVO()).ToArray() ?? new VO[0];

            _logDao?.Debug("BL Query");

            return vos;
        }
    }
}