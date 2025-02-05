using System.Drawing;

namespace MyClass
{
    public class Road : Transform
    {
        public Road(TransformData transformData) : base(transformData) { }

        public override void DrawSprite(Graphics g)
        {
            g.DrawImage(
                GameController.back,
                new Rectangle(
                    new Point((int)TransformData.Position.X, (int)TransformData.Position.Y),
                    new Size(TransformData.Size.Width, TransformData.Size.Height)
                ),
                130, 320, 200, 80, GraphicsUnit.Pixel
            );
        }
    }
}