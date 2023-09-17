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
            splitContainer1 = new SplitContainer();
            tbHistory = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            sdsdToolStripMenuItem = new ToolStripMenuItem();
            dsdsToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(5, 35);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tbHistory);
            splitContainer1.Size = new Size(1093, 720);
            splitContainer1.SplitterDistance = 779;
            splitContainer1.TabIndex = 0;
            // 
            // tbHistory
            // 
            tbHistory.Dock = DockStyle.Fill;
            tbHistory.Location = new Point(0, 0);
            tbHistory.Multiline = true;
            tbHistory.Name = "tbHistory";
            tbHistory.Size = new Size(310, 720);
            tbHistory.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { sdsdToolStripMenuItem, dsdsToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RenderMode = ToolStripRenderMode.System;
            contextMenuStrip1.ShowImageMargin = false;
            contextMenuStrip1.Size = new Size(74, 48);
            // 
            // sdsdToolStripMenuItem
            // 
            sdsdToolStripMenuItem.Name = "sdsdToolStripMenuItem";
            sdsdToolStripMenuItem.Size = new Size(73, 22);
            sdsdToolStripMenuItem.Text = "sdsd";
            // 
            // dsdsToolStripMenuItem
            // 
            dsdsToolStripMenuItem.Name = "dsdsToolStripMenuItem";
            dsdsToolStripMenuItem.Size = new Size(73, 22);
            dsdsToolStripMenuItem.Text = "dsds";
            // 
            // GameBoardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1103, 760);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "GameBoardForm";
            Padding = new Padding(5);
            Text = "GameBoard";
            Load += GameBoardForm_Load;
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox tbHistory;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem sdsdToolStripMenuItem;
        private ToolStripMenuItem dsdsToolStripMenuItem;
    }
}