using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPProjeSolution
{
    class Daire : Sekiller
    {
        public override void draw(Graphics setPaint, SolidBrush shapeColor, int x, int y)
        {
            setPaint.DrawEllipse(new Pen(Color.Black, 0), startX, startY, x - startX, y - startY);
            setPaint.FillEllipse(shapeColor, startX, startY, x - startX, y - startY);
            endX = x;
            endY = y;
        }

        public override bool select(Graphics setPaint, Pen pen, int x, int y)
        {
            if (x <= endX && x >= startX && y >= startY && y <= endY)
            {
                setPaint.DrawLine(pen, new Point(startX, startY - 4), new Point(endX, startY - 4));
                setPaint.DrawLine(pen, new Point(endX + 4, startY), new Point(endX + 4, endY));
                setPaint.DrawLine(pen, new Point(endX, endY + 4), new Point(startX, endY + 4));
                setPaint.DrawLine(pen, new Point(startX - 4, endY), new Point(startX - 4, startY));
                return true;
            }
            else if (x >= endX && x <= startX && y <= startY && y >= endY)
            {
                setPaint.DrawLine(pen, new Point(startX, startY + 4), new Point(endX, startY + 4));
                setPaint.DrawLine(pen, new Point(endX - 4, startY), new Point(endX - 4, endY));
                setPaint.DrawLine(pen, new Point(endX, endY - 4), new Point(startX, endY - 4));
                setPaint.DrawLine(pen, new Point(startX + 4, endY), new Point(startX + 4, startY));
                return true;
            }
            else if (x <= endX && x >= startX && y <= startY && y >= endY)
            {
                setPaint.DrawLine(pen, new Point(startX, startY + 4), new Point(endX, startY + 4));
                setPaint.DrawLine(pen, new Point(endX + 4, startY), new Point(endX + 4, endY));
                setPaint.DrawLine(pen, new Point(endX, endY - 4), new Point(startX, endY - 4));
                setPaint.DrawLine(pen, new Point(startX - 4, endY), new Point(startX - 4, startY));
                return true;
            }
            else if (x >= endX && x <= startX && y >= startY && y <= endY)
            {
                setPaint.DrawLine(pen, new Point(startX, startY - 4), new Point(endX, startY - 4));
                setPaint.DrawLine(pen, new Point(endX - 4, startY), new Point(endX - 4, endY));
                setPaint.DrawLine(pen, new Point(endX, endY + 4), new Point(startX, endY + 4));
                setPaint.DrawLine(pen, new Point(startX + 4, endY), new Point(startX + 4, startY));
                return true;
            }
            return false;
        }
    }
}
