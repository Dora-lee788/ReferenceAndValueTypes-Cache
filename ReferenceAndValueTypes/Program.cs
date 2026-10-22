
using System;

namespace ReferenceAndValueTypes
{
    public class ReferenceBox<T> where T : class
    {
        private T? value;

        public bool IsEmpty => value is null;
        public void Set(T item) => value = item;
        public T? Get() => value;
    }

    public class ValueBox<T> where T : struct
    {
        private T? value;

        public bool IsEmpty => value is null;
        public void Set(T item) => value = item;
        public T? Get() => value;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ReferenceBox<string> nameBox = new();
            ValueBox<int> ageBox = new();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Проверить ReferenceBox<string>");
                Console.WriteLine("2. Проверить ValueBox<int>");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                int choice = int.Parse(Console.ReadLine() ?? "");

                if (choice == 0)
                {
                    break;
                }
                else if (choice == 1)
                {
                    Console.WriteLine(nameBox.IsEmpty);

                    nameBox.Set("Алина");

                    Console.WriteLine(nameBox.IsEmpty);
                    Console.WriteLine(nameBox.Get());
                }
                else if (choice == 2)
                {
                    Console.WriteLine(ageBox.IsEmpty);

                    ageBox.Set(25);

                    Console.WriteLine(ageBox.IsEmpty);
                    Console.WriteLine(ageBox.Get());
                }
                else
                {
                    Console.WriteLine("Такого пункта нет.");
                }
            }
        }
    }
}
