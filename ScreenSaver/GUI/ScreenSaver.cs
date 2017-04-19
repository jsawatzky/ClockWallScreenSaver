using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using ClockWallScreenSaver.Reference;

namespace ClockWallScreenSaver.GUI
{

    public partial class ScreenSaver : Form
    {

        //Gobal variables
        private int clockRadius, armLength, numX, numY, clockStartX, clockStartY;

        //Brushes for drawing
        SolidBrush background = new SolidBrush(Color.Black);
        Pen hands = new Pen(Color.FromArgb(100, 100, 100), 4);
        SolidBrush clocks = new SolidBrush(Color.FromArgb(10, 10, 10));

        int format = 12;

        public ScreenSaver()
        {
            InitializeComponent();
        }

        public ScreenSaver(Rectangle Bounds)
        {
            InitializeComponent();
            this.Bounds = Bounds;

            init();

        }


        //Determine clock size and initiialize global varialbes
        private void init()
        {
            int gcd = GCD(Bounds.Width, Bounds.Height);

            numX = Bounds.Width / gcd;
            numY = Bounds.Height / gcd;

            while (numX < 22 || numY < 6 || numX % 2 != 0 || numY % 2 != 0)
            {
                if (gcd % 2 == 0) { gcd /= 2; } else { break; }

                numX = Bounds.Width / gcd;
                numY = Bounds.Height / gcd;
            }

            clockRadius = (Bounds.Width / numX) / 2;
            armLength = clockRadius - 5;

            clockStartX = (numX - 22) / 2;
            clockStartY = (numY - 6) / 2;
        }

        Timer timer = new Timer();

        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {

            //Load user settings
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClockWallScreensaver");

            if (key != null)
            {
                format = (int)key.GetValue("format");
                background.Color = Color.FromArgb((int)key.GetValue("background"));
                clocks.Color = Color.FromArgb((int)key.GetValue("clock"));
                hands.Color = Color.FromArgb((int)key.GetValue("hand"));
            }

            //Cover screen
            Cursor.Hide();
            TopMost = true;

            //Set the timer to rumm every 33ms (30fps)
            timer.Interval = 33;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }

        Graphics g;

        //Update the screen
        private void timer_Tick(object sender, System.EventArgs e)
        {

            //Get current time and seperate into digits
            String[] time = DateTime.Now.ToString("HH:mm:ss.fff").Split(new char[]{ ':','.'});

            int h = int.Parse(time[0]) % format;
            int h1 = h / 10;
            int h2 = h % 10;
            int m = int.Parse(time[1]);
            int m1 = m / 10;
            int m2 = m % 10;
            int s = int.Parse(time[2]);
            int ms = int.Parse(time[3]);

            int mNew = (m + 1) % 60;
            int hNew = mNew == 0 ? (h + 1) % 24 : h;

            //Get the graphics object
            if (g == null) g = this.CreateGraphics();

            int[,] clockValsNew = null;
            double percent = 0;

            //If the seconds is greater than 55 determine the new time and get the percent
            //through the animation
            if (s >= 55)
            {
                s = (s + 5) % 60;
                ms += s * 1000;

                percent = ((double) ms) / 5000.0;
                
                int h1New = hNew / 10;
                int h2New = hNew % 10;
                int m1New = mNew / 10;
                int m2New = mNew % 10;

                clockValsNew = getClockVals(h1New, h2New, m1New, m2New);
            }
            
            //Create an image for double buffering
            Bitmap img = new Bitmap(Bounds.Width, Bounds.Height);
            Graphics g2 = Graphics.FromImage(img);
            g2.FillRectangle(background, 0, 0, Bounds.Width, Bounds.Height);

            //Get the values for all clocks
            int[,] clockVals = getClockVals(h1, h2, m1, m2);
            if (clockValsNew == null) clockValsNew = clockVals;

            int x = clockRadius;
            for (int xI = 0; xI < numX; xI++)
            {
                int y = clockRadius;
                for (int yI = 0; yI < numY; yI++)
                {
                    g2.FillEllipse(clocks, x - clockRadius, y - clockRadius, 2 * clockRadius, 2 * clockRadius);

                    //If its part of the digital display, display the custom value
                    if (xI >= clockStartX && xI < clockStartX+22 && yI >= clockStartY && yI < clockStartY+6)
                    {
                        int xP = xI - clockStartX;
                        int yP = yI - clockStartY;
                        int change = Math.Min(getChange(clockVals[xP, yP], clockValsNew[xP, yP]),
                            getChange(clockVals[xP, yP], getRelatedTime(clockValsNew[xP, yP])));
                        int val = (int) (clockVals[xP, yP] + (change * percent)) % 720;

                        g2.DrawLine(hands, x, y, (float) (x + Math.Sin(((val % 60) / 60.0) * 2 * Math.PI) * armLength),
                            (float) (y - Math.Cos(((val % 60) / 60.0) * 2 * Math.PI) * armLength));
                        g2.DrawLine(hands, x, y, (float)(x + Math.Sin((((val / 60) / 12.0) * 2 * Math.PI) + (((val % 60) / 60.0) * Math.PI / 6)) * armLength / 1.5),
                            (float)(y - Math.Cos((((val / 60) / 12.0) * 2 * Math.PI) + (((val % 60) / 60.0) * Math.PI / 6)) * armLength / 1.5));
                    } else //Else draw the current time
                    {
                        g2.DrawLine(hands, x, y, (float)(x + Math.Sin((m / 60.0) * 2 * Math.PI) * armLength),
                                (float)(y - Math.Cos((m / 60.0) * 2 * Math.PI) * armLength));
                        g2.DrawLine(hands, x, y, (float)(x + Math.Sin(((((h % 12) / 12.0) * 2 * Math.PI)) + ((m / 60.0) * Math.PI / 6)) * armLength / 1.5),
                            (float)(y - Math.Cos(((((h % 12) / 12.0) * 2 * Math.PI)) + ((m / 60.0) * Math.PI / 6)) * armLength / 1.5));
                    }

                    y += clockRadius * 2;
                }
                x += clockRadius * 2;
            }
            g2.Dispose();
            g.DrawImage(img, 0, 0);
            img.Dispose();
        }

