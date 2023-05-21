namespace ChessWF.Pieces;

public interface IСhessPieces
{
    public DataGridView GridShape { get; set; }

    public Dictionary<Point, ChessPieceCell> BoardCells { get; set; }

    public Side Side { get; set; }

    public Image Image { get; set; }

    public bool CheckPointOnPossibleMove(Point location);

    public List<Point> GetPointsOnPossibleMove(Point location);

    public List<Point> GetPointsOnWay(Point locationStart, Point locationEnd);

    public void SetNewLocation(Point point);
}