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
        private bool isClosingConfirmed = false;
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

                    // Daten in Blöcken hinzufügen, um UI-Updates zu reduzieren
                    int batchSize = 100; // Anzahl der Zeilen pro UI-Update
                    List<string[]> batch = new List<string[]>();

                    for (int i = 1; i < lines.Length; i++)
                    {
                        var data = lines[i].Split(',');
                        batch.Add(data);

                        // Fortschrittsbalken und UI-Update alle "batchSize" Zeilen
                        if (i % batchSize == 0 || i == lines.Length - 1)
                        {
                            Invoke(new Action(() =>
                            {
                                foreach (var row in batch)
                                {
                                    dataGridView.Rows.Add(row);
                                }

                                progressBar.Value = i; // Fortschritt aktualisieren
                            }));

                            batch.Clear(); // Batch leeren
                        }
                    }
                }

                // Nach Abschluss des Ladevorgangs und vor dem Verstecken der ProgressBar
                progressBar.Value = progressBar.Maximum; // Fortschritt auf 100% setzen
                await Task.Delay(500); // 500 Millisekunden warten, damit die ProgressBar sichtbar bleibt
                progressBar.Visible = false; // Fortschrittsbalken ausblenden

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
                isClosingConfirmed = true; // Bestätigen, dass das Beenden zugelassen ist
                Application.Exit();
            }
        }

        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            hasUnsavedChanges = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosingConfirmed)
            {
                if (!BeendenPrüfenUndSchließen())
                {
                    e.Cancel = true; // Beenden abbrechen
                }
                else
                {
                    isClosingConfirmed = true; // Bestätigen, dass das Beenden zugelassen ist
                }
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
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    isClosingConfirmed = true; // Schließen bestätigen
                    return true; // Programm kann beendet werden
                }

                return false; // Benutzer hat "Nein" gewählt, nicht beenden
            }

            return true; // Keine Änderungen vorhanden, beenden erlaubt
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                // Strg + S wurde gedrückt
                Console.WriteLine("Strg + S wurde gedrückt..."); //Debugging-Ausgabe
                CSVSpeichernToolStripMenuItem_Click(this, EventArgs.Empty);
                e.Handled = true; // Signalisiert, dass das Ereignis verarbeitet wurde
            }
        }

        private void zeileEinfuegenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Prüfen, ob eine Zelle ausgewählt ist
                if (dataGridView.SelectedCells.Count > 0)
                {
                    // Überprüfen, ob nur eine Zelle ausgewählt ist
                    int rowIndex = dataGridView.SelectedCells[0].RowIndex;

                    // Neue Zeile unter der ausgewählten Zeile einfügen
                    DataGridViewRow newRow = new DataGridViewRow();
                    dataGridView.Rows.Insert(rowIndex + 1, newRow);
                }
                else
                {
                    throw new InvalidOperationException("Keine Zelle ausgewählt.");
                }
            }
            catch (Exception ex)
            {
                /*MessageBox.Show($"Fehler: {ex.Message}\nEs wird eine neue Zeile am Ende der Tabelle hinzugefügt.",
                                "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);*/

                // Fallback: Neue Zeile am Ende der Tabelle einfügen
                DataGridViewRow newRow = new DataGridViewRow();
                dataGridView.Rows.Add(newRow);
            }
        }

        private void cSVErstellenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Daten in DataGridView zurücksetzen
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();

                // Standardspalten hinzufügen (optional, z. B. "Spalte1", "Spalte2")
                dataGridView.Columns.Add("Spalte1", "Spalte 1");
                dataGridView.Columns.Add("Spalte2", "Spalte 2");

                // Optional: Eine erste leere Zeile hinzufügen
                dataGridView.Rows.Add();

                /*MessageBox.Show("Neue CSV-Datei wurde erstellt und geladen.",
                                "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Erstellen der neuen CSV-Datei: {ex.Message}",
                                "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                // Index der angeklickten Spalte
                int columnIndex = e.ColumnIndex;

                // Aktuellen Spaltennamen abrufen
                string currentName = dataGridView.Columns[columnIndex].HeaderText;

                // Eingabefeld für neuen Namen anzeigen
                string newName = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Geben Sie einen neuen Namen für die Spalte '{currentName}' ein:",
                    "Spaltennamen bearbeiten",
                    currentName);

                // Überprüfen, ob ein neuer Name eingegeben wurde
                if (!string.IsNullOrEmpty(newName))
                {
                    dataGridView.Columns[columnIndex].HeaderText = newName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Bearbeiten des Spaltennamens: {ex.Message}",
                                "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
