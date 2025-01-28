using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    public class Bird : Transform
    {

        int frameCount = 0;
        int srcY = 0;

        public Bird(PointF pos, Size size) : base(pos, size)
        {
        }

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

            g.DrawImage(GameController.halloween, new Rectangle(new Point((int)position.X, (int)position.Y), new Size(size.Width, size.Height)), 40, srcY, 60, 30, GraphicsUnit.Pixel);
        }
    }
}
