using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    class StreamLearningY
    {
        public static void WriteFile()
        {
            StreamWriter writer = new StreamWriter("text.txt");
            writer.WriteLine("Hello World");
            writer.Close();
        }

        public static void ReadFile()
        {
            StreamReader writer = new StreamReader("text.txt");
            Console.WriteLine(writer.ReadLine());
            writer.Close();
        }



    }
}
