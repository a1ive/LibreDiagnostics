/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using BlackSharp.MVVM.ComponentModel;

namespace LibreDiagnostics.Models.Helper
{
    public class TextValuePair<TValue> : ViewModelBase
    {
        #region Properties

        string _Text;
        public string Text
        {
            get { return _Text; }
            set { SetField(ref _Text, value); }
        }

        TValue _Value;
        public TValue Value
        {
            get { return _Value; }
            set { SetField(ref _Value, value); }
        }

        #endregion
    }
}
