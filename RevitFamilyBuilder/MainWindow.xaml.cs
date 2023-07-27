using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using RevitFamilyBuilder.Helpers;
using RevitFamilyBuilder.ViewModels;


namespace RevitFamilyBuilder
{
    public partial class MainWindow : Window
    {
        Point? lastCenterPositionOnTarget;
        Point? lastMousePositionOnTarget;
        Point? lastDragPoint;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize the MainViewModel and set it as the DataContext of the MainWindow
            MainViewModel viewModel = new MainViewModel();
            DataContext = viewModel;


            scrollViewer.ScrollChanged += OnScrollViewerScrollChanged;
            scrollViewer.MouseLeftButtonUp += OnMouseLeftButtonUp;
            scrollViewer.PreviewMouseLeftButtonUp += OnMouseLeftButtonUp;
            scrollViewer.PreviewMouseWheel += OnPreviewMouseWheel;

            scrollViewer.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown;
            scrollViewer.MouseMove += OnMouseMove;

            slider.ValueChanged += OnSliderValueChanged;


            // TESTING
            //countCircles = 0;
        }


        private void DisplayDataButton_Click(object sender, RoutedEventArgs e)
        {
            List<MonitorInfoProvider.MonitorInfo> monitors = MonitorInfoProvider.GetConnectedMonitors();
        }






        //private bool isDragging;
        //private Point startPoint;
        //private TranslateTransform translateTransform;

        //private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    var rectangle = (Rectangle)sender;
        //    isDragging = true;
        //    startPoint = e.GetPosition(rectangle);
        //    translateTransform = rectangle.RenderTransform as TranslateTransform;
        //    rectangle.CaptureMouse();
        //}

        //private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (isDragging)
        //    {
        //        var rectangle = (Rectangle)sender;
        //        var currentPosition = e.GetPosition(rectangle);
        //        var offset = currentPosition - startPoint;

        //        if (translateTransform != null)
        //        {
        //            translateTransform.X += offset.X;
        //            translateTransform.Y += offset.Y;
        //        }
        //    }
        //}

        //private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    var rectangle = (Rectangle)sender;
        //    isDragging = false;
        //    rectangle.ReleaseMouseCapture();
        //}

        //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //

        //int countCircles;


        #region Code behind for DockPanel Example




        //private void menuDrawRectangle_Click(object sender, RoutedEventArgs e)
        //{
        //    canvas.Children.Clear();
        //    Rectangle blueRect = new Rectangle();
        //    blueRect.Fill = Brushes.Blue;
        //    blueRect.Width = 100;
        //    blueRect.Height = 100;

        //    canvas.Children.Add(blueRect);
        //    Canvas.SetTop(blueRect, 0);
        //    Canvas.SetLeft(blueRect, 0);

        //    countCircles = 0;
        //}

        //private void menuDrawRedRectangle_Click(object sender, RoutedEventArgs e)
        //{
        //    canvas.Children.Clear();
        //    Rectangle redRect = new Rectangle();
        //    redRect.Fill = Brushes.Red;
        //    redRect.Width = 100;
        //    redRect.Height = 100;

        //    canvas.Children.Add(redRect);
        //    Canvas.SetBottom(redRect, 0);
        //    Canvas.SetRight(redRect, 0);

        //    countCircles = 0;
        //}

        //private void menuSetCircle_Click(object sender, RoutedEventArgs e)
        //{
        //    if (countCircles <= 0)
        //    {
        //        canvas.Children.Clear();
        //    }
        //    Ellipse circle = new Ellipse();
        //    if (countCircles % 2 == 0)
        //    {
        //        circle.Fill = Brushes.Black;
        //    }
        //    else
        //    {
        //        circle.Fill = Brushes.White;
        //    }
        //    if (canvas.ActualWidth > canvas.ActualHeight)
        //    {
        //        circle.Width = canvas.ActualHeight / 2 - countCircles * 10;
        //        circle.Height = circle.Width;
        //    }
        //    else
        //    {
        //        circle.Width = canvas.ActualWidth / 2 - countCircles * 10;
        //        circle.Height = circle.Width;
        //    }

