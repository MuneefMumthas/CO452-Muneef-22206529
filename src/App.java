import helpers.ConsoleColours;
import helpers.InputReader;

public class App {
    public static void main(String[] args) throws Exception 
    {
        
            System.out.println(ConsoleColours.ANSI_BG_BLACK);
            System.out.println(ConsoleColours.CONSOLE_CLEAR);
            System.out.println(ConsoleColours.ANSI_RED);
            System.out.println("====================================");
            System.out.println("CO452 Programming Concepts 2023/2024");
            System.out.println("         by Muneef Mumthas          ");
            System.out.println("====================================");
            System.out.println(ConsoleColours.ANSI_CYAN);
            System.out.println();
            System.out.println();

            Options();
    }
    public static void Options()
    {
        /// Do While loop to keep asking for an option until a valid one is chosen
        boolean ValidInput = false;
        while (!ValidInput) 
        {
            /// Prompts to choose an option
            System.out.println("1. Add a new song to the list of songs");
            System.out.println("2. Remove a song from the list of songs");
            System.out.println("3. Print a list of all the songs stored");
            System.out.println("4. Print a list of songs over a given number of plays");
            System.out.println("5. Quit");
            System.out.println("");
            String input = InputReader.getString("Enter your choice > ");

            /// Switch statement to choose and run an option
            switch (input) 
            {
                case "1":
                    System.out.println("");
                    System.out.println("option 1 selected");
                    System.out.println("");
                    ValidInput = true;
                    
                    break;
                case "2":
                    System.out.println("");
                    System.out.println("option 2 selected");
                    System.out.println("");
                    ValidInput = true;
                    
                    break;
                case "3":
                    System.out.println("");
                    System.out.println("option 3 selected");
                    System.out.println("");
                    ValidInput = true;
                    
                    break;
                case "4":
                    System.out.println("");
                    System.out.println("option 4 selected");
                    System.out.println("");
                    ValidInput = true;
                    
                    break;
                case "5":
                    System.out.println("");
                    System.out.println(ConsoleColours.ANSI_YELLOW);
                    System.out.println("Application Closed");
                    System.out.println(ConsoleColours.ANSI_CYAN);
                    System.out.println("");
                    System.exit(0);
                default:
                    System.out.println("");
                    System.out.println(ConsoleColours.ANSI_YELLOW);
                    System.out.println("Invalid input. Please try again.");
                    System.out.println(ConsoleColours.ANSI_CYAN);
                    System.out.println("");
            }
        }
    }
}
