using System ;
using System.Collections.Generic ;
using System.Linq ;
using FluentAssertions;
using NSubstitute ;
using NUnit.Framework ;
using TestDemo.Isolation ;

namespace TestDemo.Test
{
    [TestFixture]
    public class IsolationTest
    {
        [Test]
        public void 未隔離_產生Exception()
        {
            var target = new BL() ;

            // DaoImpl 未實作，而導致無法對 BL 進行單元測試
            // 必須等 BL 所有相關的 class 實作完，才可以進行整合測試 

            Assert.Catch<NotImplementedException>(() => target.Query()) ;
        }

        [Test]
        public void 隔離測試()
        {
            IDao dao = Substitute.For<IDao>() ;
            dao.Query().Returns(new List<DTO>
                                {
                                    new DTO
                                    {
                                        Id   = 1,
                                        Name = "A"
                                    },
                                    new DTO
                                    {
                                        Id   = 2,
                                        Name = "B"
                                    }
                                }) ;

            ILogDao logDao = Substitute.For<ILogDao>() ;

            var target = new BL(dao, logDao) ;
            var actual = target.Query() ;

            var expected = new[]
                           {
                               new
                               {
                                   Id   = 1,
                                   Name = "A"
                               },
                               new
                               {
                                   Id   = 2,
                                   Name = "B"
                               }
                           } ;

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void 呼叫_ILogDao_Debug_次數1()
        {
            IDao dao = Substitute.For<IDao>() ;
            dao.Query().Returns(new List<DTO>
                                {
                                    new DTO
                                    {
                                        Id   = 1,
                                        Name = "A"
                                    },
                                    new DTO
                                    {
                                        Id   = 2,
                                        Name = "B"
                                    }
                                }) ;

            ILogDao logDao = Substitute.For<ILogDao>() ;

            new BL(dao, logDao).Query() ;

            //logDao.ReceivedWithAnyArgs(2).Debug(string.Empty);

            //logDao.ReceivedWithAnyArgs(1).Debug(string.Empty);

            logDao.Received(1).Debug("No Condition QueryCondition") ;
        }

        [Test]
        public void 呼叫_ILogDao_DebugObj_DebugCollection_次數1_參數為參考型別()
        {
            var condition = new QueryCondition { Keyword = "3" } ;

            IDao dao = Substitute.For<IDao>() ;
            dao.QueryCondition(condition)
               .Returns(new List<DTO>
                        {
                            new DTO
                            {
                                Id   = 3,
                                Name = "C"
                            }
                        }) ;

            ILogDao logDao = Substitute.For<ILogDao>() ;

            var target = new BL(dao, logDao) ;
            target.Query(condition) ;

            // test success：reference equal
            // logDao.Received(1).DebugObject(condition);

            // test fail
            //var expectedCondition = new QueryCondition { Keyword = "3" };
            //logDao.Received(1).DebugObject(expectedCondition);

            logDao.Received(1).DebugObject(Arg.Is<QueryCondition>(x => QueryConditionIsEqual(x, condition))) ;
        }

        private bool QueryConditionIsEqual(QueryCondition condtion1, QueryCondition condition2)
        {
            return condtion1?.Keyword == condition2?.Keyword ;
        }

        [Test]
        public void 呼叫_參數為IEnumerable()
        {
            IEnumerable<int> ids = new[] { 5 } ;

            IDao dao = Substitute.For<IDao>() ;
            // 如果 predicate deletegate 回傳是 true 時，就會回傳 Returns() 裡面所指定的 物件
            dao.QueryCondition(Arg.Is<IEnumerable<int>>(x => IdsAreEqual(x, ids)))
               .Returns(new List<DTO>
                        {
                            new DTO
                            {
                                Id   = 5,
                                Name = "E"
                            }
                        }) ;

            ILogDao logDao = Substitute.For<ILogDao>() ;

            IEnumerable<int> actualCollection = null ;
            logDao.DebugCollection(Arg.Do<int[]>(x => actualCollection = x)) ;

            var target     = new BL(dao, logDao) ;
            var conditions = new List<VO> { new VO { Id = 5 } } ;
            target.Query(conditions) ;

            IEnumerable<int> expectedCollection = new[] { 5 } ;
            actualCollection.Should().BeEquivalentTo(expectedCollection);
        }

        private bool IdsAreEqual(IEnumerable<int> ids1, IEnumerable<int> ids2)
        {
            return ids1.SequenceEqual(ids2) ;
        }
    }
}