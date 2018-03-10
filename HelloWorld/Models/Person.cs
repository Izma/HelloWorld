using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Opinion { get; set; }
        public string Genre { get; set; }
        public int Age { get; set; }
    }
}