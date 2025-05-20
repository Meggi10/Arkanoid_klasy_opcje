using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ArkanoidGame
{
    public partial class Arkanoid : Form
    {
        GameManager gameManager;
        BrickManager brickManager;
        BallController ballController;
        PlayerController playerController;

        private int totalBricks;

        public Arkanoid(Color ballColor, Color paddleColor, Color brickColor, int ballSpeed, int brickRows, int brickCols)
        {
            InitializeComponent();

            gameManager = new GameManager();

            brickManager = new BrickManager(this)
            {
                BrickColor = brickColor,
                BrickRows = brickRows,
                BrickCols = brickCols
            };

            ballController = new BallController(ball, ballSpeed);
            playerController = new PlayerController(player);

            ball.BackColor = ballColor;
            player.BackColor = paddleColor;

            totalBricks = brickRows * brickCols;

            StartGame();
        }

        private void StartGame()
        {
            brickManager.RemoveBricks(); // Wyczyœæ stare
            brickManager.PlaceBricks();
            gameManager.Reset();
            ballController.ResetPosition();
            playerController.ResetPosition();

            timer.Start();
            txtScore.Text = "Score: 0";
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + gameManager.Score;

            playerController.Move();
            ballController.Move();
            ballController.BounceOffPlayer(player);

            foreach (var brick in brickManager.Bricks.ToList())
            {
                if (ballController.BounceOffBrick(brick))
                {
                    gameManager.AddScore(1);
                    this.Controls.Remove(brick);
                    brickManager.Bricks.Remove(brick);
                    break;
                }
            }

            if (gameManager.Score >= totalBricks)
            {
                gameManager.EndGame("You win! Press Enter to play again!", timer, txtScore);
            }

            if (ballController.IsOutOfBounds(489))
            {
                gameManager.EndGame("You lose! Press Enter to play again!", timer, txtScore);
            }
        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) playerController.GoLeft = true;
            if (e.KeyCode == Keys.Right) playerController.GoRight = true;
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) playerController.GoLeft = false;
            if (e.KeyCode == Keys.Right) playerController.GoRight = false;

            if (e.KeyCode == Keys.Enter && gameManager.IsGameOver)
            {
                StartGame();
            }
        }

        private void Arkanoid_Load(object sender, EventArgs e)
        {
            // opcjonalne
        }
    }
}
