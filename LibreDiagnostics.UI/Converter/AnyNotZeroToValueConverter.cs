/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using Avalonia.Data.Converters;
using System.Globalization;

namespace LibreDiagnostics.UI.Converter
{
    internal class AnyNotZeroToValueConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var value in values)
            {
                if (value is IConvertible convertible)
                {
                    var converted = convertible.ToUInt64(culture);

                    if (converted != 0)
                    {
                        return converted;
                    }
                }
            }

            return null;
        }
    }
}
