using StructuralVisualizer1;

namespace UnitTestsStructural;

public class SegmentTest
{

    [Fact]
    public void SegmentValid()
    {
        Segment testSegment = new Segment(new Point(400, 0), new Point(0, 400));


        Assert.Throws<CustomExceptions.TparamException>(() => testSegment.PointAt(56.7));
    }

    [Fact]
    public void TestPointAt()
    {
        Segment testSegment = new Segment(new Point(400, 0), new Point(0, 400));
        double t = new TParam().Make(0.25);
        Point expected = new Point(300, 100);
        Point actual = testSegment.PointAt(t);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestMiddlePoint()
    {
        Segment testSegment = new Segment(new Point(400, 0), new Point(0, 400));
        Assert.Equal(new Point(200,200),testSegment.Middle);
    }

    [Fact]
    public void TestParallelSegmentsNoIntersection()
    {
        Segment testSegment = new Segment(new Point(400, 0), new Point(0, 400));
        Segment other = new Segment(new Point(200, 0), new Point(0, 200));
        Point? actual = testSegment.IntersectionWith(other);
        Assert.Null(actual);
    }

    [Fact]
    public void TestSegmentsIntersection(){
        Segment testSegment = new Segment(new Point(400, 0), new Point(0, 400));
        Segment other = new Segment(new Point(0, 0), new Point(400, 400));
        Point? expected = new Point(200, 200);
        Point? actual = testSegment.IntersectionWith(other);
        Assert.Equal(expected, actual);
        
            
    }
}