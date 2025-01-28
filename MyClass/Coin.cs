using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    public class Coin : Transform
    {

        private int frameCount = 0;
        private int animationCount = 0;


        public Coin(PointF pos, Size size) : base(pos, size)
        {

        }



        public override void DrawSprite(Graphics g)
        {
            frameCount++;
            if (frameCount <= 5)
                animationCount = 0;
            else if (frameCount > 5 && frameCount <= 10)
                animationCount = 1;
            else if (frameCount > 10 && frameCount <= 15)
                animationCount = 2;
            else if (frameCount > 15 && frameCount <= 20)
                animationCount = 3;
            else if (frameCount > 20 && frameCount <= 25)
                animationCount = 4;
            else if (frameCount > 25 && frameCount <= 30)
                animationCount = 5;
            else if (frameCount > 30 && frameCount <= 35)
                animationCount = 6;
            else if (frameCount > 35)
                frameCount = 0;
            g.DrawImage(GameController.coin, new Rectangle((int)position.X, (int)position.Y, (int)size.Width, size.Height),
                200 * animationCount, 40, 200, 170, GraphicsUnit.Pixel);
        }
    }
}
