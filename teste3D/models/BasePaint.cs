using teste3D.geometrics;
using teste3D.interfaces;

namespace teste3D.models
{
    public class BasePaint : IPaint
    {
        public int Cor { get; set; }
        public float PenSize { get; set; }

        private bool _locked = false;
        public bool Lock
        {
            get { return _locked; }
            set
            {
                _locked = value;
                var p = this.GetPoints();
                foreach (var item in p)
                    item.Locked = _locked;
            }
        }

        public virtual void DoPaint(System.Drawing.Graphics g)
        {
            // Do Nothing
        }

        public virtual PointD[] GetPoints()
        {
            // Do Nothing
            return null;
        }
        public virtual void DoMelt(PointD selected)
        {
            // Do Nothing
        }

        public virtual void DoBreak(PointD selected)
        {
            // Do Nothing
        }
    }
}
