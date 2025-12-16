/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using System.Globalization;

namespace LibreDiagnostics.Language
{
    public static class Culture
    {
        #region Fields

        public const string DEFAULT = "en-US";

        #endregion

        #region Properties

        public static string[] Languages
        {
            get
            {
                return
                [
                    "de-DE",
                    DEFAULT,
                    "es-ES",
                    "fi-FI",
                    "fr-FR",
                    "it-IT",
                    "ja-JP",
                    "ru-RU",
                    "zh-Hans-CN",
                ];
            }
        }

        #endregion

        #region Public

        public static void SetCurrent(CultureInfo culture)
        {
            Resources.Resources.Culture = culture;

            Thread.CurrentThread.CurrentCulture   = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        public static List<CultureItem> GetAll()
        {
            var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Where(ci => Languages.Any(l => string.Equals(ci.Name, l, StringComparison.OrdinalIgnoreCase)))
                .OrderBy(ci => ci.DisplayName)
                .Select(ci => new CultureItem { Text = ci.DisplayName, Value = ci.Name });

            return cultures.ToList();
        }

        #endregion
    }
}
