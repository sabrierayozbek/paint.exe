using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPProjeSolution
{
    class Rectangle : Sekiller
    {
        public override void draw(Graphics setPaint, SolidBrush shapeColor, int x, int y)
        {
            setPaint.DrawRectangle(new Pen(Color.Black, 0), Math.Min(startX, x), Math.Min(startY, y), Math.Max(startX, x) - Math.Min(startX, x), Math.Max(startY, y) - Math.Min(startY, y));
            setPaint.FillRectangle(shapeColor, Math.Min(startX, x), Math.Min(startY, y), Math.Max(startX, x) - Math.Min(startX, x), Math.Max(startY, y) - Math.Min(startY, y));
            endX = x;
            endY = y;
        }

        public override bool select(Graphics setPaint, Pen pen, int x, int y)
        {
            if (x >= startX && x <= endX && y >= startY && y <= endY)
            {
                setPaint.DrawLine(pen, new Point(startX, startY - 4), new Point(endX, startY - 4));
                setPaint.DrawLine(pen, new Point(endX + 4, startY), new Point(endX + 4, endY));
                setPaint.DrawLine(pen, new Point(endX, endY + 4), new Point(startX, endY + 4));
                setPaint.DrawLine(pen, new Point(startX - 4, endY), new Point(startX - 4, startY));
                return true;
            }
            else if (x <= startX && x >= endX && y <= startY && y >= endY)
            {
                setPaint.DrawLine(pen, new Point(startX + 4, startY), new Point(startX + 4, endY));
                setPaint.DrawLine(pen, new Point(startX, endY - 4), new Point(endX, endY - 4));
                setPaint.DrawLine(pen, new Point(endX - 4, startY), new Point(endX - 4, endY));
                setPaint.DrawLine(pen, new Point(endX, startY + 4), new Point(startX, startY + 4));
                return true;
            }
            else if (x >= startX && x <= endX && y <= startY && y >= endY)
            {
                setPaint.DrawLine(pen, new Point(startX - 4, startY), new Point(startX - 4, endY));
                setPaint.DrawLine(pen, new Point(startX, endY - 4), new Point(endX, endY - 4));
                setPaint.DrawLine(pen, new Point(endX + 4, startY), new Point(endX + 4, endY));
                setPaint.DrawLine(pen, new Point(endX, startY + 4), new Point(startX, startY + 4));
                return true;
            }
            else if (x <= startX && x >= endX && y >= startY && y <= endY)
            {
                setPaint.DrawLine(pen, new Point(startX + 4, startY), new Point(startX + 4, endY));
                setPaint.DrawLine(pen, new Point(startX, endY + 4), new Point(endX, endY + 4));
                setPaint.DrawLine(pen, new Point(endX - 4, startY), new Point(endX - 4, endY));
                setPaint.DrawLine(pen, new Point(endX, startY - 4), new Point(startX, startY - 4));
                return true;
            }
            return false;
        }
    }
}
