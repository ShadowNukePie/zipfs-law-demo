using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Zipfs_Law_Demonstration
{
    class Program
    {
        public static Random ranGen = new Random();
        public static int RPVcounter;
        public static bool wordTerminated;
        // TO DO: uh nothing really i'm kinda done
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to a console demonstration for Zipf's Law using random text generation. Please enter how many random words you would like to generate");
            int wordsToGen = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Please enter a filepath and filename for the output.");
            Console.WriteLine("Filepath?");
            string filePath = Console.ReadLine();
            Console.WriteLine("Filename? (Include .txt)");
            string fileName = Console.ReadLine();
            string FFSW = System.IO.Path.Combine(@filePath, @fileName);
            System.IO.StreamWriter textFile = new System.IO.StreamWriter(@FFSW);
         
            int[] lengthList = new int[wordsToGen];
            for (int wTG = 1; wTG < wordsToGen; wTG++)
            {
                
                do
                {
                   int keyPressed = GenerateRandom(1, 28);
                   if(keyPressed != 27)
                    {
                        RPVcounter++;
                    }
                   else
                    {
                        wordTerminated = true;
                    }
                }
                while(!wordTerminated);
                string word = GenWord(RPVcounter);
                Console.WriteLine("Word : " + word + " Length : " + word.Length);
                lengthList[wTG] = word.Length;
                RPVcounter = 0;
                wordTerminated = false;
            }

            int maxLength = lengthList.Max();
            for(int a = 0; a <= maxLength; a++)
            {
                int ct = 0;
                for(int b = 0; b < wordsToGen; b++)
                {
                    if (lengthList[b] == a)
                        ct++;
                }
                textFile.WriteLine("Count of " + a + " = " + ct);
            }

            textFile.Close();
            Console.ReadKey();
        } //end of main

        public static string GenWord(int maxSize)
        {
            char[] chars = new char[26];
            chars =
            "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
        public static int GenerateRandom(int mini, int maxi)
        {
            int rt = ranGen.Next(mini, maxi);
            return rt;
        } // end of genword
    }// end of program class
} // end of file

