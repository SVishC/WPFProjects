using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfTreeView
{
    //we can access this image converter using static reference to the instance.We are marking the attribute so that it can be shown in intellisense

    [ValueConversion(typeof(string),typeof(BitmapImage))]
    class PathToImageConverter : IValueConverter
    {
        //This instance can be directly used by the control instead of creating a static resource in xaml...efficiency of both the approaches is debatable.
        public static PathToImageConverter Instance=new PathToImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string ImageFileName = (string)value;

            string ImagePath = $"Images\\{ImageFileName}.png";

            return new BitmapImage(new Uri($"pack://application:,,,/{ImagePath}"));

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
