using System;
using System.Windows.Forms;

namespace Asteroids
{
    static class Program
    {
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 800;
            
            SplashScreen.Init(form);
            
            form.Show();
            SplashScreen.ShowTitle();
            SplashScreen.Load();
            SplashScreen.Draw();
            Application.Run(form);
        }
    }
}
