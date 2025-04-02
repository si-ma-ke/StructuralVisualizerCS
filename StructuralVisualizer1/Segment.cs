namespace StructuralVisualizer;

public class Segment(Point start, Point end)
{

    public Point Start { get; private set; } = start;
    public Point End { get; private set; } = end;

    public Vector DirectionVector => new VectorFactory().MakeVectorBetween(Start, End);
 
    public Vector DirectionVersor => new VectorFactory().MakeVersorBetween(Start, End);

    public Vector NormalVersor => DirectionVersor.Perpendicular;

    public double Length => Start.DistanceTo(Start,End);

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
        
        return vs < 0 ? Start : (vs > 0 ? End : Start.Displaced(d,vs));
        
    }

    public double DistanceTo(Point p) => p.DistanceTo(ClosestPointTo(p), p);

}