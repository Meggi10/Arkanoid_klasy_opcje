using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame
{
    public class BallController
    {
        private PictureBox ball;
        private Random rnd = new Random();
        public int BallX { get; set; } = 5;
        public int BallY { get; set; } = 5;
        public Color BallColor
        {
            get => ball.BackColor;
            set => ball.BackColor = value;
        }
        public Point Position
        {
            get => new Point(ball.Left, ball.Top);
            set
            {
                ball.Left = value.X;
                ball.Top = value.Y;
            }
        }

        public Size Size
        {
            get => ball.Size;
            set => ball.Size = value;
        }

        public BallController(PictureBox ball, int speed)
        {
            this.ball = ball;
            BallX = speed;
            BallY = speed;
        }

        public BallController(PictureBox ball)
        {
            this.ball = ball;
        }

        public void Move()
        {
            ball.Left += BallX;
            ball.Top += BallY;

            if (ball.Left < 0 || ball.Left > 756)
                BallX = -BallX;

            if (ball.Top < 0)
                BallY = -BallY;
        }

        public void BounceOffPlayer(PictureBox player)
        {
            if (ball.Bounds.IntersectsWith(player.Bounds))
            {
                BallY = rnd.Next(5, 12) * -1;
                BallX = (BallX < 0 ? -1 : 1) * rnd.Next(5, 12);
            }
        }

        public bool BounceOffBrick(PictureBox brick)
        {
            if (ball.Bounds.IntersectsWith(brick.Bounds))
            {
                Rectangle ballRect = ball.Bounds;
                Rectangle brickRect = brick.Bounds;

                int ballBottom = ballRect.Bottom;
                int ballTop = ballRect.Top;
                int ballLeft = ballRect.Left;
                int ballRight = ballRect.Right;

                int brickBottom = brickRect.Bottom;
                int brickTop = brickRect.Top;
                int brickLeft = brickRect.Left;
                int brickRight = brickRect.Right;

                bool hitFromTopOrBottom =
                    (ballBottom >= brickTop && ballTop < brickTop) ||
                    (ballTop <= brickBottom && ballBottom > brickBottom);

                bool hitFromSides =
                    (ballRight >= brickLeft && ballLeft < brickLeft) ||
                    (ballLeft <= brickRight && ballRight > brickRight);

                if (hitFromTopOrBottom)
                {
                    BallY = -BallY;
                }
                else if (hitFromSides)
                {
                    BallX = -BallX;
                }
                else
                {
                    BallY = -BallY;
                }

                return true;
            }
            return false;
        }


        public bool IsOutOfBounds(int bottomLimit) => ball.Top > bottomLimit;

        public void ResetPosition()
        {
            ball.Left = 385;
            ball.Top = 364;
            BallX = 5;
            BallY = 5;
        }
    }

}
