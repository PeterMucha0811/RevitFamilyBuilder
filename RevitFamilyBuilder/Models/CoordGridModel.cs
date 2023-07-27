using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace RevitFamilyBuilder.Models
{
    public class CoordGridModel
    {
        private double gridLineSpacing;
        private double gridSize;

        public double GridLineSpacing
        {
            get { return gridLineSpacing; }
            set { gridLineSpacing = value; }
        }

        public double GridSize
        {
            get { return gridSize; }
            set { gridSize = value; }
        }

        // Add other properties and methods for grid functionality
        // ...

        // Example method for calculating coordinates
        public Point CalculateCoordinates(double x, double y)
        {
            // Perform coordinate calculation logic
            // ...

            //return new Point(calculatedX, calculatedY);
            return new Point(1, 2);
        }
    }
}
