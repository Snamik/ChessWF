using ChessWF.Control;

namespace ChessWF.Common;

public interface IСhessPiece
{
    public GameBoard? GameBoard { get; set; }

    public Side Side { get; set; }

    public Image Image { get; set; }

    public List<Point> GetPointsOnPossibleMove(Point location);

    public List<Point> GetPointsOnWay(Point locationStart, Point locationEnd);

    public void SetNewLocation(Point point);
}