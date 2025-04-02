using StructuralVisualizer;

namespace UnitTestsStructural
{
}

namespace StructuralVisualizer1
{
    public class SegmentTest
    {

        [Fact]
        public void SegmentValid()
        {
            Segment testSegment = new Segment(new Point(400, 0), new Point(0, 400));


            Assert.Throws<CustomExceptions.TparamException>(() => testSegment.PointAt(56.7));
        }
    }
}