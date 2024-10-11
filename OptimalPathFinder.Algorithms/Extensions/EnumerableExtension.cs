namespace OptimalPathFinder.Algorithms.Extensions
{
    public static class EnumerableExtension
    {
         /*
            Данный метод расширения служит для получения всех сочетаний элементов различной длины из данной коллекции.
            Длина ограничивается размером коллекции, при этом каждый элемент входит один раз. Также нет повторений, 
            повторениями считаются последовательности состояшие из одних и тех же элементов, в независимости от их расположения. 
         */
        public static IEnumerable<IEnumerable<T>> MakeCombinationsWithoutRepetition<T>(this IEnumerable<T> items)
        {
            // Проверка на пустую коллекцию или единственный элемент
            if (!items.Skip(1).Any())
            {
                yield return items;
                yield break;
            }

            //Получение первого элемента и его "ленивая" передача
            var first = items.First();
            var element = Enumerable.Repeat(first, 1);
            yield return element;

            //Перебор всех сочетаний посредством рекурсии
            foreach (var permutation in MakeCombinationsWithoutRepetition(items.Skip(1)))
            {
                yield return permutation;
                yield return permutation.Prepend(first);
            }
        }
    }
}
