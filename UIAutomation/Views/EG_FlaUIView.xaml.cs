using System.Windows.Controls;
using UIAutomation.ViewModels;

namespace UIAutomation.Views
{
    public partial class EG_FlaUIView : UserControl
    {
        public EG_FlaUIView()
        {
            InitializeComponent();

            EG_FlaUIViewModel viewModel = new EG_FlaUIViewModel();
            DataContext = viewModel;
        }
    }
}
