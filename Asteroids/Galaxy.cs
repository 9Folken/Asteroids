using System;

using System.Drawing;


namespace Asteroids
{
    class Galaxy:BaseObject
    {
        public Galaxy(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        public override void Draw​()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            Image newImage = Image.FromFile("galaxy.png");
            SplashScreen.Buffer​.Graphics.DrawImage(newImage, Pos.X - Size.Width, Pos.Y - Size.Height, r.Next(15,25), r.Next(15, 25));
        }

        public override void Update​()
        {
            Pos​.X​​ = (Pos​.X​​ + Dir​.X);
            if (Pos.X < 0) Pos.X = SplashScreen.Width + Size.Width;
        }
    }
}
