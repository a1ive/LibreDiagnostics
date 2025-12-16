/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using LibreDiagnostics.Models.Interfaces;

namespace LibreDiagnostics.Models.Converter
{
    public static class ConverterFactory
    {
        #region Fields

        static readonly Dictionary<Type, IValueConverter> _Converters = new();

        #endregion

        #region Public

        public static IValueConverter GetConverterShared<TConverter>()
            where TConverter : class, IValueConverter, new()
        {
            if (!_Converters.TryGetValue(typeof(TConverter), out var converter))
            {
                converter = new TConverter();
                _Converters.Add(typeof(TConverter), converter);
            }

            return converter;
        }

        public static IValueConverter GetConverterUnique<TConverter>()
            where TConverter : class, IValueConverter, new()
        {
            return new TConverter();
        }

        #endregion
    }
}
