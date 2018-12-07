using NUnit.Framework;
using System.Collections.Generic;

namespace TestDemo.Test
{
    [TestFixture]
    public class CollectionCompareTest
    {
        // NUnit Attribute reference： 

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

            CollectionAssert.AreEqual(actual , expected);
        }
    }
}