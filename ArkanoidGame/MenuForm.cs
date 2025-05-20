using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidGame
{
    public partial class MenuForm : Form
    {
        public Color BallColor { get; private set; } = Color.Red;
        public Color PaddleColor { get; private set; } = Color.Blue;
        public Color BrickColor { get; private set; } = Color.Orange;
        public int BallSpeed { get; private set; } = 5;
        public int BrickRows { get; private set; }
        public int BrickCols { get; private set; }


        private ComboBox cbBallColor, cbPaddleColor, cbBrickColor;
        private NumericUpDown nudBallSpeed;
        private NumericUpDown numBrickRows, numBrickCols;
        public Button btnStart, btnSave;
        public MenuForm()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Ustawienia gry";
            this.Size = new Size(300, 300);

            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 5, ColumnCount = 2 };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            cbBallColor = CreateColorBox();
            cbPaddleColor = CreateColorBox();
            cbBrickColor = CreateColorBox();
            nudBallSpeed = new NumericUpDown { Minimum = 1, Maximum = 10, Value = 5 };
            numBrickRows = new NumericUpDown { Minimum = 1, Maximum = 8, Value = 5, Width = 100 };
            numBrickCols = new NumericUpDown { Minimum = 1, Maximum = 10, Value = 5, Width = 100 };

            layout.Controls.Add(new Label { Text = "Kolor piłki:", TextAlign = ContentAlignment.MiddleRight }, 0, 0);
            layout.Controls.Add(cbBallColor, 1, 0);
            layout.Controls.Add(new Label { Text = "Kolor paletki:", TextAlign = ContentAlignment.MiddleRight }, 0, 1);
            layout.Controls.Add(cbPaddleColor, 1, 1);
            layout.Controls.Add(new Label { Text = "Kolor cegiełek:", TextAlign = ContentAlignment.MiddleRight }, 0, 2);
            layout.Controls.Add(cbBrickColor, 1, 2);
            layout.Controls.Add(new Label { Text = "Szybkość piłki:", TextAlign = ContentAlignment.MiddleRight }, 0, 3);
            layout.Controls.Add(nudBallSpeed, 1, 3);
            layout.Controls.Add(new Label { Text = "Liczba rzędów cegiełek:", TextAlign = ContentAlignment.MiddleRight }, 0, 4);
            layout.Controls.Add(numBrickRows, 1, 4);
            layout.Controls.Add(new Label { Text = "Liczba kolumn cegiełek:", TextAlign = ContentAlignment.MiddleRight }, 0, 5);
            layout.Controls.Add(numBrickCols, 1, 5);


            btnStart = new Button { Text = "Start", Dock = DockStyle.Fill };
            btnStart.Click += BtnStart_Click;
            layout.Controls.Add(btnStart, 0, 6);
            layout.SetColumnSpan(btnStart, 2);

            this.Controls.Add(layout);
        }

        private ComboBox CreateColorBox()
        {
            var cb = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cb.Items.AddRange(new[] { "Red", "Blue", "Green", "Yellow", "Orange", "White" });
            cb.SelectedIndex = 0;
            return cb;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            BallColor = Color.FromName(cbBallColor.SelectedItem.ToString());
            PaddleColor = Color.FromName(cbPaddleColor.SelectedItem.ToString());
            BrickColor = Color.FromName(cbBrickColor.SelectedItem.ToString());
            BallSpeed = (int)nudBallSpeed.Value;
            BrickRows = (int)numBrickRows.Value;
            BrickCols = (int)numBrickCols.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
