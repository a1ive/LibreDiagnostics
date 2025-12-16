/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using DiskInfoToolkit;
using LibreHardwareMonitor.Hardware.Storage;
using System.Reflection;

namespace LibreDiagnostics.Models.Helper
{
    public sealed class LHMReflection
    {
        public static Storage GetStoragePropertyFromStorageDevice(StorageDevice sd)
        {
            return typeof(StorageDevice).GetProperty("Storage", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(sd) as Storage;
        }
    }
}
