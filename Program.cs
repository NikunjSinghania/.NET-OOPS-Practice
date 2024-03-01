using System;
using System.Diagnostics;
using System.Text;
using Check_DLL;
//using OOPS_2;
namespace OOPS {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            PrintRandomNumber P = new PrintRandomNumber();
            PrintRandomNumber.printRandom();
            P.printRandomPrivate();
            P.printRandom_2();

            RandomMain R = new RandomMain();

            Check_DLL_File C = new Check_DLL_File();
            C.printRandom_2();

            Car car = new Car();
            car.price = 100;

            Console.WriteLine(car.price);
            Console.WriteLine(car.owner);

            car.Brand = "Volkswagen";
            Console.WriteLine(car.Brand);

            Dictionary<int, int> D = new Dictionary<int, int>();
            //D.Add(1, 2);

            //foreach (var item in D)
            //{
            //    Console.WriteLine(item.Key+" "+ item.Value);
            //}

            Random rf = new Random();
            for(int i = 0; i<100000;i++)
            {
                D.Add(i , rf.Next(1, 101));
            }
            Stopwatch watch = new Stopwatch();
            watch.Start();
            StringBuilder S = new StringBuilder();
            foreach (var item in D)
            {
                S.Append(item.Key + " " + item.Value + "\n");

            }
            File.WriteAllText("index_1.txt", S.ToString());
            watch.Stop();

            Console.WriteLine(watch.ElapsedMilliseconds);

            Stopwatch watch_2 = new Stopwatch();
            watch_2.Start();
            string temp = "";
            foreach (var item in D)
            {
                temp += item.Key + " " + item.Value + "\n";

            }
            File.WriteAllText("index_2.txt", temp);
            watch_2.Stop();

            Console.WriteLine(watch_2.ElapsedMilliseconds);
        }
    }

    class Car
    {
        public string name = "Default Car";
        public float price { get; set; }

        public string owner;

        private string BRAND;
        public string Brand
        {
            get
            {
                return BRAND;
            }

            set
            {
                BRAND = value;
            }
        }

    }

        class PrintRandomNumber
        {
            public static void printRandom()
            {
                Random random = new Random();
                Console.WriteLine(random.Next());
            }

            public void printRandomPrivate()
            {
                Random random = new Random(1);
                Console.WriteLine(random.Next());
            }

            public void printRandom_2()
            {
                Random random = new Random();
                ReadOnlySpan<int> choices = new ReadOnlySpan<int>();
                //random.GetItems(choices, 10);
                //foreach(int choice in choices)
                //{
                //    Console.WriteLine(choice);
                //}
            }

            protected void printRandom_3()
            {
                Random random = new Random();
                Console.WriteLine(random.Next(100));
            
            }
        }

    class RandomMain : PrintRandomNumber
    {
        public RandomMain()
        {
            printRandom_3();
        }
    }
}