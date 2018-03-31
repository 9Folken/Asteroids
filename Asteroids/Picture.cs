using System.Drawing;


namespace Asteroids
{
    internal class Picture:BaseObject
    {
       public Picture(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        public override void Draw​()
        {
            Image newImage = Image.FromFile("star.png");            
            SplashScreen.Buffer​.Graphics.DrawImage(newImage, Pos.X - Size.Width, Pos.Y - Size.Height, 10,10);
        }

        public override void Update​()
        {
            Pos​.X​​ = (Pos​.X​​ + Dir​.X);
            if (Pos.X < 0) Pos.X = SplashScreen.Width + Size.Width;
        }

    }
}
