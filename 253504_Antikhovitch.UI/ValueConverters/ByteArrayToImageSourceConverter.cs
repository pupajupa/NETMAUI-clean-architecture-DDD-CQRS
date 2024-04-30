using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Antikhovitch.UI.ValueConverters
{
    public class ByteArrayToImageSourceConverter : IValueConverter
    {
#pragma warning disable CS8767 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует неявно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
#pragma warning restore CS8767 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует неявно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).
        {
            if (value is byte[] byteArray)
            {
                // Преобразование массива байтов в изображение
                ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(byteArray));
                return imageSource;
            }
            // Возвращаемое значение по умолчанию
            return ImageSource.FromFile("dotnet_bot.png");
        }

#pragma warning disable CS8767 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует неявно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
#pragma warning restore CS8767 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует неявно реализованному элементу (возможно, из-за атрибутов допустимости значений NULL).
        {
            // Не нужно реализовывать метод ConvertBack
            throw new NotImplementedException();
        }
    }
}
