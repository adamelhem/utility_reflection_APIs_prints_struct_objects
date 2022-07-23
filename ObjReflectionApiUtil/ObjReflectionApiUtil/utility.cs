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

            var ClassProperties = new ObjProperty
            {
                ObjType = obj.GetType(),
                ObjProperties = new List<ObjProperty>()
            };

            var propertiesInfo = obj.GetType().GetProperties();


            if (ClassProperties.ObjType.IsPrimitive || ClassProperties.ObjType == typeof(string))
            {
                return ClassProperties;
            }


            foreach (var prop in propertiesInfo)
            {
                var objProperty = new ObjProperty();
                objProperty.ObjValue = prop.GetValue(obj);
                objProperty.ObjType = prop.PropertyType;
                ClassProperties.ObjProperties.Add(objProperty);
                ClassProperties.ObjProperties.Add(StructObjectsInfo(objProperty.ObjValue));
            }

            return ClassProperties;
        }

    }
}
