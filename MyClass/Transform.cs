using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyClass
{
    public class Transform
    {
        
            public PointF position { get; set; }
            public Size size { get; set; }

            public Transform()
            {

                position = PointF.Empty;
                size = Size.Empty;

            }


            public Transform(PointF pos, Size size)
            {
                this.position = pos;
                this.size = size;
            }
            public virtual void DrawSprite(Graphics g)
            {

            }
        
    }
}
