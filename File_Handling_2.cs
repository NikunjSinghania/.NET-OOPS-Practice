using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    class File_Handling_2
    {
        public static void FileH()
        {
            string content = String.Empty;

            string rootPath = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                DirectoryInfo directoryInfo = InitialiseSourceDirectory(rootPath);

                string htmlOutputFilePath = Path.Combine(rootPath, "DATA.html");

                FileInfo[] textFiles = directoryInfo.GetFiles("*.txt");

                using (var htmlFile = new StreamWriter(htmlOutputFilePath))
                {
                    foreach(FileInfo textFile in textFiles)
                    {
                        using(StreamReader sw = new StreamReader(textFile.FullName))
                        {
                            content = sw.ReadToEnd();
                        }
                        htmlFile.Write(content);
                    }
                }
            }
            catch
            {

            }
        }

        public static DirectoryInfo InitialiseSourceDirectory(string rootPath)
        {
            string dataDirectoryPath = Path.Combine(rootPath, "Data");

            string infoFilePath = Path.Combine(dataDirectoryPath, "Informaton.txt");

            if(!Directory.Exists(dataDirectoryPath))
            {
                Directory.CreateDirectory(dataDirectoryPath);
            }
            
            DirectoryInfo sourceDirectory = new DirectoryInfo(dataDirectoryPath);
            int numOfFiles = sourceDirectory.GetFiles("*.txt").Length;

            if(numOfFiles == 0)
            {
                using (StreamWriter sw = new StreamWriter(infoFilePath))
                {
                    sw.WriteLine("Lorem Ipsum");
                }
            }
            else if(numOfFiles > 1 && File.Exists(infoFilePath))
            {
                File.Delete(infoFilePath);
            }
            
            return sourceDirectory;

        }
        
    }


}
