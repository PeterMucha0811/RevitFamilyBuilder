using System.Collections.ObjectModel;
using System.Linq;

namespace CanvasPanZoom.ViewModels
{
    public class PanZoomViewModel : ViewModelBase
    {
        private double _offsetX;
        public double OffsetX
        {
            get { return _offsetX; }
            set
            {
                _offsetX = value;
                OnPropertyChanged(nameof(OffsetX));
            }
        }


        private double _offsetY;
        public double OffsetY
        {
            get { return _offsetY; }
            set
            {
                _offsetY = value;
                OnPropertyChanged(nameof(OffsetY));
            }
        }


        private double _scaleFactor = 1;
        public double ScaleFactor
        {
            get { return _scaleFactor; }
            set
            {
                _scaleFactor = value;
                OnPropertyChanged(nameof(ScaleFactor));
                ROIs.ToList().ForEach(x => x.ScaleFactor = value);
            }
        }


        //  Region Of Interest (ROI) Collection
        private ObservableCollection<ROI> _rois;
        public ObservableCollection<ROI> ROIs
        {
            get { return _rois ?? (_rois = new ObservableCollection<ROI>()); }
        }
    }
}
