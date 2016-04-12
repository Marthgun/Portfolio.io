using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollGame
{
    class Program
    {
        static void Main(string[] args)
        {
            intro();
            monies.moneytotal = monies.moneytotal = 100;
            string again = ""; // play again
            do {

                betting();
                userRoll();
                compRoll();
                calculateRoll();
                Console.Write("Would you like to play again?\n{Yes | No}\n>");
                again = Console.ReadLine();
                again = again.ToLower();
            } while (again.Equals("yes"));

            Console.ReadKey();

        }
        public static void intro()
        {
            string play = "";
            Console.Write("Welcome to Dice Roll.\n" +
                "A game where you roll the dice to win monies.\n\n");
            Console.Write("Would you like to play?\n{Yes | No}\n>");
            play = Console.ReadLine();
            play = play.ToLower();
            if (play.Equals("yes") || play.Equals("y"))
                Console.WriteLine("You get 100 free monies on the house.");
            else
                System.Environment.Exit(0);

            //userRoll();
            //compRoll();
            

            Console.ReadKey();


            

        }       
        static void userRoll()
        {
            string ans1 = "";
            int x = 1; // die min
            int y = 6; // die max
            int die1 = randomGen(x, y);
            int die2 = randomGen(x, y);
            Console.Write("Type {roll} to cast the die.\n>");
            ans1 = Console.ReadLine();
            ans1 = ans1.ToLower();
            if (ans1.Equals("roll"))
            {
                Console.WriteLine("You rolled: " + die1);
                Console.WriteLine("You rolled: " + die2);
                Console.WriteLine("Your total: " + (die1 + die2));
                dice.userDie = die1 + die2;
            }
        }
        static void compRoll()
        {
            int x = 1; //die min
            int y = 6; //die max
            int die3 = randomGen(x, y);
            int die4 = randomGen(x, y);
            Console.WriteLine("Computer rolled: " + die3);
            Console.WriteLine("Computer rolled: " + die4);
            Console.WriteLine("Computer total: " + (die3 + die4));
            dice.compDie = die3 + die4;

        }
        static void betting()
        {
            string ans1 = ""; // answer 1st question
            Boolean loop = true;
            
        
            do
            {
                Console.Write("Would you like to place a bet?\n{Yes | No}\n>");
                ans1 = Console.ReadLine();
                ans1 = ans1.ToLower();
                if (ans1.Equals("yes"))
                {
                    Console.Write("How much would you like to bet?\n" + "(1 - " +
                        monies.moneytotal + ")\n>");
                    monies.betamount = int.Parse(Console.ReadLine());
                    if (monies.betamount > monies.moneytotal)
                    {
                        Console.WriteLine("Enter a number that does not exceed your wallet.");
                        loop = false;
                    }

                   else if (monies.betamount <= 0)
                    {
                        Console.WriteLine("Enter a number that is not less than your current wallet.");
                        loop = false;
                    }
                    else if (monies.betamount > 0 && monies.betamount <= monies.moneytotal)
                        loop = true;

                }
                else
                    loop = true;
            } while (!loop);
            

            monies.moneytotal = monies.moneytotal - monies.betamount;
            Console.WriteLine("Your current wallet balance is: " + monies.moneytotal);


        }
        static void calculateRoll()
        {
            int usertotal = dice.userDie;
            int comptotal = dice.compDie;
            int refund = monies.betamount;
            if (usertotal.Equals(comptotal))
            {
                Console.WriteLine("It's a tie; roll again.");
                monies.moneytotal = monies.moneytotal + refund;
            }
            if (usertotal > comptotal)
            {
                Console.WriteLine("You win!");
                monies.moneytotal = monies.moneytotal + (monies.betamount * 2);
            }
            if (usertotal < comptotal)
            {
                Console.WriteLine("You lose...");
            }
            if (monies.moneytotal.Equals(0))
            {
                Console.WriteLine("You are bankrupt...Game Over Son.");
                Console.ReadKey();
                System.Environment.Exit(0);

            }
            if (monies.moneytotal > 500)
                Console.WriteLine("Congratulations you've reached Silver Status.");
            if (monies.moneytotal > 1000)
                Console.WriteLine("Congratulations you've reached Gold Status. ");
        }
        private static readonly Random getrandom = new Random();
        private static readonly object synclock = new object();     
           
        public static int randomGen(int minrange, int maxrange)
        {
            lock(synclock)
            {
                return getrandom.Next(minrange, maxrange);
            }

        }
        public static class monies
        {
            public static int moneytotal;
            public static int betamount;
        }
        public static class dice
        {
            public static int userDie;
            public static int compDie;
        }
    }
}
