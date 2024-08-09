using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            pictureBox2.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if(pipeTop.Left < -180)
{
                pipeTop.Left = 950;
                score++;
}
            if (pictureBox2.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                pictureBox2.Bounds.IntersectsWith(pipeTop.Bounds) ||
                pictureBox2.Bounds.IntersectsWith(ground.Bounds) || pictureBox2.Top < -25
                )
            {
                
                endGame();
            }
            if (score > 5)
            {
                pipeSpeed = 15;
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void endGame()
        {
            timer1.Stop(); 
            scoreText.Text += " Game over!!!"; 
        }
    }
}
