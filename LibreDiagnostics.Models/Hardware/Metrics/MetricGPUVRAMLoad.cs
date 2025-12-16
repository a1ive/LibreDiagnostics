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
    public class MetricGPUVRAMLoad : MetricBoardItem
    {
        #region Constructor

        public MetricGPUVRAMLoad(ISensor memoryUsedSensor, ISensor memoryTotalSensor, HardwareMetricKey key)
            : base(null, key, DataType.Percent)
        {
            MemoryUsedSensor = memoryUsedSensor;
            MemoryTotalSensor = memoryTotalSensor;
        }

        #endregion

        #region Properties

        protected ISensor MemoryUsedSensor { get; set; }
        protected ISensor MemoryTotalSensor { get; set; }

        #endregion

        #region Public

        public override void Update()
        {
            if (MemoryUsedSensor != null && MemoryTotalSensor != null &&
                MemoryUsedSensor.Value.HasValue && MemoryTotalSensor.Value.HasValue)
            {
                double load = MemoryUsedSensor.Value.Value / MemoryTotalSensor.Value.Value * 100.0;

                Update(load);
            }
            else
            {
                Text = Resources.NoSensorValue;
            }
        }

        #endregion
    }
}
