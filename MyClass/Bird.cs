using System.Drawing;

namespace MyClass
{
    public class Bird : Transform
    {
        int frameCount = 0;
        int srcY = 0;

        public Bird(TransformData transformData) : base(transformData) { }

        public override void DrawSprite(Graphics g)
        {
            frameCount++;
            if (frameCount <= 20)
            {
                srcY = 120;
            }
            else if (frameCount > 20 && frameCount <= 40)
            {
                srcY = 170;
            }
            else if (frameCount > 40 && frameCount <= 60)
            {
                srcY = 210;
            }

            if (frameCount > 60)
                frameCount = 0;

            g.DrawImage(
                GameController.halloween,
                new Rectangle(
                    new Point((int)TransformData.Position.X, (int)TransformData.Position.Y),
                    new Size(TransformData.Size.Width, TransformData.Size.Height)
                ),
                40, srcY, 60, 30, GraphicsUnit.Pixel
            );
        }
    }
}