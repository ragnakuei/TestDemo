using NUnit.Framework;
using System.Collections.Generic;
using FluentAssertions;

namespace TestDemo.Test
{
    [TestFixture]
    public class CollectionCompareTest
    {
        [Test]
        public void ListOfInt_InOrder()
        {
            var actual = new List<int> { 1 , 2 , 3 , 4 , 5 };

            var expected = new List<int> { 1 , 2 , 3 , 4 , 5 };

            CollectionAssert.AreEqual(actual , expected);
        }

        [Test]  // ExpectedObjects reference: https://github.com/derekgreer/expectedObjects/wiki
        public void ListOfInt_UnOrder()
        {
            var actual = new List<int> { 2 , 1 , 3 , 4 , 5 };

            var expected = new List<int> { 1 , 2 , 3 , 4 , 5 };

            // Test Failed
            // CollectionAssert 只要順序不相同，就視為不相等
            // CollectionAssert.AreEqual(actual , expected);
            
            // Test Succss 
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ListOfClass_InOrder()
        {
            var actual = new List<CustomClass>
                         {
                             new CustomClass { Id = 1 , Name = "A" }
                           , new CustomClass { Id = 2 , Name = "B" }
                           , new CustomClass { Id = 3 , Name = "C" }
                         };

            var expected = new List<CustomClass>
                           {
                               new CustomClass { Id = 1 , Name = "A" }
                             , new CustomClass { Id = 2 , Name = "B" }
                             , new CustomClass { Id = 3 , Name = "C" }
                           };

            // Test Failed
            // 即使表面上看起來順序相同，仍判斷為不相等
            // CollectionAssert.AreEqual(actual , expected);
            
            // Test Success
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ListOfClass_UnOrder()
        {
            var actual = new List<CustomClass>
                         {
                             new CustomClass { Id = 1 , Name = "A" }
                           , new CustomClass { Id = 2 , Name = "B" }
                           , new CustomClass { Id = 3 , Name = "C" }
                         };

            var expected = new List<CustomClass>
                           {
                               new CustomClass { Id = 2 , Name = "B" }
                             , new CustomClass { Id = 1 , Name = "A" }
                             , new CustomClass { Id = 3 , Name = "C" }
                           };

            // Test Failed
            // CollectionAssert.AreEqual(actual , expected);
            
            // Test Success
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void ListOfClass_Partial()
        {
            var actual = new List<CustomClass>
                         {
                             new CustomClass { Id = 1 , Name = "A" }
                           , new CustomClass { Id = 2 , Name = "B" }
                           , new CustomClass { Id = 3 , Name = "C" }
                         };

            // Test Failed
            // var expected = new List<CustomClass>
            //                {
            //                    new CustomClass { Id = 2 }
            //                  , new CustomClass { Id = 1 }
            //                  , new CustomClass { Id = 3 }
            //                };
            
            // Test Failed
            // var expected = new List<CustomClass>
            //              {
            //                  new CustomClass { Id = 1 , Name = "A" , Age = 10 }
            //                , new CustomClass { Id = 2 , Name = "B" , Age = 20 }
            //                , new CustomClass { Id = 3 , Name = "C" , Age = 30 }
            //              };
            
            // // ShouldMatch 用於部份比對時，只用 anonymous class 就可以了 ! 
            
            // Test Success
            var expected = new []
                           {
                               new { Id = 2 }
                             , new { Id = 1 }
                             , new { Id = 3 }
                           };
            
            // Test Failed
            // var expected = new []
            //                {
            //                    new { Id = 1 , Name = "A" , Age = 10  }
            //                  , new { Id = 2 , Name = "B" , Age = 20  }
            //                  , new { Id = 3 , Name = "C" , Age = 30  }
            //                };

            actual.Should().BeEquivalentTo(expected);
            
            // ShouldMatch 用於部份比對時，expected 的 Property 不可以多於 actual Property
        }
    }
}