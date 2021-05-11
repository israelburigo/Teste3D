using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste3D.interfaces;

namespace teste3D.geometrics
{
    public class PointD : models.BasePaint
    {
        public Pen Pen { get; set; }

        public bool Locked { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public float fX { get { return (float)X; } }
        public float fY { get { return (float)Y; } }
        public float fZ { get { return (float)Z; } }

        public int iX { get { return (int)X; } }
        public int iY { get { return (int)Y; } }
        public int iZ { get { return (int)Z; } }

        public PointF Float { get { return new PointF() { X = fX, Y = fY }; } }
        public Point Int { get { return new Point() { X = iX, Y = iY }; } }

        public PointD(PointD p)
        {
            X = p.X;
            Y = p.Y;
            Z = p.Z;
            Pen = new Pen(Color.RoyalBlue, 2);
        }

        public PointD()
        {
            Pen = new Pen(Color.RoyalBlue, 2);
        }

        public PointD SetXyz(PointD p)
        {
            X = p.X;
            Y = p.Y;
            Z = p.Z;
            return this;
        }

        public PointD SetXyz(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            return this;
        }

        public override void DoPaint(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawEllipse(Pen, fX - 4, fY - 4, 8, 8);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
        }

        public override PointD[] GetPoints()
        {
            return new[] { this };
        }

        internal bool IsNear(double x, double y)
        {
            var dx = X - x;
            var dy = Y - y;
            return Math.Sqrt(dx * dx + dy * dy) < 8;
        }

        internal bool OnSamePosition(PointD p)
        {
            return X == p.X && Y == p.Y && Z == p.Z;
        }

    }
}
