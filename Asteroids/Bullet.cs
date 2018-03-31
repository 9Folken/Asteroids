using System.Drawing;

namespace Asteroids
{
    internal class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, 
                Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X += 3;
        }
    }
}
