/*
    Isaac A. Gibbs
    2/24/2014
    Game of Life
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofLife
{
    public class Globals
    {
        public int wx;
        public int wy;
        public LifePoint[,] startWorld;
        public double sizex;
        public double sizey;
        public Boolean showDead;
        public Boolean decay;
        public Globals(int wx, int wy)
        {
            this.wx = wx;
            this.wy = wy;
            this.startWorld = new LifePoint[this.wx, this.wy];
            //JP Start
            this.startWorld[(int)this.wx / 2, (int)this.wy / 2] = new LifePoint(true, true);
            this.startWorld[(int)this.wx / 2 - 1, (int)this.wy / 2] = new LifePoint(true, true);
            this.startWorld[(int)this.wx / 2, (int)this.wy / 2 + 1] = new LifePoint(true, true);
            this.startWorld[(int)this.wx / 2, (int)this.wy / 2 - 1] = new LifePoint(true, true);
            this.startWorld[(int)this.wx / 2 + 1, (int)this.wy / 2 - 1] = new LifePoint(true, true);

            /* Blinker
            this.startWorld[(int)this.wx / 2, (int)this.wy / 2] = new LifePoint(true);
            this.startWorld[(int)this.wx / 2 - 1, (int)this.wy / 2] = new LifePoint(true);
            this.startWorld[(int)this.wx / 2 + 1, (int)this.wy / 2] = new LifePoint(true);*/

            /*Beehive
            this.startWorld[(int)this.wx / 2, (int)this.wy / 2] = new LifePoint(true);
            this.startWorld[(int)this.wx / 2 + 1, (int)this.wy / 2] = new LifePoint(true);
            this.startWorld[(int)this.wx / 2 + 2, (int)this.wy / 2 + 1] = new LifePoint(true);
            this.startWorld[(int)this.wx / 2 - 1, (int)this.wy / 2 + 1] = new LifePoint(true);
            this.startWorld[(int)this.wx / 2, (int)this.wy / 2 + 2] = new LifePoint(true);
            this.startWorld[(int)this.wx / 2 + 1, (int)this.wy / 2 + 2] = new LifePoint(true);*/

            /*Glider
            this.startWorld[(int)this.wx / 2, (int)this.wy / 2] = new LifePoint(true);
            this.startWorld[(int)this.wx / 2 + 1, (int)this.wy / 2] = new LifePoint(true);
            this.startWorld[(int)this.wx / 2 + 2, (int)this.wy / 2] = new LifePoint(true);
            this.startWorld[(int)this.wx / 2 + 2, (int)this.wy / 2 - 1] = new LifePoint(true);
            this.startWorld[(int)this.wx / 2 + 1, (int)this.wy / 2 - 2] = new LifePoint(true);*/

            /*//Pulsar
            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 12; j++)
                {
                    if (i == 2 || i == 3 || i == 4 || i == 8 || i == 9 || i == 10)
                    {
                        if (j == 0 || j == 5 || j == 7 || j == 12)
                        {
                            if (j == 0)
                            {
                                this.startWorld[(int)wx / 2 + i, (int)wy / 2] = new LifePoint(true);
                                this.startWorld[(int)this.wx / 2, (int)this.wy / 2 + i] = new LifePoint(true);
                            }
                            else
                            {
                                this.startWorld[(int)wx / 2 + i, (int)wy / 2 + j] = new LifePoint(true);
                                this.startWorld[(int)wx / 2 + j, (int)wy / 2 + i] = new LifePoint(true);

                            }
                        }
                    }
                }
            }*/

            for (int i = 0; i < this.wx; i++)
            {
                for (int j = 0; j < this.wy; j++)
                {
                    if (this.startWorld[i, j] == null)
                    {
                        this.startWorld[i, j] = new LifePoint(false, false);
                    }
                }
            }
        }
    }
}
