using OptimalPathFinder.Algorithms.Implementations.PathFinders;
using OptimalPathFinder.Core.Abstract;
using OptimalPathFinder.Core.Models;

//Список всех достопримечательностей
List<ShowplaceModel> showplaceModels = new List<ShowplaceModel>()
{
    new ShowplaceModel("Исаакиевский собор", 5, 10),
    new ShowplaceModel("Эрмитаж", 8, 11),
    new ShowplaceModel("Кунсткамера", 3.5M, 4),
    new ShowplaceModel("Петропавловская крепость", 10, 7),
    new ShowplaceModel("Ленинградский зоопарк", 9, 15),
    new ShowplaceModel("Медный всадник", 1, 17),
    new ShowplaceModel("Казанский собор", 4, 3),
    new ShowplaceModel("Спас на Крови", 2, 9),
    new ShowplaceModel("Зимний дворец Петра I", 7, 12),
    new ShowplaceModel("Зоологический музей", 5.5M, 6),
    new ShowplaceModel("Музей обороны и блокады Ленинграда", 2, 19),
    new ShowplaceModel("Русский музей", 5, 8),
    new ShowplaceModel("Навестить друзей", 12, 20),
    new ShowplaceModel("Музей восковых фигур", 2, 13),
    new ShowplaceModel("Литературно-мемориальный музей Ф.М. Достоевского", 4, 2),
    new ShowplaceModel("Екатерининский дворец", 1.5M, 5),
    new ShowplaceModel("Петербургский музей кукол", 1, 14),
    new ShowplaceModel("Музей микроминиатюры «Русский Левша»", 3, 18),
    new ShowplaceModel("Всероссийский музей А.С. Пушкина и филиалы", 6, 1),
    new ShowplaceModel("Музей современного искусства Эрарта", 7, 16)
};

//Вычисление времени
decimal timeLimit = 48 - (2 * 8);

while (true)
{
    //Я реализовал два варианта вычисления оптимального пути. Один дает наибольшую сумму важностей, 
    //другой берет в первую очередь наиболее приоритетные места, не заботясь о сумме и времязатратах
    Console.WriteLine(@"Выберите опцию: " + 
        "\n" +  "1 - Выбрать маршрут с максимальной суммой приоритетов" + "\n" 
        + "2 - Выбрать маршрут охватывающий, в первую очередь наиболее приоритетные места" + "\n" + "Любое другое число - выйти" + "\n");


    try
    {
        int option = int.Parse(Console.ReadLine());
        int sum = 0;
        decimal timeSpent = 0;
        IOptimalPathFinder pathFinder;

        //В зависимости от выбора пользователя выбираем алгоритм
        switch (option)
        {
            case 0: pathFinder = new MaxSumOfPrioritiesPathFinder(); break;
            case 1 : pathFinder = new MaxSumOfPrioritiesPathFinder(); break;
            default: return;
        }

        //Здесо идет расчет пути
        var result = pathFinder.GetOptimalPath(showplaceModels, timeLimit);

        //Далее вывод
        Console.WriteLine("\nМаршрут, потраченное время, приоритет: ");

        foreach (var path in result) 
        {
            Console.WriteLine(path.Name + ",   " + path.TimeSpent + ", " + path.Priority);
            sum += path.Priority;
            timeSpent += path.TimeSpent;
        }

        Console.WriteLine("\nПотраченное время: " + timeSpent);
        Console.WriteLine("Достигнутая сумма приоритетов: " + sum + "\n");
    }
    catch
    {
        Console.WriteLine("Введите число");
    }
}
