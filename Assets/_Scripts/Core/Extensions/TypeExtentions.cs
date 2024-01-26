using System;
using System.Collections.Generic;


public static class TypeExtentions
{
    public static bool IsList(this Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(List<>);
}

