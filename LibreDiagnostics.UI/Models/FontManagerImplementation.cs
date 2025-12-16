/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using BlackSharp.MVVM.ComponentModel;
using BlackSharp.UI.Avalonia.Global;
using LibreDiagnostics.Models.Globals;
using LibreDiagnostics.Models.Interfaces;

namespace LibreDiagnostics.UI.Models
{
    internal sealed class FontManagerImplementation : ViewModelBase, IFontManager
    {
        #region Constructor

        /// <summary>
        /// Requires Avalonia UI to be initialized.
        /// </summary>
        public FontManagerImplementation()
        {
            GlobalFontSize = Global.Settings.FontSize;
        }

        #endregion

        #region Fields

        const double _Modifier = 0.06;

        #endregion

        #region Properties

        public double GlobalFontSize
        {
            get { return GlobalResourceManager.GlobalFontSize; }
            set { GlobalResourceManager.GlobalFontSize = value; NotifyAllPropertyChanged(); }
        }

        public double TitleFontSize
        {
            get { return Global.FontManager.GlobalFontSize * GetModifier(2); }
        }

        public double SmallFontSize
        {
            get { return Global.FontManager.GlobalFontSize * GetModifier(-2); }
        }

        public double IconSize
        {
            get { return Global.FontManager.GlobalFontSize * GetModifier(12.5); }
        }

        public double BarHeight
        {
            get { return Global.FontManager.GlobalFontSize * GetModifier(-3); }
        }

        public double BarWidth
        {
            get { return BarHeight * 6; }
        }

        public double BarWidthWide
        {
            get { return BarHeight * 8; }
        }

        #endregion

        #region Private

        double GetModifier(double multiplicator)
        {
            return 1 + _Modifier * multiplicator;
        }

        #endregion
    }
}
