using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    public class Road : Transform
    {

        public Road() : base()
        {

        }


        public Road(PointF pos, Size size) : base(pos, size)
        {

        }

        public override void DrawSprite(Graphics g)
        {
            g.DrawImage(GameController.back, new Rectangle(new Point((int)position.X, (int)position.Y),
                new Size(size.Width, size.Height)), 130, 320, 200, 80, GraphicsUnit.Pixel);
        }


    }
}

