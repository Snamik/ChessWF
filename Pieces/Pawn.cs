using Timer = System.Windows.Forms.Timer;

namespace ChessWF.Pieces;

public class Pawn : IСhessPieces
{
    public DataGridView GridShape { get; set; }
    public Dictionary<Point, ChessPieceCell> BoardCells { get; set; }
    public Side Side { get; set; }
    public Image Image { get; set; }

    public Pawn(DataGridView gridShape, Side side, Image image, Dictionary<Point, ChessPieceCell> boardCells)
    {
        GridShape = gridShape;
        Side = side;
        Image = image;
        BoardCells = boardCells;
    }

    public bool CheckPointOnPossibleMove(Point location)
    {
        return true;
    }

    public List<Point> GetPointsOnPossibleMove(Point location)
    {
        if (Side == Side.Black && location.Y == 2)
        {
            return new List<Point>
            {
                new(location.X, location.Y + 1), 
                new(location.X, location.Y + 2)
            };
        }

        return new List<Point>
        {
            new(location.X, location.Y + 1),
        };
    }

    public List<Point> GetPointsOnWay(Point locationStart, Point locationEnd)
    {
        throw new NotImplementedException();
    }

    public void SetNewLocation(Point point)
    {
        if (!BoardCells.ContainsKey(point))
            throw new ArgumentOutOfRangeException(BoardCells.ToString(), @"GameBoard is not contains " + point);

        var cell = BoardCells[point];
        cell.СhessPieces = this;
        cell.DrawChessPiece();
    }
}