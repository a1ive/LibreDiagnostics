/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using BlackSharp.MVVM.ComponentModel;
using LibreDiagnostics.Models.Enums;
using LibreDiagnostics.Models.Helper;
using LibreDiagnostics.Models.Interfaces;

namespace LibreDiagnostics.Models.Hardware.Metrics
{
    public class MetricBase : ViewModelBase, IHardwareMetric
    {
        #region Constructor

        public MetricBase(HardwareMetricKey key, DataType type)
        {
            HardwareMetricKey = key;
            DataType = type;

            Label = HardwareHardwareMetricKeyTranslator.GetLabel(key);
        }

        #endregion

        #region Properties

        bool _Round;
        public bool Round
        {
            get { return _Round; }
            set { SetField(ref _Round, value); }
        }

        #endregion

        #region IHardwareMetric

        HardwareMetricKey _HardwareMetricKey;
        public HardwareMetricKey HardwareMetricKey
        {
            get { return _HardwareMetricKey; }
            set { SetField(ref _HardwareMetricKey, value); }
        }

        DataType _DataType;
        public DataType DataType
        {
            get { return _DataType; }
            set { SetField(ref _DataType, value); }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value); }
        }

        string _Label;
        public string Label
        {
            get { return _Label; }
            set { SetField(ref _Label, value); }
        }

        double _Value;
        public double Value
        {
            get { return _Value; }
            set { SetField(ref _Value, value); }
        }

        double _AlertValue;
        public double AlertValue
        {
            get { return _AlertValue; }
            set { SetField(ref _AlertValue, value); }
        }

        IValueConverter _Converter;
        public IValueConverter Converter
        {
            get { return _Converter; }
            set { SetField(ref _Converter, value); }
        }

        string _Text;
        public string Text
        {
            get { return _Text; }
            set { SetField(ref _Text, value); }
        }

        bool _IsAlertActive;
        public bool IsAlertActive
        {
            get { return _IsAlertActive; }
            set { SetField(ref _IsAlertActive, value); OnPropertyChanged(nameof(IsAlerting)); }
        }

        bool _Enabled = true;
        public bool Enabled
        {
            get { return _Enabled; }
            set { SetField(ref _Enabled, value); }
        }

        public bool IsAlerting => AlertValue != 0 && IsAlertActive;

        public virtual void Update()
        {
        }

        public void Update(double value)
        {
            //Convert value if converter is set
            value = Converter is not null ? Converter.Convert(value) : value;

            Value = value;

            IsAlertActive = Value >= AlertValue && AlertValue != 0;

            Text = string.Format("{0:#,##0.##}{1}", Round ? Math.Round(value) : value, HardwareHardwareMetricKeyTranslator.GetDataTypeAppendix(DataType));
        }

        #endregion
    }
}
