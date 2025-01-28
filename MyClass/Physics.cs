using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    public class Physics : Transform
    {

        public float gravity;
        public float a;

        public bool isJumping;
        public bool isCrouching;//присяд

        public Physics(PointF position, Size size) : base(position, size)
        {

            gravity = 0;
            a = 0.4f;
            isJumping = false;
            isCrouching = false;
        }
        public void ApplyPhysics()
        {
            CalculatePhysics();
        }
        public void CalculatePhysics()
        {
            if (position.Y < 240 || isJumping)
            {
                position = new PointF(position.X, position.Y + gravity);
                gravity += a;
            }
            if (position.Y > 240)
                isJumping = false;
        }


        public bool Collide()
        {
            for (int i = 0; i < GameController.skelets.Count; i++)
            {
                var skelet = GameController.skelets[i];
                PointF delta = new PointF();
                delta.X = (position.X + size.Width / 2) - (skelet.position.X +skelet.size.Width / 2);
                delta.Y = (position.Y + size.Height / 2) - (skelet.position.Y + skelet.size.Height / 2);
                if (Math.Abs(delta.X) <= size.Width / 2 + skelet.size.Width / 2)
                {
                    if (Math.Abs(delta.Y) <= size.Height / 2 + skelet.size.Height / 2)
                    {
                        skelet.position = new PointF(skelet.position.X, -100);
                        return true;
                    }
                    else
                    {
                        return false;


                    }
                }
            }
            for (int i = 0; i < GameController.birds.Count; i++)
            {
                var bird = GameController.birds[i];
                PointF delta = new PointF();
                delta.X = (position.X + size.Width / 2) - (bird.position.X + bird.size.Width / 2);
                delta.Y = (position.Y + size.Height / 2) - (bird.position.Y + bird.size.Height / 2);
                if (Math.Abs(delta.X) <= size.Width / 2 + bird.size.Width / 2)
                {
                    if (Math.Abs(delta.Y) <= size.Height / 2 + bird.size.Height / 2)
                    {
                        bird.position = new PointF(bird.position.X, -100);
                        return true;
                    }
                    else
                    {
                        return false;


                    }
                }
            }
            for (int i = 0; i < GameController.coins.Count; i++)
            {
                var coin = GameController.coins[i];
                PointF delta = new PointF();
                delta.X = (position.X + size.Width / 2) - (coin.position.X + coin.size.Width / 2);
                delta.Y = (position.Y + size.Height / 2) - (coin.position.Y + coin.size.Height / 2);
                if (Math.Abs(delta.X) <= size.Width / 2 + coin.size.Width / 2)
                {
                    if (Math.Abs(delta.Y) <= size.Height / 2 + coin.size.Height / 2)
                    {
                        GameController.coinCount++;


                        coin.position = new PointF(coin.position.X, -100);

                        return false;

                    }

                }
            }
           
            for (int i = 0; i < GameController.ghoats.Count; i++)
            {
                var ghoast = GameController.ghoats[i];
                PointF delta = new PointF();
                delta.X = (position.X + size.Width / 2) - (ghoast.position.X + ghoast.size.Width / 2);
                delta.Y = (position.Y + size.Height / 2) - (ghoast.position.Y + ghoast.size.Height / 2);
                if (Math.Abs(delta.X) <= size.Width / 2 + ghoast.size.Width / 2)
                {
                    if (Math.Abs(delta.Y) <= size.Height / 2 + ghoast.size.Height / 2)
                    {
                        


                        ghoast.position = new PointF(ghoast.position.X, -100);

                        return true;

                    }
                    else
                    {
                        return false;
                        

                    }

                }
            }
            return false;
        }
        public void Addforce()
        {
            if (!isJumping)
            {
                isJumping = true;
                gravity = -10;
            }
        }
    }
}
