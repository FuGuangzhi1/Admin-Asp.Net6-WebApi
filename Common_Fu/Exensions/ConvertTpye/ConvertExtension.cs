
using System.ComponentModel;
using System.Reflection;
using System;

namespace Common_Fu;

public static partial class Extension
{
    private static BindingFlags BindingFlags { get; }
     = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static;
    /// <summary>
    /// 获取某属性值
    /// </summary>
    /// <param name="obj">对象</param>
    /// <param name="propertyName">属性名</param>
    /// <returns></returns>
    public static object? GetPropertyValue(this object obj, string propertyName)
    {
        return obj?.GetType()?.GetProperty(propertyName, BindingFlags)?.GetValue(obj);
    }
    /// <summary>
    /// string
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToStr<T>(this T value)
    {
        try
        {
            return value!.ToString()!.Trim();
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// int
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int ToInt32<T>(this T value)
    {
        if (value == null) return 0;
        if (!Int32.TryParse(value.ToStr(), out int result))
            return 0;

        return result;
    }
    /// <summary>
    /// ulong
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ulong TouLong32<T>(this T value)
    {
        if (value == null) return 0;

        if (!ulong.TryParse(value.ToStr(), out ulong result))
            return 0;

        return result;
    }
    /// <summary>
    /// float
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static float ToFloat<T>(this T value)
    {
        if (value == null) return 0;

        if (!float.TryParse(value.ToStr(), out float result))
            return 0;

        return result;
    }

    /// <summary>
    /// double
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static double ToDouble<T>(this T value)
    {
        if (value == null) return 0;
        if (!double.TryParse(value.ToStr(), out double result))
            return 0;

        return result;
    }

    /// <summary>
    /// decimal
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static decimal ToDecimal<T>(this T value)
    {
        if (value == null) return 0;
        if (!decimal.TryParse(value.ToStr(), out decimal result))
            return 0;
        return result;
    }

    /// <summary>
    /// Guid
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Guid ToGuid<T>(this T value)
    {
        if (value == null) return Guid.Empty;
        if (!Guid.TryParse(value.ToStr(), out Guid result))
            return Guid.Empty;

        return result;
    }

    /// <summary>
    /// Guid?
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Guid? ToGuidNull<T>(this T value)
    {
        if (value == null) return null;
        if (!Guid.TryParse(value.ToStr(), out Guid result))
            return null;

        return result;
    }

    /// <summary>
    /// GuidString
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToGuidStr<T>(this T value)
    {
        return value.ToGuid().ToStr();
    }

    /// <summary>
    /// DateTime
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DateTime ToDateTime<T>(this T value)
    {
        if (value == null) return DateTime.MinValue;

        if (!DateTime.TryParse(value.ToStr(), out DateTime result))
            return DateTime.MinValue;

        return result;
    }

    /// <summary>
    /// DateTime?
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DateTime? ToDateTimeNull<T>(this T value)
    {
        if (value == null) return null;

        if (!DateTime.TryParse(value.ToStr(), out DateTime result))
            return null;

        return result;
    }

    /// <summary>
    /// 格式的 时间 字符串
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="FormatStr"></param>
    /// <returns></returns>
    public static string ToDateTimeFormat<T>(this T value, string FormatStr = "yyyy-MM-dd")
    {
        var datetime = value.ToDateTime();
        if (datetime.ToShortDateString() == DateTime.MinValue.ToShortDateString())
            return String.Empty;
        else
            return datetime.ToString(FormatStr);
    }

    /// <summary>
    /// bool
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool ToBool<T>(this T value)
    {
        if (value == null) return false;

        if (!bool.TryParse(value.ToStr(), out bool result))
            return false;

        return result;
    }

    /// <summary>
    /// byte[]
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static byte[]? ToBytes<T>(this T value)
    {
        try
        {
            return value as byte[];
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 时间戳转为C#格式时间
    /// </summary>
    /// <param name=”timeStamp”></param>
    /// <returns></returns>
    public static DateTime ToTime<T>(this int timeStamp)
    {
        var dtStart = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
        long lTime = long.Parse(timeStamp + "0000000");
        TimeSpan toNow = new(lTime); return dtStart.Add(toNow);
    }

    /// <summary>
    /// DateTime时间格式转换为Unix时间戳格式
    /// </summary>
    /// <param name=”time”></param>
    /// <returns></returns>
    public static int ToTimeInt<T>(this DateTime time)
    {
        var startTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
        return (int)((time) - startTime).TotalSeconds;
    }
    /// <summary>
    /// 为空才赋值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    /// <param name="type1"></param>
    /// <returns></returns>
    public static T IsTypeNull<T>(T type, T type1)
    {
        if (type == null)
        {
            type = type1;
        }
        return type;
    }
    /// <summary>
    /// 获取枚举类型的描述
    /// </summary>
    /// <param name="enumeration"></param>
    /// <returns></returns>
    public static string ToDescription(this Enum enumeration)
    {
        Type type = enumeration.GetType();
        MemberInfo[] memInfo = type.GetMember(enumeration.ToString());
        if (null != memInfo && memInfo.Length > 0)
        {
            object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (null != attrs && attrs.Length > 0)
                return ((DescriptionAttribute)attrs[0]).Description;
        }
        return enumeration.ToString();
    }
    /// <summary>
    /// 首字母小写写
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string FirstCharToLower(this string input)
    {
        if (String.IsNullOrEmpty(input))
            return input;
        string str = string.Concat(input.First().ToString().ToLower(), input.AsSpan(1));
        return str;
    }

    /// <summary>
    /// 首字母大写
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string FirstCharToUpper(this string input)
    {
        if (String.IsNullOrEmpty(input))
            return input;
        string str = string.Concat(input.First().ToString().ToUpper(), input.AsSpan(1));
        return str;
    }
}

