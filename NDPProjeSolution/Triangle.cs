using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPProjeSolution
{
    class Triangle : Sekiller
    {
        public override void draw(Graphics setPaint, SolidBrush shapeColor, int x, int y)
        {
            Point[] corners = { new Point(startX, startY), new Point(x, y), new Point(startX - x + startX, y) };
            GraphicsPath tri = new GraphicsPath();
            tri.AddPolygon(corners);
            setPaint.FillPath(shapeColor, tri);
            endX = x;
            endY = y;
        }

        public override bool select(Graphics setPaint, Pen pen, int x, int y)
        {
            if (x >= (startX - endX + startX) && x <= endX && y >= startY && y <= endY)
            {
                setPaint.DrawLine(pen, new Point(startX + 4, startY), new Point(endX + 4, endY));
                setPaint.DrawLine(pen, new Point(endX, endY + 4), new Point(startX - endX + startX, endY + 4));
                setPaint.DrawLine(pen, new Point(startX - endX + startX - 4, endY), new Point(startX - 4, startY));
                return true;
            }
            else if (x <= (startX - endX + startX) && x >= endX && y >= endY && y <= startY)
            {
                setPaint.DrawLine(pen, new Point(startX - 4, startY), new Point(endX - 4, endY));
                setPaint.DrawLine(pen, new Point(endX, endY - 4), new Point(startX - endX + startX, endY - 4));
                setPaint.DrawLine(pen, new Point(startX - endX + startX + 4, endY), new Point(startX + 4, startY));
                return true;
            }
            else if (x <= endX && x >= (startX - endX + startX) && y <= startY && y >= endY)
            {
                setPaint.DrawLine(pen, new Point(startX + 4, startY), new Point(endX + 4, endY));
                setPaint.DrawLine(pen, new Point(endX, endY + 4), new Point(startX - endX + startX, endY + 4));
                setPaint.DrawLine(pen, new Point(startX - endX + startX - 4, endY), new Point(startX - 4, startY));
                return true;
            }
            else if (x <= (startX - endX + startX) && x >= endX && y >= startY && y <= endY)
            {
                setPaint.DrawLine(pen, new Point(startX - 4, startY), new Point(endX - 4, endY));
                setPaint.DrawLine(pen, new Point(endX, endY + 4), new Point(startX - endX + startX, endY + 4));
                setPaint.DrawLine(pen, new Point(startX - endX + startX + 4, endY), new Point(startX + 4, startY));
                return true;
            }
            return false;
        }
    }
}
