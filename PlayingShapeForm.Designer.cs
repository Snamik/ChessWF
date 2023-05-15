namespace ChessWF
{
    partial class PlayingShapeForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            GridShape = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)GridShape).BeginInit();
            SuspendLayout();
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.RosyBrown;
            dataGridViewCellStyle1.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            GridShape.DefaultCellStyle = dataGridViewCellStyle1;
            GridShape.Dock = DockStyle.Fill;
            GridShape.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridShape.Location = new Point(5, 5);
            GridShape.Margin = new Padding(0);
            GridShape.MultiSelect = false;
            GridShape.Name = "GridShape";
            GridShape.RowHeadersVisible = false;
            GridShape.RowTemplate.Height = 25;
            GridShape.Size = new Size(934, 751);
            GridShape.TabIndex = 0;
            // 
            // PlayingShapeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 761);
            Controls.Add(GridShape);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            HelpButton = true;
            Name = "PlayingShapeForm";
            Padding = new Padding(5);
            Text = "PlayingShapeForm";
            Load += Form_Load;
            ((System.ComponentModel.ISupportInitialize)GridShape).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView GridShape;
    }
}