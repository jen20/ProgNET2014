using System.Windows;
using ReactiveUI;

namespace Ex8
{
    public partial class MainWindowView : IViewFor<MainWindowViewModel>
    {
        //TODO: Implement the IViewFor interface using a DependencyProperty for ViewModel

        public MainWindowView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                //TODO: Add code to bind the Router to the ViewHost

                //TODO: Add code to bind the NavigateToACommand to the NavigateToA button
                //TODO: Add code to bind the NavigateToBCommand to the NavigateToB button
                //TODO: Add code to bind the BackCommand to the Back button
            });
        }
    }
}
