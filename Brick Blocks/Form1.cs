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
    public partial class Form1 : Form
    {
        SoundPlayer player = new SoundPlayer("start.wav");
        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player.Play();
            main main = new main();
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Enabled = true;
            //ProgressBar1.Increment(2);
            main main = new main();
            main.Show();
            this.Hide();
           /* if(ProgressBar1.Value == 100)
            {
                timer1.Enabled = false;
                main main = new main();

                main.Show();
                player.Stop();
                this.Hide();
            }*/
        }
    }
}
