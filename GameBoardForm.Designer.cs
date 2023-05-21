namespace ChessWF
{
    partial class GameBoardForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TimerForm = new System.Windows.Forms.Timer(components);
            GridShape = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)GridShape).BeginInit();
            SuspendLayout();
            // 
            // TimerForm
            // 
            TimerForm.Enabled = true;
            TimerForm.Interval = 30;
            // 
            // GridShape
            // 
            GridShape.AllowUserToAddRows = false;
            GridShape.AllowUserToDeleteRows = false;
            GridShape.AllowUserToOrderColumns = true;
            GridShape.AllowUserToResizeColumns = false;
            GridShape.AllowUserToResizeRows = false;
            GridShape.BackgroundColor = SystemColors.Control;
            GridShape.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            GridShape.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridShape.ColumnHeadersVisible = false;
            GridShape.Dock = DockStyle.Fill;
            GridShape.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridShape.Location = new Point(5, 5);
            GridShape.Margin = new Padding(0);
            GridShape.MultiSelect = false;
            GridShape.Name = "GridShape";
            GridShape.RowHeadersVisible = false;
            GridShape.RowTemplate.Height = 25;
            GridShape.Size = new Size(959, 750);
            GridShape.TabIndex = 2;
            GridShape.CellClick += GridShape_CellClick;
            // 
            // GameBoardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(969, 760);
            Controls.Add(GridShape);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            HelpButton = true;
            Name = "GameBoardForm";
            Padding = new Padding(5);
            Text = "GameBoard";
            Load += Form_Load;
            Resize += GameBoardForm_Resize;
            ((System.ComponentModel.ISupportInitialize)GridShape).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer TimerForm;
        private DataGridView GridShape;
    }
}