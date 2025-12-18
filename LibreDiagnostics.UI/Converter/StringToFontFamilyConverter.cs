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
    internal class StringToFontFamilyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string fontFamily && !string.IsNullOrWhiteSpace(fontFamily))
            {
                return FontManager.Current.SystemFonts.FirstOrDefault(ff => ff.Name == fontFamily, FontManager.Current.DefaultFontFamily.Name);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is FontFamily ff)
            {
                return ff.Name;
            }

            return null;
        }
    }
}
