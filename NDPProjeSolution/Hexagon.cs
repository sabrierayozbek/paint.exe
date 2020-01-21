using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPProjeSolution
{
    class Hexagon : Sekiller
    {
        public override void draw(Graphics setPaint, SolidBrush shapeColor, int x, int y)
        {
            Point[] koseler = { new Point(startX, startY), new Point(x, startY), new Point(x + ((x - startX) / 2), (y + startY) / 2), new Point(x, y), new Point(startX, y), new Point(startX - ((x - startX) / 2), (y + startY) / 2) };
            GraphicsPath hexa = new GraphicsPath();
            hexa.AddPolygon(koseler);
            setPaint.FillPath(shapeColor, hexa);

            endX = x;
            endY = y;

        }

        public override bool select(Graphics setPaint, Pen pen, int x, int y)
        {
            if (x <= (endX + ((endX - startX) / 2)) && x >= startX - ((x - startX) / 2) && y <= endY && y >= startY)
            {
                setPaint.DrawLine(pen, new Point(startX, startY - 4), new Point(endX, startY - 4));
                setPaint.DrawLine(pen, new Point(endX + 4, startY), new Point(endX + ((endX - startX) / 2) + 4, (startY + endY) / 2));
                setPaint.DrawLine(pen, new Point(endX + ((endX - startX) / 2) + 4, (startY + endY) / 2), new Point(endX + 4, endY));
                setPaint.DrawLine(pen, new Point(endX, endY + 4), new Point(startX, endY + 4));
                setPaint.DrawLine(pen, new Point(startX - 4, endY), new Point(startX - ((endX - startX) / 2) - 4, (startY + endY) / 2));
                setPaint.DrawLine(pen, new Point(startX - ((endX - startX) / 2) - 4, (startY + endY) / 2), new Point(startX - 4, startY));
                return true;
            }
            else if (x <= (startX + (startX - endX) / 2) && x >= (endX - (startX - endX) / 2) && y >= endY && y <= startY)
            {
                setPaint.DrawLine(pen, new Point(startX, startY + 4), new Point(endX, startY + 4));
                setPaint.DrawLine(pen, new Point(endX - 4, startY), new Point((endX - (startX - endX) / 2) - 4, (startY + endY) / 2));
                setPaint.DrawLine(pen, new Point((endX - (startX - endX) / 2) - 4, (startY + endY) / 2), new Point(endX - 4, endY));
                setPaint.DrawLine(pen, new Point(endX, endY - 4), new Point(startX, endY - 4));
                setPaint.DrawLine(pen, new Point(startX + 4, endY), new Point(startX + ((startX - endX) / 2) + 4, (startY + endY) / 2));
                setPaint.DrawLine(pen, new Point(startX + ((startX - endX) / 2) + 4, (startY + endY) / 2), new Point(startX + 4, startY));
                return true;
            }
            else if (x <= (endX + (endX - startX) / 2) && x >= (startX - (endX - startX) / 2) && y <= startY && y >= endY)
            {
                setPaint.DrawLine(pen, new Point(startX, startY + 4), new Point(endX, startY + 4));
                setPaint.DrawLine(pen, new Point(endX + 4, startY), new Point((endX + (endX - startX) / 2) + 4, (startY + endY) / 2));
                setPaint.DrawLine(pen, new Point((endX + (endX - startX) / 2) + 4, (startY + endY) / 2), new Point(endX + 4, endY));
                setPaint.DrawLine(pen, new Point(endX, endY - 4), new Point(startX, endY - 4));
                setPaint.DrawLine(pen, new Point(startX - 4, endY), new Point((startX - (endX - startX) / 2) - 4, (startY + endY) / 2));
                setPaint.DrawLine(pen, new Point((startX - (endX - startX) / 2) - 4, (startY + endY) / 2), new Point(startX - 4, startY));
                return true;
            }
            else if (x <= (startX + (startX - endX) / 2) && x >= (endX - (startX - endX) / 2) && y <= endY && y >= startY)
            {
                setPaint.DrawLine(pen, new Point(startX, startY - 4), new Point(endX, startY - 4));
                setPaint.DrawLine(pen, new Point(endX - 4, startY), new Point((endX - (startX - endX) / 2) - 4, (startY + endY) / 2));
                setPaint.DrawLine(pen, new Point((endX - (startX - endX) / 2) - 4, (startY + endY) / 2), new Point(endX - 4, endY));
                setPaint.DrawLine(pen, new Point(endX, endY + 4), new Point(startX, endY + 4));
                setPaint.DrawLine(pen, new Point(startX + 4, endY), new Point(startX + ((startX - endX) / 2) + 4, (startY + endY) / 2));
                setPaint.DrawLine(pen, new Point(startX + ((startX - endX) / 2) + 4, (startY + endY) / 2), new Point(startX + 4, startY));
                return true;
            }
            return false;
        }
    }
}
