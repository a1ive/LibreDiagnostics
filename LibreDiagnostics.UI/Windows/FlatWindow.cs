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
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace LibreDiagnostics.UI.Windows;

public partial class FlatWindow : Window
{
    #region Constructor

    public FlatWindow()
    {
        MinimizeCommand = new RelayCommand(() => WindowState = WindowState.Minimized);
        MaximizeCommand = new RelayCommand(() => WindowState = WindowState.Maximized);
        RestoreCommand  = new RelayCommand(() => WindowState = WindowState.Normal   );
        CloseCommand    = new RelayCommand(Close);
    }

    #endregion

    #region XAML Properties

    public static readonly AvaloniaProperty<bool> ShowTitleBarProperty =
        AvaloniaProperty.Register<FlatWindow, bool>(nameof(ShowTitleBar));

    public static readonly AvaloniaProperty<bool> ShowTitleProperty =
        AvaloniaProperty.Register<FlatWindow, bool>(nameof(ShowTitle));

    public static readonly AvaloniaProperty<bool> ShowIconProperty =
        AvaloniaProperty.Register<FlatWindow, bool>(nameof(ShowIcon));

    public static readonly AvaloniaProperty<bool> ShowMinimizeProperty =
        AvaloniaProperty.Register<FlatWindow, bool>(nameof(ShowMinimize));

    public static readonly AvaloniaProperty<bool> ShowMaximizeProperty =
        AvaloniaProperty.Register<FlatWindow, bool>(nameof(ShowMaximize));

    public static readonly AvaloniaProperty<bool> ShowCloseProperty =
        AvaloniaProperty.Register<FlatWindow, bool>(nameof(ShowClose));

    public static readonly AvaloniaProperty<string> TitleIconProperty =
        AvaloniaProperty.Register<FlatWindow, string>(nameof(TitleIcon));

    #endregion

    #region Properties

    public bool ShowTitleBar
    {
        get { return (bool)GetValue(ShowTitleBarProperty); }
        set { SetValue(ShowTitleBarProperty, value); }
    }

    public bool ShowTitle
    {
        get { return (bool)GetValue(ShowTitleProperty); }
        set { SetValue(ShowTitleProperty, value); }
    }

    public bool ShowIcon
    {
        get { return (bool)GetValue(ShowIconProperty); }
        set { SetValue(ShowIconProperty, value); }
    }

    public bool ShowMinimize
    {
        get { return (bool)GetValue(ShowMinimizeProperty); }
        set { SetValue(ShowMinimizeProperty, value); }
    }

    public bool ShowMaximize
    {
        get { return (bool)GetValue(ShowMaximizeProperty); }
        set { SetValue(ShowMaximizeProperty, value); }
    }

    public bool ShowClose
    {
        get { return (bool)GetValue(ShowCloseProperty); }
        set { SetValue(ShowCloseProperty, value); }
    }

    public string TitleIcon
    {
        get { return GetValue(TitleIconProperty) as string; }
        set { SetValue(TitleIconProperty, value); }
    }

    public ICommand MinimizeCommand { get; }
    public ICommand MaximizeCommand { get; }
    public ICommand RestoreCommand { get; }
    public ICommand CloseCommand { get; }

    #endregion

    #region Protected

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        var titleBar = e.NameScope.Find<Control>("PART_TITLEBAR");
        if (titleBar != null)
        {
            titleBar.PointerPressed += OnTitleBarPointerPressed;
            titleBar.DoubleTapped += OnTitleBarDoubleTapped;
        }

        var resizeThumb = e.NameScope.Find<Thumb>("PART_RESIZE_BOTRIGHT");
        if (resizeThumb != null)
        {
            resizeThumb.AddHandler(Thumb.PointerPressedEvent, OnResizeBotRightPointerPressed, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
        }
    }

    #endregion

    #region Private

    void OnTitleBarPointerPressed(object sender, PointerPressedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            BeginMoveDrag(e);
        }
    }

    void OnResizeBotRightPointerPressed(object sender, PointerPressedEventArgs e)
    {
        if (!CanResize || WindowState != WindowState.Normal)
        {
            return;
        }

        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            e.Handled = true;
            BeginResizeDrag(WindowEdge.SouthEast, e);
        }
    }

    void OnTitleBarDoubleTapped(object sender, TappedEventArgs e)
    {
        if (!CanResize)
        {
            return;
        }

        if (WindowState == WindowState.Normal)
        {
            WindowState = WindowState.Maximized;
        }
        else if (WindowState == WindowState.Maximized)
        {
            WindowState = WindowState.Normal;
        }
    }

    #endregion
}
