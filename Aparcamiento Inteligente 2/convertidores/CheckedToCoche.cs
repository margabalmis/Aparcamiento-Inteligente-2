﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Aparcamiento_Inteligente_2.convertidores
{
    class CheckedToCoche : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string tipo = (string)value;
            if (tipo == "coche")
            {
                return true;
            }
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool coche = (bool)value;
            if (coche)
            {
                return "coche";
            }
            else
                return null;
        }
    }
}
