/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using LibreDiagnostics.Models.Configuration;
using LibreDiagnostics.Models.Enums;
using LibreDiagnostics.Models.Globals;
using LibreDiagnostics.Models.Hardware.Metrics;
using LibreHardwareMonitor.Hardware;

namespace LibreDiagnostics.Models.Hardware.HardwareMonitor
{
    public class HardwareMonitorFans : HardwareMonitorBoardItem
    {
        #region Constructor

        public HardwareMonitorFans(IHardware hardware, HardwareConfig config)
            : base(hardware, config)
        {
            Initialize();

            Global.SettingsChanged += OnSettingsChanged;

            //Initial call to apply settings
            OnSettingsChanged(this, new(Global.Settings));
        }

        #endregion

        #region Fields

        bool _IsFanSpeedEnabled;
        bool _AreInactiveFansEnabled;

        #endregion

        #region Public

        public override void Update()
        {
            base.Update();

            if (_IsFanSpeedEnabled)
            {
                //Show all fans
                if (_AreInactiveFansEnabled)
                {
                    HardwareMetrics.ForEach(hm => hm.Enabled = true);
                }
                else //Hide inactive fans
                {
                    HardwareMetrics.ForEach(hm => hm.Enabled = hm is MetricBase { Value: > 0d });
                }
            }
        }

        #endregion

        #region Private

        void Initialize()
        {
            var sensorList = new List<MetricFan>();

            //Fan Speed
            {
                var fans = Hardware.Sensors.Where(s => s.SensorType == SensorType.Fan && s.Value != null).ToList();

                fans.ForEach(s => sensorList.Add(new MetricFan(s, HardwareMetricKey.FanSpeed, DataType.RPM)));
            }

            HardwareMetrics.Clear();
            HardwareMetrics.AddRange(sensorList);
        }

        void OnSettingsChanged(object sender, SettingsChangedEventArgs e)
        {
            if (e.NewSettings == null)
            {
                return;
            }

            ShowName = e.NewSettings.GetHardwareConfigOptionValue<bool>(HardwareMonitorType.Fan, HardwareConfigOption.HardwareNames);

            //Set FanSpeed
            var speeds = HardwareMetrics.Where(hm => hm.HardwareMetricKey == HardwareMetricKey.FanSpeed).ToList();
            _IsFanSpeedEnabled = e.NewSettings.IsConfigEnabled(HardwareMonitorType.Fan, HardwareMetricKey.FanSpeed);
            speeds.ForEach(s => s.Enabled = _IsFanSpeedEnabled);

            //Set InactiveFans
            _AreInactiveFansEnabled = e.NewSettings.GetHardwareConfigOptionValue<bool>(HardwareMonitorType.Fan, HardwareConfigOption.ShowInactiveFans);
        }

        #endregion
    }
}
