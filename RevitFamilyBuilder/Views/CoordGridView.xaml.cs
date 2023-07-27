using RevitFamilyBuilder.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RevitFamilyBuilder.Views
{
    public partial class CoordGridView : UserControl
    {
        public CoordGridView()
        {
            InitializeComponent();

            // Initialize ViewModel and Set DataContext
            CoordGridViewModel viewModel = new CoordGridViewModel();
            DataContext = viewModel;
        }

        private void UpIncrementButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the Button Clicked as a Button
            Button clickedButton = sender as Button;

            // Get the Name of Button Clicked
            //string content = clickedButton.Name.ToString();


            //MessageBox.Show(GetParents(sender, 0));

        }

        private string GetParents(Object element, int parentLevel)
        {
            string returnValue = String.Format("[{0}] {1}", parentLevel, element.GetType());
            if (element is FrameworkElement)
            {
                Object parent0 = ((FrameworkElement)element).Parent;
                if (((FrameworkElement)element).Parent != null)
                {
                    Object parent1 = ((FrameworkElement)parent0).Parent;
                    string parentName1 = parent1.ToString();






                }
            }
            return returnValue;
        }



        private void DownIncrementButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the Button Clicked as a Button
            Button clickedButton = sender as Button;

            // Get the Name of Button Clicked
            //string content = clickedButton.Name.ToString();

        }
    }
}
