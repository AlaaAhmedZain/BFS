using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traverse_grid
{
    class Program
    {
       
        static void Main(string[] args)
        {
            traverse t = new traverse();
            int x=t.solve();
            Console.WriteLine(x.ToString());

        }
    }
}
