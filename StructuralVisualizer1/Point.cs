using System;

namespace StructuralVisualizer;

public class Point(double x = 0, double y = 0)
{
    public double X { get; } = x;

    public double Y { get; } = y;

    public double DistanceTo(Point p, Point q)
    {
        double deltaX = p.X - q.X;
        double deltaY = p.Y - q.Y;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        
    }

    public Point Displaced(Vector v, double times)
    {
        Vector scaledVec = v.ScaledBy(times);
        return new Point(X + scaledVec.U, Y + scaledVec.V);
    }
    
    
    
    protected bool Equals(Point other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Point)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public static Point operator +(Point p, Point q) => new Point(p.X + q.X, p.Y + q.Y);
    public static Vector operator -(Point p, Point q) => new Vector(p.X - q.X, p.Y - q.Y);
    
}