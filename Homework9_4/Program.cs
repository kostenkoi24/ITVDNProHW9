using System;
using System.Text;
using System.Threading;

namespace Homework9_4
{

    class BigObject : IDisposable
    {
        // Справді великий об'єкт. Буде розміщений у великій купі.
        // 100 000 000 * 4 Б = 400 000 000 Б = 390 625 КБ = 381 МБ
        Array array = new int[100000000];
        public BigObject()
        {
            Console.WriteLine(this.GetHashCode());
        }

        public void Dispose()
        {
            Console.WriteLine($"{this.GetHashCode()} has been disposed"); //реалізуйте для цього класу формалізований шаблон очищення.
        }

        //~BigObject()
        //{
        //    Console.WriteLine("Об'єкт " + this.GetHashCode() + " видалено");
        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*Створіть свій клас, об'єкти якого займатимуть багато місця в пам'яті 
             * (наприклад, у коді класу буде великий масив) і реалізуйте для цього класу формалізований шаблон очищення.
             */

            Console.OutputEncoding = Encoding.Unicode;
            // Масив об'єктів - BigObject.
            // 381 * 1000 = 381 000 МБ = 372 ГБ - розмір всього масиву.
            BigObject[] objects = new BigObject[10];

            try
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    objects[i] = new BigObject();
                    Console.WriteLine("Розмір купи = {0} MB", GC.GetTotalMemory(false) / 1024 / 1024); // true
                    //Thread.Sleep(1000);
                    //BigObject @object = new BigObject();
                }
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }

            
            

            foreach (BigObject big in objects)
            {
                big.Dispose(); // очистка памяти
            }
            


            // Delay.
            Console.ReadKey();
        }
    }
}
