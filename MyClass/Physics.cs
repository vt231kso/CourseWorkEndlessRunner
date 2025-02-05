using System;
using System.Collections.Generic;
using System.Drawing;

namespace MyClass
{
    public class Physics : Transform
    {
        public float Gravity { get; set; }
        public float Acceleration { get; set; }
        public bool IsJumping { get; set; }
        public bool IsCrouching { get; set; }

        public Physics(TransformData transformData) : base(transformData)
        {
            Gravity = 0;
            Acceleration = 0.4f;
            IsJumping = false;
            IsCrouching = false;
        }

        public void ApplyPhysics()
        {
            if (TransformData.Position.Y < 240 || IsJumping)
            {
                TransformData.Position = new PointF(
                    TransformData.Position.X,
                    TransformData.Position.Y + Gravity
                );
                Gravity += Acceleration;
            }
        }

        public bool Collide()
        {
            if (CheckCollisionWithObjects(GameController.skelets)) return true;
            if (CheckCollisionWithObjects(GameController.birds)) return true;
            if (CheckCollisionWithObjects(GameController.coins, isCoin: true)) return false;
            if (CheckCollisionWithObjects(GameController.ghoats)) return true;

            return false;
        }

        private bool CheckCollisionWithObjects<T>(IEnumerable<T> objects, bool isCoin = false) where T : Transform
        {
            foreach (var obj in objects)
            {
                if (CheckCollision(obj))
                {
                    if (isCoin) GameController.coinCount++;
                    HandleCollisionWithObject(obj);
                    return true;
                }
            }
            return false;
        }

        private bool CheckCollision(Transform obj)
        {
            PointF delta = new PointF(
                (TransformData.Position.X + TransformData.Size.Width / 2) - (obj.TransformData.Position.X + obj.TransformData.Size.Width / 2),
                (TransformData.Position.Y + TransformData.Size.Height / 2) - (obj.TransformData.Position.Y + obj.TransformData.Size.Height / 2)
            );

            return Math.Abs(delta.X) <= TransformData.Size.Width / 2 + obj.TransformData.Size.Width / 2 &&
                   Math.Abs(delta.Y) <= TransformData.Size.Height / 2 + obj.TransformData.Size.Height / 2;
        }

        private void HandleCollisionWithObject(Transform obj)
        {
            obj.TransformData.Position = new PointF(obj.TransformData.Position.X, -100);
        }

        public void Addforce()
        {
            if (!IsJumping)
            {
                IsJumping = true;
                Gravity = -10;
            }
        }
    }
}