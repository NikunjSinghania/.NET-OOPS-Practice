using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    class ParallelStreaming
    {
        public static void Check()
        {
            //string path = AppDomain.CurrentDomain.BaseDirectory;
            //string fileName = "data.txt";

            byte[] b = new byte[1024 * 1024];
            int chunkSize = 1000;
            DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            var filesData = directoryInfo.GetFiles("testdata.json");

            foreach (var f in filesData)
            {




                //Console.WriteLine(b.Length);

                //for(int i=0;i< f.Length/chunkSize;i++)
                //{
                    //FileStream fileStream = new FileStream(f.Name, FileMode.Open, FileAccess.Read, FileShare.Read);

                //fileStream.ReadAsync();

                using (FileStream fs = new FileStream(f.Name, FileMode.Open))
                {
                 UTF8Encoding temp = new UTF8Encoding(true);
                 int readLen;
                    //Console.WriteLine(File.Length / b.Length);
                    //readLen = fs.Read(b, 1, b.Length);
                    //Console.WriteLine(temp.GetString(b, 0, readLen));
                    //Console.WriteLine(temp.GetString(b, 0, readLen));
                    //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    Stopwatch s1 = Stopwatch.StartNew();
                    for (int i = 0; i < f.Length / b.Length + 1; i++)
                    {
                        readLen = fs.Read(b, 0, b.Length);
                        Console.WriteLine(temp.GetString(b));
                        //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    }
                    s1.Stop();
                    Console.WriteLine("Elapsed Time : " + s1.ElapsedMilliseconds);
                    Thread.Sleep(10000);
                    ParallelOptions _option = new ParallelOptions()
                    {
                        MaxDegreeOfParallelism = 3
                    };
                    s1 = Stopwatch.StartNew();

                    Parallel.For(0, f.Length / b.Length, _option, count =>
                        {
                            readLen = fs.Read(b, 0, b.Length);
                            Console.WriteLine(temp.GetString(b));
                            FileStream wr = new FileStream($"new_{count}.txt", FileMode.Create);
                            wr.Write(b);
                        });
                    //Parallel.ForEach(File.Read(f.Name), (line, _, lineNumber) =>
                    //{
                    //    // Your code here for processing each line
                    //    Console.WriteLine($"Line {lineNumber}: {line}");
                    //});
                    s1.Stop();
                    Console.WriteLine("Elapsed Time : "+s1.ElapsedMilliseconds);
                    //while ((readLen = fs.Read(b, 0, b.Length)) > 0)
                    //{
                    //    Console.WriteLine(temp.GetString(b, 0, readLen));
                    //}
                    //   }
                    }
                }
        }

    }
}