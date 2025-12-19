using System;

class EarthVolume
{
    static void Main()
    {
        double r = 6378;
        double pi = 3.14159;

        double v = (4.0 / 3) * pi * r * r * r;
        double volumeInMiles = v / (1.6 * 1.6 * 1.6);

        Console.WriteLine(
            "The volume of earth in cubic kilometers is "
                + v
                + " and cubic miles is "
                + volumeInMiles
        );
    }
}
