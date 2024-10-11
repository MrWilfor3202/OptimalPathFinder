using OptimalPathFinder.Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalPathFinder.Tests
{
    //Юнит-тесты для проверки работоспособности метода расширения, организующего все необходимые сочетания
    [TestFixture]
    public class EnumerableExtensionsTest
    {
        private void TestAlgorithm<T>(IEnumerable<T> input, IEnumerable<IEnumerable<T>> expectedOutput) 
        {
            var actualOutput = input.MakeCombinationsWithoutRepetition();

            CollectionAssert.AreEquivalent(expectedOutput, actualOutput);
        }

        [Test]
        public void TestEmptyCollection() => TestAlgorithm(new List<object>(), new List<List<object>> { new List<object>() });

        [Test]
        public void TestCollectionWithOneElement() 
            => TestAlgorithm(new List<object>() { "test" }, new List<List<object>> { new List<object> { "test" } });

        [Test]
        public void TestCollectionWithTwoElements()
        {
            List<int> input = new List<int> { 1, 2 };

            List<List<int>> expectedOutput = new List<List<int>> 
            {
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 1, 2}
            };

            TestAlgorithm(input, expectedOutput);
        }

        [Test]
        public void TestCollectionWithThreeElements() 
        {
            List<int> input = new List<int> { 1, 2, 3 };

            List<List<int>> expectedOutput = new List<List<int>>
            {
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 3 },
                new List<int> { 1, 2 },
                new List<int> { 1, 3 },
                new List<int> { 2, 3 },
                new List<int> { 1, 2, 3 }
            };

            TestAlgorithm(input, expectedOutput);
        }

        [Test]
        public void TestCollectionWithFourElements()
        {
            List<int> input = new List<int> { 1, 2, 3, 4 };

            List<List<int>> expectedOutput = new List<List<int>>
            {
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 3 },
                new List<int> { 4 },
                new List<int> { 1, 2 },
                new List<int> { 1, 3 },
                new List<int> { 1, 4 },
                new List<int> { 2, 3 },
                new List<int> { 2, 4 },
                new List<int> { 3, 4 },
                new List<int> { 1, 2, 3 },
                new List<int> { 1, 2, 4 },
                new List<int> { 1, 3, 4 },
                new List<int> { 2, 3, 4 },
                new List<int> { 1, 2, 3, 4 }
            };

            TestAlgorithm(input, expectedOutput);
        }
    }
}
