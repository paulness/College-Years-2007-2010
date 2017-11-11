using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmACW
{
    class RangeofBestProfitRun
    {
        #region Algorithm 1
        //'out' keyword means the method must and can only output to this parameter
        public static void Algorithm_1(double[] data, out int bestStart, out int bestEnd, out double bestTotal, out int loops)
        {
            //set all parameters default values to zero
            bestTotal = 0;
            bestStart = 0;
            bestEnd = 0;
            loops = 0;
            double subTotal = 0;

            //for every start position
            for (int start = 0; start < data.Length; start++) //when this loop is operated the start element moves up
            {
                //for every end position
                for (int end = start; end < data.Length; end++)
                {
                    subTotal = 0;
                    //adds all elements in between start and end
                    for (int i = start; i <= end; i++)
                    {
                        ///loop counter located because this is where all
                        ///the looping work is done
                        loops++;
                        subTotal += data[i];
                    }
                    if (subTotal > bestTotal)
                    {
                        bestTotal = subTotal;
                        bestStart = start;
                        bestEnd = end;
                    }
                }
            }
        }
        #endregion

        #region Algorithm 2
        /*following version is more efficient because, rather than reset the subTotal to zero
         *for each possible 'end', it just continues to add to the existing subTotal
         *until the final 'end' is reached. The subTotal is then reset for the next 'start'*/

        public static void Algorithm_2(double[] data, out int bestStart, out int bestEnd, out double bestTotal, out int loops)
        {
            //set all parameters default values to zero
            bestTotal = 0;
            bestStart = 0;
            bestEnd = 0;
            loops = 0;
            double subTotal = 0;

            //for every start position 
            for (int start = 0; start < data.Length; start++) //when this loop is operated the start element moves up 
            {
                // reset sub-total 
                subTotal = 0;
                //for every end position (valid end elements would be the same element as start to the last element in the array)
                for (int end = start; end < data.Length; end++) //before the start moves up the end increments its way along until the end from the current start
                {
                    loops++;
                    //subTotal builds up as it adds the value inside array index [end] to the total
                    subTotal += data[end];
                    //if the current subTotal is larger than the bestTotal
                    if (subTotal > bestTotal)
                    {
                        bestTotal = subTotal;
                        bestStart = start;
                        bestEnd = end;
                    }
                }
            }
        }
        #endregion

        #region Algorithm 3
        /*following version is more efficient because, rather than reset the subTotal to zero
         *for each possible 'end', it just continues to add to the existing subTotal
         *until the final 'end' is reached. The subTotal is then reset for the next 'start'*/

        public static void Algorithm_3(double[] data, out int bestStart, out int bestEnd, out double bestTotal, out int loops)
        {
            //set all parameters default values to zero
            bestTotal = 0;
            bestStart = 0;
            bestEnd = 0;
            loops = 0;
            double subTotal = 0;

            int start = 0; //set startPosition to zero
            //reset sub-total 
            subTotal = 0;

            //for every end position (valid end elements would be the same element as start to the last element in the array)
            for (int end = start; end < data.Length; end++) //before the start moves up the end increments its way along until the end from the current start
            {
                loops++;
                //subTotal builds up as it adds the value inside array index [end] to the total
                subTotal += data[end];

                ///if subtotal ever becomes a negative adding the next element
                ///will only bring down the result so just start counting up weeks
                ///from the next element
                if (subTotal < 0)
                {
                    start = end + 1;
                    subTotal = 0;
                    continue;
                }
                //if the current subTotal is larger than the bestTotal
                if (subTotal > bestTotal)
                {
                    bestTotal = subTotal;
                    bestStart = start;
                    bestEnd = end;
                }
            }
        }
        #endregion
    }
}