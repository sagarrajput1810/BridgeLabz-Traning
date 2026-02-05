using System;
using System.Runtime.Intrinsics.Arm;

class RobotHazardAuditor
{
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
        if (armPrecision < 0.0 || armPrecision > 1.0)
        {
            throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");
        }
        if (workerDensity < 1 || workerDensity > 20)
        {
            throw new RobotSafetyException("Error: Worker density must be 1 - 20");
        }
        if (machineryState != "Worn" &&
    machineryState != "Faulty" &&
    machineryState != "Critical")
{
    throw new RobotSafetyException("Error: Unsupported machinery state");
}

        double machineRiskFactor = 0;
        if(machineryState == "Worn")
        {
            machineRiskFactor = 1.3;
        }
        if(machineryState == "Faulty")
        {
            machineRiskFactor = 2.0;
        }
        if(machineryState == "Critical")
        {
            machineRiskFactor = 3.0;
        }

        double Hazard_Risk = ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);
        return Hazard_Risk;
    }

    static void Main()
    {
        try
        {
            Console.WriteLine("Enter armPrecision value between 0.0 and 1.0");
            double armPrecision=double.Parse(Console.ReadLine());
            Console.WriteLine("Enter worker density value between 1 and 20");
            int workerDensity=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter machinery state (Worn/Faulty/Critical)");
            string machineryState=(Console.ReadLine());
            RobotHazardAuditor robot = new RobotHazardAuditor();
            double result=robot.CalculateHazardRisk(armPrecision,workerDensity,machineryState);
            Console.WriteLine(result);
        }
        catch (RobotSafetyException e){
            Console.WriteLine(e);
        }
    }
}