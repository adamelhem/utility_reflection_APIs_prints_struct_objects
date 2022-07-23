using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ObjReflectionApiUtil
{
    public class utility : Iutility
    {
        private readonly ILogger _logger;
        public utility()
        {
            _logger = Logger.Logger.Instance;
        }

        public ObjProperty? StructObjectsInfo<T>(T obj, string objName = "")
        {
            try
            {

                var objType = obj.GetType();
                var objProperties = objType.GetProperties();

                var ClassProperties = new ObjProperty
                {
                    ObjType = objType,
                    ObjProperties = new List<ObjProperty?>(),
                    ObjValue = obj,
                    ObjInstanceName = objName
                };


                if (IsPrimitiveOrString(objType))
                {
                    return ClassProperties;
                }

                var propertiesInfo = obj.GetType().GetProperties();
                foreach (var prop in propertiesInfo)
                {
                    var objValue = prop.GetValue(obj);
                    var objValueName = prop.Name;
                    ClassProperties.ObjProperties.Add(StructObjectsInfo(objValue, objValueName));
                }

                return ClassProperties;
            }
            catch (Exception ex)
            {
                _logger.Error($"error at {nameof(StructObjectsInfo)}",ex);
                return null;
            }
        }

        private static bool IsPrimitiveOrString(Type objType) =>
                objType.IsPrimitive || objType == typeof(string);

    }
}
