using System.Drawing;

namespace MyClass
{
    public class TransformData
    {
        public PointF Position { get; set; }
        public Size Size { get; set; }

        public TransformData(PointF position, Size size)
        {
            Position = position;
            Size = size;
        }
    }
}