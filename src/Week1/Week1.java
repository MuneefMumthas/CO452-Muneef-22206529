package Week1;
import helpers.*;
import java.util.Scanner;

public class Week1 
{
    public static void main(String[] args)
    {
        Scanner scanner = new Scanner(System.in);

        do {
            System.out.println(ConsoleColours.CONSOLE_CLEAR);

            System.out.println("==================================");
            System.out.println("CO452 Programming Concepts 2023/24");
            System.out.println("==================================");
            System.out.println();
            System.out.println("  Week 1 Java Basic Input/Output ");
            System.out.println();
            System.out.println(" by Nicholas Day and Derek Peacock");
            System.out.println();

            String name = InputReader.getString("Enter your name > ");
            System.out.println("Hello " + name);

            System.out.println("Type 'close' to exit or any other key to restart.");
        } while (!scanner.nextLine().equalsIgnoreCase("close"));

        scanner.close();
    } 
}
