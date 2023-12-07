using System;
using static System.Console;
namespace MovieManagement
{
    public class StaffPage
    {

        public string[] keys;
        public Movie[] values;

       
        private MovieCollection<string, Movie> movieCollection;
        public MemberCollection memberCollection;
        public StaffPage(MovieCollection<string, Movie> movieCollection)
        {
            this.movieCollection = movieCollection;
            this.memberCollection = new MemberCollection();
        }
        public void menu()
        {
            Movie newMovie;
            Member newMember;
            int duration = 0;
            int pass=0;
            int phone=0;

            
            displayStaffMenu();
            bool wannaReturn = true;
            bool validInput;
            

            do
            {
                int.TryParse(ReadLine(), out int choice);
          
                if (choice == 0 || choice == 1 || choice == 2 || choice == 3 || choice == 4 || choice == 5
                || choice == 6 || choice == 7 )
                {

                    if (choice == 1 )
                    {

                        WriteLine("");
                        WriteLine("1. Add DVDs of a new movie to the system");
                        WriteLine("---------------------------------------------------------------");
                        Write("Enter Title ==>");
                        string title = ReadLine();
                        while (title == "" || title == default)
                        {
                            Write("Input is empty. Enter again ==>");
                            title = ReadLine();

                        }
                        int searchResult = movieCollection.searchDVD(title);
                        if (searchResult != -1)
                        {
                            Write("The title already exists in the system ==>");
                            WriteLine("");
                            Write("Enter to go back and choose '2' to store exisitng DVD >>");
                            ReadLine();
                            displayStaffMenu();

                        }
                        else
                        {
                            WriteLine("| 'd' for drama    | 'ad' for adventure | 'f' for family |");
                            WriteLine("| 'ac' for action  | 'sf' for sci-fi    | 'c' for comedy |");
                            WriteLine("|'an' for animated | 't' for thriller   | 'o' for other  |");
                            Write("Enter Genre ==>");
                            string genre = ReadLine();
                            while (genre == "" || genre == default ||
                                   genre != "d" && genre != "ad" && genre != "f" && genre != "ac" && genre != "sf" && genre != "c" &&
                                   genre != "an" && genre != "t" && genre != "o")
                            {
                                if (genre == "" || genre == default)
                                {
                                    Write("Input is empty. Enter again ==> ");
                                }
                                else
                                {
                                    Write("Choose from the valid genres ==> ");
                                }

                                genre = ReadLine();
                            }

                            WriteLine("| 'g' for General | 'pg' for Parental Guidance |");
                            WriteLine("| 'm' for M15+    | 'ma' for MA15+             |");
                            Write("Enter Classification ==>");
                            string classification = ReadLine();
                            while (classification == "" || classification == default ||
                                   classification != "g" && classification != "pg" && classification != "m" && classification != "ma")
                            {
                                if (classification == "" || classification == default)
                                {
                                    Write("Input is empty. Enter again ==> ");
                                }
                                else
                                {
                                    Write("Choose from the valid classifications ==>");
                                }

                                classification = ReadLine();
                            }

                            Write("Enter Duration(min) ==>");
                            validInput = true;
                            while (validInput)
                            {
                                if (int.TryParse(ReadLine(), out duration))
                                {
                                    validInput = false;
                                }
                                else
                                {
                                    Write("Enter movie duration in number ==>");
                                }
                            }

                            newMovie = new Movie(title, genre, classification, duration);

                            movieCollection.addDVD(title, newMovie);

                            WriteLine("");
                            Write("Enter to go back >>");
                            ReadLine();
                            displayStaffMenu();
                        }

                    }
                    else if (choice == 2)
                    {
                        WriteLine("");
                        WriteLine("2. Add new DVDs of an existing movie to the system");
                        WriteLine("---------------------------------------------------------------");

                        Write("Enter Title ==>");
                        string title = ReadLine();
                        while (title == "" || title == default)
                        {
                            Write("Input is empty. Enter again ==>");
                            title = ReadLine();

                        }
                        int searchResult = movieCollection.searchDVD(title);
                        if (searchResult == -1)
                        {
                            Write("The title does not exist in the system.");
                            WriteLine("");
                            Write("Enter to go back and choose '1' to store new Movie>> ");
                            ReadLine();
                            displayStaffMenu();
                        }
                        else
                        {
                            WriteLine("| 'd' for drama    | 'ad' for adventure | 'f' for family |");
                            WriteLine("| 'ac' for action  | 'sf' for sci-fi    | 'c' for comedy |");
                            WriteLine("|'an' for animated | 't' for thriller   | 'o' for other  |");
                            Write("Enter Genre ==>");
                            string genre = ReadLine();
                            while (genre == "" || genre == default ||
                                   genre != "d" && genre != "ad" && genre != "f" && genre != "ac" && genre != "sf" && genre != "c" &&
                                   genre != "an" && genre != "t" && genre != "o")
                            {
                                if (genre == "" || genre == default)
                                {
                                    Write("Input is empty. Enter again ==>");
                                }
                                else
                                {
                                    Write("Choose from the valid genres ==> ");
                                }

                                genre = ReadLine();
                            }

                            WriteLine("| 'g' for General | 'pg' for Parental Guidance |");
                            WriteLine("| 'm' for M15+    | 'ma' for MA15+             |");
                            Write("Enter Classification ==>");
                            string classification = ReadLine();
                            while (classification == "" || classification == default ||
                                   classification != "g" && classification != "pg" && classification != "m" && classification != "ma")
                            {
                                if (classification == "" || classification == default)
                                {
                                    Write("Input is empty. Enter again ==>");
                                }
                                else
                                {
                                    Write("Error: Choose from the valid classifications ==>");
                                }

                                classification = ReadLine();
                            }

                            Write("Enter Duration(min) ==>");
                            validInput = true;
                            while (validInput)
                            {
                                if (int.TryParse(ReadLine(), out duration))
                                {
                                    validInput = false;
                                }
                                else
                                {
                                    Write("Valid entry! Enter movie duration in number ==>");
                                }
                            }

                            newMovie = new Movie(title, genre, classification, duration);

                            movieCollection.addDVD(title, newMovie);


                            WriteLine("");
                            Write("Enter to go back >>");
                            ReadLine();
                            displayStaffMenu();
                        }


                    }
                    else if (choice == 3)
                    {
                        WriteLine("");
                        WriteLine("3. Remove DVDs of an existing movie from the system");
                        WriteLine("---------------------------------------------------------------");

                        WriteLine("Movie in the system");
                        Movie[] dvdArray = movieCollection.getDVD();
                        foreach (Movie item in dvdArray)
                        {
                            if (item != null)
                            {
                                WriteLine("Title: " + item.Title);
                            }
                        }
                        WriteLine("");
                        Write("Enter title to remove ==> ");
                        string inputTitle = ReadLine();
                        while (inputTitle == "")
                        {
                            WriteLine("Input is empty. Enter again");
                            inputTitle = ReadLine();


                        }

                        string deleted = "0000";
                        int deletedInt = 0000;
                        newMovie = new Movie(deleted, deleted, deleted, deletedInt);
                        movieCollection.deleteDVD(inputTitle, newMovie);

                        WriteLine("");
                        Write("Enter to go back >>");
                        ReadLine();
                        displayStaffMenu();

                    }
                    else if (choice == 4)
                    {
                        bool isValidPhone = true;
                        bool isValidPass = true;
                        WriteLine("");
                        WriteLine("4. Register a new member with the system");
                        WriteLine("---------------------------------------------------------------");
                        WriteLine("Enter First Name");
                        string firstName = ReadLine();

                        WriteLine("Enter Last Name");
                        string lastName = ReadLine();
                        WriteLine("Enter phone number");

                        while (isValidPhone)
                        {
                            if (int.TryParse(ReadLine(), out phone))
                            {
                                isValidPhone = false;
                            }
                            else
                            {
                                WriteLine("Invalid! Enter numbers for phone number");
                            }

                        }

                        WriteLine("Enter four digit Password");

                        while (isValidPass)
                        {
                            if (int.TryParse(ReadLine(), out pass) && pass.ToString().Length == 4)
                            {
                                isValidPass = false;
                            }
                            else
                            {
                                WriteLine("Invalid! Password needs to be four digit");
                            }
                        }

                        newMember = new Member(firstName, lastName, phone, pass);

                        memberCollection.addMember(newMember);


                        WriteLine("");
                        Write("Enter to go back >>");
                        ReadLine();
                        displayStaffMenu();


                    }
                    else if (choice == 5)
                    {
                        WriteLine("");
                        WriteLine("5. Remove a registered member from the system");
                        WriteLine("---------------------------------------------------------------");
                        WriteLine("Name in the system");
                        Member[] memberSubArray = memberCollection.getMember();
                        foreach (Member item in memberSubArray)
                        {
                            if (item != null)
                            {
                                WriteLine("First Name: " + item.FirstName + " | Last Name: " + item.LastName + " | Phone: " + item.PhoneNumber);
                            }
                        }
                        WriteLine("");
                        Write("Enter First Name for deleting ==> ");
                        string fName = ReadLine();
                        while (fName == "")
                        {
                            WriteLine("Input is empty. Enter again");
                            fName = ReadLine();

                        }
                        Write("Enter Last Name for deleting ==> ");
                        string LName = ReadLine();
                        while (LName == "")
                        {
                            WriteLine("Input is empty. Enter again");
                            LName = ReadLine();


                        }
                        newMember = new Member(fName, LName, 0000, 0000);
                        memberCollection.removeMember(newMember);

                        Member[] aftermemberSubArray = memberCollection.getMember();
                        foreach (Member item in aftermemberSubArray)
                        {
                            if (item != null)
                            {
                                WriteLine("First Name: " + item.FirstName + " | Last Name: " + item.LastName + " | Phone: " + item.PhoneNumber);
                            }
                        }

                        WriteLine("");
                        Write("Enter to go back >>");
                        ReadLine();
                        displayStaffMenu();
                    }
                    else if (choice == 6)
                    {
                        WriteLine("");
                        WriteLine("6.Find a member’s contact phone number, given the member’s full name");
                        WriteLine("---------------------------------------------------------------");
                        WriteLine("");
                        Write("Enter First Name ==> ");
                        string fName = ReadLine();
                        while (fName == "")
                        {
                            WriteLine("Input is empty. Enter again");
                            fName = ReadLine();

                        }
                        Write("Enter Last Name ==> ");
                        string LName = ReadLine();
                        while (LName == "")
                        {
                            WriteLine("Input is empty. Enter again");
                            LName = ReadLine();


                        }
                        newMember = new Member(fName, LName, 00, 0000);
                        memberCollection.findPhoneNum(newMember);

                        WriteLine("");
                        Write("Enter to go back >>");
                        ReadLine();
                        displayStaffMenu();
                    }
                    else if (choice == 7)
                    {
                        WriteLine("");
                        WriteLine("7. Find all the members who are currently renting a particular movie");
                        WriteLine("---------------------------------------------------------------");
                        WriteLine("");
                        WriteLine("                     COMING SOON");

                        WriteLine("");
                        Write("Enter to go back >>");
                        ReadLine();
                        displayStaffMenu();
                    }
                    else if (choice == 0)
                    {
                        wannaReturn = false;
                        break;
                    }
                    else
                    {
                        Write("Choose valid number from the list ==> ");

                    }


                }
                else
                {
                    Write("Invalid entry! Enter again ==> ");

                }

 
                
            }
            while (wannaReturn);

        }

