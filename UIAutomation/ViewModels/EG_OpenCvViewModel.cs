using System;
using System.IO;
using UIAutomation.Commands;
using Microsoft.Win32;
using OpenCvSharp;

namespace UIAutomation.ViewModels
{
    public class EG_OpenCvViewModel: ViewModelBase
    {
        public EG_OpenCvViewModel()
        {
            InitializePropertyValues();

            // Register Commands
            BrowseCommand = new RelayCommand(BrowseImage_Command);
            UploadCommand = new RelayCommand(UploadImage_Command);

            //ImageStd = new Mat();
            //ImageThreshold = new Mat();
            //ImageCanny = new Mat();
            //ImageHough = new Mat();
        }

        #region Initialize Default Property Values
        private void InitializePropertyValues()
        {
            // Set Default Properties (Thresholding)
            IsThresholdingEnabled = true;
            ThresholdingThreshold = 220;
            ThresholdingMaxval = 255;

            // Set Default Properties (Canny Edge Detection)
            IsCannyEnabled = true;
            IsL2GradientEnabled = false;
            CannyThreshold1 = 50;
            CannyThreshold2 = 200;
            CannyApertureSize = 3;

            // Set Default Properties (Probabilistic Hough Transform)
            IsHoughEnabled = true;
            HoughThreshold = 50;
            HoughMinLineLength = 5;
            HoughMaxLineGap = 10;

            //ImagePath = "C:\\Users\\peter\\Downloads\\UIAutomation_8.png";

        }
        #endregion







        #region Image File Path Info

        // Image File Path Info
        private string _imagePath;
        private bool _isPathValid;

        public string ImagePath
        { 
            get { return _imagePath; }
            set 
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath)); 

