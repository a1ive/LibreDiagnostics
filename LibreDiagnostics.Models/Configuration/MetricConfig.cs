/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using BlackSharp.Core.Interfaces;
using BlackSharp.Core.Reflection;
using BlackSharp.MVVM.ComponentModel;
using LibreDiagnostics.Models.Enums;
using LibreDiagnostics.Models.Helper;
using Newtonsoft.Json;

namespace LibreDiagnostics.Models.Configuration
{
    [JsonObject(MemberSerialization.OptIn)]
    public class MetricConfig : ViewModelBase, ICopyable<MetricConfig>, ICloneable<MetricConfig>
    {
        #region Properties

        HardwareMetricKey _HardwareMetricKey;
        [JsonProperty]
        public HardwareMetricKey HardwareMetricKey
        {
            get { return _HardwareMetricKey; }
            set { SetField(ref _HardwareMetricKey, value); }
        }

        bool _Enabled;
        [JsonProperty]
        public bool Enabled
        {
            get { return _Enabled; }
            set { SetField(ref _Enabled, value); }
        }

        public string Name
        {
            get { return HardwareHardwareMetricKeyTranslator.GetFullName(HardwareMetricKey); }
        }

        #endregion

        #region ICloneable

        public MetricConfig Clone()
        {
            var clone = (MetricConfig)MemberwiseClone();
            return clone;
        }

        #endregion

        #region ICopyable

        public void Copy(MetricConfig from)
        {
            ShallowCopy.CopyValueTypeProperties(from, this);
        }

        #endregion

        #region Public - Mock Data

        public static List<MetricConfig> GetMock()
        {
            //if (!IsInDesignMode)
            //    return null;

            return new List<MetricConfig>
            {
                new MetricConfig
                {
                    HardwareMetricKey = HardwareMetricKey.CPUTemp,
                    Enabled = true,
                },
                new MetricConfig
                {
                    HardwareMetricKey = HardwareMetricKey.GPUFan,
                    Enabled = true,
                },
            };
        }

        #endregion
    }
}
