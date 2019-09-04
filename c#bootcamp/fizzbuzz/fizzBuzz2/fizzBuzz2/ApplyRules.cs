using System;
using System.Collections.Generic;

public class ApplyRules
{
    private readonly FlagsForRules flags;
    public ApplyRules(FlagsForRules flags)
    {
        this.flags = flags;
    }

    public string ApplyAllRules(int index)
    {
        List<string> resultList = new List<string>();
        if (flags.ShouldApplyThree)
        {
            ApplyThreeRule(index, resultList);
        }
        if (flags.ShouldApplyFive)
        {
            ApplyFiveRule(index, resultList);
        }
        if (flags.ShouldApplySeven)
        {
            applySevenRule(index, resultList);
        }
        if (flags.ShouldApplyEleven)
        {
            applyElevenRule(index, resultList);
        }
        if (flags.ShouldApplyThirteen)
        {
            applyThirteenRule(index, resultList);
        }
        if (flags.ShouldApplySeventeen)
        {
            applySeventeenRule(index, resultList);
        }

        return string.Join("", resultList);
    }

    private void ApplyThreeRule(int index, List<string> resultList)
    {
        if (index % 3 == 0)
        {
            resultList.Add("Fizz");
        }
    }

    private void ApplyFiveRule(int index, List<string> resultList)
    {
        if (index % 5 == 0)
        {
            resultList.Add("Buzz");
        }
    }

    private void applySevenRule(int index, List<string> resultList)
    {
        if (index % 7 == 0)
        {
            resultList.Add("Bang");
        }
    }

    private void applyElevenRule(int index, List<string> resultList)
    {
        if (index % 11 == 0)
        {
            resultList = new List<string>();
            resultList.Add("Bong");
        }
    }

    private void applyThirteenRule(int index, List<string> resultList)
    {
        if (index % 13 == 0)
        {
            foreach (string result in resultList)
            {
                if (result[0].Equals("B"))
                {
                    resultList.Insert(resultList.IndexOf(result), "Fezz");
                }
            }
            if (!resultList.Contains("Fezz"))
            {
                resultList.Add("Fezz");
            }
        }
    }

    private void applySeventeenRule(int index, List<string> resultList)
    {
        if (index % 17 == 0)
        {
            resultList.Reverse();
        }
    }
}