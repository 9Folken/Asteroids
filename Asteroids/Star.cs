using System;
using System.Drawing;

namespace Asteroids
{
    class Star:BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size){}

        

        public override void Draw​()
        {
                       
                Random r = new Random(DateTime.Now.Millisecond);
                Color color = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                SplashScreen.Buffer​.Graphics.DrawLine(new Pen(color), Pos.X - Size.Width, Pos.Y, Pos.X + Size.Width, Pos.Y);
                SplashScreen.Buffer​.Graphics.DrawLine(new Pen(color), Pos.X, Pos.Y - Size.Height, Pos.X, Pos.Y + Size.Height);
          
        }

        public override void Update​()
        {
           
            Pos​.X​​ = (Pos​.X​​ + Dir​.X);
            
            if (Pos.X < 0) Pos.X = SplashScreen.Width + Size.Width;
           
        }
    }
}
