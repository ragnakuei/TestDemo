using System;
using NUnit.Framework;

namespace TestDemo.Test
{
    [TestFixture]
    public class CalculatorTest
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
    }
}
