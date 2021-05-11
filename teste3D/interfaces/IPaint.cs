using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste3D.geometrics;

namespace teste3D.interfaces
{
    public interface IPaint
    {
        void DoPaint(Graphics g);
        PointD[] GetPoints();
        void DoMelt(PointD selected);
        void DoBreak(PointD selected);
    }
}