        private Point mouseLocation;

        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseLocation.IsEmpty)
            {
                // Terminate if mouse is moved a significant distance
                if (Math.Abs(mouseLocation.X - e.X) > 5 ||
                    Math.Abs(mouseLocation.Y - e.Y) > 5)
                    Application.Exit();
            }
            
            mouseLocation = e.Location;
        }

        //Terminate on button press
        private void ScreenSaverForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Application.Exit();
        }

        private void ScreenSaverForm_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        //Get GCD of two numbers
        private static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
        
        //Build array of clock values for digital display
        private int[,] getClockVals(int h1, int h2, int m1, int m2)
        {
            int[,] clockVals = new int[22, 6];
            int[,] num = Number.getNumber(h1);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (num[i, j] == -1) //Display current time if not included
                    {
                        clockVals[i, j] = ((((h1 * 10) + h2) * 60) + (m1 * 10) + m2) % 720;
                    }
                    else
                    {
                        clockVals[i, j] = num[i, j];
                    }
                }
            }
            num = Number.getNumber(h2);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (num[i, j] == -1) //Display current time if not included
                    {
                        clockVals[i+5, j] = ((((h1 * 10) + h2) * 60) + (m1 * 10) + m2) % 720;
                    }
                    else
                    {
                        clockVals[i+5, j] = num[i, j];
                    }
                }
            }
            //Set colon
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (j == 0 || j == 5)
                    {
                        clockVals[i + 10, j] = ((((h1 * 10) + h2) * 60) + (m1 * 10) + m2) % 720;
                    }
                    else if (j % 2 == 1)
                    {
                        if (i == 0)
                        {
                            clockVals[i + 10, j] = 210;
                        }
                        else
                        {
                            clockVals[i + 10, j] = 405;
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {
                            clockVals[i + 10, j] = 15;
                        }
                        else
                        {
                            clockVals[i + 10, j] = 45;
                        }
                    }
                }
            }
            num = Number.getNumber(m1);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (num[i, j] == -1) //Display current time if not included
                    {
                        clockVals[i + 12, j] = ((((h1 * 10) + h2) * 60) + (m1 * 10) + m2) % 720;
                    }
                    else
                    {
                        clockVals[i + 12, j] = num[i, j];
                    }
                }
            }
            num = Number.getNumber(m2);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (num[i, j] == -1) //Display current time if not included
                    {
                        clockVals[i + 17, j] = ((((h1 * 10) + h2) * 60) + (m1 * 10) + m2) % 720;
                    }
                    else
                    {
                        clockVals[i + 17, j] = num[i, j];
                    }
                }
            }
            return clockVals;
        }

        //Get time difference between to values
        private int getChange(int val1, int val2)
        {

            int change = val2 - val1;
            if (change < 0)
            {
                change += 720;
            }
            return change;

        }

        //Get time if hour and miniute hands were switched
        private int getRelatedTime(int val)
        {
            int h = val / 60;
            int m = val % 60;
            int hNew = (int) Math.Floor((m / 60.0) * 12);
            int mNew = (int) Math.Floor((h / 12.0) * 60);
            return (hNew * 60) + mNew;
        }
    }
}
