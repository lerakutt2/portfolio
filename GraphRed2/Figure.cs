using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphRed2
{
    public abstract class Figure
    {
        public int width, height, thickness;
        public Color lineColor;
        public int x, y;
        public Figure(int thickness, Color color)
        {
            width = 100;
            height = 100;
            lineColor = color;
            this.thickness = thickness;
        }

        public abstract void FillPoints(Point[] p);
        public abstract void Draw(Graphics g);
        public abstract bool HasInside(Point p);
    }
    public class Ellipse : Figure
    {
        public Ellipse(int thickness, Color color) : base(thickness, color) { }
        public override void FillPoints(Point[] p)
        {
            if (p[0].X < p[1].X)
            {
                x = p[0].X;
                if (p[0].Y < p[1].Y) y = p[0].Y;
                else y = p[1].Y;
            }
            else
            {
                x = p[1].X;
                if (p[0].Y < p[1].Y) y = p[0].Y;
                else y = p[1].Y;
            }
            width = Math.Abs(p[1].X - p[0].X);
            height = Math.Abs(p[1].Y - p[0].Y);
        }
        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(lineColor, thickness);
            g.DrawEllipse(pen, x, y, width, height);
        }
        public override bool HasInside(Point p)
        {
            if (p.X > x && p.X < x + width && p.Y > y && p.Y < y + height) return true;
            return false;
        }
    }
    public class Rectangle : Figure
    {
        public Rectangle(int thickness, Color color) : base(thickness, color) { }

        public override void FillPoints(Point[] p)
        {
            if (p[0].X < p[1].X)
            {
                x = p[0].X;
                if (p[0].Y < p[1].Y) y = p[0].Y;
                else y = p[1].Y;
            }
            else
            {
                x = p[1].X;
                if (p[0].Y < p[1].Y) y = p[0].Y;
                else y = p[1].Y;
            }
            width = Math.Abs(p[1].X - p[0].X);
            height = Math.Abs(p[1].Y - p[0].Y);
        }
        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(lineColor, thickness);
            g.DrawRectangle(pen, x, y, width, height);
        }

        public override bool HasInside(Point p)
        {
            if (p.X > x && p.X < x + width && p.Y > y && p.Y < y + height)  return true;
            return false;
        }
    }
    public class Triangle : Figure
    {
        Point[] points;
        public Triangle(int thickness, Color color) : base(thickness, color) { }
        public override void FillPoints(Point[] p)
        {
            Point p1 = p[0];
            Point p2 = p[1];
            points = new Point[3];
            points[0] = p1;
            points[1] = new Point((p2.X + p1.X) / 2, p2.Y);
            points[2] = new Point(p2.X, p1.Y);
        }
        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(lineColor, thickness);
            g.DrawPolygon(pen, points);
        }
        public override bool HasInside(Point p)
        {
            if (p.X < points[2].X && p.X > points[0].X && p.Y < points[1].Y && p.Y > points[0].Y)
            {
                if (points[1].Y > points[0].Y && p.Y < points[1].Y && p.Y > points[0].Y)
                {
                    return true;
                }
                else if (points[0].Y > points[1].Y && p.Y < points[0].Y && p.Y > points[1].Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
