using System;
using System.Diagnostics;

namespace ObjReflectionApiUtil
{
    public class Program
    {
        static void Main(string[] args)
        {
            var obj = new object();

            var n = new Name()
            {
                firstName = "Bill",
                lastName = "Gates"
            };

            var p = new Person()
            {
                age = 55,
                name = n
            };

            var structObjectsPrint = new utility().StructObjectsInfo(p);

            Debug.WriteLine($"{structObjectsPrint}");
        }
    }
}