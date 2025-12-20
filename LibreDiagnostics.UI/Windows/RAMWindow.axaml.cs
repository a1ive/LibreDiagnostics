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
using Avalonia.Media;
using LibreDiagnostics.MVVM.ViewModels;
using LibreHardwareMonitor.Hardware;

namespace LibreDiagnostics.UI.Windows;

public partial class RAMWindow : FlatWindow
{
    #region Constructor

    public RAMWindow()
    {
        if (Design.IsDesignMode)
        {
            Background = Brushes.Black;
            Application.Current.RequestedThemeVariant = Avalonia.Styling.ThemeVariant.Dark;
        }
        else
        {
            DataContext = _ViewModel = new RAMViewModel();
        }

        InitializeComponent();
    }

    internal RAMWindow(IHardware hardware)
        : this()
    {
        _ViewModel.SetHardware(hardware);
    }

    #endregion

    #region Fields

    readonly RAMViewModel _ViewModel;

    #endregion

    #region Properties

    protected override Type StyleKeyOverride => typeof(FlatWindow);

    #endregion
}
