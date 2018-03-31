using System;
using System.Drawing;

namespace Asteroids
{
    internal class Asteroid : BaseObject, ICloneable
    {
        public int Power { get; set; }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.FillEllipse(Brushes.White,Pos.X,Pos.Y,Size.Width,Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > SplashScreen.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > SplashScreen.Height) Dir.Y = -Dir.Y;
        }

        public object Clone()
        {
            Asteroid asteroid = new Asteroid(new Point(Pos.X,Pos.Y), new Point(Dir.X,Dir.Y), new Size(Size.Width,Size.Height));
            asteroid.Power = Power;

            return asteroid;
        }
    }
}
