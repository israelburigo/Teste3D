using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using teste3D.geometrics;
using teste3D.interfaces;

namespace teste3D.models
{
    public class PaintList : List<IPaint>
    {
        public PointD Origin { get; set; }
        public double Zoom { get; set; }

        public PaintList()
        {
            Origin = new PointD() { X = 0, Y = 0, Z = 0 };
            Zoom = 1.0;
        }

        private List<PointD> GetAllPoints()
        {
            var result = new List<PointD>();
            foreach (var item in this)
                foreach (var p in item.GetPoints())
                    if (!result.Contains(p)) result.Add(p);
            return result;
        }

        internal PointD DoSelectPoint(double x, double y)
        {
            return this.GetAllPoints().FirstOrDefault(g => !g.Locked && g.IsNear(x, y));
        }

        internal PointD DoSelectAnotherPoint(PointD po, double x, double y)
        {   
            return this.GetAllPoints().FirstOrDefault(g => !g.Locked && g != po && g.IsNear(x, y));
        }

        internal void DoMelt(PointD selected)
        {
            foreach (var item in this)
                item.DoMelt(selected);
        }

        internal void DoBreak(PointD selected)
        {
            foreach (var item in this)
                item.DoBreak(selected);
        }

        #region Transformations
        public void RotateX(double rad)
        {
            var r = new double[3, 3];
            r[0, 0] = 1;
            r[0, 1] = 0;
            r[0, 2] = 0;
            r[1, 0] = 0;
            r[1, 1] = Math.Cos(rad);
            r[1, 2] = -Math.Sin(rad);
            r[2, 0] = 0;
            r[2, 1] = Math.Sin(rad);
            r[2, 2] = Math.Cos(rad);
            this.Calc(r);
        }

        public void RotateY(double rad)
        {
            var r = new double[3, 3];
            r[0, 0] = Math.Cos(rad);
            r[0, 1] = 0;
            r[0, 2] = Math.Sin(rad);
            r[1, 0] = 0;
            r[1, 1] = 1;
            r[1, 2] = 0;
            r[2, 0] = -Math.Sin(rad);
            r[2, 1] = 0;
            r[2, 2] = Math.Cos(rad);
            this.Calc(r);
        }

        public void RotateZ(double rad)
        {
            var r = new double[3, 3];
            r[0, 0] = Math.Cos(rad);
            r[0, 1] = -Math.Sin(rad);
            r[0, 2] = 0;
            r[1, 0] = Math.Sin(rad);
            r[1, 1] = Math.Cos(rad);
            r[1, 2] = 0;
            r[2, 0] = 0;
            r[2, 1] = 0;
            r[2, 2] = 1;
            this.Calc(r);
        }

        private void Calc(double[,] r)
        {
            var points = this.GetAllPoints();
            foreach (var p in points)
            {
                var x = p.X - Origin.X;
                var y = p.Y - Origin.Y;
                var z = p.Z - Origin.Z;
                p.X = r[0, 0] * x + r[0, 1] * y + r[0, 2] * z;
                p.Y = r[1, 0] * x + r[1, 1] * y + r[1, 2] * z;
                p.Z = r[2, 0] * x + r[2, 1] * y + r[2, 2] * z;
                p.X += Origin.X;
                p.Y += Origin.Y;
                p.Z += Origin.Z;
            }
        }        

        internal void DoZoom(int delta)
        {
            Zoom = delta > 0 ? 0.98 : 1.02;

            var points = this.GetAllPoints();
            foreach (var p in points)
            {
                var nX = (p.X - Origin.X) * Zoom;
                var nY = (p.Y - Origin.Y) * Zoom;
                var nZ = (p.Z - Origin.Z) * Zoom;
                p.X = nX + Origin.X;
                p.Y = nY + Origin.Y;
                p.Z = nZ + Origin.Z;
            }
        }

        internal void Translade(double dx, double dy)
        {
            var points = this.GetAllPoints();
            foreach (var p in points)
            {
                p.X += dx;
                p.Y += dy;
                p.Z += 0.0;
            }
        }
        #endregion
    }
}
