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
using System.ComponentModel.DataAnnotations;
using System.IO.Compression;
using OOPS.LearningOOPS;

namespace OOPS {

    public delegate void SumOfNumberDelegate(int sum);

    class Program
    {
        public static int sum = 0;

        public static object _lock = new object();
        public static void Method_1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Method_1 : {i}");

                Monitor.Enter(_lock);

                try
                {
                    sum -= 11;
                }
                finally
                {
                    Monitor.Exit(_lock);
                }



                //if (i == 1)
                //{
                //    //Interlocked.Increment(ref sum);
                //lock (_lock)
                //{
                //    sum += 10;
                //}
                //    //Thread.Sleep(10000);
                //}
            }
            Console.WriteLine("Methos_1");

        }

        public static void Method_2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Method_2 : {i}");

                Monitor.Enter(_lock);

                try
                {
                    sum -= 11;
                }
                finally
                {
                    Monitor.Exit(_lock);
                }



                //Interlocked.Increment(ref sum);
                //lock (_lock)
                //{
                //    sum += 10;
                //}
                //Console.WriteLine(Thread.CurrentThread.IsAlive);
            }
            Console.WriteLine("Methos_2");
        }

        public static void Method_3()
        {
            Monitor.Enter(_lock);
            for(int i = 0;i < 10;i++)
            {
                Monitor.Pulse(_lock);
                Console.WriteLine(i);
                Monitor.Wait(_lock);
            }
        }

        public static void Method_4()
        {
            Monitor.Enter(_lock);
            for (int i = 20; i < 30; i++)
            {
                Monitor.Pulse(_lock);
                Console.WriteLine(i);
                Monitor.Wait(_lock);
            }
        }

        public static void DisplaySum(int sum)
        {
            Console.WriteLine($"Sum : {sum}");
        }







         


        public static void SeedData(string binaryFile)
        {
            if (!File.Exists(binaryFile))
            {
                Binary_File_Handling emp1 = new Binary_File_Handling { Id = 1001, FirstName = "Nikunj", LastName = "Singhania", gender = 'M', isManger = false, Salary = 100 };
                Binary_File_Handling emp2 = new Binary_File_Handling { Id = 1002, FirstName = "Nikunj", LastName = "Singhania", gender = 'M', isManger = false, Salary = 200 };
                Binary_File_Handling emp3 = new Binary_File_Handling { Id = 1003, FirstName = "Nikunj", LastName = "Singhania", gender = 'M', isManger = false, Salary = 300 };

                using (BinaryWriter writer = new BinaryWriter(new FileStream(binaryFile, FileMode.Create)))
                {
                    AddEmployeeRecird(writer, emp1);
                    AddEmployeeRecird(writer, emp2);
                    AddEmployeeRecird(writer, emp3);
                }
            }
        }

        public static void AddEmployeeRecird(BinaryWriter writer, Binary_File_Handling emp)
        {
            writer.Write(emp.Id);
            writer.Write(emp.FirstName);
            writer.Write(emp.LastName);
            writer.Write(emp.Salary);
            writer.Write(emp.gender);
            writer.Write(emp.isManger);
        }
        static ManualResetEvent _mre = new ManualResetEvent(false);

        public static void write()
        {
            Console.WriteLine("Write Started");
            _mre.Reset();
            Thread.Sleep(10000);

            Console.WriteLine("Write Ended");
            _mre.Set();

        }

        public static void read()
        {
            Console.WriteLine("read Started");
            _mre.WaitOne();
            Console.WriteLine("read Ended");
        }

        static async void GET()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage R = await client.GetAsync("https://api.github.com/");
            Console.WriteLine(await R.Content.ReadAsStringAsync());
        }

        static void Main(string[] args)
        {

            #region OOPS Practice
                
            Classes_Objects Data = new Classes_Objects();

            Data.setData(1, "Nikunj Singhania");

            Data.getData();

            Classes_Objects Data_1 = new Classes_Objects(1, "Check");
            Data_1.getData();

            Classes_Objects Data_2 = new Classes_Objects(2);
            Data_2.getData();

            Classes_Objects.setSchool();

            Console.WriteLine(Classes_Objects.SCHOOL);

            #endregion





































            //GET();

            //Console.WriteLine("Overpass Async");
            //Console.ReadKey();
            //FileStream fs = new FileStream("test.txt", FileMode.Create, FileAccess.Write);

            //byte[] buffer = { 100, 101 };

            //fs.Position = 1;

            //fs.Write(buffer, 0, buffer.Length);

            //fs.Close();

            //FileStream ws = new FileStream("test.txt", FileMode.Open, FileAccess.Read);

            //byte[] r = new byte[ws.Length];

            //ws.Read(r, 0, r.Length);

            //Console.WriteLine(r);

            //FileStream Fs = new FileStream("test.txt", FileMode.Open, FileAccess.Read);
            //byte[] dataToRead = new byte[Fs.Length];
            //Console.WriteLine(dataToRead.Length);
            //int totalBytesRead = 0;
            //int chunkBytesRead = 10;

            //while(totalBytesRead < Fs.Length && chunkBytesRead > 0)
            //{
            //    chunkBytesRead = Fs.Read(dataToRead, totalBytesRead, chunkBytesRead);
            //    Console.WriteLine(chunkBytesRead);
            //}

            //GZipStream gzOut = new GZipStream(File.Create("data.zip"), CompressionMode.Compress);
            //StreamWriter SW = new StreamWriter(gzOut);

            //for(int i=0;i<10;i++)
            //{
            //    SW.Write($"LEARNING {i}");
            //}

            //SW.Close();

            //GZipStream gzIn = new GZipStream(File.OpenRead("data.zip"), CompressionMode.Decompress);

            //StreamReader SR = new StreamReader(gzIn);
            //Console.WriteLine(SR.ReadToEnd());


            //FileInfo F = new FileInfo("data.zip");
            //Console.WriteLine(F.Length);
            //await HttpClientLearning.getData();

            //FileStream F = new FileStream("check.txt", FileMode.Open, FileAccess.Read);
            //Console.WriteLine("Appending Data");
            //StreamWriter S = new StreamWriter(F);
            //S.WriteLine("Check its Working\nNew Line");
            //S.Flush();
            //S.Close();

            //byte[] buffer = new byte[F.Length];
            //buffer = Encoding.UTF8.GetBytes("Bytes Conversion");

            //F.Write(buffer, 0, buffer.Length);
            //F.Flush();
            //F.Close();


            //int bytesCount = F.Read(buffer, 0, buffer.Length);
            //Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, buffer.Length));

            //StreamReader c = new StreamReader(F);
            //Console.WriteLine(c.ReadToEnd());

            //DirectoryInfo D = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            //FileInfo[] F = D.GetFiles();

            //DirectoryInfo[] dir = D.GetDirectories();

            //foreach(var e in dir)
            //{
            //    Console.WriteLine(e.FullName);
            //}

            //foreach(var e in F)
            //{
            //    Console.WriteLine(e.FullName);
            //}

            //FileInfo F = new FileInfo("text.txt");

            //Console.WriteLine(F.Name);
            // Console.WriteLine(F.Length);
            //Console.WriteLine(F.FullName);

            //File.Copy("text.txt", "test.txt");

            //DirectoryInfo d = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            //Console.WriteLine(d.FullName);

            //Console.WriteLine(d.Parent);

            //Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory+"ParallelFiles/P/P/P");
            //StreamLearningY.WriteFile();
            //StreamLearningY.ReadFile();


            //File.WriteAllText("hello.txt", "Check");

            //Console.WriteLine(File.ReadAllText("hello.txt"));


            //MemoryStream M = new MemoryStream();
            //byte[] buffer = new byte[1024];
            //buffer[0] = 1;
            //M.Write(buffer, 0, 100);
            //Console.WriteLine(M.Read(buffer, 0, 100));
            //HttpClientLearning H = new HttpClientLearning();
            //await H.getData();



            //ParallelStreaming.Check();


            //int length = 10;
            //int sum1 = 0;
            //int sum2 = 0;


            //Stopwatch S1 = Stopwatch.StartNew();

            //for (int i=0;i< length; i++)
            //{
            //    Console.WriteLine($"Value : {i} with {Thread.CurrentThread.ManagedThreadId}");
            //    Thread.Sleep(100);
            //}
            //S1.Stop();

            //Console.WriteLine(S1.ElapsedMilliseconds);

            //ParallelOptions _option = new ParallelOptions()
            //{
            //    MaxDegreeOfParallelism = 1
            //};

            //S1 = Stopwatch.StartNew();
            //Parallel.For(0, length, _option, (count, _breakCount) =>
            //{
            //    if(count == 5)
            //    {
            //        _breakCount.Break();
            //    }
            //    Console.WriteLine($"Value : {count} with {Thread.CurrentThread.ManagedThreadId}");
            //    Thread.Sleep(100);

            //});
            //S1.Stop();


            //Console.WriteLine(S1.ElapsedMilliseconds);


            //Parallel.Invoke(
            //    _option,
            //    () => { Console.WriteLine($"Invoke 1 : {Thread.CurrentThread.ManagedThreadId}"); },
            //    () => { Console.WriteLine($"Invoke 2 : {Thread.CurrentThread.ManagedThreadId}"); }
            //);






            //Thread T1 = new Thread(write);
            //T1.Start();

            //for(int i=0;i<5;i++)
            //{
            //    Console.WriteLine(i);
            //    new Thread(read).Start();
            //}



            //int reSize = sizeof(int) + ((Binary_File_Handling.NameSize + 1) * 2) + sizeof(decimal) + (sizeof(char) - 1) + sizeof(bool);



            //string binaryFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Employee.dat");




            //SeedData(binaryFile);


            //BinaryReader br = new BinaryReader(new FileStream("Employee.dat", FileMode.Open));
            //Console.WriteLine(br.ReadInt32().ToString().PadRight(7, '_'));






            //StreamLearning.RunFun();
            //
            //File_handling_1 F = new File_handling_1("Hello.txt");
            //string[] s;
            //s =[ "Hello", "CWorld", "Aer" ];
            //F.WriteTextToFile(s);
            //Console.WriteLine(F.ReadTextFromFile());
            //
            //
            //File_Handling_2.FileH();


            //Thread T = Thread.CurrentThread;
            //T.Name = "Main Thread";
            //
            //Console.WriteLine(T.Name);
            //Console.WriteLine(Thread.CurrentThread.Name);
            //
            //Thread One = new Thread(Method_3)
            //{
            //    Name = "First"
            //};
            //Thread Two = new Thread(Method_4)
            //{
            //    Name = "Second"
            //};
            //
            //One.Start();
            //
            //Two.Start();
            //
            //
            //One.Join();
            //Console.WriteLine("One Completed");
            //
            //
            ////Two.Join();
            //Console.WriteLine("Two Completed");

            //Console.WriteLine(sum);

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