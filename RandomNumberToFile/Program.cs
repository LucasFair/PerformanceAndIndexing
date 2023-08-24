using System;
using System.IO;

namespace RandomNumberToFile
{
    internal class Program
    {
        public static string filePath = @"C:\Users\Fair\Documents\SQL\Output\";
        public static string fileName = "RandomNumbersList.txt";

        static void GenerateNumberToFile()
        {
            Random rnd = new Random();

            const int NUM_MAX = 1000000;
            const int RND_MAX = 10000;
            int rndNum;

            using (StreamWriter sWrite = new StreamWriter(filePath + fileName))  // Generates the file
            {
                for (int rndCnt = 0; rndCnt < NUM_MAX; rndCnt++)
                {
                    sWrite.WriteLine(string.Empty);  // Line break is added in order to make INSERT BULK work
                    sWrite.WriteLine(rndNum = rnd.Next(0, RND_MAX));
                }
            }
        }

        static void StateMessage(int stateNum)
        {
            switch (stateNum)
            {
                case 0:
                    Console.WriteLine("Welcome to the Random Number To File Generator(name subject to change)!\n" +
                        "Press ANY KEY to generate a text file with one million random numbers.\n");
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The text file has been generated!\nThe location is: " + filePath + fileName);
                    Console.ResetColor();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"A file, {fileName}, already exists.\n");
                    Console.ResetColor();
                    break;
                case 3:
                    Console.WriteLine("Type \"Y\" to overwrite the old file, or \"N\" to quit.");
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nThe file has been overwritten successfully!" +
                        "\nThe location is: " + filePath + fileName + "\n");
                    Console.ResetColor();
                    break;
                case 5:
                    Console.WriteLine("\nThe file remains unchanged.\n");
                    break;
                case 6:
                    Console.WriteLine("Good-bye!\n");
                    break;
                default:
                    Console.WriteLine("\nSomething went wrong.\n");
                    return;
            }
        }

        static void Main()
        {
            string userChoice = "";
            StateMessage(0);
            Console.ReadKey();  // Any key :-)
            Console.Write("\r");
            if (File.Exists(filePath + fileName))
            {
                StateMessage(2);
                while ((userChoice != "\"Y\"") && (userChoice != "Y") && (userChoice != "\"N\"") && (userChoice != "N"))
                {
                    StateMessage(3);
                    Console.Write(">  ");
                    userChoice = Console.ReadLine().ToUpper();
                }  // Prevents any input besides the ones being asked from being used

                switch (userChoice)
                {
                    case "Y":
                    case "\"Y\"":  // To prevent an obtuse user from including qoutation marks and exiting the code
                        GenerateNumberToFile();
                        StateMessage(4);
                        return;
                    case "N":
                    case "\"N\"":
                        StateMessage(5);
                        StateMessage(6);
                        return;
                    default:
                        StateMessage(6);
                        return;
                }
            }
            else
            {
                GenerateNumberToFile();
                StateMessage(1);
                return;
            }
        }
    }
}
