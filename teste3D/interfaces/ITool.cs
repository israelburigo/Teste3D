using teste3D.view.editors;

namespace teste3D.interfaces
{
    public interface ITool 
    {
        IPaint DoDown(Editor editor, double x, double y);
        IPaint DoMove(Editor editor, double x, double y);
        IPaint DoUp(Editor editor, double x, double y);
    }
}
