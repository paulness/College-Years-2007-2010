using System;

class PongGame
{

    static void winner(int team)
    {

        Console.Clear();

        switch (team)
        {

            case 1:

                Console.SetCursorPosition(30, 15);

                Console.Write("PLAYER 1 WINS!!");

                Console.SetCursorPosition(0, 24);

                break;

            case 2:

                Console.SetCursorPosition(30, 15);

                Console.Write("PLAYER 2 WINS!!");

                Console.SetCursorPosition(0, 24);

                break;

        }

        System.Threading.Thread.Sleep(2000);



    }



    static void number1(int score)
    {

        switch (score)
        {

            case 0:

                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 15;

                    Console.SetCursorPosition(one, 6);

                    Console.Write("#");

                }





                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 15;

                    Console.SetCursorPosition(one, 10);

                    Console.Write("#");

                }

                Console.SetCursorPosition(15, 7);

                Console.Write("#");

                Console.SetCursorPosition(19, 9);

                Console.Write("#");

                Console.SetCursorPosition(19, 7);

                Console.Write("#");

                Console.SetCursorPosition(15, 9);

                Console.Write("#");

                Console.SetCursorPosition(19, 8);

                Console.Write("#");

                Console.SetCursorPosition(15, 8);

                Console.Write("#");



                break;

            case 1:

                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 6;

                    Console.SetCursorPosition(15, one);

