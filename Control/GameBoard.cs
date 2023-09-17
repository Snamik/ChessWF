using ChessWF.Common;
using ChessWF.Pieces;

namespace ChessWF.Control
{
    public partial class GameBoard : UserControl
    {
        private const int ColumnCount = 10;
        private const int RowCount = 10;
        private const int SizeInfoFied = 25;

        private const string MakerFieldText = "abcdefgh";
        private const string MakerFieldNumber = "87654321";

        public readonly Dictionary<Point, BoardCell> BoardCells = new();
        public StrokeManager StepManager { get; set; }

        public bool Inverse = false;
        public int Thickness = 7;
        public readonly Pen SelectedPen;
        public readonly Pen PossiblePen;
        public readonly Color BColor = Color.Gray;
        public readonly Color WColor = Color.AntiqueWhite;

        public delegate void BoardCellClickedEventHandler(List<Point>? points);
        public event BoardCellClickedEventHandler? BoardPieseClicked;

        public delegate void ChessPieseMoveEventHandler(Point point);
        public event ChessPieseMoveEventHandler? ChessPieseMove;

        public delegate void ResizeGameBoardEventHandler();
        public event ResizeGameBoardEventHandler? ResizeGameBoard;

        public void SetPossibleCells(List<Point>? points)
        {
            BoardPieseClicked?.Invoke(points);
        }

        public void MoveToPoint(Point point)
        {
            ChessPieseMove?.Invoke(point);
        }

        private readonly string[][] _pieceOnBoard = {
            new[] { "BRook", "BLKnight", "BBishop", "BKing", "BQueen", "BBishop", "BRKnight", "BRook" },
            new[] { "BPawn", "BPawn", "BPawn", "BPawn", "BPawn", "BPawn", "BPawn", "BPawn" },
            new string[8],
            new string[8],
            new string[8],
            new string[8],
            new[] { "WPawn", "WPawn", "WPawn", "WPawn", "WPawn", "WPawn", "WPawn", "WPawn" },
            new[] { "WRook", "WLKnight", "WBishop", "WQueen", "WKing",  "WBishop", "WRKnight", "WRook" }
        };

        public GameBoard()
        {
            SelectedPen = new Pen(Color.CornflowerBlue, Thickness);
            PossiblePen = new Pen(Color.Gold, Thickness);

            InitializeComponent();

            Grid.ScrollBars = ScrollBars.None;
            Grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = Color.DarkGray,
                Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = SystemColors.ControlText,
                SelectionBackColor = SystemColors.MenuHighlight,
                SelectionForeColor = SystemColors.HighlightText,
                WrapMode = DataGridViewTriState.False
            };
        }

        public void InitControl()
        {
            for (var i = 0; i < ColumnCount; i++)
            {
                var column = new DataGridViewColumn(cellTemplate: new DataGridViewTextBoxCell());
                Grid.Columns.Add(column);
            }

            for (var i = 0; i < RowCount; i++)
            {
                Grid.Rows.Add();
            }

            SetSizeGrid();
            SetColor();
            SetSymbols();

            Grid.ClearSelection();
        }

        private void SetSizeGrid()
        {
            var rowHeight = (Grid.Size.Height - SizeInfoFied * 2) / (RowCount - 2);
            var rowWeight = (Grid.Size.Width - SizeInfoFied * 2) / (ColumnCount - 2);

            Grid.Columns[0].Width = SizeInfoFied;
            Grid.Columns[ColumnCount - 1].Width = SizeInfoFied;

            Grid.Rows[0].Height = SizeInfoFied;
            Grid.Rows[RowCount - 1].Height = SizeInfoFied;

            for (var i = 1; i < ColumnCount - 1; i++)
            {
                Grid.Columns[i].Width = rowWeight;
            }

            for (var i = 1; i < RowCount - 1; i++)
            {
                Grid.Rows[i].Height = rowHeight;
            }
        }

        private void SetColor()
        {
            var cellStyleBlack = new DataGridViewCellStyle
            {
                BackColor = Inverse ? WColor : BColor

            };
            var cellStyleWhite = new DataGridViewCellStyle
            {
                BackColor = Inverse ? BColor : WColor
            };

            for (var x = 1; x < ColumnCount - 1; x++)
            {
                var module = x % 2 == 0 ? 1 : 0;

                for (var y = 1; y < RowCount - 1; y++)
                {
                    Grid[x, y].Style = y % 2 == module ? cellStyleBlack : cellStyleWhite;

                    BoardCell cell;

                    if (string.IsNullOrEmpty(_pieceOnBoard[y - 1][x - 1]))
                    {
                        cell = new BoardCell(this, new Point(x, y), TimerForm);
                    }
                    else
                    {
                        var chessPiece = FactoryChessPieces(_pieceOnBoard[y - 1][x - 1], this, BoardCells);
                        cell = new BoardCell(this, new Point(x, y), TimerForm, chessPiece);
                    }

                    BoardCells.Add(new Point(x, y), cell);
                }
            }
        }

        private void SetSymbols()
        {
            for (var x = 1; x < RowCount - 1; x++)
            {
                var index = Inverse ? x : x - 1;

                Grid[x, 0].Value = MakerFieldText[index];
                Grid[x, RowCount - 1].Value = MakerFieldText[index];

                Grid[0, x].Value = MakerFieldNumber[index];
                Grid[ColumnCount - 1, x].Value = MakerFieldNumber[index];
            }
        }

        private void GameBoardForm_Resize(object sender, EventArgs e)
        {
            if (Grid.Columns.Count == 0 || Grid.Rows.Count == 0) return;
            SetSizeGrid();
            ResizeGameBoard?.Invoke();
        }

        private void GameBoardCellClick(object sender, DataGridViewCellEventArgs e)
        {
            Grid[e.ColumnIndex, e.RowIndex].Selected = false;
        }

        public IСhessPiece FactoryChessPieces(string image, GameBoard gameBoard, Dictionary<Point, BoardCell> boardCells)
        {
            return image switch
            {
                "BPawn" => new Pawn(gameBoard, Side.Black, Resource.BPawn),
                "BBishop" => new Bishop(gameBoard, Side.Black, Resource.BBishop),
                "BLKnight" => new Knight(gameBoard, Side.Black, Resource.BLKnight),
                "BRKnight" => new Knight(gameBoard, Side.Black, Resource.BRKnight),
                "BRook" => new Rook(gameBoard, Side.Black, Resource.BRook),
                "BQueen" => new Queen(gameBoard, Side.Black, Resource.BQueen),
                "BKing" => new King(gameBoard, Side.Black, Resource.BKing),

                "WPawn" => new Pawn(gameBoard, Side.White, Resource.WPawn),
                "WBishop" => new Bishop(gameBoard, Side.White, Resource.WBishop),
                "WLKnight" => new Knight(gameBoard, Side.White, Resource.WLKnight),
                "WRKnight" => new Knight(gameBoard, Side.White, Resource.WRKnight),
                "WRook" => new Rook(gameBoard, Side.White, Resource.WRook),
                "WQueen" => new Queen(gameBoard, Side.White, Resource.WQueen),
                "WKing" => new King(gameBoard, Side.White, Resource.WKing),
                _ => throw new ArgumentException(@"Resource don't contais " + image)
            };
        }
    }
}
