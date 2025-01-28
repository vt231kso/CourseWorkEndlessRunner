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
            if (CheckCollisionWithObjects(GameController.skelets))
            {
                return true;
            }
            if (CheckCollisionWithObjects(GameController.birds))
            {
                return true;
            }
            if (CheckCollisionWithObjects(GameController.coins))
            {
                return false;
            }
            if (CheckCollisionWithObjects(GameController.ghoats))
            {
                return true;
            }

            return false;
        }

        private bool CheckCollisionWithObjects<T>(IEnumerable<T> objects) where T : Transform
        {
            foreach (var obj in objects)
            {
                if (CheckCollision(obj))
                {
                    HandleCollisionWithObject(obj);
                    return true;
                }
            }
            return false;
        }

        private bool CheckCollision(Transform obj)
        {
            PointF delta = new PointF();
            delta.X = (position.X + size.Width / 2) - (obj.position.X + obj.size.Width / 2);
            delta.Y = (position.Y + size.Height / 2) - (obj.position.Y + obj.size.Height / 2);

            return Math.Abs(delta.X) <= size.Width / 2 + obj.size.Width / 2 &&
                   Math.Abs(delta.Y) <= size.Height / 2 + obj.size.Height / 2;
        }

        private void HandleCollisionWithObject(Transform obj)
        {
            obj.position = new PointF(obj.position.X, -100); // Виконання дії після колізії
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
