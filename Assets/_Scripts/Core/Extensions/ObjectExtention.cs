using System.Collections.Generic;

namespace Core.Extensions
{
    public static class ObjectExtention
    {
        public static bool IsGenericList(this object o)//tag NOT USING.
        {
            var oType = o.GetType();
            return oType.IsGenericType && (oType.GetGenericTypeDefinition() == typeof(List<>));
        }
    }
}
