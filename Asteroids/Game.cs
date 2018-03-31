using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Remoting.Contexts;

namespace Asteroids
{
    internal class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }
        public static BaseObject[] _objs;
        //static Game() { }
        


        public static void Init​(Form​​ form)
        {
            //​​Графическое​​ устройство​​ для​​ вывода​​ графики
            Graphics​​ g;
            //​​ предоставляет​​ доступ​​ к​​ главному​​ буферу​​ графического​​ контекста​​ для​​ текущего​​ приложения
            _context​​ = BufferedGraphicsManager​.Current;
            g​​ = form​.CreateGraphics​(); //​​ Создаём​​ объект​​ -​​ поверхность​​ рисования​​ и​​ связываем​​ его​​ с​​ формой
                                           //​​ Запоминаем​​ размеры​​ формы
            Width​​ = form​.Width;
            Height​​ = form​.Height;
            //​​ Связываем​​ буфер​​ в​​ памяти​​ с​​ графическим​​ объектом.
            //​​ для​​ того,​​ чтобы​​ рисовать​​ в​​ буфере
            Buffer​​ = _context​.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer {Interval = 100};
            timer.Start();
            timer.Tick += Timer_Tick;
            Game.Load();
        }

        public static void Draw()
        {
           // Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawString("Paul Bykow", Font.FromHdc, Brush.Equals,)
           // Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
           // Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
          //  Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
            
        }

        public static void Load()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            _objs = new BaseObject[30*r.Next(50,100)];

            for (int i = 0; i < _objs.Length/2; i++)
                _objs[i] = new Star(new Point(r.Next(300,700), i * r.Next(5,30) ), new Point(-i, 0), new Size(3, 3));

            //for (int i = _objs.Length / 2;  i < _objs.Length; i++)
            //    _objs[i] = new BaseObject(new Point(r.Next(100, 300), i * r.Next(2, 8)), new Point(-i, 0), new Size(5, 5));
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }


        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}


