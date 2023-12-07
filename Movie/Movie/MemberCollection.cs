using System;
using static System.Console;
namespace MovieManagement
{
    public class MemberCollection
    {
        public Member[] valueArray;
        public int arrayLength = 5;

        public MemberCollection()
        {
            valueArray = new Member[arrayLength];
        }

        public int getAsciiSum(string value)
        {
            int total = 0;

            for (int i = 0; i < value.Length; ++i)
            {
                total += (int)value[i];
            }
            return total;
        }
        public Member[] getMember()
        {
            Member[] subArrayForDisplay = new Member[arrayLength];
            int memberIndex = 0;

            for (int i = 0; i < arrayLength; ++i)
            {
                if (valueArray[i] != null)
                {
                    subArrayForDisplay[memberIndex] = valueArray[i];
                    ++memberIndex;
                }
            }
            return subArrayForDisplay;
        }
        public void addMember(Member value)
        {

            int i = 0;
            if (valueArray[0] == null)
            {
                valueArray[0] = value;
            }
            else
            {
                while (i < arrayLength && valueArray[i] != null)
                {
                    i++;
                }
                if (i >= arrayLength)
                {
                    WriteLine("Storege is full. Contact IT dept.");
                    return;
                }
                if (i < arrayLength && valueArray[i] == null)
                {
                    int index = linearSearch(value, i);
                    if (index != -1)
                    {
                        WriteLine("The name is already stored");
                        return;
                    }
                    else
                    {
                        valueArray[i] = value;
                        WriteLine("Successfully sorted!");
                    }

                }

            }
            WriteLine("Member registration");
            foreach (Member item in valueArray)
            {
                WriteLine(item);
            }

        }
        public int linearSearch(Member value, int count)
        {


            for (int l = 0; l < count; l++)
            {

                int targetLNameAscii = getAsciiSum(value.LastName);

                int lNameAscii = getAsciiSum(valueArray[l].LastName);
                int targetfNameAscii = getAsciiSum(value.FirstName);
                int fNameAscii = getAsciiSum(valueArray[l].FirstName);

                if (targetLNameAscii == lNameAscii)
                {
                    if (targetfNameAscii == fNameAscii)
                    {
                        return l;
                    }

                }

            }
            return -1;
        }
        public void removeMember(Member target)
        {
            int i = 0;
            while (i < arrayLength && valueArray[i] != null)
            {
                i++;
            }
            if (valueArray[0] == null)
            {
                WriteLine("No member data is stored");
                return;
            }

            int index = linearSearch(target, i);
            if (index != -1)
            {

               
                valueArray[index] = null;
                for(int l = 0; l < i; ++l)
                {
                    if(valueArray[l + 1] != null)
                    {
                        valueArray[l] = valueArray[l + 1];
                    }
                   
                }
                valueArray[i-1] = null;

                WriteLine("The name is deleted!");
                
            }
            else
            {

                WriteLine("The name is not found in the system");
                return;
            }

        }
        public void findPhoneNum(Member target)
        {
            int i = 0;
            int phoneNum;
            
            while (i < arrayLength && valueArray[i] != null)
            {
                i++;
            }
            if (valueArray[0] == null)
            {
                WriteLine("No member data is stored");
                return;
            }
            WriteLine("Result");
            int index = linearSearch(target, i);
            if (index != -1)
            {
                phoneNum = valueArray[index].PhoneNumber;
                
                WriteLine("| First name:{0} | Last name: {1} | Phone Number: {2} |", target.FirstName, target.LastName,phoneNum);

            }
            else
            {

                WriteLine("The name is not found in the system");
                return;
            }

        }
        public int loginAuthen(Member logUser)
        {
            int l = 0;

            while (l < arrayLength && valueArray[l] != null)
            {
                l++;
            }

            if (valueArray[0] == null)
            {
                
                return 0;
            }
            int index = linearSearch(logUser, l);
            if (index != -1)
            {
                for (int ll = 0; ll < l; ll++)
                {

                    if (logUser.Password == valueArray[ll].Password)
                    {
                        return 1;

                    }

                }
                return -1;

              

            }
            else
            {
                return -1;
            }
        }

    }



}
