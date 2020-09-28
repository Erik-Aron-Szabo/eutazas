using System;
using System.Collections.Generic;
using System.Text;

namespace eutazas
{
    public class Tasks
    {
        private static Tasks singleton;

        private Tasks() { }

        public static Tasks GetTasks()
        {
            if (singleton == null)
            {
                singleton = new Tasks();
            }

            return singleton;
        }

        // instantiating other singletons 

        Displayer displayer = Displayer.GetDisplayer();
        private static DocumentHandler documentHandler = DocumentHandler.GetDocumentHandler();
        Utility utility = Utility.GetUtility();

        private static string utasadat = "utasadat.txt";
        private static string figyelmeztetes = "figyelmeztetes.txt";
        private static string[] lines = documentHandler.Reader(utasadat);



        //1
        public void Task1()
        {
            Console.WriteLine("1.feladat");
            displayer.Display(lines);
        }

        //2
        public void Task2()
        {
            Console.WriteLine("2.feladat A buszra " + utility.TravellerCounter(lines) + " utas szeretett volna felszállni a buszra.");
            Console.WriteLine();

        }

        public void Task3()
        {
            int counter = utility.CheckingTicketsAndPass(lines);

            Console.WriteLine("3.feladat A buszra " + counter + " utas nem szálhatott fel.");
            Console.WriteLine();
        }

        public void Task4()
        {
            int[] stationAndTravellers = utility.MostTravellers_Task4(lines);
            int station = stationAndTravellers[0];
            int travellers = stationAndTravellers[1];

            Console.WriteLine($"4.feladat A legtöbb utas ({travellers} fő) a {station}. megállóban próbált felszállni.");
            Console.WriteLine();
        }

        public void Task5()
        {
            int[] travellers = utility.Task5_DicountOrFreeCounter(lines);
            int discounted = travellers[0];
            int free = travellers[1];

            Console.WriteLine($"5. feladat Ingyenesen utazók száma: {free} fő. A kedvezményesen utazók száma: {discounted} fő.");
            Console.WriteLine();
        }

        public void Task6()
        {
            //int daysBetween = utility.napokszama(2019, 12, 31, 2019, 12, 20);
            //Console.WriteLine("6.feladat");
            //Console.WriteLine(daysBetween);
        }

        public void Task7()
        {
            string[] linesWrite = utility.Task7_warningGiver(lines);
            documentHandler.Writer(linesWrite, figyelmeztetes);
            //Console.WriteLine("7.feladat");
            //displayer.Display(documentHandler.Reader(figyelmeztetes));
        }

    }
}
