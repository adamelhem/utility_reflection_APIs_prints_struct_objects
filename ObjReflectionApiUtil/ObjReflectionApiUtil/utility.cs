using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace ObjReflectionApiUtil
{
    public class utility
    {
        public utility()
        {
        }

        public ObjProperty StructObjectsInfo<T>(T obj)
        {
            var objType = obj.GetType();

            var ClassProperties = new ObjProperty
            {
                ObjType = objType,
                ObjProperties = new List<ObjProperty>(),
                ObjValue = obj
            };


            if (objType.IsPrimitive || objType == typeof(string))
            {
                return ClassProperties;
            }

            var propertiesInfo = obj.GetType().GetProperties();
            foreach (var prop in propertiesInfo)
            {
                var objValue = prop.GetValue(obj);
                ClassProperties.ObjProperties.Add(StructObjectsInfo(objValue));
            }

            return ClassProperties;
        }

    }
}
