using System;
using NUnit.Framework;

namespace TestDemo.Test
{
    [TestFixture]
    public class NUnitDemoTest
    {
        // NUnit Attribute reference： https://github.com/nunit/docs/wiki/Attributes

        [Test]
        public void 驗證Method回傳結果()
        {
            var target = new Calculator();
            var actual = target.Sum(1 , 2);

            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [Test] // Throw referenece： https://github.com/nunit/docs/wiki/Assert.Throws
        public void 驗證Exception1()
        {
            var target = new Calculator();

            var ex = Assert.Throws<DivideByZeroException>(() => target.Divided(1 , 0));
        }

        [Test]  // Catch reference： https://github.com/nunit/docs/wiki/Assert.Catch
        public void 驗證Exception2()
        {
            var target = new Calculator();

            Assert.Catch<DivideByZeroException>(() => target.Divided(1 , 0));
        }

        [Test] 
        public void 驗證ExceptionProperty()
        {
            var target = new ExceptionThrower();

            var ex = Assert.Throws<CustomException>(() => target.ThrowException("test"));
            Assert.AreEqual("Detail:test", ex.Detail);
        }
        
        [Test]
        [TestCase(1)] // TestCase reference： https://github.com/nunit/docs/wiki/TestCase-Attribute
        public void TestCase使用方式1_true(int i)
        {
            Assert.AreEqual(1, i);
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void TestCase使用方式1_false(int i)
        {
            Assert.AreEqual(false, i == 1);
        }
    }
}
