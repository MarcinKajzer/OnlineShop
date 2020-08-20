using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Shop.Utility
{
    public static class ExtensionMethods
    {
        public static List<SelectListItem> ConvertToSelectList<T>(this T arg) where T : Enum
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            string[] names = Enum.GetNames(typeof(T));
            Array values = Enum.GetValues(typeof(T));

            for (int i = 0; i < names.Length; i++)
            {
                selectList.Add(new SelectListItem
                {
                    Text = names[i],
                    Value = values.GetValue(i).ToString()
                });
            }

            return selectList;
        }
    }
}
