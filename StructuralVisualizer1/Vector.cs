namespace StructuralVisualizer1;

public class Vector(double u = 0, double v = 0)
{
    protected bool Equals(Vector other)
    {
        return U.Equals(other.U) && V.Equals(other.V);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Vector)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (U.GetHashCode() * 397) ^ V.GetHashCode();
        }
    }


    public double U { get; private set; } = u;
    public double V { get; private set; } = v;
    
    public static Vector operator +(Vector a, Vector b) => new Vector(a.U + b.U, a.V + b.V);
    public static Vector operator -(Vector a, Vector b) => new Vector(a.U - b.U, a.V - b.V);
    public static bool operator ==(Vector a, Vector b) => (ReferenceEquals(a,b)) | (new Nums().IsCloseToZero(a.U = b.U) & new Nums().IsCloseToZero((a.V = b.V)));
    public static bool operator !=(Vector a, Vector b) => ! (ReferenceEquals(a,b) | (new Nums().IsCloseToZero(a.U = b.U) & new Nums().IsCloseToZero((a.V = b.V))));
    public override  string ToString() => "(" + U + ", " + V + ")"; 
    public Vector ScaledBy(double factor) => new Vector(factor*U, factor*V);
    
    public double Norm => Math.Sqrt(U*U + V*V);
    
//    public double normalized

    public bool IsNormal => new Nums().IsCloseToOne(Norm); 
    
    public Vector Normalized => ScaledBy(1.0/Norm);

    public Vector WithLength(double length) => Normalized.ScaledBy(length);
    
    public double Dot(Vector a, Vector b) => a.U*b.U + a.V*b.V;

    public double ProjectionOver(Vector direction) => Dot(this,direction.Normalized);
    
    public double Cross(Vector a, Vector b) => a.U*b.V - a.V*b.U;

    public bool IsParallelTo(Vector a, Vector b) => new Nums().IsCloseToZero(Cross(a, b));
    
    public bool IsPerpendicularTo(Vector a, Vector b) => new Nums().IsCloseToZero(Dot(a, b));

    public double AngleValueTo(Vector a, Vector b) => Dot(a, b) / (a.Norm * b.Norm);

    public double AngleTo(Vector a, Vector b) => Math.CopySign(AngleValueTo(a, b), Cross(a, b));
    
   public Vector RotatedRadians(double radians) => new Vector(Math.Cos(radians)*Math.Sin(radians), Math.Sin(radians)*Math.Cos(radians)); 

   public Vector Perpendicular => new Vector(-V, U);
   
   public Vector Opposite => new Vector(-U, -V);

   public Vector Sine => new Vector(V / Norm);

   public Vector Cosine => new Vector(U / Norm);
}