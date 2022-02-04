using Aparcamiento_Inteligente_2.modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Aparcamiento_Inteligente_2.convertidores
{
    class MarcasToIEnumerable : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null )
            {
                return value as IEnumerable<Marcas>;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return value as ObservableCollection<Marcas>;
            }
            return null;
        }
    }
}