        public int staffLogin()
        {
            Write("Enter Staff User Name ==> ");
            string userName = ReadLine();
            while (userName == "")
            {
                Write("Input is empty. Enter again ==>");
                userName = ReadLine();

            }
            Write("Enter Staff Password ==> ");
            string passWord = ReadLine();
            while (passWord =="")
            {
                Write("Input is empty. Enter again ==> ");
                passWord = ReadLine();

            }
            if (userName == "staff" && passWord == "today123")
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        public int memberLogin()
        {
            int loginResult = 0;
            bool isEmpty = false;
            string MpassString;
            int Mpass = 0;
            Write("Enter Member First Name ==> ");
            string fName = ReadLine();
            while (fName == "")
            {
                Write("Input is empty. Enter again ==> ");
                fName = ReadLine();

            }
            Write("Enter Member Last Name ==> ");
            string lName = ReadLine();
            while (lName == "")
            {
                Write("Input is empty. Enter again ==> ");
                lName = ReadLine();

            }

            Write("Enter Member Password ==> ");

            while (!isEmpty)
            {
                MpassString = ReadLine();

                if (int.TryParse(MpassString, out Mpass))
                {
                    isEmpty = true;
                }
                else
                {
                    WriteLine("Password should be four digits. Enter again.");
                }
            }
            Member userCheck = new Member(fName, lName, 0000, Mpass);
            loginResult = memberCollection.loginAuthen(userCheck);
            return loginResult;
        }


        private static void displayStaffMenu()
        {
            WriteLine("");
            WriteLine("Staff Menu");
            WriteLine("---------------------------------------------------------------");
            WriteLine("1. Add DVDs of a new movie to the system");  //done
            WriteLine("2. Add new DVDs of an existing movie to the system"); //done
            WriteLine("3. Remove DVDs of an existing movie from the system");//done
            WriteLine("4. Register a new member with the system"); //done
            WriteLine("5. Remove a registered member from the system"); //done
            WriteLine("6. Find a member’s contact phone number, given the member’s full name"); //done
            WriteLine("7. Find all the members who are currently renting a particular movie");
            WriteLine("0. Return to main menu");
            WriteLine("");
            Write("Enter your choice ==> ");
        }
       

    }
}

