namespace ArkanoidGame
{
    partial class Arkanoid
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtScore = new Label();
            player = new PictureBox();
            ball = new PictureBox();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ball).BeginInit();
            SuspendLayout();
            // 
            // txtScore
            // 
            txtScore.AutoSize = true;
            txtScore.BackColor = Color.White;
            txtScore.Location = new Point(22, 18);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(48, 15);
            txtScore.TabIndex = 0;
            txtScore.Text = "Score :0";
            // 
            // player
            // 
            player.BackColor = Color.White;
            player.Location = new Point(337, 409);
            player.Name = "player";
            player.Size = new Size(119, 19);
            player.TabIndex = 1;
            player.TabStop = false;
            // 
            // ball
            // 
            ball.BackColor = Color.Yellow;
            ball.Location = new Point(385, 364);
            ball.Name = "ball";
            ball.Size = new Size(20, 19);
            ball.TabIndex = 2;
            ball.TabStop = false;
            // 
            // timer
            // 
            timer.Interval = 20;
            timer.Tick += mainGameTimerEvent;
            // 
            // Arkanoid
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
            Controls.Add(ball);
            Controls.Add(player);
            Controls.Add(txtScore);
            Name = "Arkanoid";
            Text = "Arkanoid";
            Load += Arkanoid_Load;
            KeyDown += keyIsDown;
            KeyUp += keyIsUp;
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ((System.ComponentModel.ISupportInitialize)ball).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtScore;
        private PictureBox player;
        private PictureBox ball;
        private System.Windows.Forms.Timer timer;
    }
}
