using System;
using static System.Console;

namespace MovieManagement
{
    public class Member
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public int Password { get; set; }

        public Member(string aFirstName, string aLastName, int aPhoneNumber, int aPassword)
        {
            FirstName = aFirstName;
            LastName = aLastName;
            PhoneNumber = aPhoneNumber;
            Password = aPassword;
        }

        public override string ToString()
        {
            return "First Name: " + FirstName + "Last Name: " + LastName
                + "Phone Number:" + PhoneNumber;
        }


    }
}

