/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

namespace LibreDiagnostics.Models.Configuration
{
    public class SettingsChangedEventArgs : EventArgs
    {
        #region Constructor

        public SettingsChangedEventArgs(Settings newSettings)
            : this(null, newSettings)
        {
        }

        public SettingsChangedEventArgs(Settings oldSettings, Settings newSettings)
        {
            OldSettings = oldSettings;
            NewSettings = newSettings;
        }

        #endregion

        #region Properties

        public Settings OldSettings { get; init; }

        public Settings NewSettings { get; }

        #endregion
    }
}
