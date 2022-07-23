using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace ObjReflectionApiUtil
{
    public struct ObjProperty : ITypeProperties<ObjProperty?>
    {
        public Type ObjType { get; set; }
        public object ObjValue { get; set; }
        string ObjTypeName => ObjType.Name;
        public IList<ObjProperty?> ObjProperties { get; set; }
        public string ObjInstanceName { get; set; }

        public override string ToString()
        {
            var str = "";
            if (!IsPrimitiveOrString(ObjType))
            {
                str += $"\nObject of Class {ObjTypeName}";
                str += "\n------------------------------------------\n";

                foreach(var objProp in ObjProperties)
                {
                    str += $" {objProp} ";
                };

            } else
            {
                str += $"{ObjInstanceName} == {ObjValue}";
            }

            return str;
        }

        private static bool IsPrimitiveOrString(Type objType) =>
            objType.IsPrimitive || objType == typeof(string);

    }

}