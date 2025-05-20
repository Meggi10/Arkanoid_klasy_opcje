using System;
using System.Windows.Forms;

namespace ArkanoidGame
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Otwórz najpierw menu startowe z ustawieniami
            var menu = new MenuForm();
            if (menu.ShowDialog() == DialogResult.OK)
            {
                // Jeœli u¿ytkownik klikn¹³ "Start", uruchom grê z wybranymi ustawieniami
                Application.Run(new Arkanoid(
                    menu.BallColor,
                    menu.PaddleColor,
                    menu.BrickColor,
                    menu.BallSpeed,
                    menu.BrickRows,
                    menu.BrickCols
                ));
            }
        }
    }
}
