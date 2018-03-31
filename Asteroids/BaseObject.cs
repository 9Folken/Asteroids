using System.Drawing;

namespace Asteroids
{
    internal abstract class BaseObject:ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        
        public bool Collision(ICollision obj) => obj.Rect.IntersectsWith(this.Rect);

        public Rectangle Rect => new Rectangle(Pos, Size);       

        public abstract void Draw();      

        public abstract void Update();
        

    }
}
