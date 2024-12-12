using System;
using System.IO;
using System.Windows.Forms;
namespace CSV_Viewer
{
    public partial class Form1 : Form
    {

        private bool hasUnsavedChanges = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void MenuLoadCsv_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                progressBar.Visible = true;
                await Task.Run(() => LoadCsv(openFileDialog.FileName));
                progressBar.Visible = false;
            }
        }
        private void LoadCsv(string filePath)
        {
            Invoke(new Action(() =>
            {
                try
                {
                    var lines = File.ReadAllLines(filePath);
                    if (lines.Length > 0)
                    {
                        var headers = lines[0].Split(',');
                        dataGridView.Columns.Clear();
                        foreach (var header in headers)
                        {
                            dataGridView.Columns.Add(header, header);
                        }

                        for (int i = 1; i < lines.Length; i++)
                        {
                            var data = lines[i].Split(',');
                            dataGridView.Rows.Add(data);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Laden der Datei: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }

        private void SaveCsv(string filePath)
        {
            try
            {
                var lines = new List<string>();

                // Kopfzeilen hinzuf�gen
                var headers = dataGridView.Columns.Cast<DataGridViewColumn>()
                                 .Select(column => column.HeaderText);
                lines.Add(string.Join(",", headers));

                // Zeilen hinzuf�gen
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var cells = row.Cells.Cast<DataGridViewCell>()
                                     .Select(cell => cell.Value?.ToString() ?? "");
                        lines.Add(string.Join(",", cells));
                    }
                }

                // Datei speichern
                File.WriteAllLines(filePath, lines);
                hasUnsavedChanges = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Speichern der Datei: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CSVSpeichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    SaveCsv(filePath);
                }
            }
        }

        private void ProgrammBeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hasUnsavedChanges)
            {
                var result = MessageBox.Show(
                    "Es gibt ungespeicherte �nderungen. M�chten Sie das Programm wirklich beenden, ohne zu speichern?",
                    "Ungespeicherte �nderungen",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            Application.Exit();
        }

        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            hasUnsavedChanges = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hasUnsavedChanges)
            {
                var result = MessageBox.Show(
                    "Es gibt ungespeicherte �nderungen. M�chten Sie das Programm wirklich beenden, ohne zu speichern?",
                    "Ungespeicherte �nderungen",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Abbrechen des Schlie�ens
                }
            }
        }

        private void UeberToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}