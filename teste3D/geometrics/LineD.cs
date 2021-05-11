using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste3D.interfaces;

namespace teste3D.geometrics
{
    public class LineD : models.BasePaint
    {
        public PointD P1 { get; set; }
        public PointD P2 { get; set; }       

        public LineD()
        {
            P1 = new PointD();
            P2 = new PointD();
            Cor = Color.Black.ToArgb();
            PenSize = 1;
        }

        public LineD(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            P1 = new PointD() { X = x1, Y = y1, Z = z1 };
            P2 = new PointD() { X = x2, Y = y2, Z = z2 };
            Cor = Color.Black.ToArgb();
            PenSize = 1;
        }

        public override void DoPaint(Graphics g)
        {
            var pen = new Pen(Color.FromArgb(Cor), PenSize);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawLine(pen, P1.fX, P1.fY, P2.fX, P2.fY);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
        }

        public override PointD[] GetPoints()
        {
            return new PointD[] { P1, P2 };
        }

        public override void DoMelt(PointD selected)
        {   
            if (P1.OnSamePosition(selected)) P1 = selected;
            if (P2.OnSamePosition(selected)) P2 = selected;
        }

        public override void DoBreak(PointD selected)
        {
            if (P1 == selected) P1 = new PointD(selected);
            if (P2 == selected) P2 = new PointD(selected);            
        }
    }
}
