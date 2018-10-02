using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace factorial_draw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            drawpic.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.trackBar1.MouseCaptureChanged += new System.EventHandler(this.dr);
        }
        List<Point> points = new List<Point>();
        private void drawpic_Click(object sender, EventArgs e)
        {
            int x0 = drawpic.Right / 2, y0 = drawpic.Bottom / 2;
            int xmax = drawpic.Right, ymax = drawpic.Bottom;
            MouseEventArgs me = (MouseEventArgs)e;
            Point coord = me.Location;
            Brush aBrush = (Brush)Brushes.Black;
            points.Add(coord);
        //   g.FillRectangle(aBrush, (float)coord.X+x0, (-(float)coord.Y) +y0, 1, 1);
            drawpic.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(points.Count>1)
            drawing = true;
            drawpic.Invalidate();
       //  drawpic.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
        }

        bool drawing = false;
        private Font fnt = new Font("Arial", 10);
        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Random rand = new Random();
            Pen pen = new Pen(Color.FromArgb(200, 0, 0, 0));
            Brush aBrush = (Brush)Brushes.Black;   
            Graphics g = e.Graphics;
            if (checkBox1.Checked)
            {
           g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            }
            int x0 = drawpic.Right / 2, y0 = drawpic.Bottom / 2;
            int xmax = drawpic.Right, ymax = drawpic.Bottom;

            for (int i = 1; i < ymax / 2; i++)
            {
                for (int x = 0; x <= xmax / 2; x++)
                { 
                      //  g.FillRectangle(aBrush, (float)x,  i, 1, 1);
                }

            }

            for (int t = 0; t < points.Count; t++)
            {
            //    e.Graphics.DrawLine(pen, (float)points[t].X + x0, (-(float)points[t].Y) + y0, (float)points[t].X + x0+10, (-(float)points[t].Y) + y0+10);
                g.FillRectangle(aBrush, points[t].X, (points[t].Y) , 2, 2);
            }
            int k = count;
            if(drawing)
            {
              
                int pos2 = rand.Next(0, points.Count);
                Point midl = new Point();
                Point last = new Point();
                while (0==pos2)
                        pos2 = rand.Next(0, points.Count);
                midl = getmiddle(points[0], points[pos2]);
                while (k!=0)
                {
                    if ((k % 10) == 0)
                    {
                        int p = ( k*100) /count;
                     progressBar1.Value = p;
               
                    }
               
                 
                    g.FillRectangle(aBrush, midl.X, (midl.Y), 1, 1);
                    last = midl;
                    pos2 = rand.Next(0, points.Count);
                    midl = getmiddle(last, points[pos2]);
                    k--;
                }
            }
            drawing = false;
            //   g.FillRectangle(aBrush, (float)buf.x1+x0, (-(float)buf.x2)+y0, 1, 1);

        }
        Point getmiddle (Point a, Point b)
        {
            Point midl = new Point();
            midl.X = (a.X + b.X) / 2;
            midl.Y = (a.Y + b.Y) / 2;
            return midl;
        }
        private void drawp_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            points.Clear();
            drawpic.Invalidate();
        }
        int count = 1000; int kof = 2000;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            count = kof * (int)num.Value; 
        }
     
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            count = kof * trackBar1.Value;
            num.Value = trackBar1.Value * 10;
        }
        private void dr(object sender, EventArgs e)
        {
drawin();
        }
        void drawin()
        {
            if (points.Count > 1)
                drawing = true;
            drawpic.Invalidate();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            drawin();
        }
    }
}
