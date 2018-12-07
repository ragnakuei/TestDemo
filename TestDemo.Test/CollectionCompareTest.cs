﻿using NUnit.Framework;
using System.Collections.Generic;
using ExpectedObjects;

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

        [Test]
        public void ListOfInt_UnOrder()
        {
            var actual = new List<int> { 2 , 1 , 3 , 4 , 5 };

            var expected = new List<int> { 1 , 2 , 3 , 4 , 5 };

            //CollectionAssert.AreEqual(actual , expected);
            expected.ToExpectedObject().ShouldEqual(actual);
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

            //CollectionAssert.AreEqual(actual , expected);
            expected.ToExpectedObject().ShouldEqual(actual);
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

            //CollectionAssert.AreEqual(actual , expected);
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}