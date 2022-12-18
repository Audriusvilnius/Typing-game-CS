using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace project
{
    public partial class Form1 : Form
    {
        Label[] L;
        Random r = new Random();
        public static int N = 10;
        public static int speed = 1;
        int typing_cor = 0;
        int typing_count = 0;
        int typing_count_er = 0;
        int typing = 0;
        int Top_speed = 0;
        int Top_score = 0;
        int Score = 0;

        public Form1()
        {
            InitializeComponent();
            label4.Text = "" + typing;
            label5.Text = "" + typing;
            label7.Text = "" + speed;
            button1.Enabled = false;
            label4.ForeColor = Color.Gray;
            label5.ForeColor = Color.Gray;
            label7.ForeColor = Color.Gray;
            label2.ForeColor = Color.Gray;
            label3.ForeColor = Color.Gray;
            label6.ForeColor = Color.Gray;
            label8.ForeColor = Color.Green;
            label10.ForeColor = Color.Crimson;
            label4.Visible=false;
            label5.Visible = false;
            label7.Visible = false; 
            label8.Visible = false;
            label10.Visible = false;
            label9.Enabled = false;
            label11.Enabled = false;
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < N; i++)
            {
                if (L[i].Text == Convert.ToString(e.KeyCode))
                {
                    typing_cor++;
                    typing_count_er++;
                    L[i].Top = 0;
                    L[i].Left = r.Next(0, panel1.Width - L[i].Width);
                    L[i].Text = Convert.ToString((char)r.Next(65, 90));
                }
                label4.Text = "" + typing_cor;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            L = new Label[N];
            Label[] labels = new Label[N];

            for (int i = 0; i < N; i++)
            {
                labels[i] = new Label();
                labels[i].Parent = panel1;
                L[i] = labels[i];
            }
            for (int i = 0; i < N; i++)
            {
                L[i].AutoSize = false;
                L[i].BorderStyle = BorderStyle.None;
                L[i].Font= new Font(this.Font, FontStyle.Bold);
                L[i].Font = new Font("Tahoma", 12);
                L[i].TextAlign = ContentAlignment.MiddleCenter;
                L[i].ForeColor = Color.White;
                L[i].FlatStyle = FlatStyle.System;
                L[i].Width = 25;
                L[i].Height = 25;
                L[i].Top = 0;
                L[i].Left = r.Next(0, panel1.Width - L[i].Width);
                L[i].Text = Convert.ToString((char)r.Next(65, 90));
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < N; i++)
            {
                label7.Text = "" + speed;
                L[i].Top += speed;
                if (L[i].Top + L[i].Height >= panel1.Height)
                {
                    typing++;
                    typing_count++;
                    L[i].Top = 0;
                    L[i].Left = r.Next(0, panel1.Width - L[i].Width);
                    L[i].Text = Convert.ToString((char)r.Next(65, 90));
                }
                label5.Text = "" + typing;
                if (typing_count >= 3)
                {
                    typing_count = 0;
                    speed --;
                }
                if (typing_count_er >= 3)
                {
                    typing_count_er = 0;
                    speed ++;
                }
                Top_score = (typing_cor - typing)*N;
                if (Top_score > Score)
                {
                    Score = Top_score;
                }
                label8.Text = "" + Score ;
                if (speed > Top_speed)
                {  
                    Top_speed = speed;
                }
                label10.Text = "" + Top_speed;
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }
        private void label7_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            button1.Enabled = false;
            numericUpDown1.Enabled = false;
            label4.Visible = true;
            label5.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label10.Visible = true;
            label9.Enabled = true;
            label11.Enabled = true;
            label1.Enabled = false;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            N = Convert.ToInt32(numericUpDown1.Value);
        }
        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
        private void label9_Click(object sender, EventArgs e)
        {
        }
    }
}
