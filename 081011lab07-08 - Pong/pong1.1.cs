using System;
using System.Collections.Generic;
using System.Text;

namespace pong
{
    class Pong
    {
        /*This source code was designed by Paul Ness, 05/11/07 - 19/11/07*/

        static int x = 2; //declaration of x and the default value set to 1 away from the edge
        static int y = 2;
        static int xSpeed = 1; //the speed x will move away from 0,0 will be defined in this variable
        static int ySpeed = 1;
        static bool escape = false;

        /*Sets the paddle length & where the paddle is to be placed*/
        static int leftPaddleX = 2;
        static int leftPaddleY = 10;
        static int leftPaddleLength = 4;

        static int rightPaddleX = 77;
        static int rightPaddleY = 10;
        static int rightPaddleLength = 4;

        // fields to save previous background and foregrounds colors 
        static ConsoleColor oldBack;
        static ConsoleColor oldFore;

        // methods 

        public static void DrawBox(int ucol, int urow, int lcol, int lrow, ConsoleColor back, ConsoleColor fore, bool fill)
        {
            const char Horizontal = '\u2500';
            const char Vertical = '\u2502';
            const char UpperLeftCorner = '\u250c';
            const char UpperRightCorner = '\u2510';
            const char LowerLeftCorner = '\u2514';
            const char LowerRightCorner = '\u2518';
            string fillLine = fill ? new string(' ', lcol - ucol - 1) : "";
            SetColors(back, fore);
            // draw top edge 
            Console.SetCursorPosition(ucol, urow);
            Console.Write(UpperLeftCorner);
            for (int i = ucol + 1; i < lcol; i++)
            {
                Console.Write(Horizontal);
            }
            Console.Write(UpperRightCorner);
            // draw sides 
            for (int i = urow + 1; i < lrow; i++)
            {
                Console.SetCursorPosition(ucol, i);
                Console.Write(Vertical);
                if (fill) Console.Write(fillLine);
                Console.SetCursorPosition(lcol, i);
                Console.Write(Vertical);
            }
            // draw bottom edge 
            Console.SetCursorPosition(ucol, lrow);
            Console.Write(LowerLeftCorner);
            for (int i = ucol + 1; i < lcol; i++)
            {
                Console.Write(Horizontal);
            }
            Console.Write(LowerRightCorner);
            RestoreColors();
        }

        // overload to use current background and foreground colors 
        public static void DrawBox(int ucol, int urow, int lcol, int lrow, bool fill)
        {
            DrawBox(ucol, urow, lcol, lrow, Console.BackgroundColor, Console.ForegroundColor, fill);
        }

        public static void SetColors(ConsoleColor back, ConsoleColor fore)
        {
            // save current background and foreground colors 
            oldBack = Console.BackgroundColor;
            oldFore = Console.ForegroundColor;
            // set them to new colors 
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public static void RestoreColors()
        {
            // restore original colors 
            Console.BackgroundColor = oldBack;
            Console.ForegroundColor = oldFore;
        }

        static void ballMovement() //start method ballMovement
        {
            do
            {
                /*Refreshes the paddles by putting blank spaces after the paddles*/
                for (int i = leftPaddleY - 1; i < leftPaddleY + leftPaddleLength; i = i + 1)
                {
                    Console.SetCursorPosition(leftPaddleX, i);
                    Console.WriteLine(" ");
                }
                for (int i = leftPaddleY - 1; i < leftPaddleY + leftPaddleLength + 1; i = i + 1)
                {
                    Console.SetCursorPosition(leftPaddleX, i);
                    Console.WriteLine(" ");
                }
                for (int i = rightPaddleY - 1; i < rightPaddleY + rightPaddleLength; i = i + 1)
                {
                    Console.SetCursorPosition(rightPaddleX, i);
                    Console.WriteLine(" ");
                }
                for (int i = rightPaddleY - 1; i < rightPaddleY + rightPaddleLength + 1; i = i + 1)
                {
                    Console.SetCursorPosition(rightPaddleX, i);
                    Console.WriteLine(" ");
                }

                /*The for loop draws the paddle down the Y axis starting from the leftPaddleY;
                 *It draws it until the it has reached the end point which is -
                 * the start point (leftPaddleY) + leftPaddleLength (the desired length of paddle)*/
                for (int i = leftPaddleY; i < leftPaddleY + leftPaddleLength; i = i + 1)
                {
                    /*While the 'for loop' goes through each loop the below are performed each time*/
                    Console.SetCursorPosition(leftPaddleX, i);
                    Console.WriteLine("|");
                }

                for (int i = rightPaddleY; i < rightPaddleY + rightPaddleLength; i = i + 1)
                {
                    Console.SetCursorPosition(rightPaddleX, i);
                    Console.WriteLine("|");
                }
                /*If any key pressed then we move into the switch statement*/
                if (Console.KeyAvailable)
                {
                    /*Creates a object of type ConsoleKeyInfo
                     * gets the value of what key is pressed and puts it into keyInfo*/
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    /*checks to see what key is stored in keyInfo*/
                    switch (keyInfo.Key)
                    {
                        /*if the key pressed in keyInfo is escape, bool escape=true*/
                        case ConsoleKey.Escape:
                            escape = true;
                            break;

                        /*if the key pressed is A leftPaddleY moves towards the origin
                         * 0,0 which means it moves up the Y axis*/
                        case ConsoleKey.W:
                            if (leftPaddleY == 2)
                            {
                                break;
                            }
                            else
                                leftPaddleY = leftPaddleY - 1;
                            break;

                        case ConsoleKey.S:
                            if (leftPaddleY == 20)
                            {
                                break;
                            }
                            else
                                leftPaddleY = leftPaddleY + 1;
                            break;

                        case ConsoleKey.U:
                            if (rightPaddleY == 2)
                            {
                                break;
                            }
                            else
                                rightPaddleY = rightPaddleY - 1;
                            break;

                        case ConsoleKey.J:
                            if (rightPaddleY == 20)
                            {
                                break;
                            }
                            else
                                rightPaddleY = rightPaddleY + 1;
                            break;
                    }
                }

                /*When the x becomes equal to the edge of the console window
                 *it reverses the value of xSpeed by multiplying it by -1*/
                if ((x == 78) || (x == 1))
                {
                    xSpeed = xSpeed * -1;
                }

                if ((y == 24) || (y == 1))
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

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetWindowSize(80, 30); //sets the window of the console to 80 by 25
            Console.BufferHeight = 30; //sets the height limit of the console
            Console.BufferWidth = 80;
            Console.Clear(); //clears the console screen (directory info etc)
            DrawBox(0, 0, 79, 25, ConsoleColor.DarkGray, ConsoleColor.Green, false);


            ballMovement(); //calls the method ballMovement located in the class

        }
    }
}