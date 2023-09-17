using ChessWF.Common;
using ChessWF.Control;

namespace ChessWF.Pieces;

internal class Knight : BasePieces, IСhessPiece
{
    public Image Image { get; set; }

    public Knight(GameBoard gameBoard, Side side, Image image) 
    {
        Image = image;
        СhessPieces = this;
        GameBoard = gameBoard;
        BoardCells = gameBoard.BoardCells;
        Side = side;
    }

    public List<Point> GetPointsOnPossibleMove(Point location)
    {
        var listPoint = new List<Point>
        {
            new(location.X - 1, location.Y - 2),
            new(location.X - 1, location.Y + 2),
            new(location.X + 1, location.Y - 2),
            new(location.X + 1, location.Y + 2),
            new(location.X - 2, location.Y - 1),
            new(location.X - 2, location.Y + 1),
            new(location.X + 2, location.Y - 1),
            new(location.X + 2, location.Y + 1)
        };

        return listPoint
             .Where(p => p.X is > 0 and < 9 && p.Y is > 0 and < 9)
             .Where(x => BoardCells[x].СhessPieces == null || BoardCells[x].СhessPieces.Side != Side)
             .ToList();
    }
}