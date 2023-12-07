using System;
using static System.Console; 
namespace MovieManagement
{
    public class MemberPage
    {
        public MovieCollection<string, Movie> movieCollection;
        public MemberCollection memberCollection = new MemberCollection();  //sub
        public MemberPage(MovieCollection<string, Movie> movieCollection)
        {
            this.movieCollection = movieCollection;
        }
        public void menu()
        {
            displayMemberMenu();
            bool wannaReturn = true;
            do
            {
                int.TryParse(ReadLine(), out int choice);
                if (choice == 1 || choice == 2 || choice == 3 || choice == 4 || choice == 5
                     || choice == 6 || choice == 0)
                {
                    if (choice == 1)
                    {
                        WriteLine("");
                        WriteLine("1. Browse all the movies");
                        WriteLine("---------------------------------------------------------------");
                        Movie[] dvdArray = movieCollection.getDVD();
                        foreach (Movie item in dvdArray)
                        {
                            if (item != null)
                            {
                                WriteLine(item);
                            }
                        }
                        WriteLine("");
                        WriteLine("Enter to go back >>");
                        ReadLine();
                        displayMemberMenu();
                    }
                    else if (choice == 2)
                    {
                        WriteLine("");
                        WriteLine("2. Display all the information about a movie, given the title of the movie");
                        WriteLine("---------------------------------------------------------------");
                        Write("Enter title ==> ");
                        string inputTitle = ReadLine();
                        while (inputTitle == "" || inputTitle == default)
                        {
                            WriteLine("Input is empty. Enter again");
                            inputTitle = ReadLine();
                        }
                        WriteLine("");
                        WriteLine("++ Result ++");
                        Movie oneMovie = movieCollection.displayDVD(inputTitle);
                        

                        if (oneMovie == default)
                        {
                            WriteLine("The given DVD does not exist in the system");
                        }
                        else
                        {
                            WriteLine(oneMovie);
                        }
                        WriteLine("");
                        WriteLine("Enter to go back >>");
                        ReadLine();
                        displayMemberMenu();
                    }
                    else if (choice == 3)
                    {
                        WriteLine("");
                        WriteLine("3. Borrow a movie DVD");
                        WriteLine("---------------------------------------------------------------");
                        Write("Enter title of DVD for borrowing ==>");
                        string title = ReadLine();
                        while (title == "" || title == default)
                        {
                            WriteLine("Input is empty. Enter again");
                            title = ReadLine();

                        }
                        movieCollection.borrowDVD(title);

                        WriteLine("");
                        WriteLine("Enter to go back >>");
                        ReadLine();
                        displayMemberMenu();
                    }
                    else if (choice == 4)
                    {
                        WriteLine("");
                        WriteLine("4. Return a movie DVD");
                        WriteLine("---------------------------------------------------------------");

                        WriteLine("Enter title of DVD for return");
                        string title = ReadLine();
                        while (title == "" || title == default)
                        {
                            WriteLine("Input is empty. Enter again");
                            title = ReadLine();

                        }

                        movieCollection.returnDVD(title);

                        WriteLine("");
                        WriteLine("Enter to go back >>");
                        ReadLine();
                        displayMemberMenu();

                    }
                    else if (choice == 5)
                    {
                        WriteLine("");
                        WriteLine("5.List current borrowing movies");
                        WriteLine("---------------------------------------------------------------");
                        movieCollection.displayRecord();

                        WriteLine("");
                        WriteLine("Enter to go back >>");
                        ReadLine();
                        displayMemberMenu();

                    }
                    else if (choice == 6)
                    {
                        WriteLine("");
                        WriteLine("6. Display the top 3 movies rented by the members");
                        WriteLine("---------------------------------------------------------------");
                        WriteLine("                     COMING SOON");

                        WriteLine("");
                        WriteLine("Enter to go back >>");
                        ReadLine();
                        displayMemberMenu();
                    }
                    else if (choice == 0)
                    {
                        wannaReturn = false;
                        return;
                    }
                }
                else
                {
                    Write("Invalid entry! Enter again ==> ");

                }
            }
            while (wannaReturn);

        }
       

        private static void displayMemberMenu()
        {
            WriteLine("Member Menu");
            WriteLine("---------------------------------------------------------------");
            WriteLine("1. Browse all the movies");//done
            WriteLine("2. Display all the information about a movie, given the title of the movie"); //done
            WriteLine("3. Borrow a movie DVD"); //done
            WriteLine("4. Return a movie DVD"); //done
            WriteLine("5. List current borrowing movies");//done
            WriteLine("6. Display the top 3 movies rented by the members"); //Didn't implement
            WriteLine("0. Return to main menu");//done
            WriteLine("");
            Write("Enter your choice ==> ");
        }
        
    }
}

