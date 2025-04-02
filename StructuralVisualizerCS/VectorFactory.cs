namespace StructuralVisualizerCS;

public class VectorFactory : Vectors
{
    public override Vector MakeVectorBetween(Point p, Point q) => q - p;
    public override Vector MakeVersor(double u, double v) => new Vector(u, v).Normalized;
    public override Vector MakeVersorBetween(Point p, Point q) => MakeVectorBetween(p,q).Normalized;

}