        //    canvas.Children.Add(circle);
        //    Canvas.SetLeft(circle, canvas.ActualWidth / 2 - circle.Width / 2);
        //    Canvas.SetTop(circle, canvas.ActualHeight / 2 - circle.Height / 2);
        //    countCircles++;
        //}

        //private void menuCheckerboard_Click(object sender, RoutedEventArgs e)
        //{
        //    canvas.Children.Clear();
        //    int squareWidth;
        //    if (canvas.ActualWidth > canvas.ActualHeight)
        //    {
        //        squareWidth = (int)(canvas.ActualHeight / 8);
        //    }
        //    else
        //    {
        //        squareWidth = (int)(canvas.ActualWidth / 8);
        //    }

        //    for (int row = 0; row < 8; row++)
        //    {
        //        for (int col = 0; col < 8; col++)
        //        {
        //            Rectangle r = new Rectangle();
        //            if ((row + col) % 2 == 0)
        //            {
        //                r.Fill = Brushes.Black;
        //            }
        //            else
        //            {
        //                r.Fill = Brushes.Red;
        //            }
        //            r.Width = squareWidth;
        //            r.Height = squareWidth;
        //            canvas.Children.Add(r);
        //            Canvas.SetLeft(r, col * squareWidth);
        //            Canvas.SetTop(r, row * squareWidth);
        //        }
        //    }
        //    countCircles = 0;

        //}

        //private void menuFunky_Click(object sender, RoutedEventArgs e)
        //{
        //    canvas.Children.Clear();
        //    Random r = new Random();
        //    int numberOfItemrs = r.Next(5, 20);
        //    for (int col = 0; col < numberOfItemrs; col++)
        //    {
        //        Ellipse ellipse = new Ellipse();

        //        if ((r.Next(10)) % 10 <= 8)
        //        {
        //            ellipse.Fill = new SolidColorBrush(Color.FromArgb((byte)(r.Next(120, 255)), (byte)(r.Next(255)), (byte)(r.Next(120, 255)), (byte)(r.Next(120, 255))));

        //        }
        //        else
        //        {
        //            LinearGradientBrush myBrush = new LinearGradientBrush();
        //            myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
        //            myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.5));
        //            myBrush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));

        //            ellipse.Fill = myBrush;
        //            //check https://docs.microsoft.com/en-us/dotnet/framework/wpf/graphics-multimedia/wpf-brushes-overview
        //            //for other brush ideas
        //        }
        //        ellipse.Width = canvas.ActualWidth / r.Next(2, 8);
        //        ellipse.Height = canvas.ActualWidth / r.Next(2, 8);
        //        canvas.Children.Add(ellipse);
        //        Canvas.SetLeft(ellipse, r.Next(0, (int)(canvas.ActualWidth - ellipse.Width)));
        //        Canvas.SetTop(ellipse, r.Next(0, (int)(canvas.ActualHeight - ellipse.Height)));
        //    }
        //    countCircles = 0;
        //}

        //private void menuLines_Click(object sender, RoutedEventArgs e)
        //{
        //    Line line = new Line();
        //    line.Stroke = Brushes.ForestGreen;
        //    line.StrokeThickness = 8;
        //    line.X1 = 0;
        //    line.X2 = canvas.ActualWidth;
        //    line.Y1 = canvas.ActualHeight / 2;
        //    line.Y2 = canvas.ActualHeight / 2;
        //    canvas.Children.Add(line);



        //    Path curvedLine = new Path();
        //    curvedLine.Stroke = Brushes.DeepSkyBlue;
        //    curvedLine.StrokeThickness = 2;

        //    PathGeometry myGeometry = new PathGeometry();
        //    PathFigureCollection figureCollection = new PathFigureCollection();
        //    PathFigure pathFigure = new PathFigure();
        //    pathFigure.StartPoint = new Point(10, 100);
        //    PathSegmentCollection psc = new PathSegmentCollection();
        //    BezierSegment bs = new BezierSegment();
        //    bs.Point1 = new Point(100, 0);
        //    bs.Point2 = new Point(200, 200);
        //    bs.Point3 = new Point(300, 100);
        //    psc.Add(bs);
        //    pathFigure.Segments = psc;
        //    figureCollection.Add(pathFigure);
        //    myGeometry.Figures = figureCollection;
        //    curvedLine.Data = myGeometry;
        //    canvas.Children.Add(curvedLine);


