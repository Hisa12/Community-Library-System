using System;
//using System.Security.Cryptography;
using static System.Console;

namespace MovieManagement
{
    public class Movie
    {

        public string Title { get; set; }
        public string Genre { get; set; }
        public string Classification { get; set; }
        public int  Duration { get; set; }

        public Movie(string aTitle, string aGenre, string aClassification, int aDuration)
        {
            Title = aTitle;
            Genre = aGenre;
            Classification = aClassification;
            Duration = aDuration;
        }

        public override string ToString()
        {
            return "| Title: "+Title +" | Genre: "+Genre +" | Classification: " +Classification+" | Duration: "+Duration+"min |";
        }


    }

    
}

