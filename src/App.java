import helpers.ConsoleColours;
import helpers.InputReader;
import java.util.HashMap;
import java.util.Map;

public class App {

    static Map<String, String[]> songDetails = new HashMap<>();
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
                    AddNewSong();
                    ValidInput = true;
                    
                    break;
                case "2":
                    System.out.println("");
                    RemoveSong();
                    System.out.println("");
                    ValidInput = true;
                    
                    break;
                case "3":
                    displayAllSongs();
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

    public static void AddNewSong() 
    {
        /// method to add a new song to the list
        System.out.println("");
        System.out.println("Enter the details of the song:");
        System.out.println("");
        String title = InputReader.getString("Title: ");
        String artist = InputReader.getString("Artist: ");

        String playCount;
        while (true) 
        {
            playCount = InputReader.getString("Play Count: ");
            
            if (playCount.matches("\\d+")) 
            {
                break;
            } 

            else 
            {
                /// error message if the play count is not a number
                System.out.println(ConsoleColours.ANSI_YELLOW);
                System.out.println("Please enter a valid number for Play Count.");
                System.out.println(ConsoleColours.ANSI_CYAN);
            }
        }

        String yearReleased;
        while (true) 
        {
            yearReleased = InputReader.getString("Year Released: ");
            if (yearReleased.matches("\\d{4}")) 
            {
                break;
            } 

            else 
            {
                /// error message if the year is not 4 digits
                System.out.println(ConsoleColours.ANSI_YELLOW);
                System.out.println("Please enter a valid 4-digit year for Year Released.");
                System.out.println(ConsoleColours.ANSI_CYAN);
            }
        }
        
        String[] details = {title, artist, playCount, yearReleased};
        songDetails.put(title, details);

        /// confirmation when the song is added
        System.out.println("");
        System.out.println(ConsoleColours.ANSI_GREEN);
        System.out.println("Song added successfully.");
        System.out.println(ConsoleColours.ANSI_CYAN);
        System.out.println("");
        Options();
    }

    public static void displayAllSongs() 
    {
        /// method to display all songs in the list
        System.out.println("");
        if (songDetails.isEmpty()) 
        {
            /// display error message if the list is empty
            System.out.println(ConsoleColours.ANSI_YELLOW);
            System.out.println("No songs added yet.");
            System.out.println(ConsoleColours.ANSI_CYAN);
            System.out.println("");
            Options();
        } 
        else 
        {
            /// display all songs in the list as a table
            System.out.println("List of all songs:");
            System.out.println("");
            System.out.println("-----------------------------------------------------------------------------------");
            System.out.printf("\u001B[36m|\u001B[40m \u001B[31m%-20s\u001B[40m \u001B[36m|\u001B[40m \u001B[31m%-20s\u001B[40m \u001B[36m|\u001B[40m \u001B[31m%-15s\u001B[40m \u001B[36m|\u001B[40m \u001B[31m%-15s\u001B[40m \u001B[36m|\u001B[40m\n", "Title", "Artist", "Play Count", "Year Released");
            
            for (String key : songDetails.keySet()) {
                String[] details = songDetails.get(key);
                System.out.println(ConsoleColours.ANSI_CYAN + "-----------------------------------------------------------------------------------");
                System.out.printf("| \u001B[36m%-20s\u001B[40m | \u001B[36m%-20s\u001B[40m | \u001B[36m%-15s\u001B[40m | \u001B[36m%-15s\u001B[40m |\n", details[0], details[1], details[2], details[3]);
            }
            System.out.println("-----------------------------------------------------------------------------------");
        }
        System.out.println("");
        Options();
    }

    public static void RemoveSong() 
    {
        /// method to remove a song from the list
        System.out.println("");
        if (songDetails.isEmpty()) 
        {
            /// display error message if the list is empty
            System.out.println(ConsoleColours.ANSI_YELLOW);
            System.out.println("No songs added yet.");
            System.out.println(ConsoleColours.ANSI_CYAN);
            System.out.println("");
            Options();
        } 
        else 
        {
            String title = InputReader.getString("Enter the title of the song you want to remove: ");
            if (songDetails.containsKey(title)) 
            {
                /// confirmation when the song is removed
                songDetails.remove(title);
                System.out.println("");
                System.out.println(ConsoleColours.ANSI_GREEN);
                System.out.println("Song removed successfully.");
                System.out.println(ConsoleColours.ANSI_CYAN);
                System.out.println("");
            } 
            else 
            {
                /// error message if the song is not in the list
                System.out.println("");
                System.out.println(ConsoleColours.ANSI_YELLOW);
                System.out.println("Song not found in the list. Please check the title and try again.");
                System.out.println(ConsoleColours.ANSI_CYAN);
                System.out.println("");
            }
            Options();
        }
    }

}
