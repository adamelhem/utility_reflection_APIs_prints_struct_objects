using System;
using System.Collections.Generic;
using System.Reflection;

namespace ObjReflectionApiUtil
{
    public interface ITypeProperties<T>
    {
        public Type ObjType { get; set; }
        public string ObjTypeName { get;}
        public object ObjValue { get; set; }
        public List<T> ObjProperties {  get; set; }
    }
}