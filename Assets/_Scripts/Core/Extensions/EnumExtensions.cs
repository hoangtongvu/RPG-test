using System;
using UnityEngine;

public static class EnumExtensions
{
    public static TEnum FromString<TEnum>(string name) where TEnum : Enum
    {
        try
        {
            return (TEnum)System.Enum.Parse(typeof(TEnum), name);
        }
        catch (System.Exception)
        {
            //return ItemCode.NoItem;
            return default;
            throw;
        }
    }



}
