using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste3D.geometrics
{
    public class GeometricUtils
    {
        public static PointF[] ConvertToFloat(PointD[] p)
        {
            var result = new PointF[p.Length];
            for (int i = 0; i < p.Length; i++)
            {
                result[i].X = p[i].fX;
                result[i].Y = p[i].fY;
            }
            return result;
        }

        public static Point[] ConvertToInt(PointD[] p)
        {
            var result = new Point[p.Length];
            for (int i = 0; i < p.Length; i++)
            {
                result[i].X = p[i].iX;
                result[i].Y = p[i].iY;
            }
            return result;
        }
    }


}
