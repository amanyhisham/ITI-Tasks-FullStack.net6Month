using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private bool isDrawing = false;  // is the mouse button held down?
        private Point lastPoint;         // last position of the mouse

        public Form1()
        {
            InitializeComponent();
        }

        // fires when mouse button is pressed down
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            lastPoint = e.Location; // save the starting point
        }

        // fires when mouse moves
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // only draw if the mouse button is held down
            if (isDrawing)
            {
                // get the Graphics object of the Form to draw on it
                Graphics g = this.CreateGraphics();

                // create a Pen with orange color and thickness 4
                Pen pen = new Pen(Color.OrangeRed, 4);

                // draw a line from the last point to the current point
                g.DrawLine(pen, lastPoint, e.Location);

                // update lastPoint to current position
                lastPoint = e.Location;

                pen.Dispose();
                g.Dispose();
            }
        }

        // fires when mouse button is released
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false; // stop drawing
        }
    }
}