/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using Avalonia.Data.Converters;
using BlackSharp.Core.Extensions;
using LibreDiagnostics.Models.Configuration;
using System.Globalization;

namespace LibreDiagnostics.UI.Converter
{
    internal class MetricConfigToSelectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IList<MetricConfig> metricConfig)
            {
                var str = StringExtensions.Join(", ", metricConfig.Where(mc => mc.Enabled).Select(mc => mc.Name));

                return string.IsNullOrEmpty(str) ? "---" : str;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
