using System;

namespace StructuralVisualizer;

public class Nums
{
    private static bool AreCloseEnough(double a, double b, double tolerance = 1e-10)
    {
        return (Math.Abs(a - b) < tolerance);
    }
    public bool IsCloseToZero(double a,  double tolerance = 1e-10)
         {
             return AreCloseEnough(a,0.0, tolerance);
         }
     public bool IsCloseToOne(double a,  double tolerance = 1e-10)
             {
                 return AreCloseEnough(a, 1.0, tolerance);
             }
    
}
