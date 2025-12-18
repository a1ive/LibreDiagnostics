/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

namespace LibreDiagnostics.Models.Interfaces
{
    /// <summary>
    /// Abstraction of font manager.
    /// </summary>
    public interface IFontManager
    {
        /// <summary>
        /// Defines global font size for the application.
        /// </summary>
        double GlobalFontSize { get; set; }

        /// <summary>
        /// Defines global font family for the application.
        /// </summary>
        string GlobalFontFamily { get; set; }

        double TitleFontSize { get; }

        double SmallFontSize { get; }

        double IconSize { get; }

        double BarHeight { get; }

        double BarWidth { get; }

        double BarWidthWide { get; }

        List<string> GetSystemFontFamilies();
    }
}
