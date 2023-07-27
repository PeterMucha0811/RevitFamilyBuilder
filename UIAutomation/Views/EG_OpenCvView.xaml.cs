using System.Windows.Controls;
using UIAutomation.ViewModels;
using Prism.Ioc;


namespace UIAutomation.Views
{
    public partial class EG_OpenCvView : UserControl
    {
        public EG_OpenCvView()
        {
            InitializeComponent();

            // Resolve the MainViewModel using IContainerProvider
            EG_OpenCvViewModel viewModel = new EG_OpenCvViewModel();
            DataContext = viewModel;
        }
    }
}
