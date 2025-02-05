using System.Drawing;

namespace MyClass
{
    public class Transform
    {
        public TransformData TransformData { get; protected set; }

        public Transform(TransformData transformData)
        {
            TransformData = transformData;
        }

        public virtual void DrawSprite(Graphics g) { }
    }
}