namespace ChessWF.Common;

public class StrokeManager
{
    public Side CurrentSide { get; set; }
    private TextBox tbHistory;

    private const string MakerFieldText = "abcdefgh";
    private const string MakerFieldNumber = "87654321";

    private record History(IСhessPiece ChessPiece, Point Starlocation, Point Emdlocation);

    private List<History> StepHistory = new List<History>();

    public StrokeManager(TextBox tbHistory)
    {
        this.tbHistory = tbHistory;
    }

    public void AddStepHistory(IСhessPiece сhessPiece, Point location, Point movePoint)
    {
        StepHistory.Add(new History(сhessPiece, location, movePoint));
        AddMessage(location, movePoint);
    }

    private void AddMessage(Point location, Point movePoint)
    {
        tbHistory.Text += $"Step  {MakerFieldText[location.X - 1]}{MakerFieldNumber[location.Y - 1]} " +
                          $"to {MakerFieldText[movePoint.X - 1]}{MakerFieldNumber[movePoint.Y - 1]}" + Environment.NewLine;
    }

    public void EndStep()
    {
        CurrentSide =  CurrentSide == Side.Black ? Side.White : Side.Black;
    }
}