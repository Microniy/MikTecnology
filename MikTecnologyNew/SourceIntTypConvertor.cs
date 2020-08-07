﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace MikTecnologyNew
{
   public enum StringTypeNode
    {
        AssemblyNode=1,
        DetailNode=2
    }
    public class SourceIntTypConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((int)value)
            {
                case (int)StringTypeNode.AssemblyNode:
                    return "pack://application:,,,/Resourses/Сборка.png";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
