using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;
using ChessWF.Pieces;

namespace ChessWF;

public partial class GameBoardForm : Form
{
    private const int ColumnCount = 10;
    private const int RowCount = 10;
    private const int SizeInfoFied = 25;

    private const string MakerFieldText = "abcdefgh";
    private const string MakerFieldNumber = "87654321";

    private Dictionary<Point, ChessPieceCell> BoardCells;

    public GameBoardForm()
    {
        BoardCells = new Dictionary<Point, ChessPieceCell>();

        InitializeComponent();

    }

    private void SetSizeGrid()
    {
        var rowHeight = (GridShape.Size.Height - SizeInfoFied * 2) / (RowCount - 2);
        var rowWeight = (GridShape.Size.Width - SizeInfoFied * 2) / (ColumnCount - 2);

        GridShape.Columns[0].Width = SizeInfoFied;
        GridShape.Columns[ColumnCount - 1].Width = SizeInfoFied;

        GridShape.Rows[0].Height = SizeInfoFied;
        GridShape.Rows[RowCount - 1].Height = SizeInfoFied;

        for (var i = 1; i < ColumnCount - 1; i++)
        {
            GridShape.Columns[i].Width = rowWeight;
        }

        for (var i = 1; i < RowCount - 1; i++)
        {
            GridShape.Rows[i].Height = rowHeight;
        }
    }

    private void SetColor(Color bColor, Color wColor, bool inverse = false)
    {
        var cellStyleBlack = new DataGridViewCellStyle
        {
            BackColor = inverse ? wColor : bColor

        };
        var cellStyleWhite = new DataGridViewCellStyle
        {
            BackColor = inverse ? bColor : wColor
        };

        for (var x = 1; x < ColumnCount - 1; x++)
        {
            var module = x % 2 == 0 ? 1 : 0;

            for (var y = 1; y < RowCount - 1; y++)
            {
                GridShape[x, y].Style = y % 2 == module ? cellStyleBlack : cellStyleWhite;

                ChessPieceCell cell;

                if (y == 2)
                {
                    var pawn = new Pawn(GridShape, Side.Black, Resource.BPawn, BoardCells);
                    cell = new ChessPieceCell(GridShape, new Point(x, y), TimerForm, pawn);
                }
                else
                {
                    cell = new ChessPieceCell(GridShape, new Point(x, y), TimerForm);
                }

                BoardCells.Add(new Point(x, y), cell);
            }
        }
    }

    private void SetSymbols(bool inverse = false)
    {
        for (var x = 1; x < RowCount - 1; x++)
        {
            var index = inverse ? x : x - 1;

            GridShape[x, 0].Value = MakerFieldText[index];
            GridShape[x, RowCount - 1].Value = MakerFieldText[index];

            GridShape[0, x].Value = MakerFieldNumber[index];
            GridShape[ColumnCount - 1, x].Value = MakerFieldNumber[index];
        }
    }

    private void Form_Load(object sender, EventArgs e)
    {
        GridShape.ScrollBars = ScrollBars.None;
        GridShape.DefaultCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            BackColor = Color.DarkGray,
            Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = SystemColors.ControlText,
            SelectionBackColor = SystemColors.MenuHighlight,
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.False
        };

        for (var i = 0; i < ColumnCount; i++)
        {
            var column = new DataGridViewColumn(cellTemplate: new DataGridViewTextBoxCell())
            {
                CellTemplate = new DataGridViewTextBoxCell(),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            GridShape.Columns.Add(column);
        }

        for (var i = 0; i < RowCount; i++)
        {
            GridShape.Rows.Add();
        }

        SetSizeGrid();
        SetColor(Tools.BColor, Tools.WColor);
        SetSymbols();

        GridShape.ClearSelection();
    }

    private void GameBoardForm_Resize(object sender, EventArgs e)
    {
        Tools.UpdateSizeGameBoard();
    }

    private void GridShape_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        GridShape[e.ColumnIndex, e.RowIndex].Selected = false;
    }
}