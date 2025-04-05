namespace StructuralVisualizer1;

public class Segment(Point start, Point end)
{

    public Point Start { get; } = start;
    public Point End { get; } = end;

    public Vector DirectionVector => new VectorFactory().MakeVectorBetween(Start, End);

    public Vector DirectionVersor => new VectorFactory().MakeVersorBetween(Start, End);

    public Vector NormalVersor => DirectionVersor.Perpendicular;

    public double Length => Start.DistanceTo(Start, End);

    public Point PointAt(double t)
    {
        new TParam().EnsureValid(t);
        return Start.Displaced(DirectionVector, t);
    }

    public Point Middle => PointAt(new TParam().Middle);

    public Point ClosestPointTo(Point p)
    {
        Vector v = new VectorFactory().MakeVectorBetween(Start, p);
        Vector d = DirectionVersor;
        double vs = v.ProjectionOver(d);

        return vs < 0 ? Start : (vs > 0 ? End : Start.Displaced(d, vs));

    }

    public double DistanceTo(Point p) => p.DistanceTo(ClosestPointTo(p), p);

    public Point? IntersectionWith(Segment other)
    {
        Vector d1 = DirectionVector, d2 = other.DirectionVector;
        
        if (d1.IsParallelTo(d1, d2))
        {
            return null;
        }

        double crossProduct = d1.Cross(d1,d2);
        Vector delta = other.Start - this.Start;
        double t1 = (delta.U * d2.V - delta.V * d2.U) / crossProduct;
        double t2 = (delta.U * d1.V - delta.V * d1.U) / crossProduct;

        if (new TParam().IsValid(t1) && new TParam().IsValid(t2))
        {
            return this.PointAt(t1);
        }
        else return null;

    }
    protected bool Equals(Segment other)
    {
        return Start.Equals(other.Start) && End.Equals(other.End);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Segment)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Start, End);
    }
    
    public override  string ToString() => "(" + Start + ", " + End + ")"; 
}

