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
using LibreHardwareMonitor.Hardware.Storage;

namespace LibreDiagnostics.UI.Windows;

public partial class StorageWindow : FlatWindow
{
    #region Constructor

    public StorageWindow()
    {
        if (Design.IsDesignMode)
        {
            Background = Brushes.Black;
            Application.Current.RequestedThemeVariant = Avalonia.Styling.ThemeVariant.Dark;
        }
        else
        {
            DataContext = _ViewModel = new StorageViewModel();
        }

        InitializeComponent();
    }

    internal StorageWindow(StorageDevice sd)
        : this()
    {
        _ViewModel.StorageDevice = sd;
    }

    #endregion

    #region Fields

    readonly StorageViewModel _ViewModel;

    #endregion

    #region Properties

    protected override Type StyleKeyOverride => typeof(FlatWindow);

    #endregion
}
