using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    public class Ghoast : Transform
    {

        int frameCount = 0;
      
        int srcX = 0;


        public Ghoast(PointF pos, Size size) : base(pos, size)
        {
        }

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

            g.DrawImage(GameController.halloween, new Rectangle(new Point((int)position.X, (int)position.Y), new Size(size.Width, size.Height)), srcX, 10, 130, 80, GraphicsUnit.Pixel);
        }
    }
}
