///<summary>
///This application generates a GUI that features a faucet that pours paint into a bucket.
///There are three controls. A trackbar which controls the flow of paint, a color button 
///that opens a colorDialog box which allows the user to change the color of the paint, and
///finally a simple Exit button which closes the application.
///</summary>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5A
{
    public partial class Form1 : Form
    {
        Color currentColor;                                     //A color variable that keeps track of current color being used for the paint.

        //The position of the faucet's paint outpour. 
        int x1Faucet = 78;                                      
        int y1Faucet = 135;
        int x2Faucet = 78;
        int y2Faucet = 349;

        //The position of the buckets paint generation.
        int x1Bucket = 66;
        int y1Bucket = 348;
        int x2Bucket = 213;
        int y2Bucket = 1;

        bool bucketFull = false;                                //Keeps track of whether or not the bucket is full.

        /// <summary>
        /// The form constructor that initializes all components and establishes the 
        /// default paint color as red, as well as the colorDialog.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            currentColor = Color.Red;
            colorDialog1.Color = Color.Red;
        }
        /// <summary>
        /// A method for the picture of the faucet. 
        /// There is no logic here but it is required for the faucet to exist.
        /// </summary>
        /// <param name="sender">Standard sender params.</param>
        /// <param name="e">Standard Event params.</param>
        private void faucetPicture_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// This method allows the bucket graphic to be painted onto the form.
        /// </summary>
        /// <param name="sender">Standard sender params.</param>
        /// <param name="e">Standard Event params.</param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Creates the bucket graphic.
            Graphics bucket = CreateGraphics();
            Pen linePen = new Pen(Color.White, 2);
            bucket.DrawLine(linePen, 65, 350, 280, 350);
            bucket.DrawLine(linePen, 65, 250, 65, 350);
            bucket.DrawLine(linePen, 280, 250, 280, 350);
        }
        /// <summary>
        /// Loads whatever is placed inside this method on startup.
        /// There is no logic in this method, therefore it does nothing.
        /// </summary>
        /// <param name="sender">Standard sender params.</param>
        /// <param name="e">Standard eventargs param</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// This is the method which controls the trackbar.  This is the main workhorse of the application.
        /// When the trackbar is moved from position 0, it will cause the faucet to turn on and begin pouring
        /// paint into the bucket.  The further right the trackbar is pushed, the faster the paint fills up
        /// the bucket.  When the bucket reaches its fill limit, the faucet automatically shuts off and the
        /// trackbar resets to its original position.  When the trackbar is moved again, the bucket is 
        /// emptied and the fill process begins all over again.
        /// </summary>
        /// <param name="sender">standard sender params</param>
        /// <param name="e">standard eventargs params</param>
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            //Checks if the trackbar value is set to the off, or zero position.
            if (trackBar.Value == 0)
            {
                paint(Color.Black, x1Faucet, y1Faucet, x2Faucet, y2Faucet);                     //Turns the faucet "off", or simply, changes the color of the paint flow to black.
                timer1.Stop();                                                                  //Stops the timer componenent from running.
            }
            //Checks  if the trackbar value is equal to 1.
            //If it is, then the paint will begin to pour at
            //The slowest rate which is every .5 seconds (500 milliseconds).
            else if (trackBar.Value == 1)
            {
                //Checks if the bucket is already full.
                //If it is, then the bucket is emptied
                //and allows for fresh paint to be added.
                if (bucketFull)  
                {
                    bucketFull = false;                                                         //Changes this variable to false as the bucket is no longer full.

                    //Generates a black rectangle in the bucket
                    //to simulate the bucket being emptied.
                    Graphics black = CreateGraphics();                                          
                    Brush brushBlack = new SolidBrush(Color.Black);
                    black.FillRectangle(brushBlack, 66, 250, 213, 100);
                }
                paint(colorDialog1.Color, x1Faucet, y1Faucet, x2Faucet, y2Faucet);              //Shows the faucets flow of paint with the current color.
                timer1.Interval = 500;                                                          //Changes the timer interval to 500, enabling the flow of paint.
                timer1.Start();                                                                 //Starts the timer to start the flow of paint.
            }
            //Checks  if the trackbar value is equal to 2.
            //If it is, then the paint will begin to pour at
            //a slightly faster rate which is every .4 seconds (400 milliseconds).
            else if (trackBar.Value == 2)
            {
                if (bucketFull)
                {
                    bucketFull = false;                                                         //Changes this variable to false as the bucket is no longer full.

                    //Generates a black rectangle in the bucket
                    //to simulate the bucket being emptied.
                    Graphics black = CreateGraphics();                                          
                    Brush brushBlack = new SolidBrush(Color.Black);                             
                    black.FillRectangle(brushBlack, 66, 250, 213, 100);                         
                }
                paint(colorDialog1.Color, x1Faucet, y1Faucet, x2Faucet, y2Faucet);              //Shows the faucets flow of paint with the current color.
                timer1.Interval = 400;                                                          //Changes the timer interval to 500, enabling the flow of paint.
                timer1.Start();                                                                 //Starts the timer to start the flow of paint.
            }
            //Checks  if the trackbar value is equal to 3.
            //If it is, then the paint will begin to pour at
            //a slightly faster rate which is every .3 seconds (300 milliseconds).
            else if (trackBar.Value == 3)
            {
                if (bucketFull)
                {
                    bucketFull = false;                                                         //Changes this variable to false as the bucket is no longer full.

                    //Generates a black rectangle in the bucket
                    //to simulate the bucket being emptied.
                    Graphics black = CreateGraphics();
                    Brush brushBlack = new SolidBrush(Color.Black);
                    black.FillRectangle(brushBlack, 66, 250, 213, 100);
                }
                paint(colorDialog1.Color, x1Faucet, y1Faucet, x2Faucet, y2Faucet);              //Shows the faucets flow of paint with the current color.
                timer1.Interval = 300;                                                          //Changes the timer interval to 500, enabling the flow of paint.
                timer1.Start();                                                                 //Starts the timer to start the flow of paint.
            }
            //Checks  if the trackbar value is equal to 4.
            //If it is, then the paint will begin to pour at
            //a slightly faster rate which is every .2 seconds (200 milliseconds).
            else if (trackBar.Value == 4)
            {
                if (bucketFull)
                {
                    bucketFull = false;                                                         //Changes this variable to false as the bucket is no longer full.

                    //Generates a black rectangle in the bucket
                    //to simulate the bucket being emptied.
                    Graphics black = CreateGraphics();
                    Brush brushBlack = new SolidBrush(Color.Black);
                    black.FillRectangle(brushBlack, 66, 250, 213, 100);
                }
                paint(colorDialog1.Color, x1Faucet, y1Faucet, x2Faucet, y2Faucet);              //Shows the faucets flow of paint with the current color.
                timer1.Interval = 200;                                                          //Changes the timer interval to 500, enabling the flow of paint.
                timer1.Start();                                                                 //Starts the timer to start the flow of paint.
            }
            //Checks  if the trackbar value is equal to 5.
            //If it is, then the paint will begin to pour at
            //a slightly faster rate which is every .1 seconds (100 milliseconds).
            else if (trackBar.Value == 5)
            {
                if (bucketFull)
                {
                    bucketFull = false;                                                         //Changes this variable to false as the bucket is no longer full.

                    //Generates a black rectangle in the bucket
                    //to simulate the bucket being emptied.
                    Graphics black = CreateGraphics();
                    Brush brushBlack = new SolidBrush(Color.Black);
                    black.FillRectangle(brushBlack, 66, 250, 213, 100);
                }
                paint(colorDialog1.Color, x1Faucet, y1Faucet, x2Faucet, y2Faucet);              //Shows the faucets flow of paint with the current color.
                timer1.Interval = 100;                                                          //Changes the timer interval to 500, enabling the flow of paint.
                timer1.Start();                                                                 //Starts the timer to start the flow of paint.
            }
            //Checks  if the trackbar value is equal to 6.
            //If it is, then the paint will begin to pour at
            //a slightly faster rate which is every .2 seconds (200 milliseconds).
            else if (trackBar.Value == 6)
            {
                if (bucketFull)
                {
                    bucketFull = false;                                                         //Changes this variable to false as the bucket is no longer full.

                    //Generates a black rectangle in the bucket
                    //to simulate the bucket being emptied.
                    Graphics black = CreateGraphics();
                    Brush brushBlack = new SolidBrush(Color.Black);
                    black.FillRectangle(brushBlack, 66, 250, 213, 100);
                }
                paint(colorDialog1.Color, x1Faucet, y1Faucet, x2Faucet, y2Faucet);              //Shows the faucets flow of paint with the current color.
                timer1.Interval = 80;                                                           //Changes the timer interval to 500, enabling the flow of paint.
                timer1.Start();                                                                 //Starts the timer to start the flow of paint.
            }
            //Checks  if the trackbar value is equal to 7.
            //If it is, then the paint will begin to pour at
            //a slightly faster rate which is every 60 millseconds.
            else if (trackBar.Value == 7)
            {
                if (bucketFull)
                {
                    bucketFull = false;                                                         //Changes this variable to false as the bucket is no longer full.

                    //Generates a black rectangle in the bucket
                    //to simulate the bucket being emptied.
                    Graphics black = CreateGraphics();
                    Brush brushBlack = new SolidBrush(Color.Black);
                    black.FillRectangle(brushBlack, 66, 250, 213, 100);
                }
                paint(colorDialog1.Color, x1Faucet, y1Faucet, x2Faucet, y2Faucet);              //Shows the faucets flow of paint with the current color.
                timer1.Interval = 60;                                                           //Changes the timer interval to 500, enabling the flow of paint.
                timer1.Start();                                                                 //Starts the timer to start the flow of paint.
            }
            //Checks  if the trackbar value is equal to 8.
            //If it is, then the paint will begin to pour at
            //a slightly faster rate which is every 40 millseconds.
            else if (trackBar.Value == 8)
            {
                if (bucketFull)
                {
                    bucketFull = false;                                                         //Changes this variable to false as the bucket is no longer full.

                    //Generates a black rectangle in the bucket
                    //to simulate the bucket being emptied.
                    Graphics black = CreateGraphics();
                    Brush brushBlack = new SolidBrush(Color.Black);
                    black.FillRectangle(brushBlack, 66, 250, 213, 100);
                }
                paint(colorDialog1.Color, x1Faucet, y1Faucet, x2Faucet, y2Faucet);              //Shows the faucets flow of paint with the current color.
                timer1.Interval = 40;                                                           //Changes the timer interval to 500, enabling the flow of paint.
                timer1.Start();                                                                 //Starts the timer to start the flow of paint.
            }
            //Checks  if the trackbar value is equal to 9.
            //If it is, then the paint will begin to pour at
            //a slightly faster rate which is every 20 millseconds.
            else if (trackBar.Value == 9)
            {
                if (bucketFull)
                {
                    bucketFull = false;                                                         //Changes this variable to false as the bucket is no longer full.

                    //Generates a black rectangle in the bucket
                    //to simulate the bucket being emptied.
                    Graphics black = CreateGraphics();
                    Brush brushBlack = new SolidBrush(Color.Black);
                    black.FillRectangle(brushBlack, 66, 250, 213, 100);
                }
                paint(colorDialog1.Color, x1Faucet, y1Faucet, x2Faucet, y2Faucet);              //Shows the faucets flow of paint with the current color.
                timer1.Interval = 20;                                                           //Changes the timer interval to 500, enabling the flow of paint.
                timer1.Start();                                                                 //Starts the timer to start the flow of paint.
            }
            //Checks  if the trackbar value is equal to 10.
            //If it is, then the paint will begin to pour at
            //a slightly faster rate which is every 10 millseconds.
            else if (trackBar.Value == 10)
            {
                if (bucketFull)
                {
                    bucketFull = false;                                                         //Changes this variable to false as the bucket is no longer full.

                    //Generates a black rectangle in the bucket
                    //to simulate the bucket being emptied.
                    Graphics black = CreateGraphics();
                    Brush brushBlack = new SolidBrush(Color.Black);
                    black.FillRectangle(brushBlack, 66, 250, 213, 100);
                }
                paint(colorDialog1.Color, x1Faucet, y1Faucet, x2Faucet, y2Faucet);              //Shows the faucets flow of paint with the current color.
                timer1.Interval = 10;                                                           //Changes the timer interval to 500, enabling the flow of paint.
                timer1.Start();                                                                 //Starts the timer to start the flow of paint.
            }
        }
        /// <summary>
        /// This is the button that allows the user to open the color dialog box and select a different color of paint.
        /// It can still change the color of the paint even in the middle of a pour.  
        /// </summary>
        /// <param name="sender">standard sender params</param>
        /// <param name="e">standard eventargs params</param>
        private void colorButton_Click(object sender, EventArgs e)
        {
            DialogResult colorResult = colorDialog1.ShowDialog();                               //Shows the color dialog.

            if (colorResult == DialogResult.OK)                                                 //Checks if the user has selected OK.
            {
                currentColor = colorDialog1.Color;                                              //Changes the current color to the color selected in the dialog box by user.

                //Checks if the trackbar value is zero.
                if(trackBar.Value > 0)
                {
                    currentColor = colorDialog1.Color;                                          //Sets the current color to the color of the dialog box even if the faucet is not running.
                    paint(currentColor, x1Faucet, y1Faucet, x2Faucet, y2Faucet);                //Shows the faucets flow of paint with the current color.
                }
                else
                {
                    currentColor = colorDialog1.Color;                                          //Sets the color of the current colot to the color of the dialog box.
                }
            }
        }
        /// <summary>
        /// This is the paint method.  Is generates the graphics that shows
        /// paint coming out of the faucet graphic.  It is simply a rectangle
        /// that turns either the color of the dialog box or black(meaning off).
        /// </summary>
        /// <param name="color">Passes in the color of the dialog box.</param>
        /// <param name="x1">Passes an x coordinate to place the outpour in the right spot.</param>
        /// <param name="y1">Passes an y coordinate to place the outpour in the right spot.</param>
        /// <param name="x2">Passes an x coordinate to place the outpour in the right spot.</param>
        /// <param name="y2">Passes an y coordinate to place the outpour in the right spot.</param>
        private void paint(Color color, int x1,int y1, int x2, int y2)
        {
            //Sets the location of the faucet outpour according to the passed params.
            this.x1Faucet = x1;
            this.y1Faucet = y1;
            this.x2Faucet = x2;
            this.y2Faucet = y2;

            //Sets the current color to the color passed through params.
            this.currentColor = color;                                                      

            //Generates the graphic for the
            //paint coming out of the faucet.
            Graphics graphics = CreateGraphics();
            Pen pen = new Pen(color, 11);
            graphics.DrawLine(pen, x1Faucet, y1Faucet, x2Faucet, y2Faucet);
        }
        /// <summary>
        /// This is the method for the exit button which
        /// allows the user to gracefully exit the program.
        /// </summary>
        /// <param name="sender">standard sender params</param>
        /// <param name="e">standard eventargs e params.</param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();                                                           //Closes the application.
        }
        /// <summary>
        /// This is a very important method for the timer compnent.
        /// Each time it ticks, it redraws both the faucet outpour 
        /// of paint and the bucket paint in order to show the 
        /// appropriate change.
        /// </summary>
        /// <param name="sender">standard sender params.</param>
        /// <param name="e">standard event args e params.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Draws the graphic that represents paint filling the bucket.
            Graphics fill = CreateGraphics();
            Brush brush = new SolidBrush(currentColor);
            fill.FillRectangle(brush, x1Bucket, y1Bucket, x2Bucket, y2Bucket);

            y1Bucket--;                                                         //Moves the bucket paint up by one pixel to simulate the paint level rising.
            y2Faucet = y2Faucet- 1;                                             //Moves the faucet outpour up by 1 pixel so that it follows the increasing paint level of the bucket.

            //Checks if the bucket has reached it's fill limit.
            //If it does, it resets all original x and y positions
            //of both the bucket paint and the faucet paint.
            if(y1Bucket < 255 && y2Faucet < 255)
            {
                bucketFull = true;                                              //Changes to true as the bucket is now full.

                paint(Color.Black, x1Faucet, y1Faucet, x2Faucet, y2Faucet);     //Turns off faucet (changes flow color to black).
                timer1.Stop();                                                  //Stops the timer.

                //Changes faucet x and y coordinates to original values.
                x1Faucet = 78;
                y1Faucet = 135;
                x2Faucet = 78;
                y2Faucet = 349;

                //Changes bucket x and y coordinates to original values.
                x1Bucket = 66;
                y1Bucket = 348;
                x2Bucket = 213;
                y2Bucket = 1;

                trackBar.Value = 0;                                             //Resets trackbar value to zero.
            }
        }
    }
}
