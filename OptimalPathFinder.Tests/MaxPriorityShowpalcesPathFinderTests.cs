using OptimalPathFinder.Algorithms.Implementations.PathFinders;
using OptimalPathFinder.Core.Abstract;
using OptimalPathFinder.Core.Models;

namespace OptimalPathFinder.Tests
{
    //Юнит-тесты для проверки работоспособности метода поиска пути, учитывающего в первую очередь приоритетные места
    [TestFixture]
    public class MaxPriorityShowpalcesPathFinderTests
    {
        private IOptimalPathFinder _pathFinder;

        [SetUp]
        public void SetUp() 
        {
            _pathFinder = new MaxPriorityShowpalcesPathFinder();
        }

        private void TestAlgorithm(IEnumerable<ShowplaceModel> input, int timeLimit, IEnumerable<ShowplaceModel> expectedOutput)
        {
            var inputList = input.ToList();
            var outputList = expectedOutput.ToList();
            var result = _pathFinder.GetOptimalPath(input, timeLimit);
            CollectionAssert.AreEquivalent(outputList, result);
        }


        [Test]
        public void TestEmptyCollection()
        {
            var input = Enumerable.Empty<ShowplaceModel>();
            var output = Enumerable.Empty<ShowplaceModel>();
            int timeLimit = 0;

            TestAlgorithm(input, timeLimit, output);
        }

        [Test]
        public void TestCollectionWithOneElement() 
        {
            var input = new List<ShowplaceModel>() { new ShowplaceModel("TEST", 1, 1)};
            var output = new List<ShowplaceModel>() { new ShowplaceModel("TEST", 1, 1)};
            int timeLimit = 1;

            TestAlgorithm(input, timeLimit, output);

            timeLimit = 0;
            output = new List<ShowplaceModel>() { };

            TestAlgorithm(input, timeLimit, output);
        }

        [Test]
        public void TestCollectionWithTwoElements() 
        {
            var input = new List<ShowplaceModel>()
            { 
                new ShowplaceModel("TEST1", 10, 10), 
                new ShowplaceModel("TEST2", 20, 20) 
            };
            var output = new List<ShowplaceModel>() { new ShowplaceModel("TEST2", 20, 20) };
            int timeLimit = 20;

            TestAlgorithm(input, timeLimit, output);

            input = new List<ShowplaceModel>()
            {
                new ShowplaceModel("TEST1", 20, 20),
                new ShowplaceModel("TEST2", 20, 20)
            };

            timeLimit = 20;
            output = new List<ShowplaceModel>() { new ShowplaceModel("TEST1", 20, 20) };

            timeLimit = 0;
            output = new List<ShowplaceModel>() { };

            TestAlgorithm(input, timeLimit, output);
        }

        [Test]
        public void TestBigCollections() 
        {
            var input = new List<ShowplaceModel>()
            {
                new ShowplaceModel("TEST1", 10, 10),
                new ShowplaceModel("TEST2", 15, 15),
                new ShowplaceModel("TEST3", 31, 25),
                new ShowplaceModel("TEST4", 23, 30),
                new ShowplaceModel("TEST5", 24, 35),
                new ShowplaceModel("TEST6", 20, 40),
                new ShowplaceModel("TEST7", 30, 45),
                new ShowplaceModel("TEST8", 41, 50)
            };
            var output = new List<ShowplaceModel>()
            {
                new ShowplaceModel("TEST7", 30, 45),
                new ShowplaceModel("TEST1", 10, 10)
            };

            int timeLimit = 40;

            TestAlgorithm(input, timeLimit, output);

            timeLimit = 100;

            output = new List<ShowplaceModel>()
            {
                new ShowplaceModel("TEST8", 41, 50),
                new ShowplaceModel("TEST7", 30, 45),
                new ShowplaceModel("TEST6", 20, 40)
            };

            TestAlgorithm(input, timeLimit, output);

            timeLimit = 20;

            output = new List<ShowplaceModel>()
            {
                new ShowplaceModel("TEST6", 20, 40)
            };

            TestAlgorithm(input, timeLimit, output);
        }

    }
}
