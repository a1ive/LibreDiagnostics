/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using CommunityToolkit.Mvvm.Input;
using LibreDiagnostics.Language.Resources;
using LibreDiagnostics.Models.Configuration;
using LibreDiagnostics.Models.Interfaces;
using LibreDiagnostics.MVVM.Utilities;
using System.Diagnostics;
using System.Reflection;
using OS = BlackSharp.Core.Platform.OperatingSystem;

namespace LibreDiagnostics.UI.Models
{
    internal partial class TrayIconImplementation : ITrayIcon
    {
        #region Constructor

        public TrayIconImplementation(Settings settings)
        {
            var icon = Application.Current?.GetValue(TrayIcon.IconsProperty)?.FirstOrDefault();
            if (icon == null)
            {
                return;
            }

            //Manually add menu
            icon.Menu = new NativeMenu
            {
                new NativeMenuItem
                {
                    Header = Resources.ButtonSettings,
                    Command = SettingsRequestedCommand,
                },
                new NativeMenuItemSeparator(),
                new NativeMenuItem
                {
                    Header = Resources.ButtonDonate,
                    Command = DonateRequestedCommand,
                },
                new NativeMenuItem
                {
                    Header = Resources.ButtonGithub,
                    Command = GithubRequestedCommand,
                },
                new NativeMenuItem
                {
                    Header = Resources.ButtonUpdate,
                    Command = UpdateRequestedCommand,
                },
                new NativeMenuItemSeparator(),
                new NativeMenuItem
                {
                    Header = Resources.ButtonRestart,
                    Command = RestartRequestedCommand,
                },
                new NativeMenuItem
                {
                    Header = Resources.ButtonClose,
                    Command = CloseRequestedCommand,
                },
            };

            //Add binding for visibility
            icon.ClearValue(TrayIcon.IsVisibleProperty);

            var binding = new Binding
            {
                Source = settings,
                Path = nameof(Settings.ShowTrayIcon),
                Mode = BindingMode.TwoWay
            };
            icon.Bind(TrayIcon.IsVisibleProperty, binding);

            //Add tooltip
            var version = Assembly.GetEntryAssembly()?.GetName().Version;
            icon.ToolTipText = $"{Resources.AppName} v{version.ToString(3)}";
        }

        #endregion

        #region Private

        void OpenInBrowser(string url)
        {
            if (OS.IsWindows())
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            else if (OS.IsLinux())
            {
                Process.Start("xdg-open", url);
            }
        }

        #endregion

        #region Commands

        [RelayCommand]
        void SettingsRequested()
        {
            MessageBro.DoOpenSettings();
        }

        [RelayCommand]
        void RestartRequested()
        {
            Process.Start(Environment.ProcessPath);
            MessageBro.DoShutdownApplication();
        }

        [RelayCommand]
        void DonateRequested()
        {
            OpenInBrowser(@"https://github.com/sponsors/Blacktempel");
        }

        [RelayCommand]
        void GithubRequested()
        {
            OpenInBrowser(@"https://github.com/Blacktempel/LibreDiagnostics");
        }

        [RelayCommand]
        async Task UpdateRequested()
        {
            //Require confirmation
            await Client.TryUpdate(true);
        }

        [RelayCommand]
        void CloseRequested()
        {
            MessageBro.DoShutdownApplication();
        }

        #endregion
    }
}
