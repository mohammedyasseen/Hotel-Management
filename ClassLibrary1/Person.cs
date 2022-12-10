using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Person
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Person()
        {
            Name = "No entry";
            PhoneNumber = "No entry";
        }
        public Person(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
