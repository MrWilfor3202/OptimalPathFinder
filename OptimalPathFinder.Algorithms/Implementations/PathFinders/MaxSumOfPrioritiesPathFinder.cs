using OptimalPathFinder.Algorithms.Extensions;
using OptimalPathFinder.Core.Abstract;
using OptimalPathFinder.Core.Models;

namespace OptimalPathFinder.Algorithms.Implementations.PathFinders
{
    public class MaxSumOfPrioritiesPathFinder : IOptimalPathFinder
    {
        /*
         Нахождение оптимального пути методом перебора(оптимизированного). 
         Этот алгоритм ищет путь с набольшей суммой приоритетов
         */

        public List<ShowplaceModel> GetOptimalPath(IEnumerable<ShowplaceModel> models, decimal timeLimit)
        {
            int maxSumOfPriorities = 0;

            IEnumerable<ShowplaceModel> result = null;

            //Получение всех необходимых сочетаний
            IEnumerable<IEnumerable<ShowplaceModel>> permutations = models.MakeCombinationsWithoutRepetition();
            
            //Нахождение пути что дает наибольшую сумму приоритетов посредством перебора всех ранее полученных сочетаний,
            //и подсчета суммы
            foreach (IEnumerable<ShowplaceModel> permutation in permutations) 
            {
                int currentSum = 0;
                decimal currentTimeSpent = 0;

                foreach (ShowplaceModel model in permutation)
                {
                    currentSum += model.Priority;
                    currentTimeSpent += model.TimeSpent;

                    if (currentTimeSpent > timeLimit)
                        break;
                }
                    
                if (currentSum > maxSumOfPriorities && currentTimeSpent <= timeLimit)
                {
                    maxSumOfPriorities = currentSum;
                    result = permutation;
                }
            }

            return result == null ? new List<ShowplaceModel>() : result.ToList();
        }
    }
}
