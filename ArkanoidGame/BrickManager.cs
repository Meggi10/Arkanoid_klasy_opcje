using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace ArkanoidGame
{
    public class BrickManager
    {
        private Control parent;
        private Random rnd = new Random();
        public List<PictureBox> Bricks { get; private set; }
        private Color brickColor = Color.White;

        private int brickRows = 3;
        private int brickCols = 5;

        public int BrickRows
        {
            get => brickRows;
            set => brickRows = value;
        }

        public int BrickCols
        {
            get => brickCols;
            set => brickCols = value;
        }

        public Color BrickColor
        {
            get => brickColor;
            set
            {
                brickColor = value;
                foreach (var brick in Bricks)
                    brick.BackColor = brickColor;
            }
        }

        private Size brickSize = new Size(100, 32);
        public Size BrickSize
        {
            get => brickSize;
            set
            {
                brickSize = value;
                foreach(var brick in Bricks)
                    brick.Size = brickSize;
            }
        }

        private int _brickWidth = 100;
        public int BrickWidth
        {
            get => _brickWidth;
            set
            {
                _brickWidth = value;
                foreach (var brick in Bricks)
                    brick.Width = value;
            }
        }

        private int _brickHeight = 32;
        public int BrickHeight
        {
            get => _brickHeight;
            set
            {
                _brickHeight = value;
                foreach(var brick in Bricks)
                    brick.Height = value;
            }
        }

        public int RemainingBricks => Bricks.Count;
        public void SetBricks(List<PictureBox> newBricks)
        {
            Bricks = newBricks;
        }

        public BrickManager(Control parentControl)
        {
            parent = parentControl;
            Bricks = new List<PictureBox>();
        }

        public void PlaceBricks()
        {
            // Najpierw usuń poprzednie cegły z kontrolki
            RemoveBricks();

            int top = 50;
            int leftStart = 100;
            int left = leftStart;

            for (int row = 0; row < brickRows; row++)
            {
                left = leftStart;

                for (int col = 0; col < brickCols; col++)
                {
                    var brick = new PictureBox
                    {
                        Height = BrickHeight,
                        Width = BrickWidth,
                        Tag = "bricks",
                        BackColor = BrickColor,
                        Left = left,
                        Top = top
                    };

                    Bricks.Add(brick);
                    parent.Controls.Add(brick);

                    left += BrickWidth + 30; // odstęp między cegłami w poziomie
                }

                top += BrickHeight + 18; // odstęp między wierszami cegiełek
            }
        }

        public void RemoveBricks()
        {
            foreach (var brick in Bricks)
            {
                parent.Controls.Remove(brick);
            }
            Bricks.Clear();
        }

    }
}