using CanvasPanZoom.Models.Enums;
using CanvasPanZoom.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;


namespace CanvasPanZoom
{
    public partial class MainWindow : Window
    {
        public PanZoomViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel = new PanZoomViewModel();

            ViewModel.ROIs.Add(new ROI() { ScaleFactor = ViewModel.ScaleFactor, X = 150, Y = 150, Height = 200, Width = 200, Shape = Shapes.Square });

            ViewModel.ROIs.Add(new ROI() { ScaleFactor = ViewModel.ScaleFactor, X = 50, Y = 230, Height = 102, Width = 300, Shape = Shapes.Round });
        }

        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            //TODO: Detect whether a ROI is being resized / dragged and prevent Panning if so.
            IsPanning = true;
            ViewModel.OffsetX = (ViewModel.OffsetX + (((e.HorizontalChange / 10) * -1) * ViewModel.ScaleFactor));
            ViewModel.OffsetY = (ViewModel.OffsetY + (((e.VerticalChange / 10) * -1) * ViewModel.ScaleFactor));

            scr.ScrollToVerticalOffset(ViewModel.OffsetY);
            scr.ScrollToHorizontalOffset(ViewModel.OffsetX);

            IsPanning = false;
        }

        private bool IsPanning { get; set; }

        private void ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (!IsPanning)
            {
                ViewModel.OffsetX = e.HorizontalOffset;
                ViewModel.OffsetY = e.VerticalOffset;
            }
        }
    }
}
