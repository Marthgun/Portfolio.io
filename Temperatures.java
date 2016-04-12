/*
*********************
Ryan Gray
Java Programming
CIS-2323
Prof. Branstool
*********************
Write an application that prompts the user for the day's high and low temperatures. 
If the high is greater than or equal to 90 degrees, display the message, "Heat warning."
If the low is less thean 32 degrees, display the message "Freeze warning."  
If the difference between the high and low temperatures is more than 40 degrees, display 
the message, "Large temperature swing." 
 */
package temperatures;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.text.DecimalFormat;
import java.util.Scanner;

/**
 *
 * @author Meow
 */
public class Temperatures {

	/**
	 * @param args the command line arguments
	 */
	public static void main(String[] args) throws IOException {
		do {
			whichDeg();
			intro();
			redo();
		}while (again);
		pressKey();
	}
	private static void whichDeg()
	{ 
		Scanner scan = new Scanner(System.in);
		String fORc = "";
		System.out.print(farenOrCelc);
		fORc = scan.nextLine().toLowerCase();
		if (fORc.equals("c"))
			degree = false;
		else 
			degree = true;
	}
	private static void intro()
	{
		DecimalFormat df = new DecimalFormat("#.0");
		double high, low;
		boolean go = true;
		boolean forth = true;
		Scanner scan = new Scanner(System.in);

		do {
		System.out.print(enterTemp);
		System.out.print(highTemp);
		high = stringMachine();
		if (high == 666)
			go = false;
		else
			go = true;
		System.out.print(lowTemp);
		low = stringMachine();
		if (low == 666)
			forth = false;
		else
			forth = true;
		}while (high < low || (go == false || forth == false));
		System.out.print(todayHigh + df.format(high) + todayLow + df.format(low) + "\n");
		warnings(high, low, degree);
		String dType = (degree) ? "Celcius" : "Farenheit";
		System.out.print(uConvert + dType + "?\n>");
		String conStr = scan.nextLine().toLowerCase();
		if (conStr.equals("yes") || conStr.equals("y"))
		{
			high = convertTemp(high, degree);
			low = convertTemp(low, degree);
			System.out.print(todayHigh + df.format(high) + todayLow + df.format(low) + "\n");
			if (dType.equals("Celcius"))
				degree = false;
			if (dType.equals("Farenheit"))
				degree = true;
			warnings(high, low, degree);
		}
	}
	private static double stringMachine()
	{
		double temp = 0;
		Scanner scan = new Scanner(System.in);
		String input =  scan.nextLine();
		boolean b = isNum(input);
		if (b == true)
			return temp = Double.parseDouble(input);
		else
			return temp = 666;
	}
	private static void warnings(double highT, double lowT, boolean deg)
	{
		if (deg && highT >= fHeat)
			System.out.println(fHeatWarn);
		if (deg && lowT <= fCold)
			System.out.println(fColdWarn);
		if (!deg && highT >= cHeat)
			System.out.println(cHeatWarn);
		if (!deg && lowT <= cCold)
			System.out.println(cColdWarn);
		if (deg && (highT-lowT) >= fSpread)
			System.out.println(tempSwing);
		if (!deg && (highT-lowT) >= cSpread)
			System.out.println(tempSwing);
	}
	private static boolean isNum(String str)
	{
		int test = 0;
		boolean bl = true;
		if (str.isEmpty())
			return bl = false;
		for (int i = 0; i < str.length(); i++ )
		{
			if (i == 0 && str.charAt(i) == '-') 
			{
				if (str.length() == 1 )
					return bl = false;
				else 
					continue;
			}
			for (int x = 0; x < iArr.length; x++)
			{
				if (str.charAt(i) == iArr[x])
					test += 1;
			}
		}
		if (test != str.length())
			return bl = false;
		else
			return bl = true;
	}
	private static double convertTemp(double temp,  boolean type)
	{
		if (!type)
			return ((9.0 / 5.0) * temp) + 32.0;
		else
			return (5.0 / 9.0) * (temp - 32);
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
	private static void pressKey() throws IOException
	{
		BufferedReader br = new BufferedReader( new InputStreamReader(System.in));
		System.out.println(pressKeyExit);
		br.readLine();
	}
	private static boolean again;
	private static boolean degree;
	private static final String farenOrCelc = "Would you like to enter the temperature in Farenheit or Celcius degrees?\n" +
			"Type {F} for Farenheit or {C} for Celcius; enter without brackets.\n>";
	private static final String enterTemp = "\nPlease enter the high and low temperatures for the current day.";
	private static final String highTemp = "\nHigh: \n>";
	private static final String lowTemp = "Low: \n>";
	private static final String todayHigh = "\nToday's high is: ";
	private static final String todayLow = "\nToday's low is: ";
	private static final String uConvert = "\nWould you like to convert your temperature to ";
	private static final String fHeatWarn = "\nHeat Warning:  Temperatures will reach above 90 degrees!";
	private static final String cHeatWarn = "\nHeat Warning:  Temperatures will reach above 32.3 degrees!";
	private static final String fColdWarn = "\nFreeze Warning:  Temperatures will drop below 32 degrees!";
	private static final String cColdWarn = "\nFreeze Warning:  Temperatures will drop below 0!";
	private static final String tempSwing = "\nLarge Temperature Swing Warning:  Temps will drastically vary, be prepared!";
	private static final String doOver = "\nWould you like to start over?\nType {Yes} or {No} without brackets:\n>";
	private static final String pressKeyExit = "Press any key to exit...";
	private static final double fHeat = 90;
	private static final double cHeat = 32.3;
	private static final double fCold = 32;
	private static final double cCold = 0;
	private static final double fSpread = 40;
	private static final double cSpread = 4.5;
	private static char[] iArr = new char[]{'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.'};
	
}
