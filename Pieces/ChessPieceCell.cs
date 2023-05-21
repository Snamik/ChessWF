using Timer = System.Windows.Forms.Timer;

namespace ChessWF.Pieces;

public class ChessPieceCell
{
    public DataGridView GridShape { get; set; }
    public Timer TimerForm { get; set; }
    public IСhessPieces? СhessPieces { get; set; }

    private Rectangle _rectangle;
    private readonly Point _location;
    private Point _newLocation;
    private PictureBox? _pictureBox;
    private readonly int _thickness;
    private bool _isSelect;
    private bool _isPossible;
    private bool _isMove;

    public ChessPieceCell(DataGridView gridShape, Point location, Timer timerForm, IСhessPieces? chessPieces = null)
    {
        GridShape = gridShape;
        _location = location;
        TimerForm = timerForm;
        СhessPieces = chessPieces;
        _thickness = Tools.Thickness;

        Tools.AfterClick += ChessPiece_AfterClick;
        Tools.Resize += DrawChessPiece;

        DrawChessPiece();
    }

    public void DrawChessPiece()
    {
        _rectangle = GridShape.GetCellDisplayRectangle(_location.X, _location.Y, false);

        if (_pictureBox == null)
        {
            _pictureBox = new PictureBox
            {
                Image = СhessPieces?.Image ?? null,
                Parent = GridShape,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Padding = Padding.Add(new Padding(8, 3, 8, 3), new Padding(_thickness)),
                Size = new Size(_rectangle.Width, _rectangle.Height),
                Location = new Point(_rectangle.X, _rectangle.Y)
            };

            _pictureBox.Click += ChessPiece_Click;
            _pictureBox.Paint += ChessPiece_Paint;
        }
        else
        {
            _pictureBox.Location = _rectangle.Location;
            _pictureBox.Size = new Size(_rectangle.Width, _rectangle.Height);
            _pictureBox.Image = СhessPieces?.Image ?? null;
        }
    }

    private void ChessPiece_Paint(object? sender, PaintEventArgs e)
    {
        if (_isPossible)
        {
            var rect = GridShape.GetCellDisplayRectangle(_location.X, _location.Y, false);
            rect.Location = new Point(0, 0);

            e.Graphics.DrawRectangle(Tools.PossiblePen, rect);
        }
        else if (_isSelect)
        {
            var rect = GridShape.GetCellDisplayRectangle(_location.X, _location.Y, false);
            rect.Location = new Point(0, 0);

            e.Graphics.DrawRectangle(Tools.SelectedPen, rect);
        }
    }

    private void ChessPiece_Click(object? sender, EventArgs e)
    {
        if (_isMove) return;

        if (_isPossible)
        {
            Tools.MoveToPoint(_location);
        }

        if (СhessPieces == null) return;

        var possiblePoints = СhessPieces.GetPointsOnPossibleMove(_location);

        if (possiblePoints.Count > 0)
        {
            Tools.Move += ChessPiece_Move;
            Tools.SetPossibleCells(possiblePoints);

            _isSelect = true;
            _pictureBox?.Invalidate();
        }
    }

    private void ChessPiece_AfterClick(List<Point>? points)
    {
        if (points != null && points.Contains(_location))
        {
            _isPossible = true;
            _isSelect = false;
            _pictureBox?.Invalidate();
        } 
        else if (_isSelect || _isPossible || points == null)
        {
            Tools.Move -= ChessPiece_Move;

            _isPossible = false;
            _isSelect = false;
            _pictureBox?.Invalidate();
        }
    }

    private void ChessPiece_Move(Point point)
    {
        _isMove = true;
        _newLocation = point;
        _isSelect = false;
        Tools.SetPossibleCells(null);

        if (СhessPieces == null || !СhessPieces.CheckPointOnPossibleMove(point)) return;

        _rectangle = GridShape.GetCellDisplayRectangle(point.X, point.Y, false);

        TimerForm.Tick += TimerForm_Tick;
    }

    private void TimerForm_Tick(object? sender, EventArgs e)
    {
        var point = _pictureBox!.Location;

        if (point.Y != _rectangle.Location.Y)
        {
            if (point.Y + 5 > _rectangle.Location.Y) 
                point.Y = _rectangle.Location.Y;
            else 
                point.Y += 5;

            _pictureBox.Location = point;
        }
        else
        {
            _isMove = false;
            TimerForm.Tick -= TimerForm_Tick;
            Tools.Move -= ChessPiece_Move;

            _rectangle = GridShape.GetCellDisplayRectangle(_location.X, _location.Y, false);
            _pictureBox.Location = _rectangle.Location;
            _pictureBox.Image = null;

            СhessPieces!.SetNewLocation(_newLocation);
            СhessPieces = null;
        }
    }
}