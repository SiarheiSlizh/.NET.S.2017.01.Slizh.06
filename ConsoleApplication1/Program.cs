using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial p1 = new Polynomial(3, 4, 6);
            Polynomial p2 = null;
            Polynomial p3 = new Polynomial(3, 5, 2, 9);
            Polynomial p4 = new Polynomial(0, 4, 5);
            Console.WriteLine(p1.Equals(p2));
            int[][] a = new int[][] { new int[] { 2, 3 }, new int[] { 2 } };
        }
    }
}
