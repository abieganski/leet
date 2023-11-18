//namespace Leetcode1743RestoreTheArrayAdjPairs;


//public class Solution {
//    public int[] RestoreArray(int[][] adjacentPairs) 
//    {
//        List<Node> roots = new List<Node>();

//        foreach(int[] pair in adjacentPairs)
//        {
//            int[] sortedPair = pair.OrderBy(x => x).ToArray();
//            int leftValue = sortedPair[0];
//            int rightValue = sortedPair[1];
            
//            Console.WriteLine($"[{leftValue}, {rightValue}]");
            
//            if (!roots.Any()) 
//            {
//                var leftNode = new Node(leftValue);
//                leftNode.Connect(new Node(rightValue));
//                roots.Add(leftNode);

//                continue;
//            }

//            Node leftSearch = null;
//            foreach (var root in roots)
//            {
//                leftSearch = Find(leftValue, root);

//                if (leftSearch != null)
//                {

//                    Node rightFromLeftSearch = null;
//                    foreach (var root2 in roots)
//                    {
//                        rightFromLeftSearch = Find(rightValue, root2);
//                        if (rightFromLeftSearch != null)
//                        {
//                            leftSearch.Connect(rightFromLeftSearch);
//                            break;
//                        }
//                    }
                    
//                    if (rightFromLeftSearch != null) break;
                    
//                    var rightNode = new Node(rightValue);
//                    leftSearch.Connect(rightNode);
//                    break;
//                }
//            }

//            if (leftSearch != null) continue;

//            Node rightSearch = null;
//            foreach (var root in roots)
//            {
//                rightSearch = Find(rightValue, root);
//                if (rightSearch != null)
//                {
//                    Node leftFromRightSearch = null;
//                    foreach (var root2 in roots)
//                    {
//                        leftFromRightSearch = Find(leftValue, root2);
//                        if (leftFromRightSearch != null)
//                        {
//                            rightSearch.Connect(leftFromRightSearch);
//                            break;
//                        }
//                    }
                    
//                    if (leftFromRightSearch != null) break;
                    
//                    var leftNode = new Node(leftValue);
//                    rightSearch.Connect(leftNode);
//                    break;
//                }
//            }
            
//            if (rightSearch != null) continue;
           
//            var newRoot = new Node(leftValue);
//            newRoot.Connect(new Node(rightValue));
//            roots.Add(newRoot);
//        }
      
//        var result = new List<int>();


//        var leftMost = roots[0];
//        while(leftMost.Left != null)
//        {
//            leftMost = leftMost.Left;
//        }

//        do
//        {
//            result.Add(leftMost.Value);
//            leftMost = leftMost.Right;
//        } while(leftMost != null);

//        return result.ToArray();

//    }

//    private Node Find(int value, Node node) {
//        if (node.HasValue(value)) {
//            return node;
//        }

//        var leftMost = node;
//        while(leftMost.Left != null)
//        {
//            leftMost = leftMost.Left;
//            if (leftMost.HasValue(value)) return leftMost;
//        }

//        var rightMost = node;
//        while (rightMost.Right != null)
//        {
//            rightMost = rightMost.Right;
//            if (rightMost.HasValue(value)) return rightMost;
//        }

//        return null;
//    }

//    public class Node 
//    {
//        public int Value;

//        public Node Left;
//        public Node Right;

//        public Node(int value)
//        {
//            Value = value;
//        }

//        public void Connect(Node neighbor) 
//        {
//            if (Left == null) {
//                Left = neighbor;
//                if (neighbor.Right != null)
//                {
//                    neighbor.Right = this;
//                }
//                neighbor.Left = this;
//            }
//            else {
//                Right = neighbor;
//                if (neighbor.Left != null)
//                {
//                    neighbor.Left = this;
//                }
//                neighbor.Right = this;
//            }
//        }

//        public override string ToString()
//        {
//            return $"({Value})";
//        }

//        public bool HasValue(int value)
//        {
//            return this.Value == value;
//        }
//    }
//}