using System;
using System.Collections.Generic;
using System.Text;

namespace eutazas
{
    public class Displayer
    {
        // This class will be used to print to Console


        // ---- Singleton Design Pattern ----

        private static Displayer singleton;

        private Displayer()
        {

        }

        public static Displayer GetDisplayer()
        {
            if (singleton == null)
            {
                singleton = new Displayer();
            }
            return singleton;
        }

        // ---- Singleton Design Pattern ----

        public void Display(string[] lines)
        {
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
            }
        }

        public void Display(int n)
        {
             Console.WriteLine(n);
        }


    }
}
