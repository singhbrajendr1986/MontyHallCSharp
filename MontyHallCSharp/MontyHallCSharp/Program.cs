using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool staywork = false, switchwork = false;
            double stays = 0, switches = 0;
            while (staywork == false || switchwork == false)
            {
                Console.WriteLine("How many stays?");
                staywork = double.TryParse(Console.ReadLine(), out stays);
                Console.WriteLine("How many switches?");
                switchwork = double.TryParse(Console.ReadLine(), out switches);
            }
            double loopstay = 0.0, loopswitch = 0.0, staygoat = 0.0, switchgoat = 0.0, staycar = 0.0, switchcar = 0.0, staytries = 0.0, switchtries = 0.0;
            Random rnd = new Random();
            {
                Console.Write("The STAY processing is:\n\n");
                var startTimeSpan = TimeSpan.Zero;
                var periodTimeSpan = TimeSpan.FromSeconds(1);
                var timer = new System.Threading.Timer((e) =>
                {
                    if (stays >= 10000)
                        PercentageTimer(loopstay, stays);
                }, null, startTimeSpan, periodTimeSpan);

                for (; loopstay < stays; loopstay += 1.0)
                {
                    int RevealedGoatDoor = 0;
                    int[] GoatDoor = new int[2];
                    int[,] door = new int[3, 2];
                    for (int x = 0; x < 2; x++)
                        GoatDoor[x] = 0;
                    for (int x = 0; x < 3; x++)
                        door[x, 0] = 1;
                    var i = Util.GetRandom();
                    if (i < 0)
                        i = i * -1;
                    door[(i % 3), 1] = 1;
                    staytries++;
                    i = Util.GetRandom();
                    if (i < 0)
                        i = i * -1;
                    string doorChoice = ((i % 3) + 1).ToString();
                    door[Convert.ToInt32(doorChoice) - 1, 0] = 0;
                    for (int x = 0; x < 3; x++)
                    {
                        if (door[x, 1] == 0)
                        {
                            if (GoatDoor[0] == 0)
                                GoatDoor[0] = x;
                            else
                                GoatDoor[1] = x;
                        }
                    }
                    bool done = false;
                    while (done == false)
                    {
                        i = Util.GetRandom();
                        if (i < 0)
                            i = i * -1;
                        RevealedGoatDoor = (i % 3);
                        if (RevealedGoatDoor != Convert.ToInt32(doorChoice) - 1 & (RevealedGoatDoor == GoatDoor[0] | RevealedGoatDoor == GoatDoor[1]))
                            done = true;
                    }
                    door[RevealedGoatDoor, 0] = 0;
                    if (door[Convert.ToInt32(doorChoice) - 1, 1] == 1)
                    {
                        staycar += 1.0;
                    }
                    else
                    {
                        staygoat += 1.0;
                    }
                }
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                for (int x = 0; x < Console.BufferWidth; x++)
                    Console.Write(" ");
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine("100.00% done");
                timer.Dispose();
            }
            {
                Console.Write("The SWITCH processing is:\n\n");
                var startTimeSpan = TimeSpan.Zero;
                var periodTimeSpan = TimeSpan.FromSeconds(1);
                var timer = new System.Threading.Timer((e) =>
                {
                    if (switches >= 10000)
                        PercentageTimer(loopswitch, switches);
                }, null, startTimeSpan, periodTimeSpan);
                for (; loopswitch < switches; loopswitch += 1.0)
                {
                    int RevealedGoatDoor = 0;
                    int[] GoatDoor = new int[2];
                    int[,] door = new int[3, 2];
                    for (int x = 0; x < 2; x++)
                        GoatDoor[x] = 0;
                    for (int x = 0; x < 3; x++)
                        door[x, 0] = 1;
                    var i = Util.GetRandom();
                    if (i < 0)
                        i = i * -1;
                    door[(i % 3), 1] = 1;
                    switchtries++;
                    i = Util.GetRandom();
                    if (i < 0)
                        i = i * -1;
                    string doorChoice = ((i % 3) + 1).ToString();
                    door[Convert.ToInt32(doorChoice) - 1, 0] = 0;
                    for (int x = 0; x < 3; x++)
                    {
                        if (door[x, 1] == 0)
                        {
                            if (GoatDoor[0] == 0)
                                GoatDoor[0] = x;
                            else
                                GoatDoor[1] = x;
                        }
                    }
                    bool done = false;
                    while (done == false)
                    {
                        i = Util.GetRandom();
                        if (i < 0)
                            i = i * -1;
                        RevealedGoatDoor = (i % 3);
                        if (RevealedGoatDoor != Convert.ToInt32(doorChoice) - 1 & (RevealedGoatDoor == GoatDoor[0] | RevealedGoatDoor == GoatDoor[1]))
                            done = true;
                    }
                    door[RevealedGoatDoor, 0] = 0;
                    for (int x = 0; x < 3; x++)
                    {
                        if (door[x, 0] == 1)
                        {
                            if (door[x, 1] == 1)
                            {
                                switchcar += 1.0;
                            }
                            else
                            {
                                switchgoat += 1.0;
                            }
                        }
                    }
                }
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                for (int x = 0; x < Console.BufferWidth; x++)
                    Console.Write(" ");
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine("100.00% done");
                timer.Dispose();
            }
            Console.WriteLine("You played " + (staytries + switchtries) + " times. You won " + (staycar + switchcar) + " cars and " + (staygoat + switchgoat) + " goats\nThis means that you got a car " + ((staycar + switchcar) / (staytries + switchtries)) * 100.0 + "% of the time in total");
            Console.WriteLine("Out of " + staytries + " stayings your percentage winrate for a car was " + (staycar / staytries) * 100.0 + "%");
            Console.WriteLine("Out of " + switchtries + " switchings your percentage winrate for a car was " + (switchcar / switchtries) * 100.0 + "%");
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        static void PercentageTimer(double loopcurrent, double looptotal)
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            for (int x = 0; x < Console.BufferWidth; x++)
                Console.Write(" ");
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine(loopcurrent / looptotal * 100.0 + "% done");
        }
    }

    public static class Util
    {
        public static int GetRandom()
        {
            return Guid.NewGuid().GetHashCode();
        }
    }
}

