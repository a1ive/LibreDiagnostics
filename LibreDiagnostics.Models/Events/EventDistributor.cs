/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using LibreHardwareMonitor.Hardware.Storage;

namespace LibreDiagnostics.Models.Events
{
    public static class EventDistributor
    {
        #region Public

        public static void ShowDriveDetails(StorageDevice storage)
        {
            ShowDriveDetailsEvent?.Invoke(storage);
        }

        #endregion

        #region Events

        public static event Action<StorageDevice> ShowDriveDetailsEvent;

        #endregion
    }
}
