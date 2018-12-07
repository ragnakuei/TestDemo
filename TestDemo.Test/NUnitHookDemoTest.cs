using System;
using NUnit.Framework;

namespace TestDemo.Test
{
    [TestFixture]
    public class NUnitHookDemoTest
    {
        // NUnit hook reference： https://blog.johnwu.cc/article/nunit-life-cycle.html

        [OneTimeSetUp]
        public void FirstRun()
        {
            Console.WriteLine("FirstRun");
        }

        [SetUp]
        public void BeforeTestRun()
        {
            Console.WriteLine("BeforeTestRun");
        }
        
        [Test]
        public void TestMethod1()
        {
            Console.WriteLine("TestMethod1");
        }

        [Test]
        public void TestMethod2()
        {
            Console.WriteLine("TestMethod2");
        }

        [TearDown]
        public void AfterTestRun()
        {
            Console.WriteLine("AfterTestRun");
        }

        [OneTimeTearDown]
        public void LastRun()
        {
            Console.WriteLine("LastRun");
        }
    }
}