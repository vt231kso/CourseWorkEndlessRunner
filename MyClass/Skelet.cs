using System;
using System.Collections.Generic;
using System.Drawing;

namespace MyClass
{
    public class Skelet : Transform
    {
        int srcX = 0;
        int srcY = 0;
        int srcW = 0;
        int srcH = 0;
        public int frameCount = 0;
        public int animationCount = 0;

        public Skelet(PointF pos, Size size) : base(pos, size)
        {

        }

        private struct AnimationFrame
        {
            public int SrcX, SrcY, SrcW, SrcH, AnimationCount;

            public AnimationFrame(int SrcX, int SrcY, int SrcW, int SrcH, int AnimationCount)
            {
                this.SrcX = SrcX;
                this.SrcY = SrcY;
                this.SrcW = SrcW;
                this.SrcH = SrcH;
                this.AnimationCount = AnimationCount;
            }
        }

        private static readonly List<AnimationFrame> AnimationFrames= new List<AnimationFrame>
        {
            new AnimationFrame(340, 240, 90, 60, 0),
            new AnimationFrame(440, 240, 90, 60, 1),
            new AnimationFrame(10, 360, 130, 60, 2),
            new AnimationFrame(140, 330, 100, 90, 3),
            new AnimationFrame(280, 330, 100, 90, 4),
            new AnimationFrame(410, 330, 100, 90, 5) 
        };

        public override void DrawSprite(Graphics g)
        {
            frameCount++;

            int frameIndex = Math.Min(frameCount / 50, AnimationFrames.Count - 1);

            var frame = AnimationFrames[frameIndex];

            int srcX = frame.SrcX;
            int srcY = frame.SrcY;
            int srcW = frame.SrcW;
            int srcH = frame.SrcH;
            int animationCount = frame.AnimationCount;

            g.DrawImage(GameController.halloween, new Rectangle((int)position.X, (int)position.Y, (int)size.Width, size.Height),
                srcX, srcY, srcW, srcH, GraphicsUnit.Pixel);
        }
    }
}
