namespace ChessWF.Control
{
    partial class GameBoard
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Grid = new DataGridView();
            TimerForm = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)Grid).BeginInit();
            SuspendLayout();
            // 
            // Grid
            // 
            Grid.AllowUserToAddRows = false;
            Grid.AllowUserToDeleteRows = false;
            Grid.AllowUserToOrderColumns = true;
            Grid.AllowUserToResizeColumns = false;
            Grid.AllowUserToResizeRows = false;
            Grid.BackgroundColor = SystemColors.Control;
            Grid.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid.ColumnHeadersVisible = false;
            Grid.Dock = DockStyle.Fill;
            Grid.EditMode = DataGridViewEditMode.EditProgrammatically;
            Grid.Location = new Point(0, 0);
            Grid.Margin = new Padding(0);
            Grid.MultiSelect = false;
            Grid.Name = "Grid";
            Grid.RowHeadersVisible = false;
            Grid.RowTemplate.Height = 25;
            Grid.Size = new Size(918, 799);
            Grid.TabIndex = 3;
            Grid.CellClick += GameBoardCellClick;
            Grid.SizeChanged += GameBoardForm_Resize;
            // 
            // TimerForm
            // 
            TimerForm.Enabled = true;
            TimerForm.Interval = 10;
            // 
            // GameBoard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Grid);
            Name = "GameBoard";
            Size = new Size(918, 799);
            ((System.ComponentModel.ISupportInitialize)Grid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer TimerForm;
        public DataGridView Grid;
    }
}
