namespace Leetcode1743RestoreTheArrayAdjPairs
{
    using System.Collections.Generic;

    public class SolutionFromLeet
    {
        public int[] RestoreArray(int[][] vals)
        {
            Dictionary<int, int[]> pairs = new Dictionary<int, int[]>();

            foreach (var val in vals)
            {
                if (pairs.ContainsKey(val[0]))
                {
                    pairs[val[0]][1] = val[1];
                }
                else
                {
                    pairs[val[0]] = new int[] { val[1], -1000000 };
                }

                if (pairs.ContainsKey(val[1]))
                {
                    pairs[val[1]][1] = val[0];
                }
                else
                {
                    pairs[val[1]] = new int[] { val[0], -1000000 };
                }
            }

            int[] result = new int[vals.Length + 1];
            int start = -1000000;

            foreach (var entry in pairs)
            {
                if (entry.Value[1] == -1000000)
                {
                    start = entry.Key;
                }
            }

            result[0] = start;
            int left = -1000000;

            for (int i = 1; i < result.Length; i++)
            {
                int[] val = pairs[start];
                int newval = (val[0] == left ? val[1] : val[0]);
                result[i] = newval;
                left = start;
                start = newval;
            }

            return result;
        }
    }
}
