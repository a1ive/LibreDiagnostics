/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using BlackSharp.Core.Collections;
using BlackSharp.MVVM.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibreDiagnostics.Models.Configuration;
using LibreDiagnostics.Models.Interfaces;
using System.Windows.Input;

namespace LibreDiagnostics.Models.Hardware.HardwareMonitor
{
    public class HardwareMonitorBase : ViewModelBase, IHardwareMonitor
    {
        #region Constructor

        public HardwareMonitorBase(HardwareConfig config)
        {
            ID = config.ID;
            Name = config.Name ?? config.ActualName;
            Enabled = config.Enabled;
            Order = config.Order;

            _HardwareMetrics = new ObservableCollectionEx<IHardwareMetric>();
        }

        #endregion

        #region Protected

        protected virtual void OnRequestHardwareDetails()
        {
        }

        #endregion

        #region IHardwareMonitor

        string _ID;
        public string ID
        {
            get { return _ID; }
            set { SetField(ref _ID, value); }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value); }
        }

        bool _ShowName;
        public bool ShowName
        {
            get { return _ShowName; }
            set { SetField(ref _ShowName, value); }
        }

        bool _Enabled = true;
        public bool Enabled
        {
            get { return _Enabled; }
            set { SetField(ref _Enabled, value); }
        }

        byte _Order;
        public byte Order
        {
            get { return _Order; }
            set { SetField(ref _Order, value); }
        }

        ObservableCollectionEx<IHardwareMetric> _HardwareMetrics;
        public ObservableCollectionEx<IHardwareMetric> HardwareMetrics
        {
            get { return _HardwareMetrics; }
            set { SetField(ref _HardwareMetrics, value); }
        }

        public virtual void Update()
        {
            foreach (var item in HardwareMetrics)
            {
                item?.Update();
            }
        }

        public ICommand RequestHardwareDetails => new RelayCommand(OnRequestHardwareDetails);

        #endregion
    }
}
