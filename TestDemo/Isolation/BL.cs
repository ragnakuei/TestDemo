using System.Collections.Generic;
using System.Linq;

namespace TestDemo.Isolation
{
    public class BL
    {
        private readonly IDao    _dao;
        private readonly ILogDao _logDao;

        /// <summary>
        /// 耦合性高的做法
        /// </summary>
        public BL()
        {
            _dao = new DaoImpl();
            _logDao = new LogImpl();
        }
        
        public BL(IDao dao , ILogDao logDao)
        {
            _dao    = dao;
            _logDao = logDao;
        }

        public VO[] Query()
        {
            var dtos = _dao?.Query();
            var vos  = dtos?.Select(d => d.ToVO()).ToArray() ?? new VO[0];

            _logDao?.Debug("No Condition QueryCondition");

            return vos;
        }

        public VO[] Query(QueryCondition condition)
        {
            _logDao?.DebugObject(condition);

            var dtos = _dao?.QueryCondition(condition);
            var vos  = dtos?.Select(d => d.ToVO()).ToArray() ?? new VO[0];

            _logDao?.DebugCollection(vos.Select(vo=>vo.Id).ToArray());

            return vos;
        }

        public VO[] Query(List<VO> conditions)
        {
            _logDao?.DebugObject(conditions);

            var dtos = _dao?.QueryCondition(conditions.Select(c=>c.Id));
            var vos  = dtos?.Select(d => d.ToVO()).ToArray() ?? new VO[0];

            _logDao?.DebugCollection(vos.Select(vo=>vo.Id).ToArray());

            return vos;
        }
    }
}