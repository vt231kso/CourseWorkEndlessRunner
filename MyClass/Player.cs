using System.Drawing;

namespace MyClass
{
    public class Player : Physics
    {
        public int FramesCount = 0;
        public int AnimationCount = 0;
        public int Score = 0;
        private int _distanceCounter;
        private readonly Image _playerImage;

        public Player(TransformData transformData, Image playerImage) 
            : base(transformData)
        {
            _playerImage = playerImage;
        }

        public override void DrawSprite(Graphics g)
        {
            if (IsCrouching)
            {
                DrawNeededSprite(g, 0, 290, 125, 145, 0, 1.35f);
            }
            else if (IsJumping)
            {
                DrawNeededSprite(g, 0, 145, 125, 145, 0, 1.35f);
            }
            else
            {
                DrawNeededSprite(g, 0, 0, 125, 145, 125, 1.35f);
            }
        }

        private void DrawNeededSprite(Graphics g, int srcX, int srcY, int width, int height, int delta, float multiplier)
        {
            FramesCount++;
            AnimationCount++;
            if (FramesCount <= 20) AnimationCount = 0;
            else if (FramesCount > 20 && FramesCount <= 40) AnimationCount = 1;
            else if (FramesCount > 40 && FramesCount <= 60) AnimationCount = 2;
            else if (FramesCount > 60) FramesCount = 0;

            g.DrawImage(
                _playerImage,
                new Rectangle(
                    new Point((int)TransformData.Position.X, (int)TransformData.Position.Y),
                    new Size((int)(TransformData.Size.Width * multiplier), TransformData.Size.Height)
                ),
                srcX + delta * AnimationCount, srcY, width, height, GraphicsUnit.Pixel
            );
        }
    }
}