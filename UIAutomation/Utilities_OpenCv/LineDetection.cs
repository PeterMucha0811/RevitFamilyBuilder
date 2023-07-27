using OpenCvSharp;
using System;

namespace UIAutomation
{
    public class LineDetection
    {
        public void DetectLines(string imagePath)
        {
            // (1) Load the image
            Mat imgGray = new Mat(imagePath, ImreadModes.Grayscale);
            Mat imgStd = new Mat(imagePath, ImreadModes.Color);
            Mat imgProb = imgStd.Clone();


            // Canny Edge Detection (Pre-Processing)
            Mat imgCanny = new Mat(imagePath, ImreadModes.Grayscale);
            Cv2.Canny(imgGray, imgCanny, 50, 200, 3, false);


            // // // // // // // // // // // TESTING // // // // // // // // // // //
            // // // // "Applying Thresholding before Canny Edge Detection" // // //


            // Apply Thresholding to the Original/Grayscaled Image.
            Mat imgThresh = new Mat();
            Cv2.Threshold(imgGray, imgThresh, 220, 255, ThresholdTypes.Binary);


            // Canny Edge Detection (Pre-Processing)
            Mat imgCannyThresh = new Mat(imagePath, ImreadModes.Grayscale);
            Cv2.Canny(imgThresh, imgCannyThresh, 50, 200, 3, false);


            // // // // // // // // // // // TESTING // // // // // // // // // // //



            // (4) Run Probabilistic Hough Transform
            LineSegmentPoint[] segProb = Cv2.HoughLinesP(imgCannyThresh, 1, Math.PI / 180, 50, 5, 10);
            foreach (LineSegmentPoint s in segProb)
            {
                imgProb.Line(s.P1, s.P2, Scalar.Red, 1, LineTypes.AntiAlias, 0);
            }

            // (5) Show results

            // Display the original image and the binary image
            Cv2.ImShow("(1) ImageStd Grayscaled", imgGray);
            Cv2.ImShow("(2) Canny Edge Detection", imgCanny);
            Cv2.ImShow("(3) ImageStd with Thresholding Applied", imgThresh);
            Cv2.ImShow("(4) Canny/Threshold ImageStd", imgCannyThresh);
            //Cv2.ImShow("(4) Hough_line_standard", imgStd);
            Cv2.ImShow("(5) Hough_line_probabilistic", imgProb);


            // Wait for a key press and then close the windows
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();













            //// Load the binary image from file
            //Mat image = Cv2.ImRead(imagePath, ImreadModes.Grayscale);

            //// Apply Hough Line Transform to detect lines
            //LineSegmentPoint[] lines = Cv2.HoughLinesP(image, 1, Math.PI / 180, 100, 100, 10);

            //int vertical_LineCount = 0;
            //int horizontal_LineCount = 0;

            //// Filter and process the detected lines
            //foreach (var line in lines)
            //{
            //    // Calculate the length and angle of the line segment
            //    double length = Math.Sqrt(Math.Pow(line.P1.X - line.P2.X, 2) + Math.Pow(line.P1.Y - line.P2.Y, 2));
            //    double angle = Math.Atan2(line.P2.Y - line.P1.Y, line.P2.X - line.P1.X) * (180 / Math.PI);

            //    // Check if it's a vertical line based on angle
            //    if (Math.Abs(angle) == 0 || Math.Abs(angle) == 180)
            //    {
            //        // Found a vertical line
            //        Cv2.Line(image, line.P1, line.P2, new Scalar(0, 0, 255), 2); // Blue color
            //        vertical_LineCount++;
            //    }
            //    // Check if it's a horizontal line based on angle
            //    else if (Math.Abs(angle) == 90 && length >= 10)
            //    {
            //        // Found a horizontal line
            //        Cv2.Line(image, line.P1, line.P2, new Scalar(0, 255, 0), 2); // Red color
            //        horizontal_LineCount++;
            //    }
            //}

            //// Display the image with detected lines
            //Cv2.ImShow("Detected Lines", image);
            //Cv2.WaitKey(0);
            //Cv2.DestroyAllWindows();
        }
    }
}






















//using OpenCvSharp;
//using System;

//namespace UIAutomation
//{
//    public class LineDetection
//    {
//        public void DetectLines(string imagePath)
//        {
//            // Load the binary image from file
//            Mat binaryImage = Cv2.ImRead(imagePath, ImreadModes.Color);

//            // Convert the imag e to grayscale
//            Mat grayImage = new Mat();
//            Cv2.CvtColor(binaryImage, grayImage, ColorConversionCodes.BGR2GRAY);

//            // Apply thresholding to create a binary image
//            Mat binaryImage_1 = new Mat();
//            Cv2.Threshold(grayImage, binaryImage_1, 230, 255, ThresholdTypes.Binary);
//            //Cv2.ImShow("Binary Image (Thresh: 230)", binaryImage_1);

//            // REVIEW TIME "Wait for a key press and then close the windows"
//            Cv2.WaitKey(0);
//            Cv2.DestroyAllWindows();


//            // Apply Hough Line Transform to detect lines
//            LineSegmentPoint[] lines = Cv2.HoughLinesP(binaryImage_1, 1, Math.PI / 180, 50, 10, 5);


//            // Filter and process the detected lines
//            foreach (var line in lines)
//            {
//                // ChatGPT, Only look for Horizontal and Vertical Lines

//                // Calculate the length of the line segment
//                double length = Math.Sqrt(Math.Pow(line.P1.X - line.P2.X, 2) + Math.Pow(line.P1.Y - line.P2.Y, 2));

//                // Check if it's a vertical line based on pixel width
//                if (length >= 122 && Math.Abs(line.P1.Y - line.P2.Y) >= 2)
//                {
//                    // Found a vertical line
//                    Cv2.Line(binaryImage_1, line.P1, line.P2, Scalar.Red, 2);
//                }
//                // Check if it's a horizontal line based on pixel width
//                else if (length >= 12 && Math.Abs(line.P1.X - line.P2.X) >= 1 && Math.Abs(line.P1.Y - line.P2.Y) < 2)
//                {
//                    // Found a horizontal line
//                    Cv2.Line(binaryImage_1, line.P1, line.P2, Scalar.Red, 2);
//                }
//            }

//            // Display the image with detected lines
//            Cv2.ImShow("Detected Lines", binaryImage_1);
//            Cv2.WaitKey(0);
//            Cv2.DestroyAllWindows();
//        }
//    }
//}



