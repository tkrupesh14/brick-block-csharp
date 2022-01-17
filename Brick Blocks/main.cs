using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Brick_Blocks
{
    public partial class main : Form
    {
        SoundPlayer Over = new SoundPlayer("Over.wav");
        SoundPlayer Start = new SoundPlayer("Start.wav");
        SoundPlayer Win = new SoundPlayer("Win.wav");


        public main()
        {
            InitializeComponent();
            Start.Play();
        }

        int ball_x = 4;
        int ball_y = 4;
        int score = 0;

        private void Game_over()
        {
            if(score>11)
            {
                timer1.Stop();
                Start.Stop();
                Win.Play();
                
                MessageBox.Show("You Won The Game 🎉");
            }

            if (Ball.Top + Ball.Height > ClientSize.Height)
            {
                timer1.Stop();
                Start.Stop();
                Over.Play();
                
                MessageBox.Show("You Loose The Game 😔");
            }
        }

        private void Get_Score()
        {
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && x.Tag == "Block")
                {
                    if (Ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        Controls.Remove(x);
                        ball_y = -ball_y;
                        score++;
                        Score.Text = "Score: " + score;
                    }
                }
            }
        }

        private void Ball_Movement()
        {
            Ball.Left += ball_x;
            Ball.Top += ball_y;

            if (Ball.Left + Ball.Width > ClientSize.Width || Ball.Left < 0)
            {
                ball_x = -ball_x;
            }

            if (Ball.Top < 0 || Ball.Bounds.IntersectsWith(Player.Bounds))
            {
                ball_y = -ball_y;

            }
        }

        private void main_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left&&Player.Left>0)
            {
                Player.Left -= 5;
            }

            if (e.KeyCode == Keys.Right && Player.Right < 536)
            {
                Player.Left += 5;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Ball_Movement();
            Get_Score();
            Game_over();
        }
    }
}
