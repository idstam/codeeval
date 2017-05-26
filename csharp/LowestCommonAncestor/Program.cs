using System;
using System.Collections.Generic;
using System.IO;

namespace CodeEval
{
    // https://www.codeeval.com/open_challenges/11/
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] s;
            using (var r = new StreamReader(args[0]))
            {
                string line;
                var root = Node.getRoot();
                line = r.ReadLine();
                do
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var numbers = line.Split(new char[]{' '});
                    var n1 = root.GetByValue(int.Parse(numbers[0]));
                    var n2 = root.GetByValue(int.Parse(numbers[1]));
                    int level = 0;
                    if(n1.Level >= n2.Level)
                    {
                        level = n2.Level;
                    }
                    else
                    {
                        level = n1.Level;
                    }
                    if(level < 1)
                    {
                        Console.WriteLine(root.Value);
                    }
                    else
                    {
                        while(n1.Level > level)
                        {
                            n1 = n1.Parent;
                        }
                        while (n2.Level > level)
                        {
                            n2 = n2.Parent;
                        }

                        while (level >= 0)
                        {
                            if(n1.Value == n2.Value)
                            {
                                Console.WriteLine(n1.Value);
                                break;
                            }
                            else
                            {
                                n1 = n1.Parent;
                                n2 = n2.Parent;
                            }
                        }
                    }
                    line = r.ReadLine();
                }
                while (line != null);
            }
            Console.ReadLine();
        }

    }

    public class Node
    {
        public Node Parent;
        public List<Node> Children = new List<Node>();
        public int Value;
        public int Level;

        public Node GetByValue(int value)
        {
            if (Value == value) return this;

            foreach(var n in GetChildren(this))
            {
                if (n.Value == value) return n;
            }

            return null;
        }
        public IEnumerable<Node> GetChildren(Node root)
        {
            foreach(var n in root.Children)
            {
                foreach(var c in  GetChildren(n))
                {
                    yield return c;
                }

                yield return n;
            }

            
        }
        public static Node getRoot()
        {
            var root = new Node() { Value = 30 };
            root.Children.Add(new Node() { Value = 8, Parent = root, Level = 1 });
            root.Children.Add(new Node() { Value = 52, Parent = root, Level = 1 });

            var n = root.GetByValue(8);
            n.Children.Add(new Node() { Value = 3, Parent = n, Level = 2 });
            n.Children.Add(new Node() { Value = 20, Parent = n, Level = 2 });

            n = root.GetByValue(20);
            n.Children.Add(new Node() { Value = 10, Parent = n, Level = 3 });
            n.Children.Add(new Node() { Value = 29, Parent = n, Level = 3 });

            return root;
        }
    }
}
