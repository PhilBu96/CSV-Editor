﻿namespace CSV_Viewer
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
            cSVErstellenToolStripMenuItem = new ToolStripMenuItem();
            menuLoadCsv = new ToolStripMenuItem();
            cSVSpeichernToolStripMenuItem = new ToolStripMenuItem();
            programmBeendenToolStripMenuItem = new ToolStripMenuItem();
            tabelleToolStripMenuItem = new ToolStripMenuItem();
            zeileEinfuegenToolStripMenuItem = new ToolStripMenuItem();
            InfoToolStripMenuItem = new ToolStripMenuItem();
            überToolStripMenuItem = new ToolStripMenuItem();
            progressBar = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowDrop = true;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 27);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(1340, 708);
            dataGridView.TabIndex = 1;
            dataGridView.CellValueChanged += DataGridView_CellValueChanged;
            dataGridView.ColumnHeaderMouseDoubleClick += dataGridView_ColumnHeaderMouseDoubleClick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { dateiToolStripMenuItem, tabelleToolStripMenuItem, InfoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1364, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            dateiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cSVErstellenToolStripMenuItem, menuLoadCsv, cSVSpeichernToolStripMenuItem, programmBeendenToolStripMenuItem });
            dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            dateiToolStripMenuItem.Size = new Size(46, 20);
            dateiToolStripMenuItem.Text = "Datei";
            // 
            // cSVErstellenToolStripMenuItem
            // 
            cSVErstellenToolStripMenuItem.Name = "cSVErstellenToolStripMenuItem";
            cSVErstellenToolStripMenuItem.Size = new Size(180, 22);
            cSVErstellenToolStripMenuItem.Text = "CSV erstellen...";
            cSVErstellenToolStripMenuItem.Click += cSVErstellenToolStripMenuItem_Click;
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
            // tabelleToolStripMenuItem
            // 
            tabelleToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { zeileEinfuegenToolStripMenuItem });
            tabelleToolStripMenuItem.Name = "tabelleToolStripMenuItem";
            tabelleToolStripMenuItem.Size = new Size(55, 20);
            tabelleToolStripMenuItem.Text = "Tabelle";
            // 
            // zeileEinfuegenToolStripMenuItem
            // 
            zeileEinfuegenToolStripMenuItem.Name = "zeileEinfuegenToolStripMenuItem";
            zeileEinfuegenToolStripMenuItem.Size = new Size(149, 22);
            zeileEinfuegenToolStripMenuItem.Text = "Zeile einfügen";
            zeileEinfuegenToolStripMenuItem.Click += zeileEinfuegenToolStripMenuItem_Click;
            // 
            // InfoToolStripMenuItem
            // 
            InfoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { überToolStripMenuItem });
            InfoToolStripMenuItem.Name = "InfoToolStripMenuItem";
            InfoToolStripMenuItem.Size = new Size(40, 20);
            InfoToolStripMenuItem.Text = "Info";
            InfoToolStripMenuItem.Click += InfoToolStripMenuItem_Click;
            // 
            // überToolStripMenuItem
            // 
            überToolStripMenuItem.Name = "überToolStripMenuItem";
            überToolStripMenuItem.Size = new Size(108, 22);
            überToolStripMenuItem.Text = "Über...";
            überToolStripMenuItem.Click += UeberToolStripMenuItem_Click;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(12, 741);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(1340, 23);
            progressBar.TabIndex = 3;
            progressBar.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1364, 776);
            Controls.Add(progressBar);
            Controls.Add(dataGridView);
            Controls.Add(menuStrip1);
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "CSV-Editor by Philipp Buthmann";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
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
        private ToolStripMenuItem tabelleToolStripMenuItem;
        private ToolStripMenuItem zeileEinfuegenToolStripMenuItem;
        private ToolStripMenuItem cSVErstellenToolStripMenuItem;
    }
}
