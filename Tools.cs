using ChessWF.Pieces;

namespace ChessWF;

public static class Tools
{
    public delegate void CellClick(List<Point>? points);
    public static event CellClick AfterClick;

    public static void SetPossibleCells(List<Point>? points)
    {
        AfterClick?.Invoke(points);
    }

    public delegate void ChessPieseMove(Point point);
    public static event ChessPieseMove Move;

    public static void MoveToPoint(Point point)
    {
        Move?.Invoke(point);
    }

    public delegate void ResizeGameBoard();
    public static event ResizeGameBoard Resize;

    public static void UpdateSizeGameBoard()
    {
        Resize?.Invoke();
    }

    public static int Thickness = 7;
    public static readonly Pen SelectedPen = new(Color.CornflowerBlue, Thickness);
    public static readonly Pen PossiblePen = new(Color.Gold, Thickness);
    public static readonly Color BColor = Color.Gray;
    public static readonly Color WColor = Color.AntiqueWhite;
}