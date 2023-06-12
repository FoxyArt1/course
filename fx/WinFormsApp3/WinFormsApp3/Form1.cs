namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        SolidBrush w;
        SolidBrush b;
        SolidBrush green;
        Pen gray;
        string kuda="up";
        Point[] snake;
        Point apple;
        int dlina=1;
        Random random;
        int width,height;
        int widthz=10, heightz=10;
        int widtha = 30, heighta = 30;
        int score =0;
        public Form1()
        {
            random = new Random();
            snake = new Point[1000];
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            width = pictureBox1.Width/10;
            height = pictureBox1.Height/10;
            snake[0].X = width/2;
            snake[0].Y = height/2;
            w = new SolidBrush(Color.White);
            green = new SolidBrush(Color.Green);
            b = new SolidBrush(Color.Black);
            gray = new Pen(Color.Gray);
            apple.X=random.Next(0,width-1);
            apple.Y=random.Next(0,height-1);
        }

        private void timer1_Tick(object sender, EventArgs args)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.FillRectangle(w, 0, 0, pictureBox1.Width, pictureBox1.Height);
            for (int i = 1; i < dlina; i++)
                for (int j = i + 1; j < dlina; j++)
                {
                    if (snake[i].X == snake[j].X && snake[i].Y == snake[j].Y)
                    {
                        timer1.Stop();
                        DialogResult res = MessageBox.Show("You Die,Restart Game? You Score" + " " + score, "GameOver", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (res == DialogResult.OK)
                        {
                            timer1.Start();
                            dlina = 4;
                            score = 0;
                        }
                        if (res == DialogResult.Cancel)
                        {
                            MessageBox.Show("You have clicked Cancel Button");
                            this.Close();
                        }
                    }
                }

            for (int i = 0; i < dlina; i++)
            {
                if (snake[i].X < 0) snake[i].X += width;
                if (snake[i].X > width) snake[i].X -= width;
                if (snake[i].Y < 0) snake[i].Y += height;
                if (snake[i].Y > height) snake[i].Y -= height;
                g.FillEllipse(b, snake[i].X * 10, snake[i].Y * 10, widthz, heightz);
                if (/*apple.X >= snake[0].X && apple.X <= snake[0].X + (widthz / 10) - 1 && apple.Y >= snake[0].Y && apple.Y <= snake[0].Y + (heightz / 10) - 1)*/ snake[0].X >= apple.X && snake[0].X <= apple.X +(widtha/10)-1 && snake[0].Y >= apple.Y && snake[0].Y <= apple.Y +(heighta/10)-1)
                {
                    apple.X = random.Next(0, width - 10);
                    apple.Y = random.Next(0, height - 10);
                    dlina++;
                    score++;
                }
            }
            g.FillEllipse(green, apple.X * 10, apple.Y * 10, widtha, heighta);
            label1.Text = "Score :" + Convert.ToString(score);
            if (kuda == "up") snake[0].Y -= 1;
            if (kuda == "down") snake[0].Y += 1;
            if (kuda == "left") snake[0].X -= 1;
            if (kuda == "right") snake[0].X += 1;
            if (dlina > 1000 - 7)
            {
                dlina = 1000 - 7;
            }
            for (int i = dlina ; i >=0; i--)
            { 
                snake[i+1].X = snake[i].X;
                snake[i + 1].Y = snake[i].Y;
            }
            if (dlina < 4) dlina++;
                pictureBox1.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (kuda != "down")
            {
                if (e.KeyCode == Keys.W)
                {
                    kuda = "up";
                }
            }
            if (kuda != "up")
            {
                if (e.KeyCode == Keys.S)
                {
                    kuda = "down";
                }
            }
            if (kuda != "right")
            {
                if (e.KeyCode == Keys.A)
                {
                    kuda = "left";
                }
            }
            if (kuda != "left")
            {
                if (e.KeyCode == Keys.D)
                {
                    kuda = "right";
                }
            }
        }
    }
}