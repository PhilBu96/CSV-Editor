namespace CSV_Viewer
{
    partial class Form1
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
            dataGridView = new DataGridView();
            menuStrip1 = new MenuStrip();
            dateiToolStripMenuItem = new ToolStripMenuItem();
            menuLoadCsv = new ToolStripMenuItem();
            cSVSpeichernToolStripMenuItem = new ToolStripMenuItem();
            programmBeendenToolStripMenuItem = new ToolStripMenuItem();
            InfoToolStripMenuItem = new ToolStripMenuItem();
            progressBar = new ProgressBar();
            überToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 27);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(1340, 708);
            dataGridView.TabIndex = 1;
            dataGridView.CellValueChanged += DataGridView_CellValueChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { dateiToolStripMenuItem, InfoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1364, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            dateiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuLoadCsv, cSVSpeichernToolStripMenuItem, programmBeendenToolStripMenuItem });
            dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            dateiToolStripMenuItem.Size = new Size(46, 20);
            dateiToolStripMenuItem.Text = "Datei";
            // 
            // menuLoadCsv
            // 
            menuLoadCsv.Name = "menuLoadCsv";
            menuLoadCsv.Size = new Size(180, 22);
            menuLoadCsv.Text = "CSV laden...";
            menuLoadCsv.Click += MenuLoadCsv_Click;
            // 
            // cSVSpeichernToolStripMenuItem
            // 
            cSVSpeichernToolStripMenuItem.Name = "cSVSpeichernToolStripMenuItem";
            cSVSpeichernToolStripMenuItem.Size = new Size(180, 22);
            cSVSpeichernToolStripMenuItem.Text = "CSV speichern...";
            cSVSpeichernToolStripMenuItem.Click += CSVSpeichernToolStripMenuItem_Click;
            // 
            // programmBeendenToolStripMenuItem
            // 
            programmBeendenToolStripMenuItem.Name = "programmBeendenToolStripMenuItem";
            programmBeendenToolStripMenuItem.Size = new Size(180, 22);
            programmBeendenToolStripMenuItem.Text = "Programm beenden";
            programmBeendenToolStripMenuItem.Click += ProgrammBeendenToolStripMenuItem_Click;
            // 
            // InfoToolStripMenuItem
            // 
            InfoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { überToolStripMenuItem });
            InfoToolStripMenuItem.Name = "InfoToolStripMenuItem";
            InfoToolStripMenuItem.Size = new Size(40, 20);
            InfoToolStripMenuItem.Text = "Info";
            InfoToolStripMenuItem.Click += InfoToolStripMenuItem_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 741);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(1340, 23);
            progressBar.TabIndex = 3;
            progressBar.Visible = false;
            // 
            // überToolStripMenuItem
            // 
            überToolStripMenuItem.Name = "überToolStripMenuItem";
            überToolStripMenuItem.Size = new Size(180, 22);
            überToolStripMenuItem.Text = "Über...";
            überToolStripMenuItem.Click += UeberToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1364, 776);
            Controls.Add(progressBar);
            Controls.Add(dataGridView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "CSV by Philipp Buthmann";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem dateiToolStripMenuItem;
        private ToolStripMenuItem menuLoadCsv;
        private ToolStripMenuItem cSVSpeichernToolStripMenuItem;
        private ToolStripMenuItem programmBeendenToolStripMenuItem;
        private ToolStripMenuItem InfoToolStripMenuItem;
        private ProgressBar progressBar;
        private ToolStripMenuItem überToolStripMenuItem;
    }
}
