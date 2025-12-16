/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using LibreDiagnostics.Models.Configuration;
using LibreHardwareMonitor.Hardware;

namespace LibreDiagnostics.Models.Hardware.HardwareMonitor
{
    public class HardwareMonitorBoardItem : HardwareMonitorBase
    {
        #region Constructor

        public HardwareMonitorBoardItem(IHardware hardware, HardwareConfig config)
            : base(config)
        {
            Hardware = hardware;

            Hardware.Update();
        }

        #endregion

        #region Properties

        protected IHardware Hardware { get; private set; }

        protected List<IHardware> SubHardware { get; } = new();

        #endregion

        #region Public

        public override void Update()
        {
            Hardware.Update();

            SubHardware.ForEach(sh => sh.Update());

            base.Update();
        }

        #endregion
    }
}
