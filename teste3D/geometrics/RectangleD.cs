using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste3D.interfaces;

namespace teste3D.geometrics
{
    public class RectangleD : models.BasePaint
    {
        public PointD P1 { get; set; }
        public PointD P2 { get; set; }
        public PointD P3 { get; set; }
        public PointD P4 { get; set; }

        public RectangleD()
        {
            P1 = new PointD();
            P2 = new PointD();
            P3 = new PointD();
            P4 = new PointD();
        }

        public RectangleD(double x, double y, double z)
        {
            P1 = new PointD() { X = x, Y = y, Z = z };
            P2 = new PointD() { X = x, Y = y, Z = z };
            P3 = new PointD() { X = x, Y = y, Z = z };
            P4 = new PointD() { X = x, Y = y, Z = z };
        }

        public RectangleD(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            P1 = new PointD() { X = x1, Y = y1, Z = z1 };
            P2 = new PointD() { X = x2, Y = y2, Z = z2 };
            P3 = new PointD() { X = x2, Y = y2, Z = z2 };
            P4 = new PointD() { X = x2, Y = y2, Z = z2 };
        }

        public override void DoPaint(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawLine(Pens.Black, P1.fX, P1.fY, P2.fX, P2.fY);
            g.DrawLine(Pens.Black, P2.fX, P2.fY, P3.fX, P3.fY);
            g.DrawLine(Pens.Black, P3.fX, P3.fY, P4.fX, P4.fY);
            g.DrawLine(Pens.Black, P4.fX, P4.fY, P1.fX, P1.fY);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
        }

        public override PointD[] GetPoints()
        {
            return new PointD[] { P1, P2, P3, P4 };
        }

        public override void DoMelt(PointD selected)
        {
            if (P1.OnSamePosition(selected)) P1 = selected;
            if (P2.OnSamePosition(selected)) P2 = selected;
            if (P3.OnSamePosition(selected)) P3 = selected;
            if (P4.OnSamePosition(selected)) P4 = selected;
        }

        public override void DoBreak(PointD selected)
        {
            if (P1 == selected) P1 = new PointD(selected);
            if (P2 == selected) P2 = new PointD(selected);
            if (P3 == selected) P3 = new PointD(selected);
            if (P4 == selected) P4 = new PointD(selected);
        }

    }
}
