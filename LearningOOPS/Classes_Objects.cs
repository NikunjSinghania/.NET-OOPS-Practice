using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.LearningOOPS
{
    class Classes_Objects
    {
        int ROLL;
        string NAME;
        public static string SCHOOL = "BRCM";

        static Classes_Objects()
        {
            SCHOOL = "CHECK CHANGE";
        }
        public Classes_Objects()
        {
            Console.WriteLine("Construct Called");
        }

        public Classes_Objects(int roll, string name)
        {
            this.ROLL = roll;
            this.NAME = name;
        }

        public Classes_Objects(int roll)
        {
            this.ROLL=roll;
        }
        public void setData(int roll, string name)
        {
            this.ROLL = roll;
            this.NAME = name;
        }

        public static void setSchool()
        {
            SCHOOL = "GYANKUNJ";
        }

        public void getData()
        {
            Console.WriteLine(this.ROLL);

            if (this.NAME == null)
                Console.WriteLine("NULL");
            else
            Console.WriteLine(this.NAME);

            Console.WriteLine(SCHOOL);
        }
    }
}
