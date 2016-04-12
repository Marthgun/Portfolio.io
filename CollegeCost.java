/*
*********************
Ryan Gray
Java Programming
CIS-2323
Prof Branstool
*********************
Write an application that prompts a user for a child's current age 
and the estimated college costs for that child at age 18.  Continue to 
reprompt a user who enters an age value greater than 18.  Display 
the amount that the user needs to save each year util the child turns 18,
assuming that no interest is earned on the money.  For this application, 
you can assume that integer division provides a sufficient answer.  
 */
package currentage;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.text.DecimalFormat;
import java.util.Scanner;

/**
 *
 * @author Meow
 */
public class CollegeCost {

	/**
	 * @param args the command line arguments
	 */
	public static void main(String[] args) throws IOException {
		test();
		do {
		intro();
		redo();
		}while (again);
		pressKey(0);
	}
	private static void test()
	{
		String name1 = "Jordan";
		String name2 = "Jore";
		int a = name1.compareTo(name2);
		System.out.println(a);
	}
	private static void intro() throws IOException
	{
		Scanner scan = new Scanner(System.in);
		String usrAge;
		String schType;
		int intType;
		int convertAge;
		System.out.print(askUsrAge);
		usrAge = scan.nextLine();
		convertAge = Integer.parseInt(usrAge);
		System.out.print(schoolType);
		schType = scan.nextLine().toLowerCase();
		intType = typeOfSchool(schType);
		tuitionCalc(convertAge, intType);
	}
	private static int typeOfSchool(String type) throws IOException
	{
		int temp = 0;
		if (type.equals("low"))
		{
			System.out.println(LOWappFee);
			System.out.println(LOWentExamFee);
			System.out.println(LOWtuitionFee);
			System.out.println(LOWbookCost);
			System.out.println(miscCost);
			System.out.print(total + LOWlowTotal + " and " +HIGHlowTotal + ".\n");
			System.out.print(inflation);
			pressKey(1);
			temp = 1;
		}
		if (type.equals("mid"))
		{
			System.out.println(MIDappFee);
			System.out.println(MIDentExamFee);
			System.out.println(MIDtuitionFee);
			System.out.println(MIDbookCost);
			System.out.println(miscCost);
			System.out.print(total + LOWmidTotal + " and " +HIGHmidTotal + ".\n");
			System.out.print(inflation);
			pressKey(1);
			temp = 2;
		}
		if (type.equals("high"))
		{
			System.out.println(HGHappFee);
			System.out.println(HGHentExamFee);
			System.out.println(HGHtuitionFee);
			System.out.println(HGHbookCost);
			System.out.println(miscCost);
			System.out.print(total + LOWhighTotal + " and " +HIGHhighTotal + ".\n");
			System.out.print(inflation);
			pressKey(1);
			temp = 3;
		}
		return temp;
	}
	private static void tuitionCalc(int age, int iType)
	{
		DecimalFormat df = new DecimalFormat("#.00");
		int untilEnroll = (18 - age);
		double[] dArr = new double[untilEnroll];
		double[] dArr2 = new double[untilEnroll];
		double low = 0;
		double high = 0;
		double tempLow = 0;
		double tempHigh = 0;
		if (iType == 0)
			System.out.println("oops");
		if(iType == 1)
		{
			low = LLT;
			high = HLT;
		}
		if (iType == 2)
		{
			low = LMT;
			high = HMT;
		}
		if (iType == 3)
		{
			low = HLT;
			high = HHT;
		}
		System.out.println("There are " + untilEnroll + " years until your child should enroll in college.");
		for (int i  = 0; i < untilEnroll; i++)
		{
			tempLow = low * inflate;
			dArr[i] = low + tempLow;
			tempHigh = high * inflate;
			dArr2[i] = high + tempHigh;
			if (i > 0)
			{
				low = dArr[i];
				high = dArr2[i];
			}
			System.out.println((i + 1) + " Year(s) from now" + " tuition and expenses will be approx between " 
					+ df.format(low) + " and " + df.format(high));
		}
		System.out.print("\n\nIn " + untilEnroll + " year(s), you should expect to pay between "
				+ "$"+df.format(dArr[untilEnroll-1]) + " and " + "$" + df.format(dArr2[untilEnroll-1]) + "\nfor tuition and expenses.\n" );
		System.out.println(keepInMind);
	}
	private static void redo()
	{
		Scanner scan = new Scanner(System.in);
		System.out.print(doOver);
		String yesORno = scan.nextLine().toLowerCase();
		if (yesORno.equals("yes") || yesORno.equals("y"))
			again = true;
		else
			again = false;
	}
	private static void pressKey(int x) throws IOException
	{
		BufferedReader br = new BufferedReader( new InputStreamReader(System.in));
		if (x == 0)
			System.out.println(pressKeyExit);
		else 
			System.out.println(pressKeyContinue);
		br.readLine();
	}
	private static boolean again;
	private static final String pressKeyExit = "Press any key to exit...";
	private static final String pressKeyContinue = "Press any key to continue...";
	private static final String doOver = "\nWould you like to start over?\nType {Yes} or {No} without brackets:\n>";
	private static final String askUsrAge = "\nWhat is the current age of the child?\n"
			+ "If the child is younger than one year, type '0', otherwise enter\n"
			+ "an integer value representing age, i.e. '1', '2', '3', etc.\n>";
	private static final String schoolType = "\nGuesstimate the type of college you intend for your child,"
			+ "\nThere is the low end 2 year college, the State University, \nor the Ivy League.  "
			+ "Keep in mind these are approximations, \nType {low}, {mid}, or {high} without brackets\n>";
	private static final String LOWappFee = "\nApplication fees average approx. $50 per school.";
	private static final String MIDappFee = "\nApplication fees average approx. $65 per school.";
	private static final String HGHappFee = "\nApplication fees average approx. $75 per school.";
	private static final String LOWentExamFee = "Entrance exams cost about $100 per examination.";
	private static final String MIDentExamFee = "Entrance exams cost about $150 per examination.";
	private static final String HGHentExamFee = "Entrance exams cost about $200 per examination.";
	private static final String LOWtuitionFee = "Tuition may cost around $5,000 per academic year (nine months).";
	private static final String MIDtuitionFee = "Tuition may cost around $15,000 per academic year (nine months).";
	private static final String HGHtuitionFee = "Tuition may cost around $30,000 per academic year (nine months).";
	private static final String LOWbookCost = "Materials and books may cost upwards of $500 per academic year.";
	private static final String MIDbookCost = "Materials and books may cost upwards of $750 per academic year.";
	private static final String HGHbookCost = "Materials and books may cost upwards of $1,000 per academic year.";
	private static final String miscCost = "Many other variables are involved, such as travel, food, housing, \n"
			+ "clothing and personal expenses that need to be accounted for \ndepending on type of school and location.";
	private static final String total = "As of this year you could expect to pay between, ";
	private static final String LOWlowTotal = "5,650";
	private static final String HIGHlowTotal = "11,300";
	private static final String LOWmidTotal = "15,915";
	private static final String HIGHmidTotal = "31,830";
	private static final String LOWhighTotal = "31,275";
	private static final String HIGHhighTotal = "62,550";
	private static final String inflation = "We can speculate based on current tuition inflation rates that tuition will increase "
			+ "\nfrom 3% to 7% per year.  Using the average of these two numbers, we can calculate the project "
			+ "\nincrease in tuition from now until your child turns 18, the typical age of enrollment into college.\n\n";
	private static final String keepInMind = "Keep in mind these represent averages based on known inflation\n"
			+ "and these figures do not include expenses mentioned earlier, such as travel, housing, clothing, etc.";
	private static final double LLT = 5650;
	private static final double HLT = 11300;
	private static final double LMT = 15915;
	private static final double HMT = 31830;
	private static final double LHT = 31275;
	private static final double HHT = 62550;
	private static final double inflate = 0.07;
}
