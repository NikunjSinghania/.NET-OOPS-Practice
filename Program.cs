using System;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Check_DLL;
//using OOPS_2;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Bson;
using System.Threading;

namespace OOPS {

    public delegate void SumOfNumberDelegate(int sum);

    class Program
    {
        public static void Method_1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                if (i == 1)
                {
                    Thread.Sleep(10000);
                }
            }
        }

        public static void Method_2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Console.WriteLine(Thread.CurrentThread.IsAlive);
            }
        }

        public static void DisplaySum(int sum)
        {
            Console.WriteLine($"Sum : {sum}");
        }
        static void Main(string[] args)
        {







            Thread T = Thread.CurrentThread;
            T.Name = "Main Thread";
            
            Console.WriteLine(T.Name);
            Console.WriteLine(Thread.CurrentThread.Name);
            
            Thread One = new Thread(Method_1)
            {
                Name = "First"
            };
            Thread Two = new Thread(Method_2)
            {
                Name = "Second"
            };
            
            One.Start();
            
            Two.Start();


            One.Join(1000);
            Console.WriteLine("One Completed");


            Two.Join();
            Console.WriteLine("Two Completed");
            //
            //ThreadStart obj = new ThreadStart(() => { Console.WriteLine("'Sleep Started ThreadStart'"); Thread.Sleep(10000);  Console.WriteLine("'CHECK'"); });
            //Thread Three = new Thread(obj);
            //Three.Start();
            //
            //ParameterizedThreadStart O = new ParameterizedThreadStart((object o) => { Console.WriteLine(o); });
            //
            //Thread Fourth = new Thread(O);
            //Fourth.Start(100);
            //
            //SumOfNumberDelegate _delegate = new SumOfNumberDelegate(DisplaySum);
            //
            //Helper H = new Helper(10, _delegate);
            //ThreadStart T_1 = new ThreadStart(H.printNumbers);
            //Thread N = new Thread(T_1);
            //N.Start();


            //byte[] fileContents = File.ReadAllBytes("index_2.txt");
            //Console.WriteLine(fileContents);
            //using (MemoryStream M = new MemoryStream(fileContents))
            //{
            //    int b;
            //    while((b = M.ReadByte()) != -1)
            //    {
            //        Console.WriteLine(b);
            //    }
            //}

            //string studentData = @"{
            //                'StudentId':'1',
            //                'SyudentName':'MS',
            //                'AcadmicYear':'First',
            //                'Courses':[
            //                            {'CourseId':'101','CourseName':'Compiler Design'},
            //                            {'CourseId':'101','CourseName':'Compiler Design'}
            //                          
            //    }";
            //
            ////2.
            //var studentObject = JsonConvert.DeserializeObject(studentData);
            ////3.
            //
            //Console.WriteLine(studentObject);
            //
            //Newtonsoft.Json.JsonSerializer jsonSerializer = new Newtonsoft.Json.JsonSerializer();
            ////4.
            //MemoryStream objBsonMemoryStream = new MemoryStream();
            ////5.
            //BsonWriter bsonWriterObject = new BsonWriter(objBsonMemoryStream);
            ////6.
            //jsonSerializer.Serialize(bsonWriterObject, studentObject);
            //
            ////7.
            //Console.WriteLine(Encoding.ASCII.GetString(objBsonMemoryStream.ToArray()));
            //Console.WriteLine();
            //
            //Console.WriteLine(Convert.ToBase64String(objBsonMemoryStream.ToArray()));
            //Console.ReadLine();
            //
            //BsonReader bsonReader = new BsonReader(objBsonMemoryStream);
            //
            //byte[] h;
            //while((h = bsonReader.ReadAsBytes()) != null)
            //{
            //    Console.WriteLine(h);
            //} 
            //Console.WriteLine("Hello World");
            //PrintRandomNumber P = new PrintRandomNumber();
            //PrintRandomNumber.printRandom();
            //P.printRandomPrivate();
            //P.printRandom_2();
            //
            //RandomMain R = new RandomMain();
            //
            //Check_DLL_File C = new Check_DLL_File();
            //C.printRandom_2();
            //
            //Car car = new Car();
            //car.price = 100;
            //
            //Console.WriteLine(car.price);
            //Console.WriteLine(car.owner);
            //
            //car.Brand = "Volkswagen";
            //Console.WriteLine(car.Brand);
            //
            //Dictionary<int, int> D = new Dictionary<int, int>();
            ////D.Add(1, 2);
            //
            ////foreach (var item in D)
            ////{
            ////    Console.WriteLine(item.Key+" "+ item.Value);
            ////}
            //
            //Random rf = new Random();
            //for(int i = 0; i<100000;i++)
            //{
            //    D.Add(i , rf.Next(1, 101));
            //}
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //StringBuilder S = new StringBuilder();
            //foreach (var item in D)
            //{
            //    S.Append(item.Key + " " + item.Value + "\n");
            //
            //}
            //File.WriteAllText("index_1.txt", S.ToString());
            //watch.Stop();
            //
            //Console.WriteLine(watch.ElapsedMilliseconds);
            //
            //Stopwatch watch_2 = new Stopwatch();
            //watch_2.Start();
            //string temp = "";
            //foreach (var item in D)
            //{
            //    temp += item.Key + " " + item.Value + "\n";
            //
            //}
            //File.WriteAllText("index_2.txt", temp);
            //watch_2.Stop();
            //
            //Console.WriteLine(watch_2.ElapsedMilliseconds);
        }

        
    }

    class Helper
    {
        private int num;
        private SumOfNumberDelegate _sumDelegate;
        public Helper(int _number, SumOfNumberDelegate _callback)
        {
            num = _number;
            _sumDelegate = _callback;
        }

        public void printNumbers()
        {
            int sum = 0;

            for(int  i = 0; i < num; i++)
            {
                sum += i;
            }
            
            if(_sumDelegate != null)
            {
                _sumDelegate(sum);
            }
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