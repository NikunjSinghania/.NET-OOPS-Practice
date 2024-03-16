using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class Binary_File_Handling
    {
        public const int NameSize = 20;
        private string _firstName = String.Empty;
        private string _lastName = String.Empty;


        public int Id { get; set; }

        public string FirstName
        {
            get
            {
                return (_firstName.Length > NameSize) ? _firstName.Substring(0, NameSize) : _firstName.PadRight(NameSize);
            }
            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return (_lastName.Length > NameSize) ? _lastName.Substring(0, NameSize) : _lastName.PadRight(NameSize);
            }
            set
            {
                _lastName = value;
            }
        }

        public decimal Salary {  get; set; }

        public char gender {  get; set; }

        public bool isManger { get; set; }

        
    }
}
