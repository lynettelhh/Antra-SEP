using System;
using System.Collections.Generic;

namespace LeetCodeQuestions;
class Program
{
    static void Main(string[] args)
    {
        //Q15 3SUM
        public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            var dict = new Dictionary<int, int>();
            for (int i = nums.Length - 1; i >= 0; i--)
                if (!dict.ContainsKey(nums[i]))
                    dict[nums[i]] = i;

            var result = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1])
                        continue;
                    if (dict.TryGetValue(-nums[i] - nums[j], out int k) && k > j)
                        result.Add(new List<int>() { nums[i], nums[j], nums[k] });
                }
            }
            return result;
        }
    }

    //Q1 two sum
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }

    }


    //Q9 ISPalindrome
        public bool IsPalindrome(int x)
        {

            if (x < 0) { return false; }
            if (x / 10 < 0) { return true; }

            string str = x.ToString();
            for (int i = 0, j = str.Length - 1; i < str.Length / 2; i++, j--)
            {
                if (!str[i].Equals(str[j]))
                {
                    return false;
                }
            }

            return true;
        }


    //Q217 Contains DUPlicate
        public bool ContainsDuplicate(int[] nums)
        {
            List<int> data = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (data.IndexOf(nums[i]) != -1)
                    return true;
                data.Add(nums[i]);
            }
            return false;


        }



    //Q412 FizzBuzz
        public IList<string> FizzBuzz(int n)
        {

            var result = new List<string>(n);

            for (int i = 1; i <= n; i++)
            {

                var sb = new StringBuilder();

                if (i % 3 == 0)
                {
                    sb.Append("Fizz");
                }
                if (i % 5 == 0)
                {
                    sb.Append("Buzz");
                }

                if (i % 5 != 0 && i % 3 != 0)
                {
                    sb.Append($"{i}");
                }

                result.Add(sb.ToString());
            }

            return result;
        }
    }
}

