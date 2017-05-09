using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CsvHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = CSVFileHelper.ReadCSV(@"D:\Data.csv");
            foreach (var i in a)
            {
                foreach (var j in i)
                {
                    Console.Write(j);
                    Console.Write("|");
                }
                Console.WriteLine("\r\n");
            }


            var list = new List<int>(new Dictionary<int, string>().Keys);

            for (var i = list.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(list[i]+list[list[i]]);
            }

            Console.ReadKey(true);
        }
    }
}
