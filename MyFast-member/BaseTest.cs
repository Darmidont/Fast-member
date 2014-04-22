using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFast_member
{
    public abstract class BaseTest
    {
        public Dictionary<string, object> PropertyDictionary;

        protected BaseTest()
        {
            PropertyDictionary = new Dictionary<string, object>();
        }
    }
}
