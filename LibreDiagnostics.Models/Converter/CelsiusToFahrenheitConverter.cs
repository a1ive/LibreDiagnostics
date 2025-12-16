/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using BlackSharp.Core.Converters;
using LibreDiagnostics.Models.Interfaces;

namespace LibreDiagnostics.Models.Converter
{
    public sealed class CelsiusToFahrenheitConverter : IValueConverter
    {
        #region IValueConverter

        public double Convert(double value)
        {
            return TemperatureConverter.CelsiusToFahrenheit((float)value);
        }

        public double ConvertBack(double value)
        {
            return TemperatureConverter.FahrenheitToCelsius((float)value);
        }

        #endregion
    }
}
