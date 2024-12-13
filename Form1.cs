using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV_Viewer
{
    public partial class Form1 : Form
    {
        private bool hasUnsavedChanges = false;
        private string lastUsedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public Form1()
        {
            InitializeComponent();

            // Event-Handler für das Schließen des Fensters
            this.FormClosing += Form1_FormClosing;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialisierungen beim Start des Programms
            progressBar.Visible = false;
            dataGridView.CellValueChanged += DataGridView_CellValueChanged;
        }

        private async void MenuLoadCsv_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                InitialDirectory = lastUsedPath
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                progressBar.Visible = true;
                progressBar.Value = 0;

                string[] lines = null;

                // Lade die Datei asynchron
                await Task.Run(() =>
                {
                    lines = File.ReadAllLines(openFileDialog.FileName);
                });

                if (lines != null && lines.Length > 0)
                {
                    progressBar.Maximum = lines.Length - 1;

                    var headers = lines[0].Split(',');

                    // UI-Komponenten aktualisieren
                    Invoke(new Action(() =>
                    {
                        dataGridView.Columns.Clear();
                        foreach (var header in headers)
                        {
                            dataGridView.Columns.Add(header, header);
                        }
                    }));

                    // Daten einfügen und Fortschritt anzeigen
                    for (int i = 1; i < lines.Length; i++)
                    {
                        var data = lines[i].Split(',');

                        Invoke(new Action(() =>
                        {
                            dataGridView.Rows.Add(data);
                            progressBar.Value = i;
                        }));

                        await Task.Delay(5); // Zeitverzögerung für sichtbare Fortschrittsanzeige
                    }
                }

                progressBar.Visible = false;
                lastUsedPath = Path.GetDirectoryName(openFileDialog.FileName);
            }
        }

        private void SaveCsv(string filePath)
        {
            try
            {
                var lines = new List<string>();

                // Kopfzeilen hinzufügen
                var headers = dataGridView.Columns.Cast<DataGridViewColumn>()
                                 .Select(column => column.HeaderText);
                lines.Add(string.Join(",", headers));

                // Zeilen hinzufügen
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var cells = row.Cells.Cast<DataGridViewCell>()
                                     .Select(cell => cell.Value?.ToString() ?? "");
                        lines.Add(string.Join(",", cells));
                    }
                }

                File.WriteAllLines(filePath, lines);
                hasUnsavedChanges = false;
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"Fehler beim Zugriff auf die Datei: {ioEx.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ein unerwarteter Fehler ist aufgetreten: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CSVSpeichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                InitialDirectory = lastUsedPath
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveCsv(saveFileDialog.FileName);
                lastUsedPath = Path.GetDirectoryName(saveFileDialog.FileName);
            }
        }

        private void ProgrammBeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BeendenPrüfenUndSchließen())
            {
                Application.Exit();
            }
        }

        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            hasUnsavedChanges = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!BeendenPrüfenUndSchließen())
            {
                e.Cancel = true;
            }
        }

        private bool BeendenPrüfenUndSchließen()
        {
            if (hasUnsavedChanges)
            {
                var result = MessageBox.Show(
                    "Es gibt ungespeicherte Änderungen. Möchten Sie das Programm wirklich beenden, ohne zu speichern?",
                    "Ungespeicherte Änderungen",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warningö
                );

                return result == DialogResult.Yes;
            }

            return true;
        }

        private void UeberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "CSV-Editor by Philipp Buthmann\n\n" +
                "Version: 1.0\n" +
                "Entwickler: Philipp Buthmann\n" +
                "Kontakt: p.buthmann@weissenhaeuserstrand.de\n" +
                "\nDieses Programm wurde entwickelt, um CSV-Dateien einfach und intuitiv zu bearbeiten.",
                "Über",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(
            //    "Dies ist ein einfacher CSV-Viewer und -Editor.\n" +
            //    "Nutzen Sie das Menü, um CSV-Dateien zu laden, zu bearbeiten und zu speichern.",
            //    "Info",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Information
            //);
        }
    }
}
