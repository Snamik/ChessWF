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

        // создаем элементы меню
        ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("Копировать");
        ToolStripMenuItem pasteMenuItem = new ToolStripMenuItem("Вставить");
        // добавляем элементы в меню
        contextMenuStrip1.Items.AddRange(new[] { copyMenuItem, pasteMenuItem });
        // ассоциируем контекстное меню с текстовым полем
    }
}