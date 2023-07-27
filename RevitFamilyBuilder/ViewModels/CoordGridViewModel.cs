using RevitFamilyBuilder.Helpers;
using RevitFamilyBuilder.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using static RevitFamilyBuilder.Helpers.MonitorInfoProvider;

namespace RevitFamilyBuilder.ViewModels
{
    public class CoordGridViewModel : ViewModelBase
    {
        private CoordGridModel coordGridModel;
        private int startPointX;
        private int startPointY;
        private int endPointX;
        private int endPointY;
        private Point point1;
        private Point point2;
        private double containerWidth;
        private double containerHeight;
        private double margin = 10; // Adjust the margin value as desired
        private double zoomLevel = 1.0;
        private Point panOffset;

        public List<MonitorInfo> MonitorInfoList { get; set; }
        public List<GradientStop> GradientStops { get; set; }


        #region Tracks Zoom Level and Offset for Panning in View/Canvas
        public double ZoomLevel
        {
            get { return zoomLevel; }
            set
            {
                if (zoomLevel != value)
                {
                    zoomLevel = value;
                    OnPropertyChanged(nameof(ZoomLevel));
                }
            }
        }

        public Point PanOffset
        {
            get { return panOffset; }
            set
            {
                if (panOffset != value)
                {
                    panOffset = value;
                    OnPropertyChanged(nameof(PanOffset));
                }
            }
        }
        #endregion


        #region Axis Properties for Line Start/End Points
        public int StartPointX
        {
            get { return startPointX; }
            set
            {
                if (startPointX != value)
                {
                    startPointX = value;
                    OnPropertyChanged(nameof(StartPointX));
                    UpdatePoints();
                }
            }
        }

        public int StartPointY
        {
            get { return startPointY; }
            set
            {
                if (startPointY != value)
                {
                    startPointY = value;
                    OnPropertyChanged(nameof(StartPointY));
                    UpdatePoints();
                }
            }
        }

        public int EndPointX
        {
            get { return endPointX; }
            set
            {
                if (endPointX != value)
                {
                    endPointX = value;
                    OnPropertyChanged(nameof(EndPointX));
                    UpdatePoints();
                }
            }
        }

        public int EndPointY
        {
            get { return endPointY; }
            set
            {
                if (endPointY != value)
                {
                    endPointY = value;
                    OnPropertyChanged(nameof(EndPointY));
                    UpdatePoints();
                }
            }
        }
        #endregion


        #region Start/End Points for Line shown on the Canvas
        public Point StartPoint
        {
            get { return point1; }
            set
            {
                if (point1 != value)
                {
                    point1 = value;
                    OnPropertyChanged(nameof(StartPoint));
                    UpdatePoints();
                }
            }
        }

        public Point EndPoint
        {
            get { return point2; }
            set
            {
                if (point2 != value)
                {
                    point2 = value;
                    OnPropertyChanged(nameof(EndPoint));
                    UpdatePoints();
                }
            }
        }
        #endregion


        public double ContainerWidth
        {
            get { return containerWidth; }
            set
            {
                if (containerWidth != value)
                {
                    containerWidth = value;
                    OnPropertyChanged(nameof(ContainerWidth));
                }
            }
        }

        public double ContainerHeight
        {
            get { return containerHeight; }
            set
            {
                if (containerHeight != value)
                {
                    containerHeight = value;
                    OnPropertyChanged(nameof(ContainerHeight));
                }
            }
        }


        public CoordGridViewModel()
        {
            // Initialize properties and commands
            coordGridModel = new CoordGridModel();

            // Call Method to Get Monitor Info
            MonitorInfoList = MonitorInfoProvider.GetConnectedMonitors();

            // Initialize LinearGradientBrush parameters and GradientStop list
            EndPoint = new Point(0.5, 1);
            StartPoint = new Point(0.2, 0);
            GradientStops = new List<GradientStop>()
        {
            new GradientStop(Colors.Blue, 0),
            new GradientStop(Colors.Magenta, 1)
        };

            point1 = new Point(60, 60);
            point2 = new Point(600, 600);
            startPointX = 60;
            startPointY = 60;
            endPointX = 600;
            endPointY = 600;

            // Register Increment Command
            IncrementCommand = new RelayCommand(IncrementButton_Command);
        }

