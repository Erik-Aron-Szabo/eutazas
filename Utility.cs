using System;
using System.Collections.Generic;
using System.Text;


namespace eutazas
{
    public class Utility
    {
        // this class will serve as a storage for helper functions 

        private static Utility singleton;

        private Utility() { }

        public static Utility GetUtility()
        {
            if (singleton == null)
            {
                singleton = new Utility();
            }
            return singleton;
        }


        // functions

        // returns # of travellers (lines)
        public int TravellerCounter(string[] lines)
        {
            int counter = 0;
            foreach (string line in lines)
            {
                counter++;
            }
            return counter;
        }

        // Task3
        public int CheckingTicketsAndPass(string[] lines)
        {
            int counter = 0;
            int today = Convert.ToInt32(DateTime.Today.ToString("yyyyMMdd"));
            foreach (string line in lines)
            {
                string[] traveller = line.Split(" ");
                for (int i = 0; i < traveller.Length; i++)
                {
                    string field3 = traveller[3];
                    string field4 = traveller[4];

                    if (field3 == "JGY" && field4 == "0" || Convert.ToInt32(field4) < today)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }


        // Task4
        public int[] MostTravellers_Task4(string[] lines)
        {
            Dictionary<int, int> mostTravellers = new Dictionary<int, int>();
            int travellerCounter = 0;
            int stationCounter = 0;
            foreach (var item in lines)
            {
                string[] line = item.Split(" ");
                for (int i = 1; i < line.Length; i++)
                {
                    int station = Convert.ToInt32(line[0]);
                    if (station != stationCounter)
                    {
                        mostTravellers.Add(stationCounter, travellerCounter);
                        stationCounter = station;
                        travellerCounter = 0;
                    }
                    travellerCounter++;
                }
            }
            
            
            return MostTravellersComparer(mostTravellers);
        }

        private int[] MostTravellersComparer(Dictionary<int, int> mostTravellers)
        {
            int[] stationAndTraveller = new int[2];
            int smallestStation = 0;
            int mostTravellersCount = 0;
            foreach (var item in mostTravellers)
            {
                int station = item.Key;
                int travellers = item.Value;

                if (station > smallestStation && travellers > mostTravellersCount)
                {
                    smallestStation = station;
                    mostTravellersCount = travellers;
                }
            }
            stationAndTraveller[0] = smallestStation;
            stationAndTraveller[1] = mostTravellersCount;
            return stationAndTraveller;
        }

        // Task 5
        // Only valid passes count
        // Free , Discounted
        public int[] Task5_DicountOrFreeCounter(string[] lines)
        {
            int today = Convert.ToInt32(DateTime.Today.ToString("yyyyMMdd"));
            string[] discounted = { "TAB", "NYB" };
            string[] free = {"NYP", "RVS", "GYK"};
            string[] other = {"FEB", "JGY" };


            int discountedTravellerCount = 0;
            int freeTravellerCount = 0;


            foreach (string item in lines)
            {
                string[] line = item.Split(" ");
                for (int i = 0; i < line.Length; i++)
                {
                    int passDate = Convert.ToInt32(line[4]);
                    string passType = line[3];

                    if (passDate >= today)
                    {

                        if (passType != "FEB" && passType != "JGY")
                        {
                            // increments discountedTravellerCounter if passType matches one
                            // of the strings in discounted array

                            foreach (var discountedPass in discounted)
                            {
                                if (passType == discountedPass)
                                {
                                    discountedTravellerCount++;
                                }
                            }

                            foreach (var freePass in free)
                            {
                                if (passType == freePass)
                                {
                                    freeTravellerCount++;
                                }
                            }
                        }

                        
                    }
                }
            }

            int[] travellers = { discountedTravellerCount, freeTravellerCount };

            return travellers;
        }


        // Task 6
        public int napokszama(int e1, int h1, int n1, int e2, int h2, int n2)
        {
            h1 = (h1 + 9) % 12;
            e1 = e1 - h1 / 10;
            int d1 = 365*e1 + e1 / 4 - e1 / 100 + e1 / 400 + (h1*306 + 5) / 10 + n1 - 1;
            h2 = (h2 + 9) % 12;
            e2 = e2 - h2 / 10;
            int d2 = 365 * e2 + e2 / 4 - e2 / 100 + e2 / 400 + (h2 * 306 + 5) / 10 + n2 - 1;
            int napokszama = d2 - d1;

            return napokszama;
        }
        // Task 7

        private int[] dateBreaker(string date)
        {
            // "20190914"
            // format should be in "yyyyMMdd"
            int year = Convert.ToInt32(date.Remove(4));
            int month = Convert.ToInt32(date.Remove(0, 4).Remove(2));
            int day = Convert.ToInt32(date.Remove(0, 6));

            int[] formattedDate = {year, month, day };

            return formattedDate;
        }


        public string[] Task7_warningGiver(string[] lines)
        {
            // this array collects the traveller's ID and their pass' date of validity
            string[] toBeWarnedTravellers = new string[0];
            foreach (var item in lines)
            {
                string[] line = item.Split(" ");
                for (int i = 0; i < line.Length; i++)
                {
                    string boardingDate = line[1].Remove(8);
                    string id = line[2];
                    string passType = line[3];
                    string dateOfValidity = line[4];
                    string[] warningRequirements = {id, dateOfValidity };

                    if (passType != "JGY")
                    {
                        int[] boardingDateArr = dateBreaker(boardingDate);
                        int[] dateOfValidityArr = dateBreaker(dateOfValidity);

                        int daysLeft = napokszama(boardingDateArr[0], boardingDateArr[1], boardingDateArr[2], dateOfValidityArr[0], dateOfValidityArr[1], dateOfValidityArr[2]);

                        if (daysLeft <= 3)
                        {
                            string[] temp = new string[toBeWarnedTravellers.Length + 1];
                            for (int j = 0; j < toBeWarnedTravellers.Length; j++)
                            {
                                temp[j] = toBeWarnedTravellers[j];
                            }
                            if (dateOfValidityArr[2] <= 9)
                            {
                                temp[temp.Length - 1] = $"{id} {dateOfValidityArr[0]}-0{dateOfValidityArr[1]}-0{dateOfValidityArr[2]}";
                            } else
                            {
                                temp[temp.Length - 1] = $"{id} {dateOfValidityArr[0]}-0{dateOfValidityArr[1]}-{dateOfValidityArr[2]}";
                            }
                            toBeWarnedTravellers = temp;
                            break;
                        }
                        break;
                    }

                }
            }
            return toBeWarnedTravellers;
        }


    }
}
