using System;
using System.Collections.Generic;

public class FizzBuzz
{
    static public void Main(String[] args)
    {
        //int num = int.Parse(args[0]);
        for (int index = 1; index <= 100; index++)
        {
            List<string> resultList = new List<string>();

            checkIfDivisibleByThree(index, resultList);
            checkIfDivisibleByFive(index, resultList);
            checkIfDivisibleBySeven(index, resultList);
            checkIfDivisibleByEleven(index, resultList);
            checkIfDivisibleByThirteen(index, resultList);
            checkIfDivisibleBySeventeen(index, resultList);

            if (resultList.Count > 0)
            {
                Console.WriteLine(string.Join("", resultList));
            }
            else
            {
                Console.WriteLine(index);
            }
        }
    }

    static private void checkIfDivisibleByThree(int index, List<string> resultList) {
        if (index % 3 == 0)
        {
            resultList.Add("Fizz");
        }
    }

    static private void checkIfDivisibleByFive(int index, List<string> resultList)
    {
        if (index % 5 == 0)
        {
            resultList.Add("Buzz");
        }
    }

    static private void checkIfDivisibleBySeven(int index, List<string> resultList)
    {
        if (index % 7 == 0)
        {
            resultList.Add("Bang");
        }
    }

    static private void checkIfDivisibleByEleven(int index, List<string> resultList)
    {
        if (index % 11 == 0)
        {
            resultList = new List();
            resultList.Add("Bong");
        }
    }

    static private void checkIfDivisibleByThirteen(int index, List<string> resultList)
    {
        if (index % 13 == 0)
        {
            if (resultList.Contains("Buzz"))
            {
                resultList.Insert(resultList.IndexOf("Buzz"), "Fezz");
            }
            else if (resultList.Contains("Bang"))
            {
                resultList.Insert(resultList.IndexOf("Bang"), "Fezz");
            }
            else if (resultList.Contains("Bong"))
            {
                resultList.Insert(resultList.IndexOf("Bong"), "Fezz");
            }
            else
            {
                resultList.Add("Fezz");
            }
        }
    }

    static private void checkIfDivisibleBySeventeen(int index, List<string> resultList) {
        if (index % 17 == 0) {
            resultList.Reverse();
        }
    }
}
