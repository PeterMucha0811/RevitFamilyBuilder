﻿using System.Windows.Controls;
using UIAutomation.ViewModels;

namespace UIAutomation.Views
{
    public partial class EG_OpenCvView : UserControl
    {
        public EG_OpenCvView()
        {
            InitializeComponent();

            EG_OpenCvViewModel viewModel = new EG_OpenCvViewModel();
            DataContext = viewModel;
        }
    }
}
