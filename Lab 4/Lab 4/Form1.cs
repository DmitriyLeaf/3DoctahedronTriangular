using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_4 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        public int rotInvPoin;
        public float x, y, z;
        public float height, wigth;
        public float[,] points = new float[6, 2];

        public float elipsX, elipsY, elipsW, elipsH, fi = 30, slopeX = 0, slopeY = 0;

        private void button3_Click(object sender, EventArgs e) {
            rotationY();
        }

        private void button4_Click(object sender, EventArgs e) {
            rotationZ();
        }

        private void button1_Click(object sender, EventArgs e) {
            rotationX();
        }

        public void init(float tb1, float tb2, float tb3, float tb4) {
            elipsX = tb1;
            elipsY = tb2;
            z = tb3;
            elipsW = tb4;
            elipsH = tb4 * 1 / 3;

            //+z / Convert.ToSingle(Math.Sqrt(2))
           for (int i = 0; i < 3; i++) {
                points[i * 2, 0] = Convert.ToSingle(elipsX + elipsW / 2 + (elipsW/2 * Math.Cos((fi + (i * 120)) * Math.PI / 180)));
                points[i * 2, 1] = Convert.ToSingle(elipsY + elipsH / 2 + (elipsH/2 * Math.Sin((fi + (i * 120)) * Math.PI / 180)));

                points[i * 2 + 1, 0] = Convert.ToSingle(elipsX - slopeX + elipsW / 2 + (elipsW/2 * Math.Cos((fi + (i * 120)) * Math.PI / 180)));
                points[i * 2 + 1, 1] = Convert.ToSingle(elipsY - slopeY + elipsW + elipsH / 2 + (elipsH/2 * Math.Sin((fi + (i * 120)) * Math.PI / 180)));
            }

        }

        public void initY(float tb1, float tb2, float tb3, float tb4) {
            elipsX = tb1;
            elipsY = tb2;
            z = tb3;
            elipsW = tb4 * 1 / 3;
            elipsH = tb4;

            //+z / Convert.ToSingle(Math.Sqrt(2))
            for (int i = 0; i < 3; i++) {
                points[i * 2, 0] = Convert.ToSingle(elipsX + elipsW / 2 + (elipsW / 2 * Math.Cos((fi + (i * 120)) * Math.PI / 180)));
                points[i * 2, 1] = Convert.ToSingle(elipsY + elipsH / 2 + (elipsH / 2 * Math.Sin((fi + (i * 120)) * Math.PI / 180)));

                points[i * 2 + 1, 0] = Convert.ToSingle(elipsX - slopeX + elipsH + elipsW / 2 + (elipsW / 2 * Math.Cos((fi + (i * 120)) * Math.PI / 180)));
                points[i * 2 + 1, 1] = Convert.ToSingle(elipsY - slopeY + elipsH / 2 + (elipsH / 2 * Math.Sin((fi + (i * 120)) * Math.PI / 180)));
            }

        }

        public void initZ(float tb1, float tb2, float tb3, float tb4) {
            elipsX = tb1;
            elipsY = tb2;
            z = tb3;
            elipsW = tb4 * 1 / 3;
            elipsH = tb4;

            //+z / Convert.ToSingle(Math.Sqrt(2))
            for (int i = 0; i < 3; i++) {
                points[i * 2, 0] = Convert.ToSingle(elipsX + elipsW / 2 + (elipsW / 2 * Math.Cos((fi + (i * 120)) * Math.PI / 180)));
                points[i * 2, 1] = Convert.ToSingle(elipsY + elipsH / 2 + (elipsH / 2 * Math.Sin((fi + (i * 120)) * Math.PI / 180)));

                points[i * 2 + 1, 0] = Convert.ToSingle(elipsX - slopeX + elipsH/2 + elipsW / 2 + (elipsW / 2 * Math.Cos((fi + (i * 120)) * Math.PI / 180)));
                points[i * 2 + 1, 1] = Convert.ToSingle(elipsY - slopeY + elipsH/2 + elipsH / 2 + (elipsH / 2 * Math.Sin((fi + (i * 120)) * Math.PI / 180)));
            }

        }

        public void rotationX() { 
            for (int i = 0; i < 360; i++) {
                fi += 1;
                init(Convert.ToSingle(textBox1.Text), Convert.ToSingle(textBox2.Text),
                     Convert.ToSingle(textBox3.Text), Convert.ToSingle(textBox4.Text));
                draw(1);
                System.Threading.Thread.Sleep(Convert.ToUInt16(textBox5.Text));
                if (i == 359) fi = 30;
            }
        }

        public void rotationY() {
            for (int i = 0; i < 360; i++) {
                fi += 1;
                initY(Convert.ToSingle(textBox1.Text), Convert.ToSingle(textBox2.Text),
                     Convert.ToSingle(textBox3.Text), Convert.ToSingle(textBox4.Text));

                draw(2);
                System.Threading.Thread.Sleep(Convert.ToUInt16(textBox5.Text));
                if (i == 359) fi = 30;
            }
        }

        public void rotationZ() {
            for (int i = 0; i < 360; i++) {
                fi += 1;
                initZ(Convert.ToSingle(textBox1.Text), Convert.ToSingle(textBox2.Text),
                     Convert.ToSingle(textBox3.Text), Convert.ToSingle(textBox4.Text));

                draw(3);
                System.Threading.Thread.Sleep(Convert.ToUInt16(textBox5.Text));
                if (i == 359) fi = 30;
            }
        }

        public void draw(int xyz) {
            Graphics gr = pictureBox1.CreateGraphics();
            Pen p = new Pen(Color.Black);
            gr.Clear(pictureBox1.BackColor);
            float[] dashValues1 = { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            float[] dashValues2 = { 100 };
            drawBord();
            if (xyz == 1) {
                if (fi >= 240 && fi <= 300) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[0, 0], points[0, 1], points[1, 0], points[1, 1]);

                if (fi >= 120 && fi <= 180) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[2, 0], points[2, 1], points[3, 0], points[3, 1]);

                if ((fi >= 30 && fi <= 60) || (fi >= 360 && fi <= 390)) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[4, 0], points[4, 1], points[5, 0], points[5, 1]);

                //---------------------------------------------------------------------------------------------------------
                if (fi >= 120 && fi <= 300) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[1, 0], points[1, 1], points[3, 0], points[3, 1]);

                if ((fi >= 30 && fi <= 180) || (fi >= 360 && fi <= 390)) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[3, 0], points[3, 1], points[5, 0], points[5, 1]);

                if ((fi >= 30 && fi <= 60) || (fi >= 240 && fi <= 390)) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[5, 0], points[5, 1], points[1, 0], points[1, 1]);
            }
            if (xyz == 2) {
                if (fi >= 150 && fi <= 210) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[0, 0], points[0, 1], points[1, 0], points[1, 1]);

                if (fi >= 30 && fi <= 90) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[2, 0], points[2, 1], points[3, 0], points[3, 1]);

                if (fi >= 270 && fi <= 330) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[4, 0], points[4, 1], points[5, 0], points[5, 1]);

                //---------------------------------------------------------------------------------------------------------
                if (fi >= 0 && fi <= 210) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[1, 0], points[1, 1], points[3, 0], points[3, 1]);

                if ((fi >= 270 && fi <= 390) || (fi >= 0 && fi <= 90)) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[3, 0], points[3, 1], points[5, 0], points[5, 1]);

                if (fi >= 150 && fi <= 330) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[5, 0], points[5, 1], points[1, 0], points[1, 1]);
            }
            if (xyz == 3) {
                if (fi >= 170 && fi <= 230) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[0, 0], points[0, 1], points[1, 0], points[1, 1]);

                if (fi >= 50 && fi <= 110) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[2, 0], points[2, 1], points[3, 0], points[3, 1]);

                if (fi >= 290 && fi <= 350) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[4, 0], points[4, 1], points[5, 0], points[5, 1]);

                //---------------------------------------------------------------------------------------------------------
                if (fi >= 20 && fi <= 230) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[1, 0], points[1, 1], points[3, 0], points[3, 1]);

                if ((fi >= 290 && fi <= 20) || (fi >= 0 && fi <= 90)) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[3, 0], points[3, 1], points[5, 0], points[5, 1]);

                if (fi >= 170 && fi <= 350) p.DashPattern = dashValues1;
                else p.DashPattern = dashValues2;
                gr.DrawLine(p, points[5, 0], points[5, 1], points[1, 0], points[1, 1]);
            }
            //---------------------------------------------------------------------------------------------------------

            //gr.DrawEllipse(p, elipsX, elipsY, elipsW, elipsH);
            //gr.DrawEllipse(p, elipsX - slopeX, elipsY + elipsW, elipsW, elipsH);
            /*
            if (fi >= 240 && fi <= 300) p.Color = Color.Red;
            else p.Color = Color.Black;
            gr.DrawLine(p, points[0, 0], points[0, 1], points[1, 0], points[1, 1]);

            if (fi >= 120 && fi <= 180) p.Color = Color.Red;
            else p.Color = Color.Black;
            gr.DrawLine(p, points[2, 0], points[2, 1], points[3, 0], points[3, 1]);
            
            if ((fi >= 30 && fi <= 60) || (fi >= 360 && fi <= 390)) p.Color = Color.Red;
            else p.Color = Color.Black;
            gr.DrawLine(p, points[4, 0], points[4, 1], points[5, 0], points[5, 1]);
            //---------------------------------------------------------------------------------------------------------
            if (fi >= 120 && fi <= 300) p.Color = Color.Red;
            else p.Color = Color.Black;
            gr.DrawLine(p, points[1, 0], points[1, 1], points[3, 0], points[3, 1]);

            if ((fi >= 30 && fi <= 180) || (fi >= 360 && fi <= 390)) p.Color = Color.Red;
            else p.Color = Color.Black;
            gr.DrawLine(p, points[3, 0], points[3, 1], points[5, 0], points[5, 1]);

            if ((fi >= 30 && fi <= 60) || (fi >= 240 && fi <= 390)) p.Color = Color.Red;
            else p.Color = Color.Black;
            gr.DrawLine(p, points[5, 0], points[5, 1], points[1, 0], points[1, 1]);
            //---------------------------------------------------------------------------------------------------------
            */
            p.Color = Color.Black;
            p.DashPattern = dashValues2;
            gr.DrawLine(p, points[0, 0], points[0, 1], points[2, 0], points[2, 1]);
            gr.DrawLine(p, points[2, 0], points[2, 1], points[4, 0], points[4, 1]);
            gr.DrawLine(p, points[4, 0], points[4, 1], points[0, 0], points[0, 1]);

            Font myFont = new Font("Arial", 8);
            gr.DrawString(Convert.ToString(fi), myFont, Brushes.Black, new Point(30, 20));
            /*for (int i = 0; i < 6; i += 2) {
                Font myFont = new Font("Arial", 8);
                gr.DrawString(Convert.ToString(points[i, 0]), myFont, Brushes.Black, new Point(10, 10 + i * 40));
                gr.DrawString(Convert.ToString(points[i, 1]), myFont, Brushes.Black, new Point(10, 20 + i * 40));
                gr.DrawString(Convert.ToString(points[i+1, 0]), myFont, Brushes.Black, new Point(10, 30 + i * 40));
                gr.DrawString(Convert.ToString(points[i+1, 1]), myFont, Brushes.Black, new Point(10, 40 + i * 40));
            }*/
        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            init(Convert.ToSingle(textBox1.Text), Convert.ToSingle(textBox2.Text),
                 Convert.ToSingle(textBox3.Text), Convert.ToSingle(textBox4.Text));
            draw(2);
        }

        public void drawBord() {
            Graphics gr = pictureBox1.CreateGraphics();
            Pen p = new Pen(Color.Black);
            gr.DrawLine(p, new Point(0, 474), new Point(0, 0));
            gr.DrawLine(p, new Point(0, 0), new Point(760, 0));
            gr.DrawLine(p, new Point(0, 473), new Point(759, 473));
            gr.DrawLine(p, new Point(759, 473), new Point(759, 0));

            Font myFont = new Font("Arial", 8);
            gr.DrawLine(p, new Point(10, 10), new Point(100, 10));
            gr.DrawString("X", myFont, Brushes.Black, new Point(110, 10));
            gr.DrawLine(p, new Point(10, 10), new Point(10, 100));
            gr.DrawString("Y", myFont, Brushes.Black, new Point(10, 110));
            gr.DrawLine(p, new Point(10, 10), new Point(100, 100));
            gr.DrawString("Z", myFont, Brushes.Black, new Point(110, 110));
        }
    }
}