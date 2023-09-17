using ChessWF.Common;
using ChessWF.Control;
using System.Windows.Forms;

namespace ChessWF.Pieces;

public abstract class BasePieces
{
    public GameBoard? GameBoard { get; set; } 
    public Side Side { get; set; }

    protected Dictionary<Point, BoardCell> BoardCells { get; set; }
    protected IСhessPiece? СhessPieces;

    public void SetNewLocation(Point point)
    {
        if (!BoardCells.ContainsKey(point))
            throw new ArgumentOutOfRangeException(BoardCells.ToString(), @"GameBoard is not contains " + point);

        var cell = BoardCells[point];
        cell.СhessPieces = СhessPieces;
        cell.DrawCell();
    }

    protected void AddPointToDirection(Point point, ICollection<Point> listPoint, ref bool direction)
    {
        if (point.X is <= 0 or >= 9 || point.Y is <= 0 or >= 9)
        {
            direction = false;
            return;
        }

        var cell = BoardCells[point];

        if (cell.СhessPieces != null)
        {
            if (cell.СhessPieces.Side != Side)
            {
                listPoint.Add(point);
            }

            direction = false;
        }
        else
        {
            listPoint.Add(point);
        }
    }

    public virtual List<Point> GetPointsOnWay(Point locationStart, Point locationEnd)
    {
        var listPoint = new List<Point>();

        var offsetX = Math.Abs(locationStart.X - locationEnd.X);
        var offsetY = Math.Abs(locationStart.Y - locationEnd.Y);

        if (offsetX == offsetY)
        {
            for (var i = 0; i < offsetX; i++)
            {
                locationStart = locationStart
                    with
                    {
                        X = locationStart.X + 1 * (locationStart.X - locationEnd.X < 0 ? 1 : -1),
                        Y = locationStart.Y + 1 * (locationStart.Y - locationEnd.Y < 0 ? 1 : -1)
                    };

                listPoint.Add(locationStart);
            }
        }
        else
        {
            for (var i = 0; i < offsetX; i++)
            {
                locationStart = locationStart
                    with
                    { X = locationStart.X + 1 * (locationStart.X - locationEnd.X < 0 ? 1 : -1) };

                listPoint.Add(locationStart);
            }
            for (var j = 0; j < offsetY; j++)
            {
                locationStart = locationStart
                    with
                    { Y = locationStart.Y + 1 * (locationStart.Y - locationEnd.Y < 0 ? 1 : -1) };

                listPoint.Add(locationStart);
            }
        }

        return listPoint;
    }
}