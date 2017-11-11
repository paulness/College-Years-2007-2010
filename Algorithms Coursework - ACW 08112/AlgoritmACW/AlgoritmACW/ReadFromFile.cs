using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AlgoritmACW
{
    class ReadFromFile
    {
        static void Main()
        {
            double[] data; //create a reference that can point to an array of doubles to hold the values
            int bestStart, bestEnd; //record start & end of a most profitable run
            double bestTotal; //the total of all the values added together in the bestStart to bestEnd run range
            int loops; //records how many loops it has taken

            Console.WriteLine("Enter Name of File to Read");
            /// name of the file and the number of readings
            string filename = Console.ReadLine();
            int items = 0;
            TextReader textIn = new StreamReader(filename);

            #region Finds out how big the array needs to be
            try
            {
                //Reads line from txt file until nothing there and increments int items each time
                //Finds out how big the array needs to be by how many lines in the file can be read
                while (textIn.ReadLine() != null)
                {
                    items++;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                textIn.Close();
            }
            #endregion

            #region reads in the data from the StreamReader into the array each line a new element
            data = new double[items]; //points data ref to array the size of items

            try
            {
                textIn = new StreamReader(filename);
                for (int i = 0; i < items; i++)
                {
                    string line = textIn.ReadLine();
                    data[i] = double.Parse(line);
                }
                textIn.Close();
            }
            catch
            {
                Console.WriteLine("File Read Failed");
                return;
            }
            #endregion

            #region CALLS THE ALGORITHMS THAT FIND THE BEST CONTIGUOUS RUN OF PROFIT WEEKS
            RangeofBestProfitRun.Algorithm_1(data, out bestStart, out bestEnd, out bestTotal, out loops);
            Console.WriteLine("Start : {0} End : {1} Total {2} Loops {3}",
            bestStart, bestEnd, bestTotal, loops);

            RangeofBestProfitRun.Algorithm_2(data, out bestStart, out bestEnd, out bestTotal, out loops);
            Console.WriteLine("Start : {0} End : {1} Total {2} Loops {3}",
            bestStart, bestEnd, bestTotal, loops);

            RangeofBestProfitRun.Algorithm_3(data, out bestStart, out bestEnd, out bestTotal, out loops);
            Console.WriteLine("Start : {0} End : {1} Total {2} Loops {3}",
            bestStart, bestEnd, bestTotal, loops);
            #endregion

            Console.ReadKey();
        }
    }
}