                    Console.Write("#");

                }

                Console.SetCursorPosition(14, 7);

                Console.Write("#");

                break;

            case 2:

                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 15;

                    Console.SetCursorPosition(one, 6);

                    Console.Write("#");

                }



                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 15;

                    Console.SetCursorPosition(one, 8);

                    Console.Write("#");

                }



                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 15;

                    Console.SetCursorPosition(one, 10);

                    Console.Write("#");

                }

                Console.SetCursorPosition(19, 7);

                Console.Write("#");

                Console.SetCursorPosition(15, 9);

                Console.Write("#");



                break;

            case 3:

                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 15;

                    Console.SetCursorPosition(one, 6);

                    Console.Write("#");

                }



                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 15;

                    Console.SetCursorPosition(one, 8);

                    Console.Write("#");

                }



                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 15;

                    Console.SetCursorPosition(one, 10);

                    Console.Write("#");

                }

                Console.SetCursorPosition(19, 7);

                Console.Write("#");

                Console.SetCursorPosition(19, 9);

                Console.Write("#");



                break;

            case 4:

                Console.SetCursorPosition(15, 6);

                Console.Write("#");



                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 15;

                    Console.SetCursorPosition(one, 8);

                    Console.Write("#");

                }





                Console.SetCursorPosition(15, 7);

                Console.Write("#");

                Console.SetCursorPosition(17, 9);

                Console.Write("#");

                Console.SetCursorPosition(17, 7);

                Console.Write("#");

                Console.SetCursorPosition(17, 10);

                Console.Write("#");

                break;



            case 5:

                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 15;

                    Console.SetCursorPosition(one, 6);

                    Console.Write("#");

                }



                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 15;

                    Console.SetCursorPosition(one, 8);

                    Console.Write("#");

                }



                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 15;

                    Console.SetCursorPosition(one, 10);

                    Console.Write("#");

                }

                Console.SetCursorPosition(15, 7);

                Console.Write("#");

                Console.SetCursorPosition(19, 9);

                Console.Write("#");



                break;

        }



    }



    static void number2(int score)
    {

        switch (score)
        {

            case 0:

                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 55;

                    Console.SetCursorPosition(one, 6);

                    Console.Write("#");

                }





                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 55;

                    Console.SetCursorPosition(one, 10);

                    Console.Write("#");

                }

                Console.SetCursorPosition(55, 7);

                Console.Write("#");

                Console.SetCursorPosition(59, 9);

                Console.Write("#");

                Console.SetCursorPosition(59, 7);

                Console.Write("#");

                Console.SetCursorPosition(55, 9);

                Console.Write("#");

                Console.SetCursorPosition(59, 8);

                Console.Write("#");

                Console.SetCursorPosition(55, 8);

                Console.Write("#");



                break;

            case 1:

                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 6;

                    Console.SetCursorPosition(55, one);

                    Console.Write("#");

                }

                Console.SetCursorPosition(54, 7);

                Console.Write("#");

                break;

            case 2:

                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 55;

                    Console.SetCursorPosition(one, 6);

                    Console.Write("#");

                }



                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 55;

                    Console.SetCursorPosition(one, 8);

                    Console.Write("#");

                }



                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 55;

                    Console.SetCursorPosition(one, 10);

                    Console.Write("#");

                }

                Console.SetCursorPosition(59, 7);

                Console.Write("#");

                Console.SetCursorPosition(55, 9);

                Console.Write("#");



                break;

            case 3:

                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 55;

                    Console.SetCursorPosition(one, 6);

                    Console.Write("#");

                }



                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 55;

                    Console.SetCursorPosition(one, 8);

                    Console.Write("#");

                }



                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 55;

                    Console.SetCursorPosition(one, 10);

                    Console.Write("#");

                }

                Console.SetCursorPosition(59, 7);

                Console.Write("#");

                Console.SetCursorPosition(59, 9);

                Console.Write("#");



                break;

            case 4:

                Console.SetCursorPosition(55, 6);

                Console.Write("#");



                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 55;

                    Console.SetCursorPosition(one, 8);

                    Console.Write("#");

                }





                Console.SetCursorPosition(55, 7);

                Console.Write("#");

                Console.SetCursorPosition(57, 9);

                Console.Write("#");

                Console.SetCursorPosition(57, 7);

                Console.Write("#");

                Console.SetCursorPosition(57, 10);

                Console.Write("#");

                break;



            case 5:

                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 55;

                    Console.SetCursorPosition(one, 6);

                    Console.Write("#");

                }



                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 55;

                    Console.SetCursorPosition(one, 8);

                    Console.Write("#");

                }



                for (int i = 0; i < 5; i = i + 1)
                {

                    int one = i + 55;

                    Console.SetCursorPosition(one, 10);

                    Console.Write("#");

                }

                Console.SetCursorPosition(55, 7);

                Console.Write("#");

                Console.SetCursorPosition(59, 9);

                Console.Write("#");



                break;

        }



    }



    public static void Main()
    {

        int x = 45;

        int y = 10;

        int xSpeed = 1;

        int ySpeed = 1;

        bool gamestillrunning = true;





        int higherY = 6;

        int middleHigherY = 7;

        int middleY = 8;

        int middleLowerY = 9;

        int lowerY = 10;

        int ydirection1 = 0;



        int higherY2 = 6;

        int middleHigherY2 = 7;

        int middleY2 = 8;

        int middleLowerY2 = 9;

        int lowerY2 = 10;

        int ydirection2 = 0;



        int score1 = 0;

        int score2 = 0;

        int speed = 200;
        string playersstring;


        int speedtimer = 100;

        Console.Clear();

        Console.WriteLine("How many Players, 1 or 2?");
        playersstring = Console.ReadLine();
        Console.Clear();






        while (gamestillrunning)
        {




            for (int i = 0; i < 19; i = i + 1)
            {

                int newy = i + 3;

                Console.SetCursorPosition(36, newy);

                Console.Write(":");

            }

            if (playersstring == "1")
            {
                if ((ySpeed == -1) && (x < 30))
                {
                    ydirection1 = -1;
                }
                if (ySpeed == 1)
                {
                    ydirection1 = 1;
                }
            }



            Console.SetCursorPosition(30, 0);

            Console.Write("Pong - By Joe Buckton" + x);



            if ((speedtimer == 0) && (speed > 50))
            {



                speed = speed - 40;

                speedtimer = speedtimer + 100;

            }



            Console.SetCursorPosition(0, 0);

            Console.Write("Score: " + score1 + " - " + score2);

            Console.SetCursorPosition(x, y);

            Console.Write(" ");

            x = x + xSpeed;

            y = y + ySpeed;



            Console.SetCursorPosition(3, higherY);

            Console.Write(" ");

            Console.SetCursorPosition(3, middleHigherY);

            Console.Write(" ");

            Console.SetCursorPosition(3, middleY);

            Console.Write(" ");

            Console.SetCursorPosition(3, middleLowerY);

            Console.Write(" ");

            Console.SetCursorPosition(3, lowerY);

            Console.Write(" ");



            Console.SetCursorPosition(75, higherY2);

            Console.Write(" ");

            Console.SetCursorPosition(75, middleHigherY2);

            Console.Write(" ");

            Console.SetCursorPosition(75, middleY2);

            Console.Write(" ");

            Console.SetCursorPosition(75, middleLowerY2);

            Console.Write(" ");

            Console.SetCursorPosition(75, lowerY2);

            Console.Write(" ");



            if (Console.KeyAvailable)
            {

                ConsoleKeyInfo keyInfo =

                Console.ReadKey(true);

                switch (keyInfo.Key)
                {

                    case ConsoleKey.Escape:

                        gamestillrunning = false;

                        break;

                    case ConsoleKey.Q:

                        if (playersstring == "2")
                        {
                            if (ydirection1 == 1)
                            {

                                ydirection1 = ydirection1 - 2;

                                break;

                            }

                            if (ydirection1 == -1)
                            {

                                break;

                            }

                            ydirection1 = ydirection1 - 1;
                        }

                        break;

                    case ConsoleKey.Z:

                        if (playersstring == "2")
                        {
                            if (ydirection1 == -1)
                            {

                                ydirection1 = ydirection1 + 2;

                                break;

                            }

                            if (ydirection1 == +1)
                            {

                                break;

                            }

                            ydirection1 = ydirection1 + 1;
                        }

                        break;

                    case ConsoleKey.UpArrow:

                        if (ydirection2 == 1)
                        {

                            ydirection2 = ydirection2 - 2;

                            break;

                        }

                        if (ydirection2 == -1)
                        {

                            break;

                        }

                        ydirection2 = ydirection2 - 1;

                        break;

                    case ConsoleKey.DownArrow:

                        if (ydirection2 == -1)
                        {

                            ydirection2 = ydirection2 + 2;

                            break;

                        }

                        if (ydirection2 == +1)
                        {

                            break;

                        }

                        ydirection2 = ydirection2 + 1;

                        break;



                        for (int i = 0; i < 5; i = i + 1)
                        {

                            int one = i + 15;

                            Console.SetCursorPosition(one, 6);

                            Console.Write("#");

                        }



                        for (int i = 0; i < 5; i = i + 1)
                        {

                            int one = i + 15;

                            Console.SetCursorPosition(one, 8);

                            Console.Write("#");

                        }



                        for (int i = 0; i < 5; i = i + 1)
                        {

                            int one = i + 15;

                            Console.SetCursorPosition(one, 10);

                            Console.Write("#");

                        }

                        Console.SetCursorPosition(19, 7);

                        Console.Write("#");

                        Console.SetCursorPosition(15, 9);

                        Console.Write("#");



                        break;

                }

            }

            higherY = higherY + ydirection1;

            higherY2 = higherY2 + ydirection2;



            middleHigherY = higherY + 1;

            middleY = higherY + 2;

            middleLowerY = higherY + 3;

            lowerY = higherY + 4;



            middleHigherY2 = higherY2 + 1;

            middleY2 = higherY2 + 2;

            middleLowerY2 = higherY2 + 3;

            lowerY2 = higherY2 + 4;



            Console.SetCursorPosition(x, y);

            Console.Write("*");



            Console.SetCursorPosition(3, higherY);

            Console.Write("|");

            Console.SetCursorPosition(3, middleHigherY);

            Console.Write("|");

            Console.SetCursorPosition(3, middleY);

            Console.Write("|");

            Console.SetCursorPosition(3, middleLowerY);

            Console.Write("|");

            Console.SetCursorPosition(3, lowerY);

            Console.Write("|");



            Console.SetCursorPosition(75, higherY2);

            Console.Write("|");

            Console.SetCursorPosition(75, middleHigherY2);

            Console.Write("|");

            Console.SetCursorPosition(75, middleY2);

            Console.Write("|");

            Console.SetCursorPosition(75, middleLowerY2);

            Console.Write("|");

            Console.SetCursorPosition(75, lowerY2);

            Console.Write("|");





            if (x == 2)
            {

                Console.Clear();

                score2 = score2 + 1;

                number1(score1);

                number2(score2);

                Console.SetCursorPosition(x, y);

                Console.Write(" ");

                x = 45;

                y = 12;
                speed = 200;

                Console.SetCursorPosition(30, 12);

                Console.Write("GOOOAAAAAL!");

                System.Threading.Thread.Sleep(5000);

                Console.SetCursorPosition(35, 12);

                Console.Clear();



            }





            if (x == 77)
            {

                Console.Clear();

                score1 = score1 + 1;

                number1(score1);

                number2(score2);

                Console.SetCursorPosition(x, y);

                Console.Write(" ");

                x = 45;

                y = 12;
                speed = 200;

                Console.SetCursorPosition(30, 12);

                Console.Write("GOOOAAAAAL!");

                System.Threading.Thread.Sleep(2000);

                Console.SetCursorPosition(35, 12);

                Console.Clear();



            }



            if ((y == 22) || (y == 3))
            {

                ySpeed = ySpeed * -1;

            }

            if (higherY == 2)
            {

                higherY = higherY + 1;

                Console.SetCursorPosition(3, 2);

                Console.Write(" ");

                Console.SetCursorPosition(3, 7);

                Console.Write("|");

            }



            if (lowerY == 23)
            {

                higherY = higherY - 1;

                Console.SetCursorPosition(3, 23);

                Console.Write(" ");

                Console.SetCursorPosition(3, 18);

                Console.Write("|");

            }



            if (higherY2 == 2)
            {

                higherY2 = higherY2 + 1;

                Console.SetCursorPosition(75, 2);

                Console.Write(" ");

                Console.SetCursorPosition(75, 7);

                Console.Write("|");

            }



            if (lowerY2 == 23)
            {

                higherY2 = higherY2 - 1;

                Console.SetCursorPosition(75, 23);

                Console.Write(" ");

                Console.SetCursorPosition(75, 18);

                Console.Write("|");

            }

            if (x == 3)
            {





                if (y == middleY)
                {

                    xSpeed = xSpeed * -1;

                }



                if ((y == lowerY) || (y == middleLowerY))
                {

                    ySpeed = 1;

                    xSpeed = xSpeed * -1;

                }



                if ((y == middleHigherY) || (y == higherY))
                {

                    ySpeed = -1;

                    xSpeed = xSpeed * -1;

                }

            }



            if (x == 75)
            {



                if (y == middleY2)
                {

                    xSpeed = xSpeed * -1;

                }



                if ((y == lowerY2) || (y == middleLowerY2))
                {

                    ySpeed = 1;

                    xSpeed = xSpeed * -1;

                }



                if ((y == middleHigherY2) || (y == higherY2))
                {

                    ySpeed = -1;

                    xSpeed = xSpeed * -1;

                }



            }



            if (score1 == 5)
            {

                Console.Clear();

                gamestillrunning = false;

                winner(1);

            }

            if (score2 == 5)
            {



                Console.Clear();

                gamestillrunning = false;

                winner(2);

            }



            System.Threading.Thread.Sleep(speed);

        }

    }



}