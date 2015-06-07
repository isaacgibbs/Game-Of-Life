using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameofLife
{
    public class LifePoint
    {
        public Color c;
        public Boolean live;
        public Boolean exists;
        public int r, g, b;
        public int ageval;
        public LifePoint(Boolean live, Boolean exists)
        {
            this.exists = exists;
            this.live = live;
            this.ageval = 30;
            this.r = 0;
            this.g = 0;
            this.b = 0;
            if (this.live)
            {
                this.c = GameofLife.gameoflife.liveColor;
                this.r = this.c.R;
                this.g = this.c.G;
                this.b = this.c.B;
            }
            else if(this.exists)
            {
                this.r = 255;
                this.c = Color.FromArgb(255, r, g, b);
            }
            else
            {
                this.c = GameofLife.gameoflife.screenColor;
            }
        }
        public LifePoint(Boolean live, Boolean exists, Color c)
        {
            this.exists = exists;
            this.live = live;
            this.ageval = 30;
            this.r = 0;
            this.g = 0;
            this.b = 0;
            if (this.live)
            {
                this.r = c.R;
                this.g = c.G;
                this.b = c.B;
                this.c = Color.FromArgb(255, r, g, b);
            }
            else if (this.exists)
            {
                this.r = 255;
                this.c = Color.FromArgb(255, r, g, b);
            }
            else
            {
                this.c = GameofLife.gameoflife.screenColor;
            }
        }
        public void updateColor()
        {
            if (this.live)
            {
                if (this.r <= 255 - ageval)
                {
                    this.r = this.r + ageval;
                }
                else
                {
                    this.r = 255;
                }
                if (this.g <= 255 - ageval)
                {
                    this.g = this.g + ageval;
                }
                else
                {
                    this.g = 255;
                }
                if (this.b <= 255 - ageval)
                {
                    this.b = this.b + ageval;
                }
                else
                {
                    this.b = 255;
                }
                this.c = Color.FromArgb(255, r, g, b);
            }
            else
            {
                if (this.exists)
                {
                    if (gameoflife.globals.decay && gameoflife.globals.showDead)
                    {
                        if (this.r - ageval >= 0)
                        {
                            this.r = this.r - ageval;
                        }
                        this.c = Color.FromArgb(255, r, g, b);
                    }
                    else if (gameoflife.globals.showDead)
                    {
                        this.r = 255;
                        this.g = 0;
                        this.b = 0;
                        this.c = Color.FromArgb(255, r, g, b);
                    }
                    else
                    {
                        this.c = GameofLife.gameoflife.screenColor;
                    }
                }

                else
                {
                    this.c = GameofLife.gameoflife.screenColor;
                }
            }
        }
    }
}
