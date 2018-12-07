﻿using System;
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

        [Test]
        [TestCase(1)]
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
