/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using BlackSharp.Core.Collections;
using System.ComponentModel;
using System.Windows.Input;

namespace LibreDiagnostics.Models.Interfaces
{
    public interface IHardwareMonitor : IOrderable, INotifyPropertyChanged
    {
        string ID { get; }
        string Name { get; set; }
        bool ShowName { get; }
        bool Enabled { get; set; }

        ObservableCollectionEx<IHardwareMetric> HardwareMetrics { get; }

        void Update();

        ICommand RequestHardwareDetails { get; }
    }
}
