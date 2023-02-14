using System;
using System.Text;
using System.Threading;

namespace Homework9_2
{

    class BigObject
    {
        
        Array array = new int[10000000];
        public BigObject()
        {
            //Console.WriteLine(this.GetHashCode());
        }

        //~BigObject()
        //{
        //    Console.WriteLine("Об'єкт " + this.GetHashCode() + " видалено");
        //}
    }




    class MemoryMonitor
    {

        public void ShowAlert(object maxMemoryUsage)
        {
            while (true)
            {
                Console.WriteLine("Monitoring...");
                int memoryUsage = (int)GC.GetTotalMemory(false) / 1024 / 1024;
                Console.WriteLine("Розмір купи = {0} MB", memoryUsage);

                if (memoryUsage >= (int)maxMemoryUsage)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Monitoring - memoryUsage > maxMemory");
                    Console.ResetColor();
                    Thread.Sleep(1000000);
                    
                }

                
            }
            
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            /*
             Створіть клас, який дозволить виконувати моніторинг ресурсів, 
            що використовуються програмою. Використовуйте його з метою 
            спостереження за роботою програми, а саме: користувач може вказати прийнятні 
            рівні споживання ресурсів (пам'яті), а методи класу дозволять видати попередження, 
            коли кількість ресурсів, що реально використовуються, наблизитися 
            до максимально допустимого рівня.
             */

            MemoryMonitor memoryMonitor = new MemoryMonitor();

            Console.WriteLine("Input maximum memory usage in MB:");

            int maxMemoryUsage = int.Parse(Console.ReadLine());

            ParameterizedThreadStart monitor = new ParameterizedThreadStart(memoryMonitor.ShowAlert);

            Thread thread = new Thread(monitor);
            thread.Start(maxMemoryUsage);

            BigObject[] objects = new BigObject[1000];

            int i = 0;

            while (thread.ThreadState == ThreadState.WaitSleepJoin ? false : true )
            {
                
                try
                {
                    
                        Console.WriteLine("Add object to memory");
                        objects[i] = new BigObject();
                        i++;
                        Thread.Sleep(1000);

                   
                }
                catch (OutOfMemoryException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            

            Console.ReadKey();
        }
    }
}
