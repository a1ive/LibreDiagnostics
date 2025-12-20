/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using LibreHardwareMonitor.Hardware;
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

        public static void ShowRAMDetails(IHardware hardware)
        {
            ShowRAMDetailsEvent?.Invoke(hardware);
        }

        #endregion

        #region Events

        public static event Action<StorageDevice> ShowDriveDetailsEvent;
        public static event Action<IHardware> ShowRAMDetailsEvent;

        #endregion
    }
}
