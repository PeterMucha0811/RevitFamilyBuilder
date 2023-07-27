using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using RevitFamilyBuilder.DialogWindows;
using RevitFamilyBuilder.Helpers;

namespace RevitFamilyBuilder.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            // Set default values
            SnipWidth = 200;
            SnipHeight = 200;
            SnipXAxis = 100;
            SnipYAxis = 100;

            Rectangle1X = 0;
            Rectangle1Y = 0;
            Rectangle1Width = 300;
            Rectangle1Height = 300;

            Rectangle2X = -20;
            Rectangle2Y = -20;
            Rectangle2Width = -200;
            Rectangle2Height = -150;


            SnipCommand = new RelayCommand(SnipButton_Click);
        }



        // // // Coordinate Grid Properties // // //












        public int Rectangle1X { get; set; }
        public int Rectangle1Y { get; set; }
        public int Rectangle1Width { get; set; }
        public int Rectangle1Height { get; set; }

        public int Rectangle2X { get; set; }
        public int Rectangle2Y { get; set; }
        public int Rectangle2Width { get; set; }
        public int Rectangle2Height { get; set; }





        






        public RelayCommand SnipCommand { get; private set; }


        private ImageSource _snippedImage;
        public ImageSource SnippedImage
        {
            get { return _snippedImage; }
            set
            {
                _snippedImage = value;
                OnPropertyChanged(nameof(SnippedImage));
            }
        }





        private int _snipWidth;
        public int SnipWidth
        {
            get { return _snipWidth; }
            set
            {
                _snipWidth = value;
                OnPropertyChanged(nameof(SnipWidth));
            }
        }

        private int _snipHeight;
        public int SnipHeight
        {
            get { return _snipHeight; }
            set
            {
                _snipHeight = value;
                OnPropertyChanged(nameof(SnipHeight));
            }
        }

        private int _snipXAxis;
        public int SnipXAxis
        {
            get { return _snipXAxis; }
            set
            {
                _snipXAxis = value;
                OnPropertyChanged(nameof(SnipXAxis));
            }
        }

        private int _snipYAxis;
        public int SnipYAxis
        {
            get { return _snipYAxis; }
            set
            {
                _snipYAxis = value;
                OnPropertyChanged(nameof(SnipYAxis));
            }
        }



        private void SnipButton_Click()
        {
            // Defining the Screen Snip Region
            Rectangle rect = new Rectangle(SnipXAxis, SnipYAxis, SnipWidth, SnipHeight);

            // Save File Path of the Image
            string filePath = "";

            using (Bitmap bmp = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    // Capture the screen snip
                    g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);

                    // File path info for saving
                    string username = Environment.UserName;
                    string saveDir = $@"C:\Users\{username}\Downloads\";
                    string saveName = "RevitFamilyBuilder_";
                    int saveNumber = 1;
                    int maxLoopNumber = 20;
                    bool saveResult = false;

                    // Check if directory exists, add suffix, and save the image
                    if (!Directory.Exists(saveDir))
                    {
                        MessageBox.Show("Save directory does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    for (int i = 1; i <= maxLoopNumber; i++)
                    {
                        saveNumber = i;
                        filePath = Path.Combine(saveDir, $"{saveName}{saveNumber}.jpeg");

                        if (!File.Exists(filePath))
                        {
                            try
                            {
                                bmp.Save(filePath, ImageFormat.Jpeg);
                                saveResult = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"An error occurred while saving the image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                        }
                    }

                    g.Dispose();
                    bmp.Dispose();

                    if (!saveResult)
                    {
                        MessageBox.Show("Failed to save the image. Maximum number of attempts reached.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    //-- Open Custom Dialog Window --//
                    if (saveResult)
                    {
                        // Create and display the custom dialog window, passing the filePath as an argument
                        CustomDialog dialog = new CustomDialog("Image Capture Successful!!!", filePath);
                        dialog.ShowDialog();
                    }

                }
            }

            // Load the captured image and set it to SnippedImage property
            SnippedImage = new BitmapImage(new Uri(filePath));
        }
    }
}

