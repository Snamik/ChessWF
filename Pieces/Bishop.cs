using ChessWF.Common;
using ChessWF.Control;

namespace ChessWF.Pieces;

public class Bishop : BasePieces, IСhessPiece
{
    public Image Image { get; set; }

    public Bishop(GameBoard gameBoard, Side side, Image image) 
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
        }

        return listPoint;
    }
}