        //}

        //private void menuText_Click(object sender, RoutedEventArgs e)
        //{
        //    // Create string to draw.
        //    String drawString = "Sample Text";

        //    // Create font and brush.
        //    Label label = new Label();
        //    label.FontFamily = new FontFamily("Times New Roman");
        //    label.FontWeight = FontWeights.Bold;
        //    label.FontSize = 16;
        //    label.Foreground = Brushes.Black;
        //    label.Content = drawString;
        //    label.LayoutTransform = new RotateTransform(-45);

        //    canvas.Children.Add(label);
        //    Canvas.SetLeft(label, canvas.ActualWidth / 2 - label.ActualWidth / 2);

        //}



        #endregion








        //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //








        void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (lastDragPoint.HasValue)
            {
                Point posNow = e.GetPosition(scrollViewer);

                double dX = posNow.X - lastDragPoint.Value.X;
                double dY = posNow.Y - lastDragPoint.Value.Y;

                lastDragPoint = posNow;

                scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - dX);
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - dY);
            }
        }

        void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mousePos = e.GetPosition(scrollViewer);
            if (mousePos.X <= scrollViewer.ViewportWidth && mousePos.Y < scrollViewer.ViewportHeight) //make sure we still can use the scrollbars
            {
                scrollViewer.Cursor = Cursors.SizeAll;
                lastDragPoint = mousePos;
                Mouse.Capture(scrollViewer);
            }
        }

        void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            lastMousePositionOnTarget = Mouse.GetPosition(grid);

            if (e.Delta > 0)
            {
                slider.Value += 1;
            }
            if (e.Delta < 0)
            {
                slider.Value -= 1;
            }

            e.Handled = true;
        }

        void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            scrollViewer.Cursor = Cursors.Arrow;
            scrollViewer.ReleaseMouseCapture();
            lastDragPoint = null;
        }

        void OnSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            scaleTransform.ScaleX = e.NewValue;
            scaleTransform.ScaleY = e.NewValue;

            var centerOfViewport = new Point(scrollViewer.ViewportWidth / 2, scrollViewer.ViewportHeight / 2);
            lastCenterPositionOnTarget = scrollViewer.TranslatePoint(centerOfViewport, grid);
        }

        void OnScrollViewerScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange != 0 || e.ExtentWidthChange != 0)
            {
                Point? targetBefore = null;
                Point? targetNow = null;

                if (!lastMousePositionOnTarget.HasValue)
                {
                    if (lastCenterPositionOnTarget.HasValue)
                    {
                        var centerOfViewport = new Point(scrollViewer.ViewportWidth / 2, scrollViewer.ViewportHeight / 2);
                        Point centerOfTargetNow = scrollViewer.TranslatePoint(centerOfViewport, grid);

                        targetBefore = lastCenterPositionOnTarget;
                        targetNow = centerOfTargetNow;
                    }
                }
                else
                {
                    targetBefore = lastMousePositionOnTarget;
                    targetNow = Mouse.GetPosition(grid);

                    lastMousePositionOnTarget = null;
                }

                if (targetBefore.HasValue)
                {
                    double dXInTargetPixels = targetNow.Value.X - targetBefore.Value.X;
                    double dYInTargetPixels = targetNow.Value.Y - targetBefore.Value.Y;

                    double multiplicatorX = e.ExtentWidth / grid.Width;
                    double multiplicatorY = e.ExtentHeight / grid.Height;

                    double newOffsetX = scrollViewer.HorizontalOffset - dXInTargetPixels * multiplicatorX;
                    double newOffsetY = scrollViewer.VerticalOffset - dYInTargetPixels * multiplicatorY;

                    if (double.IsNaN(newOffsetX) || double.IsNaN(newOffsetY))
                    {
                        return;
                    }

                    scrollViewer.ScrollToHorizontalOffset(newOffsetX);
                    scrollViewer.ScrollToVerticalOffset(newOffsetY);
                }
            }
        }

    }
}




