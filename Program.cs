using System;

namespace eutazas
{
    class Program
    {
        static void Main(string[] args)
        {
            Tasks tasks = Tasks.GetTasks();

            tasks.Task1();
            tasks.Task2();
            tasks.Task3();
            tasks.Task4();
            tasks.Task5();
            tasks.Task6();
            tasks.Task7();
            Console.WriteLine("done! PRAISE THE LORD GOD JESUS CHIRST!!!");
            Console.ReadLine();

        }
    }
}
