using ChessWF.Common;
using ChessWF.Control;

namespace ChessWF;

public partial class GameBoardForm : Form
{
    public GameBoardForm()
    {
        InitializeComponent();
    }

    private void GameBoardForm_Load(object sender, EventArgs e)
    {
        var strokeManager = new StrokeManager(tbHistory);

        var gameBoard = new GameBoard
        {
            Dock = DockStyle.Fill
        };
        gameBoard.StepManager = strokeManager;

        splitContainer1.Panel1.Controls.Add(gameBoard);
        gameBoard.InitControl();

        // ������� �������� ����
        ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("����������");
        ToolStripMenuItem pasteMenuItem = new ToolStripMenuItem("��������");
        // ��������� �������� � ����
        contextMenuStrip1.Items.AddRange(new[] { copyMenuItem, pasteMenuItem });
        // ����������� ����������� ���� � ��������� �����
    }
}