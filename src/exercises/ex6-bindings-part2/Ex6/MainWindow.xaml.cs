using System;
using System.Windows;
using ReactiveUI;

namespace Ex6
{
    public partial class MainWindow : IViewFor<MainWindowModel>
    {
        public MainWindow()
        {
            InitializeComponent();

            //TODO: Add code that binds the ViewModel's FirstName to the View's FirstName field
            //TODO: Add code that binds the GreetUser command to the GreetUserButton
            //TODO: Bind the WhatWasEntered TextBlock in the View to the EnteredField in the view
            //      using a hack binding without going via the ViewModel
            //TODO: Add code which handles the GreetUser command to show a messagebox in the view
        }

        public static readonly DependencyProperty ViewModelProperty;

        static MainWindow()
        {
            ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(MainWindowModel), typeof(MainWindow));
        }

        public MainWindowModel ViewModel
        {
            get { return (MainWindowModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (MainWindowModel)value; }
        }
    }
}