        private void UpdatePoints()
        {
            StartPoint = new Point(StartPointX, StartPointY);
            EndPoint = new Point(EndPointX, EndPointY);

            // Calculate container dimensions
            double maxX = Math.Max(StartPoint.X, EndPoint.X);
            double maxY = Math.Max(StartPoint.Y, EndPoint.Y);
            ContainerWidth = maxX + margin;  // Add some margin to the dimensions
            ContainerHeight = maxY + margin;
        }




        public RelayCommand IncrementCommand { get; private set; }
        private void IncrementButton_Command()
        {
            // Get Name of Button and split by "_" charactor.
            // The first string will contain the name of the property.
            // The second string will contain eather a 1 for +1 or 0 for -1
            // Add or Subtract One from parameter value.
            // Call notify property changed.

        }
    }










    //public class CoordGridViewModel1 : ViewModelBase
    //{
    //    private CoordGridModel coordGridModel;
    //    public List<MonitorInfo> MonitorInfoList { get; set; }
    //    public List<GradientStop> GradientStops { get; set; }


    //    // Start Point Axis Parameters
    //    public int StartPointX { get; set; }
    //    public int StartPointY { get; set; }

    //    // End Point Axis Parameters
    //    public int EndPointX { get; set; }
    //    public int EndPointY { get; set; }

    //    // Start/End Coordinate Point Parameters
    //    public Point EndPoint { get; set; }
    //    public Point StartPoint { get; set; }


    //    public CoordGridViewModel()
    //    {
    //        // Initialize properties and commands
    //        coordGridModel = new CoordGridModel();

    //        // Call Method to Get Monitor Info
    //        MonitorInfoList = MonitorInfoProvider.GetConnectedMonitors();

    //        // Initialize LinearGradientBrush parameters and GradientStop list
    //        EndPoint = new Point(0.5, 1);
    //        StartPoint = new Point(0.2, 0);
    //        GradientStops = new List<GradientStop>()
    //        {
    //            new GradientStop(Colors.Blue, 0),
    //            new GradientStop(Colors.Magenta, 1)
    //        };
    //    }






    //    public double GridLineSpacing
    //    {
    //        get { return coordGridModel.GridLineSpacing; }
    //        set
    //        {
    //            coordGridModel.GridLineSpacing = value;
    //            OnPropertyChanged(nameof(GridLineSpacing));
    //        }
    //    }

    //    public double GridSize
    //    {
    //        get { return coordGridModel.GridSize; }
    //        set
    //        {
    //            coordGridModel.GridSize = value;
    //            OnPropertyChanged(nameof(GridSize));
    //        }
    //    }
    //}
}






//    public class CoordGridViewModel1 : ViewModelBase
//    {
//        private CoordGridModel coordGridModel;
//        public List<MonitorInfo> MonitorInfoList { get; set; }

//        public CoordGridViewModel()
//        {
//            // Initialize properties and commands
//            coordGridModel = new CoordGridModel();

//            // Call Method to Get Monitor Info
//            MonitorInfoList = MonitorInfoProvider.GetConnectedMonitors();
//        }









//        public double GridLineSpacing
//        {
//            get { return coordGridModel.GridLineSpacing; }
//            set
//            {
//                coordGridModel.GridLineSpacing = value;
//                OnPropertyChanged(nameof(GridLineSpacing));
//            }
//        }

//        public double GridSize
//        {
//            get { return coordGridModel.GridSize; }
//            set
//            {
//                coordGridModel.GridSize = value;
//                OnPropertyChanged(nameof(GridSize));
//            }
//        }

//        // Add other properties and commands for interacting with the grid
//        // ...


//    }
//}
