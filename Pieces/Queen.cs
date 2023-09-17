using ChessWF.Common;
using ChessWF.Control;

namespace ChessWF.Pieces;

public class Queen : BasePieces, IСhessPiece
{
    public Image Image { get; set; }

    public Queen(GameBoard gameBoard, Side side, Image image)
    {
        Image = image;
        СhessPieces = this;
        GameBoard = gameBoard;
        BoardCells = gameBoard.BoardCells;
        Side = side;
    }

    public List<Point> GetPointsOnPossibleMove(Point location)
    {
        var listPoint = new List<Point>();

        var topLeft = true;
        var topRight = true;
        var bottomLeft = true;
        var bottomRight = true;
        var top = true;
        var bottom = true;
        var left = true;
        var right = true;

        for (var i = 1; i < 9; i++)
        {
            if (topLeft)
            {
                AddPointToDirection(new Point(location.X - i, location.Y - i), listPoint, ref topLeft);
            }
            if (topRight)
            {
                AddPointToDirection(new Point(location.X + i, location.Y - i), listPoint, ref topRight);
            }
            if (bottomLeft)
            {
                AddPointToDirection(new Point(location.X - i, location.Y + i), listPoint, ref bottomLeft);
            }
            if (bottomRight)
            {
                AddPointToDirection(new Point(location.X + i, location.Y + i), listPoint, ref bottomRight);
            }
            if (right)
            {
                AddPointToDirection(location with { X = location.X + i }, listPoint, ref right);
            }
            if (left)
            {
                AddPointToDirection(location with { X = location.X - i }, listPoint, ref left);
            }
            if (top)
            {
                AddPointToDirection(location with { Y = location.Y + i }, listPoint, ref top);
            }
            if (bottom)
            {
                AddPointToDirection(location with { Y = location.Y - i }, listPoint, ref bottom);
            }
        }

        return listPoint;
    }
}