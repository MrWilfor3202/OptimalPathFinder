using OptimalPathFinder.Core.Abstract;
using OptimalPathFinder.Core.Models;

namespace OptimalPathFinder.Algorithms.Implementations.PathFinders
{
    public class MaxPriorityShowpalcesPathFinder : IOptimalPathFinder
    {
        /*
            Нахождение оптимального пути методом перебора(оптимизированного). 
            Этот алгоритм ищет путь, включащий в первую очерердь наиболее приоритетные места
       */
        public List<ShowplaceModel> GetOptimalPath(IEnumerable<ShowplaceModel> models, decimal timeLimit)
        {
            var result = new List<ShowplaceModel>();

            List<ShowplaceModel> sortedList = models
                .OrderByDescending(model => model.Priority)
                .ToList();

            decimal currentTimeSpent = 0;

            foreach (var modelItem in sortedList)
            {
                if (currentTimeSpent + modelItem.TimeSpent > timeLimit)
                    continue;

                result.Add(modelItem);
                currentTimeSpent += modelItem.TimeSpent;
            }

            return result;
        }
    }
}
