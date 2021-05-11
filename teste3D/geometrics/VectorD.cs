using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste3D.geometrics
{
    public class VectorD : LineD
    {
        public PointD Origin { get { return P1; } set { P1 = value; } }
        public PointD Direction { get { return P2; } set { P2 = value; } }

        public VectorD(PointD o, PointD d)
        {
            Origin = new PointD(o);
            Direction = new PointD(d);
        }

        public VectorD(double xo, double yo, double zo, double xd, double yd, double zd)
        {
            Origin = new PointD() { X = xo, Y = yo, Z = zo };
            Direction = new PointD() { X = xd, Y = yd, Z = zd };
        }

        public VectorD Invert()
        {
            PointD aux;
            aux = new PointD(Origin);
            Origin.SetXyz(Direction);
            Direction.SetXyz(aux);
            aux = null;
            return this;
        }

        public double Length()
        {
            var dx = Direction.X - Origin.X;
            var dy = Direction.Y - Origin.Y;
            var dz = Direction.Z - Origin.Z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public VectorD Copy(VectorD v)
        {
            Origin.SetXyz(v.Origin);
            Direction.SetXyz(v.Direction);
            return this;
        }

        public VectorD Append(VectorD v)
        {
            var dx = Direction.X - Origin.X;
            var dy = Direction.Y - Origin.Y;
            var dz = Direction.Z - Origin.Z;
            Origin.SetXyz(v.Direction);
            Direction.SetXyz(Origin.X + dx, Origin.Y + dy, Origin.Z + dz);
            return this;
        }

        public VectorD Sum(VectorD v)
        {
            VectorD copyThis = new VectorD(Origin, Direction);
            this.Append(v);
            Origin.SetXyz(copyThis.Origin);
            return this;
        }

        public VectorD Sum(List<VectorD> array)
        {
            if (array.Count < 1) return null;
            this.Copy(array[0]);
            for (int i = 1; i < array.Count; i++)
            {
                this.Append(array[i]);
                Origin.SetXyz(array[0].Origin);
            }
            return this;
        }
    }
}
