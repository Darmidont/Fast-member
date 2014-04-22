using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFastImplementation
{
    public class TestClass
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public TestClass()
        {
            
        }
        public override string ToString()
        {
            return string.Format("Name: {0}, Age: {1}", Name, Age);
        }
    }
}
