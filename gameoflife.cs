/*
    Isaac A. Gibbs
    2/24/2014
    Game of Life
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace GameofLife
{
    public partial class gameoflife : Form
    {
        LifePoint[,] currentWorld;
        LifePoint[,] nextWorld;
        LifePoint[,] imageGrid;
        public static Globals globals;
        SolidBrush brush;
        Pen pen;
        Pen selection;
        int worldx = 50;
        int worldy = 50;
        //double zoomLimiter = 30;
        //int zoomLevel = 0;
        //int zoomSpeed = 1;
        Boolean autoAdvance = false;
        Boolean drawGrid = false;
        Boolean wrap = false;
        Boolean mouseHover;
        Rectangle zoomFrame;
        Rectangle selectionBox;
        public static Color screenColor = Color.FromArgb(255, 0, 0, 0);
        public static Color liveColor = Color.FromArgb(255, 165, 136, 105);
        bool dragging;
        public gameoflife()
        {
            InitializeComponent();
            createWorld();
        }
        public void createWorld()
        {
            dragging = false;
            worldy = worldx;
            brush = new SolidBrush(Color.Black);
            pen = new Pen(Color.Gray, 1);
            selection = new Pen(Color.Green, 2);
            globals = new Globals(worldx, worldy);
            globals.sizex = worldBox.Width / worldx;
            globals.sizey = worldBox.Height / worldy;
            currentWorld = globals.startWorld;
            nextWorld = new LifePoint[worldx, worldy];
            worldTimer.Interval = timeSlider.Value;
            worldTimer.Start();
            timer1.Start();
            //zoomFrame = new Rectangle(0,0,worldx,worldx);
            selectionBox = new Rectangle(0,0,0,0);
            if (checkDead.Checked)
            {
                globals.showDead = true;
            }
            if (checkDecay.Checked)
            {
                globals.decay = true;
            }
        }
        public void loadWorld()
        {
            worldy = worldx;
            for (int i = 0; i < this.worldx; i++)
            {
                for (int j = 0; j < this.worldy; j++)
                {
                    if (globals.startWorld[i, j] == null)
                    {
                        globals.startWorld[i, j] = new LifePoint(false, false);
                    }
                }
            }
            autoAdvance = false;
            textBox1.Text = worldx.ToString();
            globals.sizex = worldBox.Width / worldx;
            globals.sizey = worldBox.Height / worldy;
            currentWorld = globals.startWorld;
            nextWorld = new LifePoint[worldx, worldy];
            worldTimer.Interval = timeSlider.Value;
            worldTimer.Start();
            timer1.Start();
        }
        private void updateWorld()
        {
            int neighbors = 0;
            nextWorld = new LifePoint[worldx, worldy];
            for (int i = 0; i < worldx; i++)
            {
                for (int j = 0; j < worldy; j++)
                {
                    neighbors = neighborCount(i, j);
                    if (neighbors < 2 || neighbors > 3)
                    {
                        if (currentWorld[i, j].live)
                        {
                            nextWorld[i, j] = new LifePoint(false, true);   
                        }
                        else if(currentWorld[i,j].exists)
                        {
                            nextWorld[i, j] = currentWorld[i, j];
                        }
                        else
                        {
                            nextWorld[i, j] = new LifePoint(false, false);
                        }
                    }
                    else if (neighbors == 3 && !currentWorld[i,j].live)
                    {
                        nextWorld[i, j] = new LifePoint(true, true);
                    }
                    else
                    {
                        nextWorld[i, j] = currentWorld[i, j];
                    }
                    nextWorld[i, j].updateColor();
                }
            }
            currentWorld = nextWorld;
        }

        public int neighborCount(int x, int y)
        {
            int num = 0; //total number of neighbors found
            int x1 = 0; //temp values for storing the location being tested
            int y1 = 0;
            for (int i = -1; i <= 1; i++) //Loops interate through locations from (x-1, y-1) to (x+1, y+1)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (!(i == 0 && j == 0)) //stops the loops from checking the center point
                    {
                        if (wrap) //checks for screen wrap
                        {
                            x1 = (x + worldx + i) % worldx; //gives absolute location on grid
                            y1 = (y + worldy + j) % worldy;
                            if (currentWorld[x1, y1].live) //checks for living point
                            {
                                num++;
                            }
                        }
                        else
                        {
                            x1 = x + i; 
                            y1 = y + j;
                            if ((x1 >= 0 && x1 < worldx) && (y1 >= 0 && y1 < worldy)) //only checks points within the current grid bounds
                            {
                                if (currentWorld[x1, y1].live) //checks for living point
                                {
                                    num++;
                                }
                            }
                        }
                    }
                }
            }
            return num;
        }
        private void worldBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle();
            rect.Width = (int)globals.sizex;
            rect.Height = (int)globals.sizey;
            for (int i = 0; i < worldx; i++)
            {
                for (int j = 0; j < worldy; j++)
                {
                    brush.Color = currentWorld[i, j].c;
                    rect.X = i* (int)(globals.sizex);
                    rect.Y = j * (int)(globals.sizey);
                    g.FillRectangle(brush, rect);
                    if (drawGrid)
                    {
                        g.DrawRectangle(pen, rect);
                    }
                }
            }
            g.DrawRectangle(selection, selectionBox);
        }
        private void worldBox_MouseWheel(object sender, MouseEventArgs e)
        {
            /*if (e.Delta < 0)
            {
                ZoomOut();
            }
            else
            {
                ZoomIn();
            }
            setZoom();*/
        }
        /*private void setZoom()
        {
            int x = zoomLevel * zoomSpeed;
            int y = (worldy / worldx) * x;
            int x2 = worldx - x;
            x2 = x2 - x;
            int y2 = worldy - y;
            y2 = y2 - y;
            zoomFrame.X = x;
            zoomFrame.Y = y;
            zoomFrame.Width = x2;
            zoomFrame.Height = y2;
            globals.sizex = worldBox.Width / zoomFrame.Width;
            globals.sizey = worldBox.Height / zoomFrame.Height;
        }
        private void ZoomIn()
        {
            if ((zoomLevel * zoomSpeed) < (worldx/2))
            {
                zoomLevel++;
            }
        }
        private void ZoomOut()
        {
            if (zoomLevel > 0)
            {
                zoomLevel--;
            }
        }
        /*private void setZoom()
        {
            double x = (zoomLevel * (((worldBox.Width / 2) - zoomLimiter) / zoomSpeed));
            double y = (worldy / worldx) * x;
            double x2 = worldBox.Width - x;
            x2 = x2 - x;
            double y2 = worldBox.Height - y;
            y2 = y2 - y;
            x = x / (worldBox.Width / worldx);
            y = y / (worldBox.Height / worldy);
            x2 = x2 / (worldBox.Width / worldx);
            y2 = y2 / (worldBox.Height / worldy);
            if (x < 0)
            {
                zoomFrame.X = 0;
            }
            if (y < 0)
            {
                zoomFrame.Y = 0;
            }
            if ((x2 + x) > worldx)
            {
                zoomFrame.Width = worldx;
            }
            if ((y2 + y) > worldy)
            {
                zoomFrame.Height = worldy;
            }
            else
            {
                zoomFrame.X = (int)x;
                zoomFrame.Y = (int)y;
                zoomFrame.Width = (int)x2;
                zoomFrame.Height = (int)y2;
            }
            globals.sizex = worldBox.Width / zoomFrame.Width;
            globals.sizey = worldBox.Height / zoomFrame.Height;
        }
        private void ZoomIn()
        {
            if (zoomLevel < 1.9)
            {
                zoomLevel += 0.1;
            }
        }
        private void ZoomOut()
        {
            if (zoomLevel > 0)
            {
                zoomLevel -= 0.1;
            }
        }*/

        private void worldBox_Click(object sender, EventArgs e)
        {

        }

        private void worldTimer_Tick(object sender, EventArgs e)
        {
            if (autoAdvance)
            {
                updateWorld();
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            worldTimer.Stop();
            int n;
            bool isNumeric = int.TryParse( textBox1.Text, out n);
            if (isNumeric)
            {
                worldx = int.Parse(textBox1.Text);
            }
            else
            {
                worldx = 50;
            }
            worldy = worldx;
            createWorld();
            worldTimer.Start();
        }

        private void worldBox_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            x = (int)(zoomFrame.X + (x / globals.sizex));
            y = (int)(zoomFrame.Y + (y / globals.sizey));
            if (currentWorld[x, y].live)
            {
                currentWorld[x, y] = new LifePoint(false, false);
            }
            else
            {
                currentWorld[x, y] = new LifePoint(true, true);
            }
            currentWorld[x, y].updateColor();
            worldBox.Refresh();
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            updateWorld();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            autoAdvance = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            autoAdvance = false;
        }

        private void gridBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gridBox.Checked)
            {
                drawGrid = true;
            }
            else
            {
                drawGrid = false;
            }
        }

        private void timeSlider_Scroll(object sender, ScrollEventArgs e)
        {
            worldTimer.Interval = e.NewValue;
        }


        private void checkWrap_CheckedChanged(object sender, EventArgs e)
        {
            if (checkWrap.Checked)
            {
                this.wrap = true;
            }
            else
            {
                this.wrap = false;
            }
        }

        private void worldBox_MouseEnter(object sender, EventArgs e)
        {
            worldBox.Focus();
        }

        private void worldBox_MouseHover(object sender, EventArgs e)
        {
            if (this.mouseHover == false)
            {
                this.mouseHover = true;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog openFileDialog1 = new SaveFileDialog();
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            DialogResult userClickedOK = openFileDialog1.ShowDialog();

            if (userClickedOK == DialogResult.OK)
            {
                System.IO.FileInfo fInfo = new System.IO.FileInfo(openFileDialog1.FileName);

                string strFileName = fInfo.Name;

                string strFilePath = fInfo.DirectoryName;
                writeNewFile(strFilePath, strFileName);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            DialogResult userClickedOK = openFileDialog1.ShowDialog();

            if (userClickedOK == DialogResult.OK)
            {
                System.IO.FileInfo fInfo = new System.IO.FileInfo(openFileDialog1.FileName);

                string strFileName = fInfo.Name;

                string strFilePath = fInfo.DirectoryName;
                readFile(strFilePath, strFileName);
            }
        }

        public void setWorldSize()
        {
            int n;
            bool isNumeric = int.TryParse(textBox1.Text, out n);

            if (isNumeric)
            {
                worldTimer.Stop();
                timer1.Stop();
                int sizeRatio = worldx;
                int ox = worldx;
                int oy = worldy;
                worldx = int.Parse(textBox1.Text);
                sizeRatio = (worldx - sizeRatio) / 2;
                worldy = worldx;
                zoomFrame = new Rectangle(0, 0, worldx, worldx);
                nextWorld = new LifePoint[worldx, worldy];
                double sx, sy;
                for (int i = 0; i < ox; i++)
                {
                    for (int j = 0; j < oy; j++)
                    {
                        if (currentWorld[i, j].live)
                        {
                            sx = i + sizeRatio;
                            sy = j + sizeRatio;
                            if ((int)sx < worldx && (int)sy < worldy)
                            {
                                if ((int)sx >= 0 && (int)sy >= 0)
                                {
                                    nextWorld[(int)sx, (int)sy] = new LifePoint(true, true);
                                }
                            }
                        }
                    }
                }
                currentWorld = nextWorld;
                for (int i = 0; i < this.worldx; i++)
                {
                    for (int j = 0; j < this.worldy; j++)
                    {
                        if (currentWorld[i, j] == null)
                        {
                            currentWorld[i, j] = new LifePoint(false, false);
                        }
                    }
                }
                globals.sizex = worldBox.Width / worldx;
                globals.sizey = worldBox.Height / worldy;
                worldTimer.Start();
                timer1.Start();
            }
        }

        private void writeNewFile(String directory, String name)
        {
            using (System.IO.StreamWriter writer =
            new System.IO.StreamWriter((directory + "\\" + name)))
            {
                writer.WriteLine(worldx.ToString());
                for (int i = 0; i < worldx; i++)
                {
                    for (int j = 0; j < worldy; j++)
                    {
                        if(currentWorld[i,j].live)
                        {
                            writer.WriteLine(i.ToString() + " " + j.ToString()); 
                        }
                    }
                }
                writer.Close();
            }
        }

        private void readFile(String directory, String name)
        {
            int[] worldSize = new int[2];
            int x, y = 0;
            List<int[]> tempCoords = new List<int[]>();
            Boolean parseOk = false;
            String fline;
            System.IO.StreamReader file = new System.IO.StreamReader((directory + "\\" + name));
            
            if((fline = file.ReadLine()) != null){
                //parseOk = int.TryParse(fline.Split(' ')[0], out worldSize[0]); //used for setting x and y sizes individually
                //parseOk = int.TryParse(fline.Split(' ')[1], out worldSize[1]);
                parseOk = int.TryParse(fline, out worldSize[0]);
                if (parseOk)
                {
                    while ((fline = file.ReadLine()) != null && parseOk)
                    {
                        parseOk = int.TryParse(fline.Split(' ')[0], out x);
                        parseOk = int.TryParse(fline.Split(' ')[1], out y);
                        if (parseOk)
                        {
                            tempCoords.Add(new int[2]{x, y});
                        }
                    }
                    if (parseOk)
                    {
                        worldx = worldSize[0];
                        worldy = worldSize[0];
                        globals.startWorld = new LifePoint[worldx, worldy];
                        foreach(int[] coord in tempCoords)
                        {
                            if(coord[0] <= worldx - 1 && coord[0] >= 0)
                            {
                                if(coord[1] <= worldy - 1 && coord[1] >= 0)
                                {
                                    globals.startWorld[coord[0], coord[1]] = new LifePoint(true, true);
                                }
                            }
                        }
                        loadWorld();
                    }
                }
            }
            file.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            worldBox.Refresh();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                setWorldSize();
            }
        }

        private void checkDead_CheckedChanged(object sender, EventArgs e)
        {
            globals.showDead = checkDead.Checked;
        }

        private void checkDecay_CheckedChanged(object sender, EventArgs e)
        {
            globals.decay = checkDecay.Checked;
        }

        private void gameoflife_Load(object sender, EventArgs e)
        {

        }

        private void worldBox_MouseDown(object sender, MouseEventArgs e) //sets the upper left point of the selection box
        {
            timer1.Stop();
            worldTimer.Stop();
            int x2 = e.X / (worldBox.Width / worldx); 
            int y2 = e.Y / (worldBox.Height / worldy); 
            this.selectionBox.X = x2 * (int)((globals.sizex) + 0.6); //converts to the display selection coordinates
            this.selectionBox.Y = y2 * (int)((globals.sizey) + 0.6);
        }

        private void worldBox_MouseUp(object sender, MouseEventArgs e) //sets the width and height of the selection box
        {
            int x2 = e.X / (worldBox.Width / worldx);
            int y2 = e.Y / (worldBox.Height / worldy);
            this.selectionBox.Width = (x2 * (int)((globals.sizex) + 0.6)) - this.selectionBox.X;
            this.selectionBox.Height = (y2 * (int)((globals.sizex) + 0.6)) - this.selectionBox.Y;
            worldTimer.Start();
            timer1.Start();
        }
        public void horizontalMirror()
        {
            int x = this.selectionBox.X / (worldBox.Width / worldx); //converts world selection coordinates to unit coordinates
            int y = this.selectionBox.Y / (worldBox.Height / worldy); 
            int width = this.selectionBox.Width / (worldBox.Width / worldx);
            int height = this.selectionBox.Height / (worldBox.Height / worldy);
            int x2 = width + x;
            int y2 = height + y;
            if (this.selectionBox.Width / (worldBox.Width / worldx) > 2) //checks for a minimum selection width of 2
            {
                LifePoint[,] temp = new LifePoint[worldx, worldy]; //temporary array for storing changes
                for (int i = x; i < x2 - 1; i++)
                {
                    for (int j = y; j < y2 - 1; j++)
                    {
                        if (i != (x2 - i)) //checks if the index is at a mid point that can't be mirrored
                        {
                            temp[i, j] = currentWorld[x2 - i, j];
                        }
                        else
                        {
                            temp[i, j] = currentWorld[i, j];
                        }
                    }
                }
                for (int i = x; i < x2 - 1; i++)
                {
                    for (int j = y; j < y2 - 1; j++)
                    {
                        currentWorld[i, j] = temp[i, j];
                    }
                }
            }
        }
        public void verticalMirror()
        {

        }

        private void hmirrorButton_Click(object sender, EventArgs e)
        {
            horizontalMirror();
        }

        private void vmirrorButton_Click(object sender, EventArgs e)
        {
            verticalMirror();
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Bitmap Images (.bmp)|*.bmp|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            DialogResult userClickedOK = openFileDialog1.ShowDialog();

            if (userClickedOK == DialogResult.OK)
            {
                System.IO.FileInfo fInfo = new System.IO.FileInfo(openFileDialog1.FileName);

                string strFileName = fInfo.Name;

                string strFilePath = fInfo.DirectoryName;
                readImage(strFilePath, strFileName);
            }
        }
        private void refreshImage()
        {
            Color tempc;
            int colort;
            bool isNumeric = int.TryParse(colorThreshold.Text, out colort);
            bool invert = invertThresh.Checked;
            if (isNumeric && (imageGrid != null))
            {
                for (int i = 0; i < worldx; i++)
                {
                    for (int j = 0; j < worldy; j++)
                    {
                        if (imageGrid[i, j] != null)
                        {
                            tempc = imageGrid[i, j].c;
                        }
                        else
                        {
                            tempc = Color.FromArgb(0, 0, 0, 0);
                        }
                        if (!invert)
                        {
                            if ((tempc.R + tempc.G + tempc.B) / 3 > colort)
                            {
                                globals.startWorld[i, j] = new LifePoint(true, true, tempc);
                            }
                            else
                            {
                                globals.startWorld[i, j] = new LifePoint(false, false);
                            }
                        }
                        else
                        {
                            if ((tempc.R + tempc.G + tempc.B) / 3 < colort)
                            {
                                globals.startWorld[i, j] = new LifePoint(true, true, tempc);
                            }
                            else
                            {
                                globals.startWorld[i, j] = new LifePoint(false, false);
                            }
                        }
                    }
                }
                loadWorld();
            }
        }
        private void readImage(String directory, String name)
        {
            Bitmap bmp = (Bitmap)Image.FromFile(directory + "\\" + name);
            int colort;
            bool isNumeric = int.TryParse(colorThreshold.Text, out colort);
            if(isNumeric)
            {
                if((bmp.Width > worldx) || (bmp.Height > worldy))
                {
                    if(bmp.Width > bmp.Height) {
                        textBox1.Text = (bmp.Width + 10).ToString();
                    }
                    else
                    {
                        textBox1.Text = (bmp.Height + 10).ToString();
                    }
                    setWorldSize();
                }
                Color tempc;
                int sx = (worldx/2) - (bmp.Width/2);
                int sy = (worldy/2) - (bmp.Height/2);
                globals.startWorld = new LifePoint[worldx, worldy];
                imageGrid = new LifePoint[worldx, worldy];
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        tempc = bmp.GetPixel(i , j);
                        if ((tempc.R > 0) || (tempc.G > 0) || (tempc.B > 0))
                        {
                            imageGrid[i + sx, j + sy] = new LifePoint(true, true, tempc);
                        }
                        if ((tempc.R + tempc.G + tempc.B) / 3 > colort)
                        {
                            globals.startWorld[i + sx, j + sy] = new LifePoint(true, true, tempc);
                        }
                    }
                }
                loadWorld();
            }
        }

        private void refreshbutton_Click(object sender, EventArgs e)
        {
            refreshImage();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            colorThreshold.Text = hScrollBar1.Value.ToString();
        }

        private void colorThreshold_TextChanged(object sender, EventArgs e)
        {
            int num;
            bool isNumeric = int.TryParse(colorThreshold.Text, out num);
            if (isNumeric)
            {
                hScrollBar1.Value = num;
            }
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            screenColor = colorDialog1.Color;
            worldBox.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            liveColor = colorDialog1.Color;
            worldBox.Refresh();
        }

    }
}
