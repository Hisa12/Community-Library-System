using System;
using static System.Console;
namespace MovieManagement
{
    class Program
    {
        public static void Main(string[] args)
        {
            MovieCollection<string, Movie> movieCollection = new MovieCollection<string, Movie>();
            StaffPage staffPage = new StaffPage(movieCollection);
            MemberPage memberPage = new MemberPage(movieCollection);
            selectMenu(staffPage,memberPage);

        }
        private static void selectMenu(StaffPage staffPage, MemberPage memberPage)
        {
            mainMenu();

            do
            {
                int.TryParse(ReadLine(), out int choice);
                if (choice == 1 || choice == 2 || choice == 3)
                {
                    if (choice == 1)
                    {

                        int authent = staffPage.staffLogin();
                        if (authent == 1)
                        {
                            WriteLine("Successful login! Enter to see Staff menu >> ");
                            ReadLine();
                            staffPage.menu();


                        }
                        else
                        {
                            WriteLine("Your login attempt was not successful. Please try again.");
                            ReadLine();

                        }

                        mainMenu();


                    }
                    else if (choice == 2)
                    {
                        int loginResult = staffPage.memberLogin();
                        if (loginResult == 0)
                        {
                            WriteLine("No member is stored in the system");
                            ReadLine();
                        }
                        else if (loginResult == -1)
                        {
                            WriteLine("Your login attempt was not successful. Please try again.");
                            ReadLine();
                        }
                        else
                        {
                            WriteLine("Successful login! Enter to see Member menu >>");
                            ReadLine();
                            memberPage.menu();

                        }

                        mainMenu();


                    }
                    else
                    {
                        WriteLine("Bye!");
                        break;
                    }

                }
                else
                {
                    WriteLine(" ");
                    Write("Invalid entry! Enter again ==> ");

                }
                
            }
            while (true);

        }
        private static void mainMenu()
        {
            WriteLine("=================================================");
            WriteLine("COMMUNITY LIBRARY MOVIE DVD MANAGEMENT SYSTEM");
            WriteLine("=================================================");
            WriteLine("");
            WriteLine("Main Menu");
            WriteLine("--------------------------------------------------");
            WriteLine("Select from the following:");
            WriteLine("1. Staff");
            WriteLine("2. Member");
            WriteLine("3. End the program");
            WriteLine("");
            Write("Enter your choice ==> ");
        }
       



    }
};
