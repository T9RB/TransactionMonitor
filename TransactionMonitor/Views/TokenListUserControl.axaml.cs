﻿using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using TransactionMonitor.ViewModels;

namespace TransactionMonitor.Views;

public partial class TokenListUserConrtol : UserControl
{
    public TokenListUserConrtol()
    {
        InitializeComponent();
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}