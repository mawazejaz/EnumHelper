using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Helper.EnumHelper
{

    public static class EnumExtensionMethods
    {
        //to selcted List
        public static SelectList ToSelectList<TEnum>()
        where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return new SelectList(Enum.GetValues(typeof(TEnum))
            .OfType<Enum>()
            .Select(x => new SelectListItem
            {
                Text = Enum.GetName(typeof(TEnum), x),
                Value = (Convert.ToInt32(x))
                .ToString()
            }), "Value", "Text");
        }
        //with Selected Value
        public static SelectList ToSelectList<TEnum>(TEnum selectedValue)
    where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return new SelectList(Enum.GetValues(typeof(TEnum))
            .OfType<Enum>()
            .Select(x => new SelectListItem
            {
                Text = Enum.GetName(typeof(TEnum), x),
                Value = (Convert.ToInt32(x))
                .ToString()
            }), "Value", "Text", selectedValue);
        }

        //to selcted List
        public static SelectList ToSelectListDisplayName<TEnum>()
        where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return new SelectList(Enum.GetValues(typeof(TEnum))
            .OfType<Enum>()
            .Select(x => new SelectListItem
            {
                Text = GetDisplayName(x),
                Value = (Convert.ToInt32(x))
                .ToString()
            }), "Value", "Text");
        }
        //with Selected Value
        public static SelectList ToSelectListDisplayName<TEnum>(TEnum selectedValue)
    where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return new SelectList(Enum.GetValues(typeof(TEnum))
            .OfType<Enum>()
            .Select(x => new SelectListItem
            {
                Text = GetDisplayName(x),
                Value = (Convert.ToInt32(x))
                .ToString()
            }), "Value", "Text", selectedValue);
        }

        //Display Name of the enum
        public static string GetDisplayName(Enum enumValue)
        {
            string displayName;
            displayName = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();
            if (String.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }


    }

}
