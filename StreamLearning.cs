using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    class StreamLearning
    {

        const int IdOffset = 0;
        const int IdLength = 6;

        const int FirstNameOffset = 16;
        const int FirstNameLenth = 40;

        const int LastNameOffset = 56;
        const int LastNameLength = 40;

        const int SalaryOffset = 96;
        const int SalaryLength = 20;

        const int GenderOffset = 116;
        const int GenderLength = 4;

        const int IsManagerOffset = 120;
        const int IsManagerLength = 16;

        const int RecordLength = IdLength + FirstNameLenth  + LastNameLength + SalaryLength + GenderLength + IsManagerLength;

        public static void RunFun()
        {
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            MemoryStream ms = new MemoryStream(RecordLength);

            seedData(unicodeEncoding, ms);

            ms.Seek(0, SeekOrigin.Begin);

            Console.WriteLine("Employee Record befre Promotion");
            Console.WriteLine("-------------------------------");

            Console.WriteLine($"ID : {GetField(unicodeEncoding, ms, IdOffset, IdLength)}");
            Console.WriteLine($"FirstName : {GetField(unicodeEncoding, ms, FirstNameOffset, FirstNameLenth)}");
            Console.WriteLine($"LastName : {GetField(unicodeEncoding, ms, LastNameOffset, LastNameLength)}");
            Console.WriteLine($"Salary : {GetField(unicodeEncoding, ms, SalaryOffset, SalaryLength)}");
            Console.WriteLine($"Gender : {GetField(unicodeEncoding, ms, GenderOffset, GenderLength)}");
            Console.WriteLine($"IsManager : {GetField(unicodeEncoding, ms, IsManagerOffset, IsManagerLength)}");

            Console.WriteLine("-------------------------------");

            Console.ReadKey();

            UpdateSalary(unicodeEncoding, ms, 1000);
            UpdateIsManager(unicodeEncoding, ms, true);

            Console.WriteLine($"ID : {GetField(unicodeEncoding, ms, IdOffset, IdLength)}");
            Console.WriteLine($"FirstName : {GetField(unicodeEncoding, ms, FirstNameOffset, FirstNameLenth)}");
            Console.WriteLine($"LastName : {GetField(unicodeEncoding, ms, LastNameOffset, LastNameLength)}");
            Console.WriteLine($"Salary : {GetField(unicodeEncoding, ms, SalaryOffset, SalaryLength)}");
            Console.WriteLine($"Gender : {GetField(unicodeEncoding, ms, GenderOffset, GenderLength)}");
            Console.WriteLine($"IsManager : {GetField(unicodeEncoding, ms, IsManagerOffset, IsManagerLength)}");

        }

        public static void seedData(UnicodeEncoding unicodeEncoding, MemoryStream ms)
        {
            int id = 101;
            string firstName = "Nikunj";
            string lastName = "SinghaniaSinghaniaSiS";
            decimal salary = 100;
            char gender = 'M';
            bool isManager = false;

            string employeeRecord = id.ToString().PadRight(IdLength / 2, '_') + firstName.PadRight(FirstNameLenth / 2, '_') + lastName.PadRight(LastNameLength / 2, '_') + salary.ToString().PadRight(SalaryLength / 2, '_') + gender.ToString().PadRight(GenderLength / 2, '_') + isManager.ToString().PadRight(IsManagerLength / 2, '_');
        
            Console.WriteLine(employeeRecord);

            byte[] employeeData = unicodeEncoding.GetBytes(employeeRecord);

            ms.Write(employeeData, 0, employeeRecord.Length * 2);
        }

        public static string GetField(UnicodeEncoding unicodeEncoding, MemoryStream ms, int offset, int length)
        {
            ms.Seek(offset, SeekOrigin.Begin);
            byte[] byteArray = new byte[length];
            int count = ms.Read(byteArray, 0, length);
            string fieldValue = new string(ReturnCharArrayFromByteArray(unicodeEncoding, byteArray, count));
            return fieldValue.Trim();
        }

        public static char[] ReturnCharArrayFromByteArray(UnicodeEncoding unicodeEncoding, byte[] byteArray, int count)
        {
            char[] charArray = new char[unicodeEncoding.GetCharCount(byteArray, 0, count)];

            unicodeEncoding.GetDecoder().GetChars(byteArray, 0, count, charArray, 0);

            return charArray;

        }

        public static void UpdateField(UnicodeEncoding unicodeEncoding, MemoryStream ms, int offset, int length, string newValue)
        {
            byte[] data = unicodeEncoding.GetBytes(newValue);

            ms.Seek(offset, SeekOrigin.Begin);
            ms.Write(data ,0 , length);
        }

        public static void UpdateIsManager(UnicodeEncoding unicodeEncoding, MemoryStream ms, bool isManager)
        {
            string newValue = isManager.ToString().PadRight(IsManagerLength / 2);
            UpdateField(unicodeEncoding, ms, IsManagerOffset, IsManagerLength, newValue);
        }

        public static void UpdateSalary(UnicodeEncoding unicodeEncoding, MemoryStream ms, decimal salary)
        {
            string newValue = salary.ToString().PadRight(SalaryLength / 2);
            UpdateField(unicodeEncoding, ms, SalaryOffset, SalaryLength, newValue);
        }
    }
}
