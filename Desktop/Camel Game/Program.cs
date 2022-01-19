using System;

namespace Camel_Game
{
    class Program
    {
        static void Main(string[] args)
        {

            // Introduction
            Console.WriteLine("Welcome to Camel!");
            Console.WriteLine("You have stolen a camel to make your way across the great Mobi desert.");
            Console.WriteLine("The natives want their camel back and are chasing you down!");
            Console.WriteLine("Survive your desert trek and out run the natives.");

            // variables
            int milesTraveled = 0;
            int thirst = 0;
            int camelFatigue = 0;
            int nativesTraveled = -20;
            int canteen = 3;
            int oasis = 0;

            // Main game Loop
            bool done = false;
            while (!done)
            {
                // variables using random
                Random rnd = new Random();
                int nativesBehind = milesTraveled - nativesTraveled;
                int fullspeed = rnd.Next(10, 21);
                int moderateSpeed = rnd.Next(5, 13);

                // Print Commands
                Console.WriteLine();
                Console.WriteLine("A. Drink from your canteen.");
                Console.WriteLine("B. Ahead moderate speed.");
                Console.WriteLine("C. Ahead full speed.");
                Console.WriteLine("D. Stop and rest.");
                Console.WriteLine("E. Status check.");
                Console.WriteLine("Q. Quit.");

                // User command
                Console.Write("What is your command? ");
                string userCommand = Console.ReadLine();
                Console.WriteLine();

                // Process user command

                // If the user chooses a and wants to drink from the canteen
                if (userCommand == "a")
                {
                    if (canteen == 0)
                    {
                        Console.WriteLine("You're out of water.");
                    }
                    else
                    {
                        canteen -= 1;
                        thirst *= 0;
                        Console.WriteLine("You drank from the canteen.");
                        Console.WriteLine("You have " + canteen + " drinks left and you are no longer thirsty.");
                    }
                }
                // If the user chooses b and goes moderate speed
                else if (userCommand == "b")
                {
                    Console.WriteLine("You went ahead at moderate speed.");
                    Console.WriteLine("You traveled " + moderateSpeed + " miles!");
                    milesTraveled += moderateSpeed;
                    thirst += 1;
                    camelFatigue += 1;
                    nativesTraveled += rnd.Next(7, 15);
                    oasis = rnd.Next(1, 21);
                }
                // if the user chooses c and wants to go ahead at full speed
                else if (userCommand == "c")
                {
                    Console.WriteLine("You went ahead at full speed.");
                    Console.WriteLine("You traveled " + fullspeed + " miles!");
                    milesTraveled += fullspeed;
                    thirst += 1;
                    camelFatigue += rnd.Next(1, 4);
                    nativesTraveled += rnd.Next(7, 15);
                    oasis = rnd.Next(1, 21);

                }
                // if the user chooses d and wants to stop and rest
                else if (userCommand == "d")
                {
                    Console.WriteLine("You stopped and rested");
                    camelFatigue *= 0;
                    Console.WriteLine("Your camel is refreshed and happy. His fatigue is now " + camelFatigue);
                    nativesTraveled += rnd.Next(1, 21);
                }
                else if (userCommand == "e")
                {
                    Console.WriteLine("Miles Traveled: " + milesTraveled);
                    Console.WriteLine("Drinks in Canteen: " + canteen);
                    Console.WriteLine("Your camel has " + camelFatigue + " amount of fatigue.");
                    Console.WriteLine("The natives are " + nativesBehind + " miles behind you.");
                }
                // If the user wants to quit
                else if (userCommand == "q")
                {
                    done = true;
                }
                // If the user puts any other letter or anyhting else besides the above
                else
                {
                    Console.WriteLine("Unknown command.");
                }
                // If the user finds an oasis
                if (oasis == 20)
                {
                    camelFatigue = 0;
                    thirst = 0;
                    canteen = 3;
                    Console.WriteLine("You found an oasis! After taking a drink you filled your canteen and the camel is refreshed.");
                }
                // When the natives are 15 miles or closer to the user
                if (milesTraveled - nativesTraveled <= 15)
                {
                    Console.WriteLine("The natives are drawing near! Oh no!");
                }
                // When the user crosses the desert
                if (milesTraveled >= 200)
                {
                    Console.WriteLine("You made it across the desert, you win! Yay!");
                    done = true;
                }
                // If the natives caught up to the user
                if (nativesTraveled >= milesTraveled)
                {
                    Console.WriteLine("The natives caught and beheaded you.");
                    Console.WriteLine("You're dead. Game Over. You can restart the game and try again");
                    done = true;
                }
                // if the user is getting thirsty
                if (thirst > 4 && thirst <= 6)
                {
                    Console.WriteLine("You are thirsty");
                }
                // if the user is duper dehydrated, either when the user forgot to drink
                // and/or their canteen ran out
                if (thirst > 6)
                {
                    Console.WriteLine("You died of dehydration!");
                    done = true;
                }
                // if the camel is started to get tired
                if (camelFatigue > 5 && canteen <= 8)
                {
                    Console.WriteLine("Your camel is getting tired.");
                }
                // if the camel got too tired and died
                if (camelFatigue > 8)
                {
                    Console.WriteLine("Your camel is dead.");
                    Console.WriteLine("Due to no longer having a camel, the natives caught up to you!");
                    Console.WriteLine("The natives beheaded you. You are now dead. You can restart the game and try again.");
                    done = true;
                }
            }
        }
    }
}
