using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NDPProjeSolution
{
    abstract class Sekiller
    {
        public string shapeName { get; set; }
        public int startX { get; set; }
        public int startY { get; set; }
        public int endX { get; set; }
        public int endY { get; set; }
        public Color Color { get; set; }
       

        public abstract void draw(Graphics setPaint, SolidBrush shapeColor, int x, int y);
        public abstract bool select(Graphics setPaint, Pen pen, int x, int y);
    }
}
