using System;
using System.Collections.Generic;
using ExpectedObjects;
using NSubstitute;
using NUnit.Framework;
using TestDemo.Isolation;
using Assert = NUnit.Framework.Assert;

namespace TestDemo.Test
{
    [TestFixture]
    public class IsolationTest
    {
        [Test]
        public void 未隔離_產生Exception()
        {
            IDao    dao    = new DaoImpl();
            ILogDao logDao = new LogImpl();

            var target = new BL(dao , logDao);

            Assert.Catch<NotImplementedException>(()=>target.Query());
        }

        [Test]
        public void 隔離測試()
        {
            IDao    dao    = Substitute.For<IDao>();
            dao.Query().Returns(new List<DTO>
                                {
                                    new DTO { Id = 1, Name = "A" }
                                  , new DTO { Id = 2, Name = "B" }
                                });

            ILogDao logDao = Substitute.For<ILogDao>();

            var target = new BL(dao , logDao);
            var actual = target.Query();

            var expected = new []
                           {
                               new { Id = 1, Name = "A" }
                             , new { Id = 2, Name = "B" }
                           };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void 呼叫_ILogDao_Debug_次數1()
        {
            IDao dao = Substitute.For<IDao>();
            dao.Query().Returns(new List<DTO>
                                {
                                    new DTO { Id = 1, Name = "A" }
                                  , new DTO { Id = 2, Name = "B" }
                                });

            ILogDao logDao = Substitute.For<ILogDao>();

            var target = new BL(dao , logDao);
            target.Query();

            //logDao.ReceivedWithAnyArgs(2).Debug(string.Empty);
            logDao.Received(1).Debug("BL Query");
        }
    }
}