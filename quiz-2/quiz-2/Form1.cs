using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quiz_2
{
    public partial class Form1 : Form
    {
        public string player1 { get; set; }
        public string player2 { get; set; }
        public int score1 { get; set; }
        public int score2 { get; set; }

        int count = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.player1 = null;
            this.player2 = null;
            groupBox3.Visible = false;
            label7.Visible = false;
        }

        private void btnCreateGame_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text.Trim()))
                    throw new Exception("Please enter player 1 name");
                if (string.IsNullOrEmpty(textBox2.Text.Trim()))
                    throw new Exception("Please enter player 2 name");

                this.player1 = textBox1.Text.Trim();
                this.player2 = textBox2.Text.Trim();

                MessageBox.Show("Creating game successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.player1.Trim()))
                    throw new Exception("Please enter player 1 name");
                if (string.IsNullOrEmpty(this.player2.Trim()))
                    throw new Exception("Please enter player 2 name");

                MessageBox.Show("Loading game successfully");

                textBox3.Text = this.player1.Trim();
                textBox4.Text = this.player2.Trim();

                groupBox3.Visible = true;
                label7.Visible = true;
                label7.Text = "Waiting";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStartSimulator_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            this.score1 = random.Next(0, 16);
            this.score2 = random.Next(0, 16);

            groupBox1.Enabled = false;
            groupBox2.Enabled = false;

            
            label7.Text = "Playing";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count > 0 && count !=0)
            {
                count--;
                label7.Text = count + " seconds";
            }
            else if(count == 0)
            {
                timer1.Stop();
                textBox6.Text = this.score1.ToString();
                textBox5.Text = this.score2.ToString();
                if (this.score1 > this.score2)
                {
                    label7.Text = $"Result \n\n {this.player1} Wins";
                }
                else if (this.score1 < this.score2)
                {
                    label7.Text = $"Result \n\n {this.player2} Wins";

                }
                else
                {
                    label7.Text = "Result \n\n Draw";
                }
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
            }
            else
            {
                label7.Text = "Simulating is collapsed";
            }
        }
    }
}
