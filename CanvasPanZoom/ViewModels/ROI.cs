using CanvasPanZoom.Models.Enums;

namespace CanvasPanZoom.ViewModels
{
    public class ROI : ViewModelBase
    {
        private Shapes _shape;
        public Shapes Shape
        {
            get { return _shape; }
            set
            {
                _shape = value;
                OnPropertyChanged(nameof(Shape));
            }
        }


        private double _scaleFactor;
        public double ScaleFactor
        {
            get { return _scaleFactor; }
            set
            {
                _scaleFactor = value;
                OnPropertyChanged(nameof(ScaleFactor));
                OnPropertyChanged(nameof(ActualX));
                OnPropertyChanged(nameof(ActualY));
                OnPropertyChanged(nameof(ActualHeight));
                OnPropertyChanged(nameof(ActualWidth));
            }
        }


        private double _x;
        public double X
        {
            get { return _x; }
            set
            {
                _x = value;
                OnPropertyChanged(nameof(X));
                OnPropertyChanged(nameof(ActualX));
            }
        }


        private double _y;
        public double Y
        {
            get { return _y; }
            set
            {
                _y = value;
                OnPropertyChanged(nameof(Y));
                OnPropertyChanged(nameof(ActualY));
            }
        }


        private double _height;
        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
                OnPropertyChanged(nameof(ActualHeight));
            }
        }


        private double _width;
        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
                OnPropertyChanged(nameof(ActualWidth));
            }
        }

        public double ActualX { get { return X * ScaleFactor; } }
        public double ActualY { get { return Y * ScaleFactor; } }

        public double ActualWidth { get { return Width * ScaleFactor; } }
        public double ActualHeight { get { return Height * ScaleFactor; } }
    }
}
