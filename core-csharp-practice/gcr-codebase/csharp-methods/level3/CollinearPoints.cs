// Check collinearity using slope and area
// Program to determine if three points are collinear using two methods
using System;

class CollinearPoints {
    // Entry point of the program
    static void Main(string[] args) {
        // Define three points
        double x1 = 2, y1 = 4;
        double x2 = 4, y2 = 6;
        double x3 = 6, y3 = 8;

        // Check collinearity using both methods
        Console.WriteLine("Collinear (Slope) = " + IsCollinearSlope(x1, y1, x2, y2, x3, y3));
        Console.WriteLine("Collinear (Area) = " + IsCollinearArea(x1, y1, x2, y2, x3, y3));
    }

    // Method 1: Check collinearity using slope comparison
    static bool IsCollinearSlope(double x1, double y1, double x2, double y2, double x3, double y3) {
        // Calculate slopes between point pairs
        double slopeAB = (y2 - y1) / (x2 - x1);
        double slopeBC = (y3 - y2) / (x3 - x2);
        double slopeAC = (y3 - y1) / (x3 - x1);
        // Points are collinear if all slopes are equal
        return slopeAB == slopeBC && slopeBC == slopeAC;
    }

    // Method 2: Check collinearity using area of triangle
    static bool IsCollinearArea(double x1, double y1, double x2, double y2, double x3, double y3) {
        // Calculate area of triangle formed by three points
        double area = 0.5 * (x1 * (y2 - y3) +
                             x2 * (y3 - y1) +
                             x3 * (y1 - y2));
        // Points are collinear if area is zero
        return area == 0;
    }
}
