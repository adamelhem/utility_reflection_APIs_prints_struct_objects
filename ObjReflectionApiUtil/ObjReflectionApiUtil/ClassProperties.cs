using System;
using System.Collections.Generic;
using System.Reflection;

namespace ObjReflectionApiUtil
{
    public struct ObjProperty : ITypeProperties<ObjProperty>
    {
        public Type ObjType { get; set; }
        public string ObjTypeName => ObjType.Name;
        public object ObjValue { get; set; }
        public List<ObjProperty> ObjProperties { get; set ; }
    }
}