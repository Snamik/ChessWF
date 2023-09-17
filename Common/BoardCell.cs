using ChessWF.Control;
using Timer = System.Windows.Forms.Timer;

namespace ChessWF.Common;

public class BoardCell
{
    public GameBoard GameBoard { get; set; }
    public Timer TimerForm { get; set; }
    public IСhessPiece? СhessPieces { get; set; }

    private readonly Point _location;
    private PictureBox? _pictureBox;
    private readonly int _thickness;
    private bool _isSelect;
    private bool _isPossible;
    private bool _isMove;

    private int _currentStepMovePoint = 0;
    private List<Point> _movePoints;

    public BoardCell(GameBoard gameBoard, Point location, Timer timerForm, IСhessPiece? chessPieces = null)
    {
        GameBoard = gameBoard;
        _location = location;
        TimerForm = timerForm;
        СhessPieces = chessPieces;
        _thickness = GameBoard.Thickness;

        GameBoard.BoardPieseClicked += ChessPieceСellPiese_Clicked;
        GameBoard.ResizeGameBoard += DrawCell;

        DrawCell();
    }

    public void DrawCell()
    {
        var rectangle = GameBoard.Grid.GetCellDisplayRectangle(_location.X, _location.Y, false);

        if (_pictureBox == null)
        {
            _pictureBox = new PictureBox
            {
                Image = СhessPieces?.Image ?? null,
                Parent = GameBoard.Grid,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Padding = Padding.Add(new Padding(10, 3, 10, 3), new Padding(_thickness)),
                Size = new Size(rectangle.Width, rectangle.Height),
                Location = new Point(rectangle.X, rectangle.Y)
            };

            _pictureBox.Click += PictureBox_Click;
            _pictureBox.Paint += ChessPiece_Paint;
        }
        else
        {
            _pictureBox.Location = rectangle.Location;
            _pictureBox.Size = new Size(rectangle.Width, rectangle.Height);
            _pictureBox.Image = СhessPieces?.Image ?? null;
        }
    }

    private void ChessPiece_Paint(object? sender, PaintEventArgs e)
    {
        if (_isPossible)
        {
            var rect = GameBoard.Grid.GetCellDisplayRectangle(_location.X, _location.Y, false);
            rect.Location = new Point(0, 0);

            e.Graphics.DrawRectangle(GameBoard.PossiblePen, rect);
        }
        else if (_isSelect)
        {
            var rect = GameBoard.Grid.GetCellDisplayRectangle(_location.X, _location.Y, false);
            rect.Location = new Point(0, 0);

            e.Graphics.DrawRectangle(GameBoard.SelectedPen, rect);
        }
    }

    public void ReDrawImage()
    {
        _pictureBox?.Invalidate();
    }

    private void PictureBox_Click(object? sender, EventArgs e)
    {
        // Фигура в движние
        if (_isMove) return;

        // Ячейка выделенна как возможная, тригер движение выбраной фигры к этой ячейки
        if (_isPossible)
        {
            GameBoard.MoveToPoint(_location);
            return;
        }

        // Пустая ячейка
        if (СhessPieces == null) return;

        // Чужой ход
        if (GameBoard.StepManager.CurrentSide != СhessPieces.Side) return;

        var possiblePoints = СhessPieces.GetPointsOnPossibleMove(_location);
        if (possiblePoints.Count <= 0) return;

        GameBoard.ChessPieseMove += ChessPieceСell_Move;
        GameBoard.SetPossibleCells(possiblePoints);

        _isSelect = true;
        _pictureBox?.Invalidate();
    }

    private void ChessPieceСellPiese_Clicked(List<Point>? points)
    {
        if (points != null && points.Contains(_location))
        {
            _isPossible = true;
            _isSelect = false;
            _pictureBox?.Invalidate();
        }
        else if (_isSelect || _isPossible || points == null)
        {
            GameBoard.ChessPieseMove -= ChessPieceСell_Move;

            _isPossible = false;
            _isSelect = false;
            _pictureBox?.Invalidate();
        }
    }

    private void ChessPieceСell_Move(Point movePoint)
    {
        _isMove = true;
        _isSelect = false;

        GameBoard.SetPossibleCells(null);

        if (СhessPieces == null) return;

        _pictureBox!.BringToFront();
        _currentStepMovePoint = 0;
        _movePoints = СhessPieces.GetPointsOnWay(_location, movePoint);
        GameBoard.StepManager.AddStepHistory(СhessPieces, _location, movePoint);

        TimerForm.Tick += TimerForm_Tick;
    }

    private void TimerForm_Tick(object? sender, EventArgs e)
    {
        if (_currentStepMovePoint >= _movePoints!.Count)
        {
            _isMove = false;
            TimerForm.Tick -= TimerForm_Tick;
            GameBoard.ChessPieseMove -= ChessPieceСell_Move;

            _pictureBox!.Image = null;
            _pictureBox.Location = GameBoard.Grid.GetCellDisplayRectangle(_location.X, _location.Y, false).Location;

            СhessPieces!.SetNewLocation(_movePoints[_currentStepMovePoint -1]);
            СhessPieces = null;

            GameBoard.StepManager.EndStep();

            return;
        }

        var point = _movePoints[_currentStepMovePoint];

        var currentPoint = _pictureBox!.Location;
        var nextPoint = GameBoard.Grid.GetCellDisplayRectangle(point.X, point.Y, false).Location;

        var move = 7;
        var moveX = 0;
        var moveY = 0;

        moveX = (currentPoint.X - nextPoint.X) switch
        {
            < 0 => move,
            > 0 => -move,
            _ => moveX
        };
        moveY = (currentPoint.Y - nextPoint.Y) switch
        {
            < 0 => move,
            > 0 => -move,
            _ => moveY
        };

        if (currentPoint.X != nextPoint.X || currentPoint.Y != nextPoint.Y)
        {
            if (currentPoint.X != point.X)
            {
                var isEnd = moveX > 0
                    ? currentPoint.X + moveX > nextPoint.X
                    : currentPoint.X + moveX < nextPoint.X;

                if (isEnd) 
                    currentPoint.X = nextPoint.X;
                else
                    currentPoint.X += moveX;
            }
            if (currentPoint.Y != point.Y)
            {
                var isEnd = moveY > 0
                    ? currentPoint.Y + moveY > nextPoint.Y
                    : currentPoint.Y + moveY < nextPoint.Y;

                if (isEnd)
                    currentPoint.Y = nextPoint.Y;
                else
                    currentPoint.Y += moveY;
            }

            _pictureBox.Location = currentPoint;
        }
        else
        {
            _currentStepMovePoint++;
        }
    }
}