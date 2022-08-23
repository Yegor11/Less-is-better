using System;
using System.Collections.Generic;
using System.Xml;

namespace TestTask
{
    internal class Program
    {
        static ulong numbersum(string numbers) // splitting number into digits for comparing string elements
        {
            ulong number = Convert.ToUInt64(numbers);
            ulong result = 0;
            while (number != 0)
            {
                result += number % 10;
                number /= 10;
            }
            return result;
        }
        static bool check(string one , string two) // predicat to compare elements in sort algorithm
        {
             bool result = true;

             if (numbersum(one) < numbersum(two))
             {
                 result = true;
             }
             if( numbersum(one) > numbersum(two) )
             {
                 result = false;
             }
             if (numbersum(one) == numbersum(two))
             {
                 char[] charofone = one.ToCharArray();
                 char[] charoftwo = two.ToCharArray();
                 int min =  Math.Min(one.Length, two.Length);
                 for (int i = 0; i < min; i++)
                 {
                     if (charofone[i] == charoftwo[i])
                     {
                         continue;
                     }
                     if (charofone[i] < charoftwo[i])
                     {
                         result = true;
                         break;
                     }
                     if (charofone[i] > charoftwo[i])
                     {
                         result = false;
                         break;
                     }
                 }
                 
             }
             return result;
         }
        
        static List<string> Quicksort(List<string> list) // quicksort algorithm for list
        {
            if (list.Count <= 1)
            {
                return list;
            }
            
            int pivotPosition = list.Count / 2;
            string pivotValue = list[pivotPosition];
            list.RemoveAt(pivotPosition);
            List<string> smaller = new List<string>();
            List<string> greater = new List<string>();
            foreach (var item in list)
            {
                if ( check(item,pivotValue))
                {
                    smaller.Add(item);
                }
                else
                {
                    greater.Add(item);
                }
            }
            List<string> sorted = Quicksort(smaller);
            sorted.Add(pivotValue);
            sorted.AddRange(Quicksort(greater));
            return sorted;
        }
        
        static string Order(string input)
        {
            // deleting extra spaces from string
            char[] inputofchars = input.Trim().ToCharArray();
            string nospacesstring = String.Empty;
            for (int i = 0; i < inputofchars.Length; i++)
            {
                if (! ((inputofchars[i] == ' ') && (inputofchars[ i + 1 ] == ' ')))
                {
                    nospacesstring += inputofchars[i];
                }
            }

            // creating list to work more comfortable 
            List<string> numbers = new List<string>();
            char[] nospacesofchars = nospacesstring.ToCharArray();
            string number = String.Empty;
            for (int j = 0; j < nospacesofchars.Length; j++  )
            {
                if (nospacesofchars[j] != ' ')
                {
                    number += nospacesofchars[j];
                }
                else
                {
                    numbers.Add(number);
                    number = String.Empty;
                }
            }
            numbers.Add(number);

            // casting back to string, because of task requirements
            List<string> sortedlist  =  Quicksort(numbers);
            string sortedstring = String.Empty;
            foreach (var element in sortedlist)
            {
                sortedstring += element;
                sortedstring += " ";
            }
            return sortedstring.Trim();
        }

        public static void Main(string[] args)
        {
            
           string list = "71899703 200 6 91 425 4 67407 7 96488 6 4 2 7 31064 9 7920 1 34608557 27 72 18 81";
           if (list == String.Empty)
           {
               Console.WriteLine("Empty list!");
           }
           else
           {
               Console.WriteLine(" Was before sorting: " + list );
               Console.WriteLine(" After sorting: " + Order(list) );
           }
        }
    }
}