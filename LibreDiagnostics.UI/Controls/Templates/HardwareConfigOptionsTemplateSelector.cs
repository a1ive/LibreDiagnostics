/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Metadata;
using LibreDiagnostics.Models.Configuration;
using LibreDiagnostics.Models.Enums;

namespace LibreDiagnostics.UI.Controls.Templates
{
    internal class HardwareConfigOptionsTemplateSelector : IDataTemplate
    {
        [Content]
        public Dictionary<HardwareConfigOptionValueKind, IDataTemplate> Templates { get; } = new();

        public Control Build(object param)
        {
            var hco = param as HardwareConfigOptions;

            var key = hco.ValueKind;

            return Templates[key].Build(hco);
        }

        public bool Match(object data)
        {
            return data is HardwareConfigOptions;
        }
    }
}
