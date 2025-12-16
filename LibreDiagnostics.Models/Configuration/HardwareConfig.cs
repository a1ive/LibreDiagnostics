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
using Newtonsoft.Json;

namespace LibreDiagnostics.Models.Configuration
{
    /// <summary>
    /// Represents a hardware configuration.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class HardwareConfig : DragDropViewModelBase, ICopyable<HardwareConfig>
    {
        #region Properties

        string _ID;
        [JsonProperty]
        public string ID
        {
            get { return _ID; }
            set { SetField(ref _ID, value); }
        }

        string _Name;
        [JsonProperty]
        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value); }
        }

        string _ActualName;
        [JsonProperty]
        public string ActualName
        {
            get { return _ActualName; }
            set { SetField(ref _ActualName, value); }
        }

        bool _Enabled = true;
        [JsonProperty]
        public bool Enabled
        {
            get { return _Enabled; }
            set { SetField(ref _Enabled, value); }
        }

        byte _Order;
        [JsonProperty]
        public byte Order
        {
            get { return _Order; }
            set { SetField(ref _Order, value); }
        }

        #endregion

        #region ICloneable

        public override HardwareConfig Clone()
        {
            var clone = (HardwareConfig)MemberwiseClone();
            return clone;
        }

        #endregion

        #region ICopyable

        public void Copy(HardwareConfig from)
        {
            ShallowCopy.CopyValueTypeProperties(from, this);
        }

        #endregion

        #region Public - Mock Data

        public static List<HardwareConfig> GetMock()
        {
            //if (!IsInDesignMode)
            //    return null;

            return new()
            {
                new()
                {
                    ID = "First",
                    Name = "HwCfgName",
                    ActualName = "HwCfgActName",
                    Enabled = true,
                    Order = 1,
                },
                new()
                {
                    ID = "Second",
                    Name = "Hamsti",
                    ActualName = "Ofenkäsi",
                    Enabled = false,
                    Order = 2,
                },
            };
        }

        #endregion
    }
}
