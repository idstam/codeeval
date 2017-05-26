using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace StringPermutations
{
    //https://www.codeeval.com/open_challenges/14/
    class Program
    {
        static void Main(string[] args)
        {
            using (var r = new StreamReader(args[0]))
            {
                string line;
                line = r.ReadLine();

                do
                {
                    if (line.Trim() == "") continue;
                    var perms = new SortedSet<string>(new myStringComparer());
                    
                    foreach (var p in permutations(line))
                    {
                        perms.Add(p);
                    }

                    Console.WriteLine(string.Join(",", perms));

                    line = r.ReadLine();
                }
                while (line != null);
            }
            //Console.ReadLine();

        }
        static IEnumerable<string> permutations(string org)
        {
            string ret;
            if (org.Length == 1)
            {
                yield return org;

            }
            else
            {
                for (int i = 0; i < org.Length; i++)
                {
                    string foo = org[i].ToString();
                    for (int j = 0; j < org.Length; j++)
                    {
                        if (j != i) foo += org[j];
                    }

                    foreach (var p in permutations(foo.Substring(1)))
                    {
                        yield return org[i] + p;
                    }
                }
            }
        }
    }

    class myStringComparer:IComparer<string>
    {
        public int Compare(string x, string y)
        {
            for(int i = 0; i < x.Length; i++)
            {
                char cx = x[i];
                char cy = y[i];

                if (cx == cy) continue;
                if (Char.IsDigit(cx) && Char.IsDigit(cy)) return string.Compare(cx.ToString(), cy.ToString());
                if (Char.IsUpper(cx) && Char.IsUpper(cy)) return string.Compare(cx.ToString(), cy.ToString());
                if (Char.IsLower(cx) && Char.IsLower(cy)) return string.Compare(cx.ToString(), cy.ToString());
                if (Char.IsDigit(cx)) return -1;
                if (Char.IsUpper(cx) && Char.IsDigit(cy)) return 1;
                if (Char.IsUpper(cx)) return -1;
                
                return 1;
            }

            return 0;            
        }

  
    }
}
