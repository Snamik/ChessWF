using ChessWF.Common;
using ChessWF.Control;

namespace ChessWF.Pieces;

public class Pawn : BasePieces, IСhessPiece
{
    public Image Image { get; set; }

    public Pawn(GameBoard gameBoard, Side side, Image image) 
    {
        Image = image;
        СhessPieces = this;
        GameBoard = gameBoard;
        BoardCells = gameBoard.BoardCells;
        Side = side;
    }

    public List<Point> GetPointsOnPossibleMove(Point location)
    {
        if (Side == Side.Black)
        {
            if (location.Y == 2) 
                return new List<Point>
                {
                    location with { Y = location.Y + 1 }, 
                    location with { Y = location.Y + 2 }
                };

            return new List<Point>
            {
                location with { Y = location.Y + 1 },
            };
        }

        if (location.Y == 7)
            return new List<Point>
            {
                location with { Y = location.Y - 1 },
                location with { Y = location.Y - 2 }
            };

        return new List<Point>
        {
            location with { Y = location.Y - 1 },
        };
    }

    public override List<Point> GetPointsOnWay(Point locationStart, Point locationEnd)
    {
        var points = new List<Point>();

        if (Side == Side.Black)
        {
            var point = new Point(locationStart.X, locationStart.Y + 1);
            points.Add(point);

            while (point.Y < locationEnd.Y)
            {
                point = new Point(point.X, point.Y + 1);
                points.Add(point);
            } 
        }
        else
        {
            var point = new Point(locationStart.X, locationStart.Y - 1);
            points.Add(point);

            while (point.Y > locationEnd.Y)
            {
                point = new Point(point.X, point.Y - 1);
                points.Add(point);
            }
        }

        return points;
    }
}