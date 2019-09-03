using System;
using System.Collections;

public class FizzBuzz
{
    static private ArrayList checkIfDivisibleByThree(int index, ArrayList resultArrayList) {
        if (index % 3 == 0)
        {
            resultArrayList.Add("Fizz");
        }

        return resultArrayList;
    }

    static private ArrayList checkIfDivisibleByFive(int index, ArrayList resultArrayList)
    {
        if (index % 5 == 0)
        {
            resultArrayList.Add("Buzz");
        }

        return resultArrayList;
    }

    static private ArrayList checkIfDivisibleBySeven(int index, ArrayList resultArrayList)
    {
        if (index % 7 == 0)
        {
            resultArrayList.Add("Bang");
        }

        return resultArrayList;
    }

    static private ArrayList checkIfDivisibleByEleven(int index, ArrayList resultArrayList)
    {
        if (index % 11 == 0)
        {
            resultArrayList = new ArrayList();
            resultArrayList.Add("Bong");
        }

        return resultArrayList;
    }

    static private ArrayList checkIfDivisibleByThirteen(int index, ArrayList resultArrayList)
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

        return resultArrayList;
    }

    static private ArrayList checkIfDivisibleBySeventeen(int index, ArrayList resultArrayList) {
        if (index % 17 == 0) {
            resultArrayList.Reverse();
        }
        return resultArrayList;
    }

    static public void Main(String[] args)
    {
        for (int index = 1; index <= 100; index++)
        {
            ArrayList resultArrayList = new ArrayList();

            resultArrayList = checkIfDivisibleByThree(index, resultArrayList);
            resultArrayList = checkIfDivisibleByFive(index, resultArrayList);
            //resultArrayList = checkIfDivisibleBySeven(index, resultArrayList);
            //resultArrayList = checkIfDivisibleByEleven(index, resultArrayList);
            //resultArrayList = checkIfDivisibleByThirteen(index, resultArrayList);



            if (resultArrayList.Count > 0)
            {
                String resultStringToPrint = "";
                foreach (String result in resultArrayList) {
                    resultStringToPrint += result;
                }
                Console.WriteLine(resultStringToPrint);
            }
            else {
                Console.WriteLine(index);
            }
        }
    }
}