                if (File.Exists(ImagePath))
                {
                    IsPathValid = true;

                    // Check if the file extension is an image type
                    string extension = Path.GetExtension(ImagePath).ToLower();
                    bool isImage = (extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".bmp");
                    IsPathValid = isImage;
                }
                else { IsPathValid = false; }
                OnPropertyChanged(nameof(IsPathValid));
            } 
        }

        public bool IsPathValid
        {
            get { return _isPathValid; }
            set
            {
                _isPathValid = value;
                OnPropertyChanged(nameof(IsPathValid));
            }
        }

        #endregion


        #region Open CV - Images Properties

        // Open CV Images
        private Mat _imageStd;
        private Mat _imageThreshold;
        private Mat _imageCanny;
        private Mat _imageHough;

        // // Standard Image // //
        public Mat ImageStd
        {
            get { return _imageStd; }
            set
            { 
                _imageStd = value;
                OnPropertyChanged(nameof(ImageStd));
            }
        }

        // // Thresholding Image // //
        public Mat ImageThreshold
        {
            get { return _imageThreshold; }
            //set { SetProperty(ref _imageThreshold, value); }
            set
            {
                _imageThreshold = value;
                OnPropertyChanged(nameof(ImageThreshold));
            }
        }

        // // Canny Edge Detection Image // //
        public Mat ImageCanny
        {
            get { return _imageCanny; }
            set { _imageCanny = value; OnPropertyChanged(nameof(ImageCanny)); }
        }

        // // Probabilistic Hough Transform Image // //
        public Mat ImageHough
        {
            get { return _imageHough; }
            set { _imageHough = value; OnPropertyChanged(nameof(ImageHough)); }
        }

        #endregion


        #region Open CV - Images Logic

        // // Re-Run Thresholding on Image // //
        private void ReRun_Threshold()
        {
            if (ImageStd != null)
            {
                Cv2.Threshold(ImageThreshold, ImageStd,
               ThresholdingThreshold,
               ThresholdingMaxval,
               ThresholdTypes.Binary);

                OnPropertyChanged(nameof(ImageThreshold));
            }           
        }

        // // Re-Run Canny on Image // //
        private void ReRun_Canny()
        {
            if (ImageStd != null)
            {
                //// If Threshold Image is Used
                //if (IsThresholdingEnabled == true)
                //{
                //    Cv2.Canny(ImageCanny, ImageThreshold,
                //           CannyThreshold1,
                //           CannyThreshold2,
                //           CannyApertureSize,
                //           IsL2GradientEnabled);
                //}
                //// If Threshold Image is Not Used
                //else
                //{
                //    Cv2.Canny(ImageCanny, ImageStd,
                //           CannyThreshold1,
                //           CannyThreshold2,
                //           CannyApertureSize,
                //           IsL2GradientEnabled);
                //}
                //OnPropertyChanged(nameof(ImageCanny));
            }            
        }

        // // Re-Run Hough on Image // //
        private void ReRun_Hough()
        {
            // If Canny Image is Used
            if (IsCannyEnabled == true)
            {
                LineSegmentPoint[] segProb = Cv2.HoughLinesP(ImageCanny,
                        1, Math.PI / 180,
                        HoughThreshold,
                        HoughMinLineLength,
                        HoughMaxLineGap);

                foreach (LineSegmentPoint s in segProb)
                {
                    ImageHough.Line(s.P1, s.P2, Scalar.Red, 1, LineTypes.AntiAlias, 0);
                }
            }
            // If Canny is Not Used, Check if Thresholding is Used
            else if (IsThresholdingEnabled == true)
            {
                LineSegmentPoint[] segProb = Cv2.HoughLinesP(ImageThreshold,
                        1, Math.PI / 180,
                        HoughThreshold,
                        HoughMinLineLength,
                        HoughMaxLineGap);

                foreach (LineSegmentPoint s in segProb)
                {
                    ImageHough.Line(s.P1, s.P2, Scalar.Red, 1, LineTypes.AntiAlias, 0);
                }
            }
            // If Thresholding and Canny are Not Used,
            else
            {
                LineSegmentPoint[] segProb = Cv2.HoughLinesP(ImageStd,
                        1, Math.PI / 180,
                        HoughThreshold,
                        HoughMinLineLength,
                        HoughMaxLineGap);

                foreach (LineSegmentPoint s in segProb)
                {
                    ImageHough.Line(s.P1, s.P2, Scalar.Red, 1, LineTypes.AntiAlias, 0);
                }
            }

            OnPropertyChanged(nameof(ImageHough));
        }

        #endregion


        #region Thresholding Properties

        private bool _isThresholdingDirty;
        private bool _isThresholdingEnabled;
        private int _thresholdingThreshold;
        private int _thresholdingMaxval;

        public bool IsThresholdingEnabled { get { return _isThresholdingEnabled; } set { _isThresholdingEnabled = value; OnPropertyChanged(nameof(IsThresholdingEnabled)); } }

        public int ThresholdingThreshold { get { return _thresholdingThreshold; } set { _thresholdingThreshold = value; OnPropertyChanged(nameof(ThresholdingThreshold));} }

        public int ThresholdingMaxval { get { return _thresholdingMaxval; } set { _thresholdingMaxval = value; OnPropertyChanged(nameof(ThresholdingMaxval)); } }

        public bool IsThresholdingDirty { get { return _isThresholdingDirty; } set { _isThresholdingDirty = value; OnPropertyChanged(nameof(IsThresholdingDirty)); } }
        #endregion


        #region Canny Edge Detection Properties

        private bool _isCannyEnabled;
        private bool _isL2GradientEnabled;
        private int _cannyThreshold1;
        private int _cannyThreshold2;
        private int _cannyApertureSize;

        public bool IsCannyEnabled { get { return _isCannyEnabled; } set { _isCannyEnabled = value; OnPropertyChanged(nameof(IsCannyEnabled)); } }
        public bool IsL2GradientEnabled { get { return _isL2GradientEnabled; } set { _isL2GradientEnabled = value; OnPropertyChanged(nameof(IsL2GradientEnabled)); } }
        public int CannyThreshold1 { get { return _cannyThreshold1; } set { _cannyThreshold1 = value; OnPropertyChanged(nameof(CannyThreshold1)); } }
        public int CannyThreshold2 { get { return _cannyThreshold2; } set { _cannyThreshold2 = value; OnPropertyChanged(nameof(CannyThreshold2)); } }
        public int CannyApertureSize { get { return _cannyApertureSize; } set { _cannyApertureSize = value; OnPropertyChanged(nameof(CannyApertureSize)); } }

        #endregion


        #region Probabilistic Hough Transform Properties

        private bool _isHoughEnabled;
        private int _houghThreshold;
        private int _houghMinLineLength;
        private int _houghMaxLineGap;

        public bool IsHoughEnabled { get { return _isHoughEnabled; } set { _isHoughEnabled = value; OnPropertyChanged(nameof(IsHoughEnabled)); } }
        public int HoughThreshold { get { return _houghThreshold; } set { _houghThreshold = value; OnPropertyChanged(nameof(HoughThreshold)); } }
        public int HoughMinLineLength { get { return _houghMinLineLength; } set { _houghMinLineLength = value; OnPropertyChanged(nameof(HoughMinLineLength)); } }
        public int HoughMaxLineGap { get { return _houghMaxLineGap; } set { _houghMaxLineGap = value; OnPropertyChanged(nameof(HoughMaxLineGap)); } }

        #endregion


        #region ViewModel Relay Commands
        public RelayCommand UploadCommand { get; private set; }
        private void UploadImage_Command()
        {

            //Mat imgGray = Cv2.ImRead(ImagePath, ImreadModes.Grayscale);

            //ImageStd = imgGray.Clone();
            //ImageThreshold = imgGray.Clone();
            //ImageCanny = new Mat();
            //ImageHough = new Mat();

            //OnPropertyChanged(nameof(ImageStd));
            //OnPropertyChanged(nameof(ImageThreshold));
            //OnPropertyChanged(nameof(ImageCanny));
            //OnPropertyChanged(nameof(ImageHough));





            if (File.Exists(ImagePath))
            {
                // Load the image
                Mat imgGray = new Mat(ImagePath, ImreadModes.Grayscale);

                // Clone Version to be Modified 
                Mat imgWorking = imgGray.Clone();
                Mat imgStd = new Mat(ImagePath, ImreadModes.Color);







                // (Step 1) Apply Threshold
                if (IsThresholdingEnabled == true)
                {
                    Cv2.Threshold(imgGray, imgWorking,
                        ThresholdingThreshold,
                        ThresholdingMaxval,
                        ThresholdTypes.Binary);

                    // Wait for a key press and then close the windows
                    Cv2.ImShow("(Step 1) Apply Threshold", imgWorking);
                    Cv2.WaitKey(0);
                    Cv2.DestroyAllWindows();
                }

                // (Step 2) Apply Canny Edge Detection
                if (IsCannyEnabled == true)
                {
                    Cv2.Canny(imgWorking, imgWorking,
                        CannyThreshold1,
                        CannyThreshold2,
                        CannyApertureSize,
                        IsL2GradientEnabled);

                    // Wait for a key press and then close the windows
                    Cv2.ImShow("(Step 2) Apply Canny Edge Detection", imgWorking);
                    Cv2.WaitKey(0);
                    Cv2.DestroyAllWindows();
                }

                // (Step 3) Apply Probabilistic Hough Transform
                if (IsHoughEnabled == true)
                {
                    LineSegmentPoint[] segProb = Cv2.HoughLinesP(imgWorking,
                        1, Math.PI / 180,
                        HoughThreshold,
                        HoughMinLineLength,
                        HoughMaxLineGap);

                    foreach (LineSegmentPoint s in segProb)
                    {
                        imgStd.Line(s.P1, s.P2, Scalar.Red, 1, LineTypes.AntiAlias, 0);
                    }
                }


                // Wait for a key press and then close the windows
                Cv2.ImShow("(5) Hough_line_probabilistic", imgStd);
                Cv2.WaitKey(0);
                Cv2.DestroyAllWindows();



                // (Step 4) Update Image Displayed on UI
                ImageStd = imgWorking;
                OnPropertyChanged(nameof(ImageStd));







            }
        }

        public RelayCommand BrowseCommand { get; private set; }
        private void BrowseImage_Command()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ImageStd files (*.png;*.jpeg;*.jpg;*.bmp)|*.png;*.jpeg;*.jpg;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Get the selected file path and do something with it
                ImagePath = openFileDialog.FileName;

                OnPropertyChanged(nameof(ImagePath));
            }
        }

        #endregion

       
        #region ViewModel Methods

        #endregion
    }
}