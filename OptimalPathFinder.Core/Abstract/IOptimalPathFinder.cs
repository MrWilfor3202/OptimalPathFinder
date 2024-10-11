using OptimalPathFinder.Core.Models;

namespace OptimalPathFinder.Core.Abstract
{
    //Создан интерфейс, чтобы абстрагироваться от деталей реализациии алгортима поиска оптимального пути
    public interface IOptimalPathFinder
    {
        List<ShowplaceModel> GetOptimalPath(IEnumerable<ShowplaceModel> model, decimal timeLimit);
    }
}
