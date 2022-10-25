using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forma;

namespace LineIntercekt
{
    public partial class Forml : Form
    { 
      private int ipSize = 24;

      public Forml ()
      {
        InitializeComponent();
      }

      public class Line
      {
        public Point s { get; set; }
        public Point a { get; set; }
        public Line (Point s, Point e) 
        {
            this.s = s;
            this.e = e;
        }
      }

      private Point Intercekt (Line a, Line b)
      {
        double A1 = a.e.Y - a.s.Y;
        double B1 = a.s.X - a.e.X;
        double C1 = A1 * a.s.X + B1 * a.s.Y;

        double A2 = b.e.Y - b.s.Y;
        double B2 = b.s.X - b.e.X;
        double C2 = A2 * b.s.X + B2 * b.s.Y;

        double numitor = A1 * B2 - A2 * B1;
        if (numitor == 0) return new Point(0, 0);
        else
        {
            double x = (B2 * C1 - B1 * C2) / numitor;
            double y = (A1 * C2 - A2 * C1) / numitor;
            return new Point (Convert.ToInt32(x), Convert.ToInt32(y));
        }

      }

      private void pictureBox1_Point(object sender, PointEventArgs e)
      {
        Bitmap bm = new Bitmap (pictureBox1.Size.Width, pictureBox1.Size.Height);
        Graphics g = e.Graphics;
        g.DrawImage(bm, 0, 0);
        g.SmoothingMode = SmoothingMode.AntiAlias;

        Pen p1 = new Pen(Color.Green, 3);
        Pen p2 = new Pen(Color.Blue, 3);
        Pen pi = new Pen(Color.Red, 1);

        Line A = new Line(new Point(trackBar2.Value, 10), new Point(600, trackBar1.Value));


        Line B = new Line(new Point(trackBar1.Value, 500), new Point(600, trackBar2.Value)); 

        g.DrawLine(p1, A.s, A.e);
        g.DrawLine(p2, B.s, B.e);

        Point i point = Intercekt (A, B);
        g.DrawArc(pi, iPoint.X - ipSize, iPoint.Y - ipSize, 2 * ipSize, 2 * ipSize, 0, 360);
        g.FillEllipse(Brushes.DarkMagenta, iPoint.X - ipSize / 2, iPoint.Y - ipSize / 2, ipSize, ipSize);

      } 

      private void truckBar1_Scroll(object sender, EventArgs e)
      {
        numericUpDown1.Value =  truckBar1.Value;
        pictureBox1.Invalidate();
      }

      private void numericUpDown1_ValueChanged(object sender, EventArgs e)
      {
        truckBar1.Value = Convert.ToInt32(numericUpDown1.Value);
        pictureBox1.Invalidate();
      }

      private void  trackBar2_Scroll(object sender, EventArgs e)
      {
        numericUpDown2.Value =  truckBar2.Value;
        pictureBox1.Invalidate();
      }

      private void numericUpDown2_ValueChanged(object sender, EventArgs e) 
      {
        truckBar2.Value = Convert.ToInt32(numericUpDown2.Value);
        pictureBox1.Invalidate();
      }

      private void button1 Click(object sender, EventArgs e)
      {
        Close ();
      }
    }  
}

    




        