import helpers.ConsoleColours;
import helpers.InputReader;
import java.util.HashMap;
import java.util.Map;

/*This program is designed to emulate the main features of a music streaming 
service such as Spotify or Apple Music. Developed by Muneef Mumthas (22206529)

Functions Overview:
- Options(): Handles user interaction and option selection.
- AddNewSong(): Adds a new song to the list of songs, with details such as title, artist, play count, and year released.
- displayAllSongs(): Displays all songs in the list in a tabular format.
- RemoveSong(): Removes a specific song from the list based on user input.
- DisplaySongsOverPlayCount(): Displays songs with play counts exceeding a specified threshold.
 */

public class App 
{

    static Map<String, String[]> songDetails = new HashMap<>();

    public static void main(String[] args) throws Exception 
    {

        System.out.println(ConsoleColours.ANSI_BG_BLACK);
        System.out.println(ConsoleColours.CONSOLE_CLEAR);
        System.out.println(ConsoleColours.ANSI_RED);
        System.out.println("======================================");
        System.out.println(" CO452 Programming Concepts 2023/2024 ");
        System.out.println("              Music App               ");
        System.out.println("     by Muneef Mumthas - 22206529     ");
        System.out.println("======================================");
        System.out.println(ConsoleColours.ANSI_CYAN);
        System.out.println();
        System.out.println();

        /// default list of song data by Muneef Mumthas
        String[] song1 = {"Creepin", "Weeknd & 21 Savage", "1026635895", "2022"};
        String[] song2 = {"Heat Waves", "Glass Animals", "2699455058", "2020"};
        String[] song3 = {"Holiday", "KSI", "162871627", "2021"};
        String[] song4 = {"IDGAF", "Drake (feat. Yeat)", "85805327", "2023"};
        String[] song5 = {"Jimmy Cooks", "Drake & 21 Savage", "738814390", "2022"};
        String[] song6 = {"Noticed", "Lil Mosey", "689950012", "2018"};
        String[] song7 = {"Ordinary Person", "Anirudh", "3120000", "2023"};
        String[] song8 = {"Pepas", "Farruko", "1373325589", "2021"};
        String[] song9 = {"The Box", "Roddy Rich", "1723410235", "2019"};
        String[] song10 = {"Whoopty", "CJ", "734237240", "2020"};

        songDetails.put("Creepin", song1);
        songDetails.put("Heat Waves", song2);
        songDetails.put("Holiday", song3);
        songDetails.put("IDGAF", song4);
        songDetails.put("Jimmy Cooks", song5);
        songDetails.put("Noticed", song6);
        songDetails.put("Ordinary Person", song7);
        songDetails.put("Pepas", song8);
        songDetails.put("The Box", song9);
        songDetails.put("Whoopty", song10);

        Options();
    }

    public static void Options() 
    {
        /// Do While loop to keep asking for an option until a valid one is chosen
        boolean ValidInput = false;
        while (!ValidInput) {
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
                    DisplaySongsOverPlayCount();
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
        /// Method to add a new song to the list
        /// This method also allows users to replace an existing song with the same title by entering the title in the same format.
        System.out.println("");
        System.out.println("Enter new song details or the existing song name in the same format to replace:");
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
            System.out.printf("\u001B[36m|\u001B[40m \u001B[31m%-20s\u001B[40m \u001B[36m|\u001B[40m \u001B[31m%-20s\u001B[40m \u001B[36m|\u001B[40m \u001B[31m%-15s\u001B[40m \u001B[36m|\u001B[40m \u001B[31m%-15s\u001B[40m \u001B[36m|\u001B[40m\n",
            "Title", "Artist", "Play Count", "Year Released");

            for (String key : songDetails.keySet()) 
            {
                String[] details = songDetails.get(key);
                String formattedPlayCount = String.format("%,d", Long.parseLong(details[2]));
                System.out.println(ConsoleColours.ANSI_CYAN
                        + "-----------------------------------------------------------------------------------");
                System.out.printf(
                        "| \u001B[36m%-20s\u001B[40m | \u001B[36m%-20s\u001B[40m | \u001B[36m%-15s\u001B[40m | \u001B[36m%-15s\u001B[40m |\n",
                        details[0], details[1], formattedPlayCount, details[3]);
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
            String title = InputReader.getString("Enter the title of the song you want to remove (case sensitive): ");
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

    public static void DisplaySongsOverPlayCount() 
    {
        /// method to display all songs with plays over a given number
        long PlayCountThreshold;
        if (songDetails.isEmpty()) 
        {
            // error message if the list is empty
            System.out.println(ConsoleColours.ANSI_YELLOW);
            System.out.println("No songs added yet.");
            System.out.println(ConsoleColours.ANSI_CYAN);
            System.out.println("");
            Options();
        } 
        else 
        {
            while (true) 
            {
                try 
                {
                    PlayCountThreshold = Long.parseLong(InputReader.getString("Play Count Threshold: "));
                    break;
                } 
                catch (NumberFormatException e) 
                {
                    // error message if the play count is not a number
                    System.out.println(ConsoleColours.ANSI_YELLOW);
                    System.out.println("Please enter a valid number for the play count threshold.");
                    System.out.println(ConsoleColours.ANSI_CYAN);
                }
            }
            boolean songsFound = false;
            for (String key : songDetails.keySet()) 
            {
                String[] details = songDetails.get(key);
                Long playCount = Long.parseLong(details[2]);
                if (playCount > PlayCountThreshold) 
                {
                    songsFound = true;
                    break;
                }
            }
            if (songsFound) 
            {
                // Display all songs with plays over the minimum play count
                System.out.println("");
                System.out.println("List of songs with plays over " + PlayCountThreshold + ":");
                System.out.println("");
                System.out
                        .println("-----------------------------------------------------------------------------------");
                System.out.printf(
                        "\u001B[36m|\u001B[40m \u001B[31m%-20s\u001B[40m \u001B[36m|\u001B[40m \u001B[31m%-20s\u001B[40m \u001B[36m|\u001B[40m \u001B[31m%-15s\u001B[40m \u001B[36m|\u001B[40m \u001B[31m%-15s\u001B[40m \u001B[36m|\u001B[40m\n",
                        "Title", "Artist", "Play Count", "Year Released");

                for (String key : songDetails.keySet()) 
                {
                    String[] details = songDetails.get(key);
                    String formattedPlayCount = String.format("%,d", Long.parseLong(details[2]));
                    long playCount = Long.parseLong(details[2]);

                    if (playCount > PlayCountThreshold) 
                    {
                        System.out.println(ConsoleColours.ANSI_CYAN
                                + "-----------------------------------------------------------------------------------");
                        System.out.printf(
                                "| \u001B[36m%-20s\u001B[40m | \u001B[36m%-20s\u001B[40m | \u001B[36m%-15s\u001B[40m | \u001B[36m%-15s\u001B[40m |\n",
                                details[0], details[1], formattedPlayCount, details[3]);
                    }
                }
                System.out
                        .println("-----------------------------------------------------------------------------------");
            } 
            else 
            {
                /// error message if there are no songs with plays over the minimum play count
                System.out.println(ConsoleColours.ANSI_YELLOW);
                System.out.println("No songs available with over " + PlayCountThreshold + " plays.");
                System.out.println(ConsoleColours.ANSI_CYAN);
            }
            System.out.println("");
            Options();
        }
    }

}
