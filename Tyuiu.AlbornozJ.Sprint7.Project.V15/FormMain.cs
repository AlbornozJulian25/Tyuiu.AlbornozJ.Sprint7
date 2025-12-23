using Microsoft.VisualBasic;
using System.Collections.Generic;
using Tyuiu.AlbornozJ.Sprint7.Project.V15.Lib;

namespace Tyuiu.AlbornozJ.Sprint7.Project.V15
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.Text = "Управление Договорами - Albornoz J. Вариант 15";
            this.Size = new System.Drawing.Size(900, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewContracts_AJ_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelStatistics_AJ_Paint(object sender, PaintEventArgs e)
        {

        }

        private void statusStripMain_AJ_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonLoad_AJ_Click(object sender, EventArgs e)
        {
            DataService ds = new DataService();            
            chartContracts_AJ.Visible = false;
            dataGridViewContracts_AJ.Visible = true;
            string path = @"C:\Users\litan\source\repos\Tyuiu.AlbornozJ.Sprint7\Tyuiu.AlbornozJ.Sprint7.Project.V15\bin\Debug\net8.0-windows\contracts.csv";
            string[,] data = ds.LoadFromFileData(path);

            dataGridViewContracts_AJ.Rows.Clear();
            dataGridViewContracts_AJ.Columns.Clear();
            for (int i = 0; i < data.GetLength(1); i++)
            {
                dataGridViewContracts_AJ.Columns.Add("Column" + i, data[0, i]);
            }
            for (int i = 1; i < data.GetLength(0); i++)
            {
                List<string> row = new List<string>();
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    row.Add(data[i, j]);
                }
                dataGridViewContracts_AJ.Rows.Add(row.ToArray());
            }
            decimal total = ds.GetTotalAmount(path);
            decimal average = ds.GetAverageAmount(path);
            int count = data.GetLength(0) - 1;

            decimal max = 0;
            for (int i = 1; i < data.GetLength(0); i++)
            {
                if (decimal.TryParse(data[i, 4], out decimal amount))
                {
                    if (amount > max) max = amount;
                }
            }
            labelMax_AJ.Text = "Максимальная сумма: " + max.ToString("N2");

            labelTotal_AJ.Text = "Общая сумма: " + total.ToString("N2");
            labelAverage_AJ.Text = "Средняя сумма: " + average.ToString("N2");
            labelCount_AJ.Text = "Количество договоров: " + count.ToString();
            toolStripStatusLabelReady_AJ.Text = "Данные загружены";

        }

        private void toolStripButtonSearch_AJ_Click(object sender, EventArgs e)
        {
            string searchText = Microsoft.VisualBasic.Interaction.InputBox("Введите название организации для поиска:", "Поиск", "", -1, -1);
            if (!string.IsNullOrEmpty(searchText))
            {
                chartContracts_AJ.Visible = false;
                dataGridViewContracts_AJ.Visible = true;
                DataService ds = new DataService();
                string path = @"C:\Users\litan\source\repos\Tyuiu.AlbornozJ.Sprint7\Tyuiu.AlbornozJ.Sprint7.Project.V15\bin\Debug\net8.0-windows\contracts.csv";
                string[,] result = ds.SearchByOrganization(path, searchText);
                dataGridViewContracts_AJ.Rows.Clear();
                dataGridViewContracts_AJ.Columns.Clear();

                for (int i = 0; i < result.GetLength(1); i++)
                {
                    dataGridViewContracts_AJ.Columns.Add("Column" + i, result[0, i]);
                }

                for (int i = 1; i < result.GetLength(0); i++)
                {
                    List<string> row = new List<string>();
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        row.Add(result[i, j]);
                    }
                    dataGridViewContracts_AJ.Rows.Add(row.ToArray());
                }

                toolStripStatusLabelReady_AJ.Text = "Найдено договоров: " + (result.GetLength(0) - 1);
            }
        }

        private void toolStripButtonStats_AJ_Click(object sender, EventArgs e)
        {
            DataService ds = new DataService();
            string path = @"C:\Users\litan\source\repos\Tyuiu.AlbornozJ.Sprint7\Tyuiu.AlbornozJ.Sprint7.Project.V15\bin\Debug\net8.0-windows\contracts.csv";

            decimal total = ds.GetTotalAmount(path);
            decimal average = ds.GetAverageAmount(path);

            MessageBox.Show($"Общая сумма всех договоров: {total:N2}\nСредняя сумма договора: {average:N2}", "Статистика", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButtonChart_AJ_Click(object sender, EventArgs e)
        {
            if (dataGridViewContracts_AJ.Rows.Count == 0)
            {
                MessageBox.Show("Сначала загрузите данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridViewContracts_AJ.Visible = false;
            chartContracts_AJ.Visible = true;

            DataService ds = new DataService();
            string path = @"C:\Users\litan\source\repos\Tyuiu.AlbornozJ.Sprint7\Tyuiu.AlbornozJ.Sprint7.Project.V15\bin\Debug\net8.0-windows\contracts.csv";
            string[,] data = ds.LoadFromFileData(path);

            chartContracts_AJ.Series.Clear();
            chartContracts_AJ.Titles.Clear();
            chartContracts_AJ.Titles.Add("Сумма договоров по типам");

            // Crear diccionario para sumar por tipo
            Dictionary<string, decimal> sumsByType = new Dictionary<string, decimal>();

            for (int i = 1; i < data.GetLength(0); i++)
            {
                string type = data[i, 5]; // Columna 5 = ТипДоговора
                if (decimal.TryParse(data[i, 4], out decimal amount))
                {
                    if (sumsByType.ContainsKey(type))
                        sumsByType[type] += amount;
                    else
                        sumsByType[type] = amount;
                }
            }

            var series = new System.Windows.Forms.DataVisualization.Charting.Series();
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series.Name = "Типы договоров";

            foreach (var item in sumsByType)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            chartContracts_AJ.Series.Add(series);
            toolStripStatusLabelReady_AJ.Text = "График построен";
        }
    }
}
