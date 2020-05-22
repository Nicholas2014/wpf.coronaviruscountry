using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ContactManager.Presenters
{
    public class PhoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            #region Parameterizing Converters
            
            //var formattedText = parameter as string;
            //if (string.IsNullOrEmpty(formattedText))
            //{
            //    return string.Empty;
            //}

            // xaml 
            // {Binding Path=OfficePhone,Converter={StaticResource phoneConverter},ConverterParameter='TEL:{0}'}

            //return string.Format(formattedText, value);

            #endregion

            var result = value as string;

            if (!string.IsNullOrEmpty(result))
            {
                var filteredResult = FilterNonNumeric(result);

                long num = System.Convert.ToInt64(filteredResult);
                switch (filteredResult.Length)
                {
                    case 11:
                        result = string.Format("{0:+# (###) ###-####}", num);
                        break;
                    case 10:
                        result = string.Format("{0:(###) ###-####}", num);
                        break;
                    case 7:
                        result = string.Format("{0:###-####}", num);
                        break;
                    default:
                        break;
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return FilterNonNumeric(value as string);
        }

        private string FilterNonNumeric(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.Empty;
            }

            var filteredResult = string.Empty;
            foreach (Char item in source)
            {
                if (char.IsDigit(item))
                {
                    filteredResult += item;
                }
            }

            return filteredResult;
        }
    }
}
