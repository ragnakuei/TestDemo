using System;
using NUnit.Framework;

namespace TestDemo.Test
{
    [TestFixture]
    public class NUnitDemoTest
    {
        [Test]
        public void 驗證Method回傳結果()
        {
            var target = new Calculator();
            var actual = target.Sum(1 , 2);

            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void 驗證Exception()
        {
            var target = new Calculator();

            var ex = Assert.Throws<DivideByZeroException>(() => target.Divided(1 , 0));
        }

        [Test]
        public void 驗證ExceptionProperty()
        {
            var target = new ExceptionThrower();

            var ex = Assert.Throws<CustomException>(() => target.ThrowException("test"));
            Assert.AreEqual("Detail:test", ex.Detail);
        }
    }
}
