using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSetQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskSolver ts = new TaskSolver(new HashableStringPModuloFactory());

            int m = int.Parse (Console.ReadLine());

            for (int i = 0; i < m; ++i)
            {
                string[] line = Console.ReadLine().Split(' ');
                int operationNumber = int.Parse(line[0]);
                string str = line[1];

                switch (operationNumber)
                {
                    case 1: ts.AddString(str); break;
                    case 2: ts.DeleteString(str); break;
                    case 3: Console.WriteLine(ts.NumberOfOccurencesOfStringsFromSetIn(str)); break;
                }
            }
        }
    }
}
