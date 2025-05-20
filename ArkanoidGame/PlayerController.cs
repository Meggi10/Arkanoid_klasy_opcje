using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame
{
    public class PlayerController
    {
        private PictureBox player;
        public int Speed { get; set; } = 12;
        public bool GoLeft { get; set; }
        public bool GoRight { get; set; }

        public Point Position
        {
            get => player.Location;
            set => player.Location = value;
        }

        public Color PlayerColor
        {
            get => player.BackColor;
            set => player.BackColor = value;
        }

        public PlayerController(PictureBox player)
        {
            this.player = player;
        }

        public void Move()
        {
            if (GoLeft && player.Left > 0)
                player.Left -= Speed;

            if (GoRight && player.Left < 700)
                player.Left += Speed;
        }

        public void ResetPosition()
        {
            player.Left = 337;
            player.Top = 409;
        }
    }

}
