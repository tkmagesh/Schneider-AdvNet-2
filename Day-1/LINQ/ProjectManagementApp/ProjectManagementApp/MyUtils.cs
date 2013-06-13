using System.Collections.Generic;

namespace ProjectManagementApp
{
    public static class MyUtils
    {
        public static List<int> GetEvenNumbers(int limit)
        {
            var result = new List<int>();
            for(var i=1;i<=limit;i++)
                if (i % 2 == 0) result.Add(i);
            return result;
        } 

        public static IEnumerable<int> GetEvenNumbersLazy(int limit)
        {
            for (var i = 1; i <= limit; i++)
                if (i%2 == 0)
                    yield return i;
        }
    }
}