using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.UI.ValueConverters
{
    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            int id = (int)value;
            string path = Path.Combine(FileSystem.AppDataDirectory, "E:\\BSUIR\\2\\NET MAUI\\253504_Antikhovitch\\253504_Antikhovitch.UI\\Resources\\Images\\");
            string fname = $"{id}.png";
            string imagePath = Path.Combine(path, fname);
            if (Path.Exists(imagePath))
            {
                return ImageSource.FromFile(imagePath);
            }
            return ImageSource.FromFile("dotnet_bot.png");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
