namespace ChessWF;

public partial class PlayingShapeForm : Form
{
    private const int ColumnCount = 10;
    private const int RowCount = 10;
    private const int SizeInfoFied = 25;
    private const string MakerFieldText = "abcdefgh";
    private const string MakerFieldNumber = "87654321";

    public PlayingShapeForm()
    {
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

        for (var i = 0; i < ColumnCount; i++)
        {
            GridShape.Columns.Add(new DataGridViewColumn(cellTemplate: new DataGridViewTextBoxCell()));
        }

        for (var i = 0; i < RowCount; i++)
        {
            GridShape.Rows.Add();
        }

        GridShape.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, Color.Aqua);
        GridShape.DefaultCellStyle.SelectionForeColor = Color.FromArgb(254, Color.Aqua);


        SetSizeGrid();
        SetColor(Color.DarkGoldenrod, Color.Bisque);
        SetSymbols();
    }

    private void GridShape_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        var thickness = 10;

        if (!(e.ColumnIndex > -1 & e.RowIndex > -1)) return;

        // Skip marker field
        if (e.ColumnIndex is 0 or ColumnCount - 1) return;
        if (e.RowIndex is 0 or RowCount - 1) return;

        using var selectedPen = new Pen(Color.CornflowerBlue, thickness);

        if (this.GridShape[e.ColumnIndex, e.RowIndex].Selected)
        {
            e.Graphics.DrawRectangle(selectedPen, new Rectangle(
                e.CellBounds.Left + thickness / 2, e.CellBounds.Top + thickness / 2,
                e.CellBounds.Width - thickness, e.CellBounds.Height - thickness));
        }
    }
}