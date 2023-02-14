using System;
using System.Text;

namespace Homework9_4
{

    class BigObject
    {
        // Справді великий об'єкт. Буде розміщений у великій купі.
        // 100 000 000 * 4 Б = 400 000 000 Б = 390 625 КБ = 381 МБ
        Array array = new int[100000000];
        public BigObject()
        {
            Console.WriteLine(this.GetHashCode());
        }
        ~BigObject()
        {
            Console.WriteLine("Об'єкт " + this.GetHashCode() + " видалено");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Масив об'єктів - BigObject.
            // 381 * 1000 = 381 000 МБ = 372 ГБ - розмір всього масиву.
            BigObject[] objects = new BigObject[1000];

            try
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    //objects[i] = new BigObject();
                    BigObject @object = new BigObject();
                }
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
