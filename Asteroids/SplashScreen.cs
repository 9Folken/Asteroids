using System;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    internal class SplashScreen
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }
        public static BaseObject[] _objs;

        private static Bullet _bullet;
        private static Asteroid[] _asteroids;

        private Button btnStart;
        private Button btnAchievement;
        private Button btnExit;

        public static void Init​(Form​​ form)
        {
            //​​Графическое​​ устройство​​ для​​ вывода​​ графики
            Graphics​​ g;


            //​​ предоставляет​​ доступ​​ к​​ главному​​ буферу​​ графического​​ контекста​​ для​​ текущего​​ приложения
            _context​​ = BufferedGraphicsManager​.Current;

            //​​ Создаём​​ объект​​ -​​ поверхность​​ рисования​​ и​​ связываем​​ его​​ с​​ формой
            g​​ = form​.CreateGraphics​(); 

            //​​ Запоминаем​​ размеры​​ формы
            Width​​ = form​.Width;
            Height​​ = form​.Height - 120;

            //​​ Связываем​​ буфер​​ в​​ памяти​​ с​​ графическим​​ объектом.
            //​​ для​​ того,​​ чтобы​​ рисовать​​ в​​ буфере
            Buffer​​ = _context​.Allocate(g, new Rectangle(0, 0, Width, Height));

            //................Butons.....................

            Button btnStart = new Button
            {
                
                Location = new System.Drawing.Point(10, 700),
                Name = "btnStart",
                Size = new System.Drawing.Size(75, 23),
                TabIndex = 0,
                Text = "Start!",
                UseVisualStyleBackColor = true
            };

            Button btnAchievement = new Button
            {

                Location = new System.Drawing.Point(100, 700),
                Name = "btnAchievement",
                Size = new System.Drawing.Size(85, 23),
                TabIndex = 0,
                Text = "Achievements",
                UseVisualStyleBackColor = true
            };

            Button btnExit = new Button
            {

                Location = new System.Drawing.Point(700, 700),
                Name = "btnExit",
                Size = new System.Drawing.Size(75, 23),
                TabIndex = 0,
                Text = "Exit",
                UseVisualStyleBackColor = true
            };


            form.Controls.Add(btnStart);
            form.Controls.Add(btnAchievement);
            form.Controls.Add(btnExit);

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
            
            Load();
        }

        public static void Draw()
        {           

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid obj in _asteroids)
                obj.Draw();
            _bullet.Draw();
            Buffer.Render();

        }

        public static void ShowTitle()
        {
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.AliceBlue);
            Buffer.Graphics.DrawString("Create by Pavel Bykow", drawFont, drawBrush, 100, 100);
            Buffer.Render();
            System.Threading.Thread.Sleep(2000);
            Buffer.Graphics.Clear(Color.AliceBlue);
        }

        public static void Load()
        {          

            Random r = new Random(DateTime.Now.Millisecond);
            _objs = new BaseObject[r.Next(150, 250)];
            _bullet = new Bullet(new Point(0,200), new Point(5,0), new Size(4,1));
            _asteroids = new Asteroid[30];
            int selector;
            int rnd = r.Next(5, 50);

            for (int i = 0; i < _objs.Length; i++)
            {
                selector = r.Next(1, 2);
                
                switch (selector)
                {
                    case 1:
                        _objs[i] = new Star(new Point(r.Next(5, Width), r.Next(5, Height)), new Point(-i, 0), new Size(r.Next(3, 7), r.Next(3, 7)));
                        break;
                    case 2:
                        // _objs[i] = new Galaxy(new Point(r.Next(5, Width), r.Next(5, Height)), new Point(-i, 0), new Size(2, 2));
                        _objs[i] = new Star(new Point(r.Next(5, Width), r.Next(5, Height)), new Point(-i, 0), new Size(r.Next(3, 7), r.Next(3, 7)));
                        break;
                    
                    default:
                        _objs[i] = new Picture(new Point(r.Next(5, Width), r.Next(5, Height)), new Point(-i, 0), new Size(10, 10));
                        break;
                }
            }

            for (int i = 0; i < _asteroids.Length; i++)
            {
                _asteroids[i] = new Asteroid(new Point(Width, r.Next(0, Height)), new Point(-rnd, rnd), new Size(15, 15));
            }

        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();

            foreach (Asteroid a in _asteroids)
            {
                a.Update();
                if (a.Collision(_bullet)) { System.Media.SystemSounds.Hand.Play(); }               
            }
            _bullet.Update();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

    }
}
