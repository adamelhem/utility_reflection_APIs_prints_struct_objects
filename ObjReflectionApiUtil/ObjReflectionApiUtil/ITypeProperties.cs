using System;
using System.Collections.Generic;
using System.Reflection;

namespace ObjReflectionApiUtil
{
    public interface ITypeProperties<T>
    {
        public Type ObjType { get; set; }
        public string ObjInstanceName { get; set; }
        public object ObjValue { get; set; }
        public IList<T> ObjProperties {  get; set; }
    }
}