/*
Ryan Gray
Java Programming
CIS-2323
Prof. Branstool

 */
package address;
import java.util.Scanner;
/**
 *
 * @author Meow
 */
public class Address {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        String name = "Test";
        int address_num = 201;
        String address_name = "JamesTown Ct.";
        String city_st = "Edmond, Ok";
        int zip = 73034;
       String yes = "yes";
       //String no = "no";
       
       int retry = 0;
       
        do {
        System.out.println("Would you like to view my information?");
        Scanner input = new Scanner(System.in);
        String nsa = input.nextLine().toLowerCase();
        
        if (nsa.equals(yes)) 
        {
            System.out.println(name);
            System.out.println(address_num + " " +  address_name);
            System.out.println(city_st + " " + zip);
        }
        else
        {
            System.out.println("Are you sure you want to exit?");
            
            String ru_sure = input.nextLine().toLowerCase();
            if (ru_sure.equals(yes))
                System.exit(0);
            else
                retry = 1;
                
        }   
            
        } while(retry == 1);
        
       
        
        
        
    }
    
}
