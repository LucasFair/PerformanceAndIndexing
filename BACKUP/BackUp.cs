using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace RandomNumberToFile
{
    internal class Program
    {
        public static string filePath = @"C:\Users\Fair\Documents\SQL\Output\";
        public static string fileName;
        static int GenerateNumberToFile(int stateNum)
        {
            Random rnd = new Random();

            fileName = "RandomNumbersListNEW.txt";

            bool bFileExists;
            string fileOutput = filePath + fileName;
            List<int> listNum = new List<int>();  // Making a list that will contain the numbers.
            const int NUM_MAX = 1000000;
            const int RND_MAX = 10000;
            int rndNum;

            if (!File.Exists(fileOutput))
            {
                bFileExists = false;
                using (StreamWriter sWrite = new StreamWriter(fileOutput))
                {
                    for (int rndCnt = 0; rndCnt < NUM_MAX; rndCnt++)
                    {
                        sWrite.WriteLine(string.Empty);
                        sWrite.WriteLine(rndNum = rnd.Next(0, RND_MAX));
                    }

                    /*
                    for (int rndCnt = 0; rndCnt < NUM_MAX; rndCnt++)  // Counts to max number value
                    {
                        do
                        {
                            rndNum = rnd.Next(0, RND_MAX);  // Generates the random number within the range
                        } while (listNum.Contains(rndNum));  // This prevents duplicate numbers, and will redo the random number
                                                             // until the max draw amount has been reached
                        listNum.Add(rndNum);  // Adds the generated numbers to the list
                    }

                    for (int outCnt = 0; outCnt < listNum.Count; outCnt++)   // This prints out the elements 
                    {
                        if (outCnt < NUM_MAX - 1)
                        {
                            //string txtStart;
                            //txtStart = (listNum[outCnt] + ", ");
                            //sWrite.Write(listNum[outCnt] + ", ");
                            sWrite.WriteLine(outCnt);
                            sWrite.WriteLine(listNum[outCnt]);
                        }
                        else
                        {
                            //string txtEnd;
                            //txtEnd = Convert.ToString(listNum[outCnt]);
                            //sWrite.Write(listNum[outCnt]);
                            sWrite.WriteLine(outCnt);
                            sWrite.WriteLine(listNum[outCnt]);
                        }
                    }
                    */
                }
                return stateNum = 0;
                //string readTxt = File.ReadAllText(fileOutput);
                //Console.WriteLine(fileOutput);
            }
            else
            {
                bFileExists = true;
                return stateNum = 1;
            }
        }

        static void StateMessage(int stateNum)
        {
            switch (stateNum)
            {
                case 0:
                    Console.WriteLine("The text file has been generated!\nThe location is: " + filePath + fileName);
                    break;
                case 1:
                    Console.WriteLine("The file already exists.\nWould you like to replace it?");
                    break;
                case 2:
                    Console.WriteLine("Are you sure?");
                    break;
                case 3:
                    Console.WriteLine("Type \"Y\" to overwrite the file.");
                    break;
            }
        }
        static void Main()
        {
            StateMessage(GenerateNumberToFile(0));
        }
    }
}
