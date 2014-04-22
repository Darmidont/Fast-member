using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyDynamicProvider
{
    public class MyDynamic : IDynamicMetaObjectProvider
    {
        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            throw new NotImplementedException();
        }

        public void DefineMethod()
        {
            Console.WriteLine("Define method");
        }
    }
}
