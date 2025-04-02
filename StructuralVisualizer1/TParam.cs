namespace StructuralVisualizer;

public class TParam
{
   private const double Min = 0;
   private const double Max = 1.0;
   public double Middle = 0.5;


   public double Make(double value) => value < Min ? Min : (value > Max ? Max : value);
   public void EnsureValid(double t)
   {
      if (!IsValid(t)) throw new CustomExceptions.TparamException("TParam not in range. It is " + t);

   }

   private bool IsValid(double t) => (t < Min || t > Max) ? false : true;
   
   
   
}


