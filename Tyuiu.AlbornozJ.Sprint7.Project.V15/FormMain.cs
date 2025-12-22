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
    }
}
