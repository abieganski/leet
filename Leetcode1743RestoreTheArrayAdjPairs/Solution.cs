using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Leetcode1743RestoreTheArrayAdjPairs;

public class Solution
{
    public int[] RestoreArray(int[][] adjacentPairs)
    {
        HashSet<int> once = new();
        HashSet<int> twice = new();

        CouplesStore couples = new();

        foreach (int[] pair in adjacentPairs)
        {
            couples.Add(new Couple(pair));

            int left = pair[0];
            int right = pair[1];

            if (once.Contains(left))
            {
                twice.Add(left);
                once.Remove(left);
            }
            else
            {
                once.Add(left);
            }

            if (once.Contains(right))
            {
                twice.Add(right);
                once.Remove(right);
            }
            else
            {
                once.Add(right);
            }
        }

        // find the root (only has one neighbor)
        int rootNumber = once.First();

        var result = new List<int> { rootNumber };

        Couple rootCouple = couples.GetAndRemoveCouple(rootNumber);

        int nextNumber = rootCouple.TheOtherNumber(rootNumber);
        result.Add(nextNumber);

        while (couples.Any())
        {
            Couple nextCouple = couples.GetAndRemoveCouple(nextNumber);
            if (nextCouple != null) 
            { 
                nextNumber = nextCouple.TheOtherNumber(nextNumber);
                result.Add(nextNumber);
            }
            else
            {
                break;
            }
        }

        return result.ToArray();
    }

    public class CouplesStore
    {
        Dictionary<int, int> leftRight = new();      // e.g. [2, 3]
        Dictionary<int, int> rightLeft = new();      // e.g. [3, 2]

        Dictionary<int, int> leftRight2 = new();     // e.g. [2, 7]
        Dictionary<int, int> rightLeft2 = new();     // e.g. [7, 2]

        public bool Any()
        {
            return leftRight.Any() || rightLeft.Any() || leftRight2.Any() || rightLeft2.Any();
        }

        public void Add(Couple couple)
        {
            if (leftRight.ContainsKey(couple.Left) || rightLeft.ContainsKey(couple.Right))
            {
                leftRight2.Add(couple.Left, couple.Right);
                rightLeft2.Add(couple.Right, couple.Left);
            }
            else
            {
                leftRight.Add(couple.Left, couple.Right);
                rightLeft.Add(couple.Right, couple.Left);
            }
        }

        public Couple GetAndRemoveCouple(int number)
        {
            if (leftRight.TryGetValue(number, out int right))
            {
                leftRight.Remove(number);
                rightLeft.Remove(right);
                return new Couple(new[] { number, right });
            }
            if (rightLeft.TryGetValue(number, out right))
            {
                rightLeft.Remove(number);
                leftRight.Remove(right);
                return new Couple(new[] { number, right });
            }
            if (leftRight2.TryGetValue(number, out right))
            {
                leftRight2.Remove(number);
                rightLeft2.Remove(right);
                return new Couple(new[] { number, right });
            }
            if (rightLeft2.TryGetValue(number, out right))
            {
                rightLeft2.Remove(number);
                leftRight2.Remove(number);
                return new Couple(new[] { number, right });
            }
            return null;

        }
    }

    public class Couple

    {
        public int Left { get; set; }
        public int Right { get; set; }

        public Couple(int[] pair)
        {
            Left = pair[0];
            Right = pair[1];
        }

        public bool Contains(int number)
        {
            return this.Left == number || this.Right == number;
        }

        public int TheOtherNumber(int number)
        {
            if (Left == number) return Right;
            if (Right == number) return Left;
            throw new Exception("number not in couple");
        }
    }
}
