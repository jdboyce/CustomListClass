using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenericListClass
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> firstNumberList = new CustomList<int>();
            CustomList<int> secondNumberList = new CustomList<int>();
            CustomList<int> combinedList = new CustomList<int>();
            CustomList<int> subtractedList = new CustomList<int>();


            Console.WriteLine("\nFirst List\n");

            firstNumberList.Add(1);
            firstNumberList.Add(3);
            firstNumberList.Add(5);
            firstNumberList.Add(7);


            for (int i = 0; i < firstNumberList.count; i++)
            {
                Console.WriteLine(firstNumberList.items[i]);
            }

            Console.WriteLine("\nSecond List\n");

            secondNumberList.Add(2);
            secondNumberList.Add(4);
            secondNumberList.Add(6);
            secondNumberList.Add(8);

            for (int i = 0; i < secondNumberList.count; i++)
            {
                Console.WriteLine(secondNumberList.items[i]);
            }


            firstNumberList.ZipWith(secondNumberList);

            Console.WriteLine("\n\nZipped List\n\n");

            for (int i = 0; i < firstNumberList.count; i++)
            {
                Console.WriteLine(firstNumberList.items[i]);
            }

            Console.ReadKey();
        }
    }
}