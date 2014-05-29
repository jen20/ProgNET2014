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

            this.WhenActivated(d =>
            {
                d(ViewModel.GreetUser.Subscribe(_ => 
                    MessageBox.Show(string.Format("Hello {0}", ViewModel.FirstName))));

                d(this.Bind(ViewModel, vm => vm.FirstName, v => v.FirstName.Text));
                d(this.BindCommand(ViewModel, vm => vm.GreetUser, v => v.GreetUserButton));

                d(ViewModel.WhenAnyValue(vm => vm.FirstName).BindTo(this, v => v.WhatWasEntered.Text));
            });

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
