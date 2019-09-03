using System;
using System.Collections;

public class FizzBuzz
{
    static public void Main(String[] args)
    {
        for (int index = 1; index <= 100; index++)
        {
            ArrayList resultArrayList = new ArrayList();

            checkIfDivisibleByThree(index, resultArrayList);
            checkIfDivisibleByFive(index, resultArrayList);
            checkIfDivisibleBySeven(index, resultArrayList);
            checkIfDivisibleByEleven(index, resultArrayList);
            checkIfDivisibleByThirteen(index, resultArrayList);
            checkIfDivisibleBySeventeen(index, resultArrayList);

            if (resultArrayList.Count > 0)
            {
                Console.WriteLine(string.Join("", resultArrayList));
            }
            else
            {
                Console.WriteLine(index);
            }
        }
    }

    static private void checkIfDivisibleByThree(int index, ArrayList resultArrayList) {
        if (index % 3 == 0)
        {
            resultArrayList.Add("Fizz");
        }
    }

    static private void checkIfDivisibleByFive(int index, ArrayList resultArrayList)
    {
        if (index % 5 == 0)
        {
            resultArrayList.Add("Buzz");
        }
    }

    static private void checkIfDivisibleBySeven(int index, ArrayList resultArrayList)
    {
        if (index % 7 == 0)
        {
            resultArrayList.Add("Bang");
        }
    }

    static private void checkIfDivisibleByEleven(int index, ArrayList resultArrayList)
    {
        if (index % 11 == 0)
        {
            resultArrayList = new ArrayList();
            resultArrayList.Add("Bong");
        }
    }

    static private void checkIfDivisibleByThirteen(int index, ArrayList resultArrayList)
    {
        if (index % 13 == 0)
        {
            if (resultArrayList.Contains("Buzz"))
            {
                resultArrayList.Insert(resultArrayList.IndexOf("Buzz"), "Fezz");
            }
            else if (resultArrayList.Contains("Bang"))
            {
                resultArrayList.Insert(resultArrayList.IndexOf("Bang"), "Fezz");
            }
            else if (resultArrayList.Contains("Bong"))
            {
                resultArrayList.Insert(resultArrayList.IndexOf("Bong"), "Fezz");
            }
            else
            {
                resultArrayList.Add("Fezz");
            }
        }
    }

    static private void checkIfDivisibleBySeventeen(int index, ArrayList resultArrayList) {
        if (index % 17 == 0) {
            resultArrayList.Reverse();
        }
    }
}
