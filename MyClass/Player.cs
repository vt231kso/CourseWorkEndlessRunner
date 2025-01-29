using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    public class Player : Physics
    {

        public int framesCount = 0;
        public int animationCount = 0;
        public int score = 0;
        private int distanceCounter;
        private BitmapImage playerImage;
        public Player(PointF position, Size size, Image playerImage) : base(position, size)
        {
            this.playerImage = playerImage;
            framesCount = 0;
            score = 0;
            distanceCounter = 0;
        }
        public void UpdateScore()
        {
            distanceCounter += 7; 
            if (distanceCounter >= 100)
            {
                score++;
                distanceCounter = 0; 
            }
        }
        public override void DrawSprite(Graphics g)
        {
            if (isCrouching)
            {
                DrawNeededSprite(g, 0, 290, 125, 145, 0, 1.35f);
            }
            else if (isJumping)
            {
                DrawNeededSprite(g, 0, 145, 125, 145, 0, 1.35f);

            }

            else
            {
                DrawNeededSprite(g, 0, 0, 125, 145, 125, 1.35f);
            }

        }
        public void DrawNeededSprite(Graphics g, int srcX, int srcY, int width, int height, int delta, float multiplier)
        {
            framesCount++;
            animationCount++;
            if (framesCount <= 20)
                animationCount = 0;
            else if (framesCount > 20 && framesCount <= 40)
                animationCount = 1;
            else if (framesCount > 40&& framesCount<=60)
                animationCount = 2;
            else if (framesCount > 60)
                framesCount = 0;
            g.DrawImage(playerImage, new Rectangle(new Point((int)position.X, (int)position.Y), new Size((int)(size.Width * multiplier), size.Height)), srcX + delta * animationCount, srcY, width, height, GraphicsUnit.Pixel);
        }
    }
}
