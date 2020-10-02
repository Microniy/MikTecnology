using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace MikTecnologyNew
{
  
    public class SourceIntTypConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((int)value)
            {
                case 1:
                    return "pack://application:,,,/Resourses/Сборка.png";
                case 2:
                    return "pack://application:,,,/Resourses/Деталь.png";
                case 3:
                    return "pack://application:,,,/Resourses/Материал.png";
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
