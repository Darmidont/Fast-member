using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFastMember;

namespace MyFastImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new TestClass();
            var accessor = ObjectAccessor.Create(obj);
            var testClassDictionary = new Dictionary<string, object>();
            testClassDictionary.Add("Name", "Vasya");
            testClassDictionary.Add("Age", 10);

            foreach (KeyValuePair<string, object> keyValuePair in testClassDictionary)
            {
                accessor[keyValuePair.Key] = keyValuePair.Value;
            }

            Console.WriteLine(obj.ToString());
            Console.WriteLine("End a program");
            Console.ReadLine();
        }
    }
}
