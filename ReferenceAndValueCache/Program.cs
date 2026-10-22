
using System;

namespace ReferenceAndValueCache
{
    public class ReferenceCache<T> where T : class
    {
        private T? value;

        public void Set(T item) => value = item;

        public bool TryGet(out T? result)
        {
            result = value;
            return value is not null;
        }
    }

    public class ValueCache<T> where T : struct
    {
        private T? value;

        public void Set(T item) => value = item;

        public bool TryGet(out T? result)
        {
            result = value;
            return value.HasValue;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ReferenceCache<string> nameCache = new();
            ValueCache<double> numberCache = new();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Проверить ReferenceCache<string>");
                Console.WriteLine("2. Проверить ValueCache<double>");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                int choice = int.Parse(Console.ReadLine() ?? "");

                if (choice == 0)
                {
                    break;
                }
                else if (choice == 1)
                {
                    string? name;

                    bool found = nameCache.TryGet(out name);
                    Console.WriteLine(found);
                    Console.WriteLine(name is null ? "null" : name);

                    nameCache.Set("Алина");

                    found = nameCache.TryGet(out name);
                    Console.WriteLine(found);
                    Console.WriteLine(name);
                }
                else if (choice == 2)
                {
                    double? number;

                    bool found = numberCache.TryGet(out number);
                    Console.WriteLine(found);
                    Console.WriteLine(number.HasValue ? number.Value.ToString() : "null");

                    numberCache.Set(25.5);

                    found = numberCache.TryGet(out number);
                    Console.WriteLine(found);
                    Console.WriteLine(number);
                }
                else
                {
                    Console.WriteLine("Такого пункта нет.");
                }
            }

            // ReferenceCache<double> cache1 = new(); // CS0452: double — тип значения.
            // ValueCache<string> cache2 = new(); // CS0453: string — ссылочный тип.
        }
    }
}

