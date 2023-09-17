using ChessWF.Common;
using ChessWF.Control;

namespace ChessWF.Pieces;

public class Rook : BasePieces, IСhessPiece
{
    public Image Image { get; set; }

    public Rook(GameBoard gameBoard, Side side, Image image) 
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

        var top = true; 
        var bottom = true; 
        var left = true;
        var right = true;

        for (var i = 1; i < 9; i++)
        {
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