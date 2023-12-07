using System;
using System.Linq;
using System.Reflection;
using static System.Console;

namespace MovieManagement
{
    public class MovieCollection<TKey, TValue>
    {

        private int count=0;
        private const int arrayLength = 10;
        private const int rentalLength = 5;
        public TKey[] keys;
        public TValue[] values;
        public TKey[] rentalRecord=new TKey[rentalLength];
        public int recordCount = 0;

        public MovieCollection()
        {
            keys = new TKey[arrayLength];
            values = new TValue[arrayLength];
        }

        public int generateHashCode(TKey key)
        {
            int index = 0;
            if(key is IEnumerable<char> charKey)
            {
                foreach(char c in charKey)
                index += Convert.ToInt32(c);
            }
            return index;
        }
        public void addDVD(TKey key, TValue value)
        {
            int index = generateHashCode(key);
            int offset=0;
            int length = keys.Length;
            while(keys[(index+offset)% length] != null)
            {
                ++offset;

            }
            keys[(index + offset) % length] = key;
            values[(index + offset) % length] = value;


            count++;


            Write("");
            WriteLine("The Movie is stored successfully!");

        }
        public TValue[] getDVD()
        {
            TValue[] dvds = new TValue[10];
            int dvdsIndex = 0;
           
            for (int i = 0; i < keys.Length; ++i)
            {
                if (values[i] != null)
                {
                    dvds[dvdsIndex] = values[i];
                    ++dvdsIndex;
                }
            }
            return dvds;
        }
        public int searchDVD(TKey key)
        {
            int index = generateHashCode(key);
            int length = keys.Length;
            int offset = 0;

            while ((index + offset) % length < length && keys[(index + offset) % length] != null && keys[(index + offset) % length].Equals(key)==false)
            {
                offset++;
            }

            if (keys[(index + offset) % length] != null && keys[(index + offset)%length].Equals(key)==true)
            {
               
                return (index + offset) % length;
            }
            else
            {
               
                return -1;
            }

        }
        public void deleteDVD(TKey key, TValue value)
        {
            string deleted = "DELETED";
            TKey deletedT = (TKey)Convert.ChangeType(deleted, typeof(TKey));
            int index = searchDVD(key);
            if (index != -1)
            {
                keys[index] = deletedT;
                values[index] = value;
                count--;
                WriteLine("The given DVD is successfully deleted");
            }
            else
            {
                WriteLine("The given DVD is not in the system");
            }
        }
        public TValue displayDVD(TKey key)
        {
            TValue oneDVD;
            int index = searchDVD(key);
            if (index == -1)
            {
                return default(TValue);
            }
            else
            {
                oneDVD = values[index];
                return oneDVD;
            }
     
        }
      
        public void borrowDVD(TKey key)
        {
            int l = 0;


            int index = searchDVD(key);
            if (index != -1)
            {

                while (l < rentalRecord.Length && rentalRecord[l] != null && rentalRecord[l].Equals(key) == false)
                {
                    l++;
                }

                if (l >= rentalRecord.Length)
                {
                    WriteLine("You already borrowed 5 DVDs");
                }
                else if (l < rentalRecord.Length && rentalRecord[l] != null && rentalRecord[l].Equals(key) == true)
                {
                    WriteLine("You already borrowed the title of DVD");
                }
                else
                {
                    rentalRecord[l] = key;
                    WriteLine("The DVD is borrowed!");
                }
            }
            else
            {
                WriteLine("No title of the dvd in the system");
            }

           

        }
        public void returnDVD(TKey key)
        {
            int i=0;
            int count = 0;
            while (count < rentalLength && rentalRecord[count] != null)
            {
                count++;
            }
            while (i<rentalLength && rentalRecord[i]!=null && rentalRecord[i].Equals(key) == false)
            {
                i++;
            }
            if (i > rentalLength)
            {
                WriteLine("This DVD is not borrowd");
            }
            else if (rentalRecord[i] != null && rentalRecord[i].Equals(key) == true)
            {
                rentalRecord[i] = default(TKey);

                for(int j=i;j<=count-j;++j)
                {
                    rentalRecord[j] = rentalRecord[j + 1];

                }
                rentalRecord[count-1] = default(TKey);

                WriteLine("The DVD is returned");
            }
            else
            {
                WriteLine("This DVD is not borrowd");
            }

           
            int z = 0;
            WriteLine("++ Rental Record ++");
            if (rentalRecord[0]==null)
            {
                WriteLine("No DVD is borrowed");
            }
            while (z < rentalLength && rentalRecord[z] != null)
            {

                WriteLine(rentalRecord[z]);
                ++z;
            }

        }
        public void displayRecord()
        {
            int z = 0;
            WriteLine("++ Rental Record ++");
            if (rentalRecord[0] == null)
            {
                WriteLine("No DVDs are borrowed");
            }
            while (z < rentalLength && rentalRecord[z] != null)
            {

                WriteLine(rentalRecord[z]);
                ++z;
            }
        }

    }



}

