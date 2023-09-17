using ChessWF.Common;
using ChessWF.Control;

namespace ChessWF.Pieces;

public class King : BasePieces, IСhessPiece
{
    public Image Image { get; set; }

    public King(GameBoard gameBoard, Side side, Image image)
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
            location with { Y = location.Y + 1 },
            location with { Y = location.Y - 1 },
            location with { X = location.X - 1 },
            location with { X = location.X + 1 },
            new(location.X - 1, location.Y - 1),
            new(location.X - 1, location.Y + 1),
            new(location.X + 1, location.Y - 1),
            new(location.X + 1, location.Y + 1),
        };

        return listPoint
            .Where(p => p.X is > 0 and < 9 && p.Y is > 0 and < 9)
            .Where(x => BoardCells[x].СhessPieces == null || BoardCells[x].СhessPieces.Side != Side)
            .ToList();
    }
}