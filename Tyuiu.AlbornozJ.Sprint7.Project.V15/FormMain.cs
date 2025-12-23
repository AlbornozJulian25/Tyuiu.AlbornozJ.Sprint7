using System.Windows.Forms;


using Tyuiu.AlbornozJ.Sprint7.Project.V15.Lib;

namespace Tyuiu.AlbornozJ.Sprint7.Project.V15
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            openFileDialogContracts.Filter = "Значения, разделённые запятыми(*.csv)|*.csv|Все файлы(*.*)|*.*";
            openFileDialogEmployees.Filter = "Значения, разделённые запятыми(*.csv)|*.csv|Все файлы(*.*)|*.*";
        }

        private DataService ds = new DataService();
        private string openFilePathContracts;
        private string openFilePathEmployees;

        private void buttonAddFileContracts_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialogContracts.ShowDialog();
                openFilePathContracts = openFileDialogContracts.FileName;

                string[,] rawData = ds.LoadFromFileData(openFilePathContracts);
                dataGridViewContracts.Rows.Clear();

                for (int i = 0; i < rawData.GetLength(0); i++)
                {
                    string[] row = new string[rawData.GetLength(1)];
                    for (int j = 0; j < row.Length; j++)
                    {
                        row[j] = rawData[i, j];
                    }
                    dataGridViewContracts.Rows.Add(row);
                }

                MessageBox.Show("Данные договоров успешно загружены!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                UpdateStatistics();
                UpdateCharts();

                buttonSaveFileContracts.Enabled = true;
                buttonAddRowContracts.Enabled = true;
                buttonDelRowContracts.Enabled = true;
                buttonEditRowContracts.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveFileContracts_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialogContracts.FileName = "contracts.csv";
                saveFileDialogContracts.InitialDirectory = @"C:\DataSprint7\";

                if (saveFileDialogContracts.ShowDialog() != DialogResult.OK)
                    return;

                string path = saveFileDialogContracts.FileName;
                File.WriteAllText(path, "");

                int rows = dataGridViewContracts.RowCount;
                int columns = dataGridViewContracts.ColumnCount;

                for (int i = 0; i < rows; i++)
                {
                    if (dataGridViewContracts.Rows[i].IsNewRow)
                        continue;

                    string str = "";
                    for (int j = 0; j < columns; j++)
                    {
                        var cellValue = dataGridViewContracts.Rows[i].Cells[j].Value;
                        string cellStr = cellValue?.ToString() ?? "";

                        if (j == columns - 1)
                            str += cellStr;
                        else
                            str += cellStr + ";";
                    }
                    File.AppendAllText(path, str + "\r\n", System.Text.Encoding.UTF8);
                }

                MessageBox.Show("Данные успешно сохранены!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddRowContracts_Click(object sender, EventArgs e)
        {
            try
            {
                int newRowIndex = dataGridViewContracts.Rows.Add();

                if (newRowIndex >= 0)
                {
                    dataGridViewContracts.FirstDisplayedScrollingRowIndex = newRowIndex;
                    dataGridViewContracts.ClearSelection();
                    dataGridViewContracts.Rows[newRowIndex].Selected = true;
                }
                UpdateStatistics();
                UpdateCharts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении новой строки:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonEditRowContracts_Click(object sender, EventArgs e)
        {
            if (dataGridViewContracts.ReadOnly)
            {
                dataGridViewContracts.ReadOnly = false;
                MessageBox.Show("Режим редактирования включён.\nКликните по ячейке для изменения данных.",
                    "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridViewContracts.ReadOnly = true;
                MessageBox.Show("Режим редактирования выключен.\nИзменения можно сохранить с помощью кнопки «Сохранить файл».",
                    "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonDelRowContracts_Click(object sender, EventArgs e)
        {
            dataGridViewContracts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (dataGridViewContracts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.", "Строка не выбрана",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите удалить выбранные строки?", "Подтвердите удаление",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                List<int> rowsToDelete = new List<int>();
                foreach (DataGridViewRow selectedRow in dataGridViewContracts.SelectedRows)
                    rowsToDelete.Add(selectedRow.Index);

                for (int i = rowsToDelete.Count - 1; i >= 0; i--)
                {
                    dataGridViewContracts.Rows.RemoveAt(rowsToDelete[i]);
                }

                dataGridViewContracts.ClearSelection();
                MessageBox.Show("Строка успешно удалена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                UpdateStatistics();
                UpdateCharts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления строки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // МЕТОДЫ ДЛЯ СОТРУДНИКОВ (аналогичные, но для второй таблицы)

        private void buttonAddFileEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialogEmployees.ShowDialog();
                openFilePathEmployees = openFileDialogEmployees.FileName;

                string[,] rawData = ds.LoadFromFileData(openFilePathEmployees);
                dataGridViewEmployees.Rows.Clear();

                for (int i = 0; i < rawData.GetLength(0); i++)
                {
                    string[] row = new string[rawData.GetLength(1)];
                    for (int j = 0; j < row.Length; j++)
                    {
                        row[j] = rawData[i, j];
                    }
                    dataGridViewEmployees.Rows.Add(row);
                }

                MessageBox.Show("Данные сотрудников успешно загружены!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                UpdateStatistics();
                UpdateCharts();

                buttonSaveFileEmployees.Enabled = true;
                buttonAddRowEmployees.Enabled = true;
                buttonDelRowEmployees.Enabled = true;
                buttonEditRowEmployees.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics()
        {
            // СТАТИСТИКА ДОГОВОРОВ
            if (dataGridViewContracts.Rows.Count > 0)
            {
                int totalContracts = 0;
                double totalSum = 0;
                double maxSum = 0;
                double minSum = double.MaxValue;

                foreach (DataGridViewRow row in dataGridViewContracts.Rows)
                {
                    if (row.IsNewRow) continue;
                    totalContracts++;

                    // Сумма договора в 5-м столбце (индекс 4)
                    if (row.Cells[4].Value != null &&
                        double.TryParse(row.Cells[4].Value.ToString(),
                        System.Globalization.NumberStyles.Float,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out double sum))
                    {
                        totalSum += sum;
                        if (sum > maxSum) maxSum = sum;
                        if (sum < minSum) minSum = sum;
                    }
                }

                double avgSum = totalContracts > 0 ? totalSum / totalContracts : 0;

                labelTotalContracts.Text = $"Всего договоров: {totalContracts}";
                labelTotalSum.Text = $"Общая сумма: {totalSum:F2} руб.";
                labelAvgSum.Text = $"Средняя сумма: {avgSum:F2} руб.";
                labelMaxSum.Text = $"Максимальная сумма: {(maxSum > 0 ? maxSum.ToString("F2") : "0")} руб.";
                labelMinSum.Text = $"Минимальная сумма: {(minSum < double.MaxValue ? minSum.ToString("F2") : "0")} руб.";
            }
            else
            {
                labelTotalContracts.Text = "Всего договоров: 0";
                labelTotalSum.Text = "Общая сумма: 0 руб.";
                labelAvgSum.Text = "Средняя сумма: 0 руб.";
                labelMaxSum.Text = "Максимальная сумма: 0 руб.";
                labelMinSum.Text = "Минимальная сумма: 0 руб.";
            }

            // СТАТИСТИКА СОТРУДНИКОВ
            if (dataGridViewEmployees.Rows.Count > 0)
            {
                int totalEmployees = 0;
                double totalSalary = 0;
                double maxSalary = 0;
                double minSalary = double.MaxValue;

                foreach (DataGridViewRow row in dataGridViewEmployees.Rows)
                {
                    if (row.IsNewRow) continue;
                    totalEmployees++;

                    // Оклад в 6-м столбце (индекс 5)
                    if (row.Cells[5].Value != null &&
                        double.TryParse(row.Cells[5].Value.ToString(),
                        System.Globalization.NumberStyles.Float,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out double salary))
                    {
                        totalSalary += salary;
                        if (salary > maxSalary) maxSalary = salary;
                        if (salary < minSalary) minSalary = salary;
                    }
                }

                double avgSalary = totalEmployees > 0 ? totalSalary / totalEmployees : 0;

                labelTotalEmployees.Text = $"Всего сотрудников: {totalEmployees}";
                labelAvgSalary.Text = $"Средний оклад: {avgSalary:F2} руб.";
                labelMaxSalary.Text = $"Максимальный оклад: {(maxSalary > 0 ? maxSalary.ToString("F2") : "0")} руб.";
                labelMinSalary.Text = $"Минимальный оклад: {(minSalary < double.MaxValue ? minSalary.ToString("F2") : "0")} руб.";
            }
            else
            {
                labelTotalEmployees.Text = "Всего сотрудников: 0";
                labelAvgSalary.Text = "Средний оклад: 0 руб.";
                labelMaxSalary.Text = "Максимальный оклад: 0 руб.";
                labelMinSalary.Text = "Минимальный оклад: 0 руб.";
            }
        }

        private void UpdateCharts()
        {
            UpdateContractTypesChart();
            UpdateSalaryChart();
        }

        private void UpdateContractTypesChart()
        {
            chartContractTypes.Series.Clear();
            chartContractTypes.Titles.Clear();

            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Типы договоров",
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
            };
            chartContractTypes.Series.Add(series);

            var contractTypes = new Dictionary<string, int>();

            // Тип договора в 7-м столбце (индекс 6)
            foreach (DataGridViewRow row in dataGridViewContracts.Rows)
            {
                if (row.IsNewRow) continue;

                string type = row.Cells[6]?.Value?.ToString() ?? "Не указан";
                if (!contractTypes.ContainsKey(type))
                    contractTypes[type] = 0;
                contractTypes[type]++;
            }

            foreach (var kvp in contractTypes)
            {
                if (kvp.Value > 0)
                    series.Points.AddXY(kvp.Key, kvp.Value);
            }
        }

        private void UpdateSalaryChart()
        {
            chartSalary.Series.Clear();
            chartSalary.Titles.Clear();

            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Оклады",
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                Color = System.Drawing.Color.SteelBlue
            };
            chartSalary.Series.Add(series);

            int employeeCount = 0;
            foreach (DataGridViewRow row in dataGridViewEmployees.Rows)
            {
                if (row.IsNewRow) continue;
                employeeCount++;

                string shortName = $"Сотр. {employeeCount}";
                if (row.Cells[5]?.Value != null &&
                    double.TryParse(row.Cells[5].Value.ToString(),
                    System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double salary))
                {
                    series.Points.AddXY(shortName, salary);
                }
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void руководствоПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Руководство пользователя:\n\n" +
                "1. Загрузите файлы contracts.csv и employees.csv\n" +
                "2. Для редактирования данных нажмите кнопку 'Редактировать'\n" +
                "3. Для сохранения изменений нажмите 'Сохранить файл'\n" +
                "4. Статистика обновляется автоматически",
                "Руководство пользователя",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Подтвердите выход",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            this.Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Инициализация при загрузке формы
            textBoxSearchContracts.Text = "";
            textBoxSearchEmployees.Text = "";
            // Para dataGridViewContracts
            dataGridViewContracts.Columns.Add("Код договора", "Код договора");
            dataGridViewContracts.Columns.Add("Организация", "Организация");
            dataGridViewContracts.Columns.Add("Дата начала", "Дата начала");
            dataGridViewContracts.Columns.Add("Дата окончания", "Дата окончания");
            dataGridViewContracts.Columns.Add("Сумма", "Сумма");
            dataGridViewContracts.Columns.Add("Примечание", "Примечание");
            dataGridViewContracts.Columns.Add("Тип договора", "Тип договора");

            // Para dataGridViewEmployees
            dataGridViewEmployees.Columns.Add("Табельный номер", "Табельный номер");
            dataGridViewEmployees.Columns.Add("ФИО", "ФИО");
            dataGridViewEmployees.Columns.Add("Адрес", "Адрес");
            dataGridViewEmployees.Columns.Add("Телефон", "Телефон");
            dataGridViewEmployees.Columns.Add("Должность", "Должность");
            dataGridViewEmployees.Columns.Add("Оклад", "Оклад");
            dataGridViewEmployees.Columns.Add("Начало работы", "Начало работы");
            dataGridViewEmployees.Columns.Add("Окончание работы", "Окончание работы");
        }

        private void textBoxSearchContracts_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearchContracts.Text.ToLower();

            foreach (DataGridViewRow row in dataGridViewContracts.Rows)
            {
                bool visible = false;

                if (!row.IsNewRow)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null &&
                            cell.Value.ToString().ToLower().Contains(searchText))
                        {
                            visible = true;
                            break;
                        }
                    }
                }

                row.Visible = visible || string.IsNullOrEmpty(searchText);
            }
        }

        private void buttonRefreshContracts_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(openFilePathContracts))
            {
                buttonAddFileContracts_Click(sender, e);
            }
        }

        private void buttonRefreshEmployees_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(openFilePathEmployees))
            {
                buttonAddFileEmployees_Click(sender, e);
            }
        }
    }
}