/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using LibreDiagnostics.Models.Enums;
using System.ComponentModel;

namespace LibreDiagnostics.Models.Interfaces
{
    public interface IHardwareMetric : INotifyPropertyChanged
    {
        HardwareMetricKey HardwareMetricKey { get; }
        DataType DataType { get; }
        string Name { get; }
        string Label { get; }
        string Text { get; }
        bool IsAlertActive { get; }
        bool Enabled { get; set; }

        void Update();
        void Update(double value);
    }
}
