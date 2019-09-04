using System;

public class FizzBuzz
{
    static public void Main(String[] args)
    {
        Console.WriteLine("Please input max num: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine("Please add which rules to include by number separated by a comma: ");
        string rulesString = Console.ReadLine();
        rulesString = rulesString.Replace(" ","");
        string[] rulesList = rulesString.Split(',');

        FlagsForRules flagsForRules = addFlagsToFlagsForRules(rulesList);
        var ruleApplier = new ApplyRules(flagsForRules);

        for (int index = 1; index <= num; index++)
        {
            string resultList = ruleApplier.ApplyAllRules(index);

            if (resultList.Length > 0)
            {
                Console.WriteLine(resultList);
            }
            else
            {
                Console.WriteLine(index);
            }
        }
    }

    static private FlagsForRules addFlagsToFlagsForRules(string[] rules)
    {
        FlagsForRules flagsForRules = new FlagsForRules();
        foreach (var rule in rules)
        {
            int num = int.Parse(rule);
            if (num == 3)
            {
                flagsForRules.ShouldApplyThree = true;
            }
            else if (num == 5)
            {
                flagsForRules.ShouldApplyFive = true;
            }
            else if (num == 7)
            {
                flagsForRules.ShouldApplySeven = true;
            }
            else if (num == 11)
            {
                flagsForRules.ShouldApplyEleven = true;
            }
            else if (num == 13)
            {
                flagsForRules.ShouldApplyThirteen = true;
            }
            else if (num == 17)
            {
                flagsForRules.ShouldApplySeventeen = true;
            }
        }

        return flagsForRules;
    }
}
