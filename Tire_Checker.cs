/**
Written by:
Ryan Gray
For the sole use of:
OSU-OKC 
C# Programming Class
CIS-2023
Instructor:  Paul Clark
Unless Consent is Granted by one of the parties mentioned above.
*/

/*
** Note that commented code left in is for testing purposes
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Tire_Checker
{
    class Program
    {
      
        static void Main(string[] args)
        {
            string input1 = "";
            string ans1 = "";
            int fl = 0; // front left tire
            int fr = 0; // front right
            int rl = 0; // rear left
            int rr = 0; // rear right
            

            Console.WriteLine("Welcome to Tire Checker!");
            Console.Write("Would you like a brief explanation of terms?\n{Yes | No}\n>");
            ans1 = Console.ReadLine();
            ans1 = ans1.ToLower();
            if (ans1.Equals("yes") || ans1.Equals("y"))
                Console.Write("After this brief introduction you will be asked to input the psi of " +
                    "each of your tires.\n" + "The acceptable psi limits are between 25psi and 35psi." + 
                    "\nAny tire above or below these limits will result in an error message." + 
                    "\nAside from the psi limits, there is another error message that will be given if, " + 
                    "of the four tires, \nthere is a difference of 5 or more psi between them, even if any or all " +
                    "tires are within the psi limits." + "\nFor example, tire A has 30 psi, while tire " +
                    "\nB has 25psi.  Both are within the psi limits, however the two tires are more than 5 " +
                    "or more psi apart.  \nMake sure to follow all recommendations listed.\n\n  "); 

            Console.Write("Would you like to input your tire information?\n{Yes | No}\n>");
            input1 = Console.ReadLine();
            input1 = input1.ToLower();
            if (input1.Equals("yes") || input1.Equals("y"))
                Console.Write("Enter the tire pressure of your front left tire (in psi)\n>");
            else
                System.Environment.Exit(0);

            fl = int.Parse(Console.ReadLine());

            Console.Write("Enter the tire pressure of your front right tire (in psi)\n>");
            fr = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the tire pressure of your rear left tire (in psi)\n>");
            rl = int.Parse(Console.ReadLine());
            Console.Write("Enter the tire pressure of your rear right tire (in psi)\n>");
            rr = Convert.ToInt32(Console.ReadLine());


            Console.Write("\nPlease check the error reports below.\n" +
                "\nAlso note that while your tires may be within accpetable limits," +
                " your tire ratio may need to be adjusted for maximal efficiency and safety.\n\n");

           
             Program p = new Program();
             Console.Write("In regards to your front left tire:  ");
             p.checkPressure(fl);
             Console.Write("\nIn regards to your front right tire:  ");
             p.checkPressure(fr);
             Console.Write("\nIn regards to your rear left tire:  ");
             p.checkPressure(rl);
             Console.Write("\nIn regards to your front left tire:  ");
             p.checkPressure(rr);
             p.tireRatio(fl, fr, rl, rr);   
          
           
            if (tireGLOB.goodmargin.Equals(2))
                Console.Write("\nAll four tires pass both criteria for psi margin and ratio." +
                    " No adjustments in air quantity need to be made.");
            
            //Console.WriteLine(tireGLOB.tirecode);
            
                     
            
            Console.ReadKey();
        }
         public static class tireGLOB
        {

            public static int tirecode; // code to check if one or more tires are outside of range
            public static int tirecode2;
            public static int goodmargin; // checks if all tires are in good margin
            
 
        }
        public void checkPressure(int psi)
        {
            
            if (psi < 25)
            {
                Console.WriteLine("Your tire pressure is too low, YOU ARE GOING TO KILL SOMEONE FOOL!");
                tireGLOB.tirecode = tireGLOB.tirecode + 2;
            }
            if (psi > 35)
            {
                Console.WriteLine("Your tire pressure is too high, DEATH IS IMMINENT!");
                tireGLOB.tirecode = tireGLOB.tirecode + 2;
            }
            if (psi >= 25 && psi <= 35)
            {
                Console.WriteLine("This tire is within the DPS standard limits of acceptable use.\n");
                tireGLOB.tirecode2 = tireGLOB.tirecode2 + 1;
            }

            if (tireGLOB.tirecode.Equals(8))
                Console.WriteLine("All four tires are too low and need to be aired to within an acceptable margin.");
            if (tireGLOB.tirecode2.Equals(4))
                Console.WriteLine("All four tires are within acceptable margin.  Make sure to check the ratio between them.\n\n");
            if (tireGLOB.tirecode > 4 && tireGLOB.tirecode < 8)
                Console.WriteLine("One or more tires needs immediate attention." +
                    "  Make sure to use the proper equipment when airing your tire.");
            if (tireGLOB.tirecode2.Equals(4))
                tireGLOB.goodmargin = tireGLOB.goodmargin + 1;
           
            

            
                
        }
      
        public void tireRatio(int fl, int fr, int rl, int rr)
        {
            int rat1 = 0; // ratio1...etc
            int rat2 = 0;
            int rat3 = 0;
            int rat4 = 0;
            int rat5 = 0;
            int rat6 = 0;

            rat1 = Math.Abs(fl - fr);
            rat2 = Math.Abs(fl - rl);
            rat3 = Math.Abs(fl - rr);
            rat4 = Math.Abs(fr - rl);
            rat5 = Math.Abs(fr - rr);
            rat6 = Math.Abs(rl - rr);
            if (rat1 > 4 || rat2 > 4 || rat3 > 4)
                Console.Write("Your tire pressure exceeds the ratio limit that is considered safe.\n" +
                    "\nMake sure your tire pressure does not vary more than 4 psi per tire.\n\n");
            else
               if (rat4 > 4 || rat5 > 4 || rat6 > 4)
                   Console.Write("Your tire pressure exceeds the ratio limit that is considered safe.\n" +
                    "\nMake sure your tire pressure does not vary more than 4 psi per tire.\n\n");

            if (rat1 > 4)
                Console.WriteLine("Check the ratio between your front left and front right tires to expedite the problem.");
            if (rat2 > 4)
                Console.WriteLine("Check the ratio between your front left and rear left tires to expedite the problem.");
            if (rat3 > 4)
                Console.WriteLine("Check the ratio between your front left and rear right tires to expedite the problem.");
            if (rat4 > 4)
                Console.WriteLine("Check the ratio between your front right and rear left tires to expedite the problem.");
            if (rat5 > 4)
                Console.WriteLine("Check the ratio between your front right and rear right tires to expedite the problem.");
            if (rat6 > 4)
                Console.WriteLine("Check the ratio between your rear left and rear right tires to expedite the problem.");


            if (rat1 < 5 && rat2 < 5 && rat3 < 5 && rat4 < 5 && rat5 < 5 && rat6 < 5)
                Console.WriteLine("All tires are within acceptable psi ratio.");
            if (rat1 < 5 && rat2 < 5 && rat3 < 5 && rat4 < 5 && rat5 < 5 && rat6 < 5)
                tireGLOB.goodmargin = tireGLOB.goodmargin + 1;



        }
    }
}
//There is one small flaw in the code I left in for you.
