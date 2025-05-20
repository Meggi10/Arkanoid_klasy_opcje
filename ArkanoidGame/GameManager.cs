using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace ArkanoidGame
{
    public class GameManager
    {
        public bool IsGameOver { get; private set; }
        public int Score { get; private set; }
        public int Lives { get; private set; }
        public bool IsPaused { get; private set; }
        public int HighScore { get; private set; }
        public int BrickRows { get; private set; }
        public int BrickColumns { get; private set; }

        public void Reset()
        {
            Score = 0;
            IsGameOver = false;
        }

        public void AddScore(int value)
        {
            Score += value;
        }

        public void EndGame(string message, Timer timer, Label scoreLabel)
        {
            IsGameOver = true;
            timer.Stop();
            scoreLabel.Text = $"Score: {Score} {message}";
        }
    }

}
