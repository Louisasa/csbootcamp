using System;
using System.Collections.Generic;

public class FizzBuzz2
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

    public class FlagsForRules
    {
        public bool ShouldApplyThree { get; set; }

        public bool ShouldApplyFive { get; set; }

        public bool ShouldApplySeven { get; set; }

        public bool ShouldApplyEleven { get; set; }

        public bool ShouldApplyThirteen { get; set; }

        public bool ShouldApplySeventeen { get; set; }
    }

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
                applyThreeRule(index, resultList);
            }
            if (flags.ShouldApplyFive)
            {
                applyFiveRule(index, resultList);
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

            return String.Join("", resultList);
        }

        private void applyThreeRule(int index, List<string> resultList)
        {
            if (index % 3 == 0)
            {
                resultList.Add("Fizz");
            }
        }

        private void applyFiveRule(int index, List<string> resultList)
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

        private void applySeventeenRule(int index, List<string> resultList)
        {
            if (index % 17 == 0)
            {
                resultList.Reverse();
            }
        }
    }
}
