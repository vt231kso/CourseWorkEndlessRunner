using System.Drawing;

namespace MyClass
{
    public class Ghoast : Transform
    {
        int frameCount = 0;
        int srcX = 0;

        public Ghoast(TransformData transformData) : base(transformData) { }

        public override void DrawSprite(Graphics g)
        {
            frameCount++;
            if (frameCount <= 20)
            {
                srcX = 10;
            }
            else if (frameCount > 20 && frameCount <= 40)
            {
                srcX = 150;
            }
            else if (frameCount > 40 && frameCount <= 60)
            {
                srcX = 290;
            }
            else if (frameCount > 60 && frameCount <= 80)
            {
                srcX = 410;
            }

            if (frameCount > 80)
                frameCount = 0;

            g.DrawImage(
                GameController.halloween,
                new Rectangle(
                    new Point((int)TransformData.Position.X, (int)TransformData.Position.Y),
                    new Size(TransformData.Size.Width, TransformData.Size.Height)
                ),
                srcX, 10, 130, 80, GraphicsUnit.Pixel
            );
        }
    }
}