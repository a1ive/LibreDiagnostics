/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using LibreHardwareMonitor.Hardware;
using LibreDiagnostics.Models.Enums;
using LibreDiagnostics.Language.Resources;

namespace LibreDiagnostics.Models.Hardware.Metrics
{
    public class MetricBoardItem : MetricBase
    {
        #region Constructor

        public MetricBoardItem(ISensor sensor, HardwareMetricKey key, DataType type)
            : base(key, type)
        {
            Sensor = sensor;
        }

        #endregion

        #region Properties

        protected ISensor Sensor { get; set; }

        #endregion

        #region Public

        public override void Update()
        {
            if (Sensor != null && Sensor.Value.HasValue)
            {
                Update(Sensor.Value.Value);
            }
            else
            {
                Text = Resources.NoSensorValue;
            }
        }

        public bool HasSensor(ISensor other)
        {
            return ReferenceEquals(Sensor, other);
        }

        #endregion
    }
}
