using System;
using System.Collections.Generic;
using System.Text;

namespace pong
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            /*Declaration of integer x and y and the default value set to 1, 1 away from 0, 0*/
            int x = 1;
            int y = 1;

            /*Declaration of the variable of the speed it moves away from
             * 0,0 (how many spaces does it skip before it is refreshed in a new space)*/
            int xSpeed = 1;
            int ySpeed = 1;

            bool escape;
            escape = false;

            /*Clears the console screen
             *(gets rid of directory information etc)
              I did this outside the loop so it only clears the screen once*/
            Console.Clear();
            do
            {
                /*If a key is pressed then instructions inside if statement will be used*/
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.Escape:
                            escape = true;
                            break;
                    }
                }

                /*When the x becomes equal to the edge of the console window
                 *it reverses the value of xSpeed by multiplying it by -1*/ 
                if ((x == 79) || (x == 0))
                {
                    xSpeed = xSpeed * -1;
                }

                if ((y == 24) || (y == 0))
                {
                    ySpeed = ySpeed * -1;
                }
                /*This writes a blank string behind the ball
                * which creates the effect the ball is moving*/
                Console.SetCursorPosition(x, y);
                Console.Write(" ");

                /*Yeah this increments x by the value of int xSpeed,
                * because it is in the loop its going to increment-
                * every time it goes through the loop*/
                x = x + xSpeed;
                y = y + ySpeed;

                /*Sets the cursor position away from x=0, y=0 (top left hand corner)
                * to the values in variables x & y*/
                Console.SetCursorPosition(x, y);
                /*Write the string on the current cursor position*/
                Console.Write("O");


                /*This slows down each process in the program to ???ms*/
                System.Threading.Thread.Sleep(200);
                /*Program loops while escape is not false (!escape)*/
            } while (!escape);
        }
    }
}
