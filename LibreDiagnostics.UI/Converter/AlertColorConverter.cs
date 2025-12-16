/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using Avalonia.Data.Converters;
using Avalonia.Media;
using System.Globalization;

namespace LibreDiagnostics.UI.Converter
{
    internal class AlertColorConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Count == 3
             && values[0] is bool alerting
             && values[1] is Color normal
             && values[2] is Color alert)
            {
                return alerting ? new SolidColorBrush(alert) : new SolidColorBrush(normal);
            }

            return Brushes.Transparent;
        }
    }
}
