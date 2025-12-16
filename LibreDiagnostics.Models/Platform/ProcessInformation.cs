/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using BlackSharp.MVVM.ComponentModel;

namespace LibreDiagnostics.Models.Platform
{
    public class ProcessInformation : ViewModelBase
    {
        #region Properties

        decimal? _TotalMemorySize;
        public decimal? TotalMemorySize
        {
            get { return _TotalMemorySize; }
            set { SetField(ref _TotalMemorySize, value); }
        }

        #endregion
    }
}
