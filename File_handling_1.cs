using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    class File_handling_1
    {
        public string _rootPath = AppDomain.CurrentDomain.BaseDirectory;

        public string _fileName = "TextFile.txt";

        public File_handling_1(string fileName)
        {
            _fileName = fileName;
        }

        public void WriteTextToFile(string[] lines)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(_rootPath, _fileName), true))
            {
                foreach (string line in lines)
                {
                    outputFile.WriteLine(line);
                }
            }
        }

        public string ReadTextFromFile()
        {
            using StreamReader sr = new StreamReader(Path.Combine(_rootPath, _fileName));
            string result = sr.ReadToEnd();
            return result;
        }
    }
}
